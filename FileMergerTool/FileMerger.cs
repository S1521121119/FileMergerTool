using FileMergerTool.Properties;
using System.Data;
using System.Text;

namespace FileMergerTool
{
    public partial class FileMerger : Form
    {
        #region FIELDS

        private readonly List<FileInfo> fileList = [];
        private List<string> excludeList = [];
        private static readonly string[] separator = ["\r\n", "\r", "\n"];
        private const int SIZE_LIMIT_MB = 10; // Maximum total file size limit in MB (10 MB)
        private const int CHECK_INTERVAL = 25; // Check file size every 25 files

        #endregion FIELDS

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the FileMergerTool form.
        /// </summary>
        public FileMerger()
        {
            InitializeComponent();
            LoadSettings();
        }

        #endregion CONSTRUCTOR

        #region FORM_EVENT_HANDLERS

        /// <summary>
        /// Saves settings when the form is closing.
        /// </summary>
        private void ImportDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.FolderPath = txtFolderPath.Text;
            Settings.Default.Ignore = rtxIgnore.Text;
            Settings.Default.Save();
        }

        #endregion FORM_EVENT_HANDLERS

        #region BUTTON_EVENT_HANDLERS

        /// <summary>
        /// Opens a folder browser dialog to select a folder and updates the folder path text box.
        /// </summary>
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            using var folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                txtFolderPath.Text = folderDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Initiates the file scanning process.
        /// </summary>
        private void BtnImportFiles_Click(object sender, EventArgs e)
        {
            ScanFiles();
        }

        /// <summary>
        /// Clears the selected files in the checklist and updates the summary.
        /// </summary>
        private void BtnClearSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clstFilePath.Items.Count; i++)
            {
                clstFilePath.SetItemChecked(i, false);
            }
            fileList.Clear();
            UpdateSummary();
        }

        /// <summary>
        /// Merges the content of selected files and displays it in the content text box.
        /// </summary>
        private void BtnMerge_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            fileList.ForEach(f =>
            {
                sb.AppendLine($"================================================");
                sb.AppendLine($"FILE: {f.FullName}");
                sb.AppendLine($"================================================");
                sb.AppendLine(File.ReadAllText(f.FullName));
                sb.AppendLine($"================================================");
            });

            rtxFilesContent.Text = sb.ToString();
        }

        /// <summary>
        /// Copies the merged file content to the clipboard and shows a summary of the copied text.
        /// </summary>
        private void BtnCopyAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(rtxFilesContent.Text))
                {
                    MessageBox.Show("沒有內容可複製！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Clipboard.SetText(rtxFilesContent.Text);

                int charCount = rtxFilesContent.Text.Length;
                int lineCount = rtxFilesContent.Text.Split(separator, StringSplitOptions.None).Length;

                MessageBox.Show(
                    $"已成功複製進剪貼簿\r\n" +
                    $"字數: {charCount} \r\n" +
                    $"行數: {lineCount} \r\n",
                    "複製成功",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"複製失敗：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Updates the file list and summary when a file's check state changes in the checklist.
        /// </summary>
        private void ClstFilePath_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                fileList.Clear();
                for (int i = 0; i < clstFilePath.Items.Count; i++)
                {
                    if (clstFilePath.GetItemChecked(i) || (i == e.Index && e.NewValue == CheckState.Checked))
                    {
                        string path = clstFilePath.Items[i]?.ToString() ?? "empty";
                        fileList.Add(new FileInfo(path));
                    }
                }
                UpdateSummary();
            }));
        }

        #endregion BUTTON_EVENT_HANDLERS

        #region CORE_FUNCTIONALITY

        /// <summary>
        /// Loads default or saved settings into the form controls.
        /// </summary>
        private void LoadSettings()
        {
            txtFolderPath.Text = Settings.Default.FolderPath;
            if (string.IsNullOrEmpty(txtFolderPath.Text))
            {
                txtFolderPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            rtxIgnore.Text = Settings.Default.Ignore;
            if (string.IsNullOrEmpty(rtxIgnore.Text))
            {
                rtxIgnore.Text = @"bin/
obj/
.git
.vs
.user
.csproj
.config
.xml
.resx
.dll
.pdb
.ini
.exe
.xlsx";
            }
        }

        /// <summary>
        /// Scans the selected directory for files, applies exclusion filters, and updates the UI.
        /// </summary>
        private void ScanFiles()
        {
            fileList.Clear();
            excludeList = [.. rtxIgnore.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim())];

            if (string.IsNullOrEmpty(txtFolderPath.Text) || !Directory.Exists(txtFolderPath.Text))
            {
                MessageBox.Show("請選擇有效的資料夾路徑！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ScanDirectory(new DirectoryInfo(txtFolderPath.Text));
            GenerateTreeViewOutput();
            UpdateSummary();
        }

        /// <summary>
        /// Recursively scans a directory and its subdirectories for files, respecting exclusion rules.
        /// </summary>
        /// <param name="dir">The directory to scan.</param>
        private void ScanDirectory(DirectoryInfo dir)
        {
            try
            {
                if (IsExcludedFolder(dir.FullName))
                    return;

                int fileCount = 0;

                foreach (var file in dir.GetFiles())
                {
                    if (!IsExcludedFile(file))
                    {
                        fileList.Add(file);
                        fileCount++;

                        if (fileCount % CHECK_INTERVAL == 0)
                        {
                            long totalSizeMB = fileList.Sum(f => f.Length) / 1024 / 1024;
                            if (totalSizeMB > SIZE_LIMIT_MB)
                            {
                                var result = MessageBox.Show(
                                    $"目前檔案總大小已超過 {SIZE_LIMIT_MB} MB ({totalSizeMB} MB)。是否繼續掃描？",
                                    "檔案大小限制",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

                                return;
                            }
                        }
                    }
                }

                foreach (var subDir in dir.GetDirectories())
                {
                    ScanDirectory(subDir);
                }
            }
            catch (OperationCanceledException ex)
            {
                MessageBox.Show(ex.Message, "掃描已停止", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"掃描時發生錯誤：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        /// <summary>
        /// Determines if a folder should be excluded based on the ignore list.
        /// </summary>
        /// <param name="folderPath">The full path of the folder to check.</param>
        /// <returns>True if the folder is excluded; otherwise, false.</returns>
        private bool IsExcludedFolder(string folderPath)
        {
            string relativePath = Path.GetRelativePath(txtFolderPath.Text, folderPath);
            if (relativePath == ".")
                return false;

            relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);

            return excludeList.Any(exclude =>
            {
                string excludeFolder = exclude.TrimEnd('/').Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
                return relativePath.Contains(Path.DirectorySeparatorChar + excludeFolder + Path.DirectorySeparatorChar) ||
                       relativePath.EndsWith(Path.DirectorySeparatorChar + excludeFolder) ||
                       relativePath == excludeFolder;
            });
        }

        /// <summary>
        /// Determines if a file should be excluded based on its extension or name.
        /// </summary>
        /// <param name="file">The file to check.</param>
        /// <returns>True if the file is excluded; otherwise, false.</returns>
        private bool IsExcludedFile(FileInfo file)
        {
            return excludeList.Any(exclude =>
                file.Extension.Equals(exclude, StringComparison.OrdinalIgnoreCase) ||
                file.Name.EndsWith(exclude, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Populates the checklist with scanned files, defaulting to all checked.
        /// </summary>
        private void GenerateTreeViewOutput()
        {
            clstFilePath.Items.Clear();
            foreach (var file in fileList)
            {
                clstFilePath.Items.Add(file.FullName, true);
            }
        }

        /// <summary>
        /// Updates the summary text box with file count and total size.
        /// </summary>
        private void UpdateSummary()
        {
            var sb2 = new StringBuilder();
            long contentSize = 0;
            fileList.ForEach(f =>
            {
                sb2.AppendLine($"================================================");
                sb2.AppendLine($"FILE: {f.FullName}");
                sb2.AppendLine($"================================================");
                sb2.AppendLine($"================================================");
                contentSize += f.Length;
            });

            var sb = new StringBuilder();
            sb.AppendLine($"File Count : {fileList.Count}");
            sb.AppendLine($"File Size : {(contentSize + sb2.Capacity) / 1024}k");

            txtSummary.Text = sb.ToString();
        }

        #endregion CORE_FUNCTIONALITY
    }
}