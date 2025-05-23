﻿using FileMergerTool.CustomControls;

namespace FileMergerTool
{
    partial class FileMerger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtFolderPath = new TextBox();
            btnOpen = new Button();
            rtxIgnore = new RichTextBox();
            btnMerge = new Button();
            rtxFilesContent = new RichTextBox();
            splMain = new SplitContainer();
            splTop = new SplitContainer();
            tlpnlExcludeSummary = new TableLayoutPanel();
            gbxIgnore = new GroupBox();
            gbxSummary = new GroupBox();
            txtSummary = new TextBox();
            gbxFilePath = new GroupBox();
            clstFilePath = new CustomCheckedListBox();
            gbxFilesContent = new GroupBox();
            btnClearSelect = new Button();
            btnCopyIntoClipboard = new Button();
            btnSelectAll = new Button();
            btnSaveMergedFile = new Button();
            ((System.ComponentModel.ISupportInitialize)splMain).BeginInit();
            splMain.Panel1.SuspendLayout();
            splMain.Panel2.SuspendLayout();
            splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splTop).BeginInit();
            splTop.Panel1.SuspendLayout();
            splTop.Panel2.SuspendLayout();
            splTop.SuspendLayout();
            tlpnlExcludeSummary.SuspendLayout();
            gbxIgnore.SuspendLayout();
            gbxSummary.SuspendLayout();
            gbxFilePath.SuspendLayout();
            gbxFilesContent.SuspendLayout();
            SuspendLayout();
            // 
            // txtFolderPath
            // 
            txtFolderPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFolderPath.Location = new Point(12, 12);
            txtFolderPath.Name = "txtFolderPath";
            txtFolderPath.Size = new Size(629, 23);
            txtFolderPath.TabIndex = 0;
            // 
            // btnOpen
            // 
            btnOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpen.Location = new Point(647, 12);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(75, 23);
            btnOpen.TabIndex = 2;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += BtnOpen_Click;
            // 
            // rtxIgnore
            // 
            rtxIgnore.BorderStyle = BorderStyle.None;
            rtxIgnore.Dock = DockStyle.Fill;
            rtxIgnore.Location = new Point(3, 19);
            rtxIgnore.Name = "rtxIgnore";
            rtxIgnore.Size = new Size(250, 61);
            rtxIgnore.TabIndex = 3;
            rtxIgnore.Text = "";
            // 
            // btnMerge
            // 
            btnMerge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMerge.Location = new Point(583, 90);
            btnMerge.Name = "btnMerge";
            btnMerge.Size = new Size(142, 23);
            btnMerge.TabIndex = 7;
            btnMerge.Text = "Merge";
            btnMerge.UseVisualStyleBackColor = true;
            btnMerge.Click += BtnMerge_Click;
            // 
            // rtxFilesContent
            // 
            rtxFilesContent.BorderStyle = BorderStyle.None;
            rtxFilesContent.Dock = DockStyle.Fill;
            rtxFilesContent.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtxFilesContent.Location = new Point(3, 19);
            rtxFilesContent.Name = "rtxFilesContent";
            rtxFilesContent.Size = new Size(559, 180);
            rtxFilesContent.TabIndex = 11;
            rtxFilesContent.Text = "";
            rtxFilesContent.WordWrap = false;
            // 
            // splMain
            // 
            splMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splMain.Location = new Point(12, 41);
            splMain.Name = "splMain";
            splMain.Orientation = Orientation.Horizontal;
            // 
            // splMain.Panel1
            // 
            splMain.Panel1.Controls.Add(splTop);
            // 
            // splMain.Panel2
            // 
            splMain.Panel2.Controls.Add(gbxFilesContent);
            splMain.Size = new Size(565, 384);
            splMain.SplitterDistance = 178;
            splMain.TabIndex = 12;
            // 
            // splTop
            // 
            splTop.Dock = DockStyle.Fill;
            splTop.Location = new Point(0, 0);
            splTop.Name = "splTop";
            // 
            // splTop.Panel1
            // 
            splTop.Panel1.Controls.Add(tlpnlExcludeSummary);
            // 
            // splTop.Panel2
            // 
            splTop.Panel2.Controls.Add(gbxFilePath);
            splTop.Size = new Size(565, 178);
            splTop.SplitterDistance = 262;
            splTop.TabIndex = 12;
            // 
            // tlpnlExcludeSummary
            // 
            tlpnlExcludeSummary.ColumnCount = 1;
            tlpnlExcludeSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpnlExcludeSummary.Controls.Add(gbxIgnore, 0, 0);
            tlpnlExcludeSummary.Controls.Add(gbxSummary, 0, 1);
            tlpnlExcludeSummary.Dock = DockStyle.Fill;
            tlpnlExcludeSummary.Location = new Point(0, 0);
            tlpnlExcludeSummary.Name = "tlpnlExcludeSummary";
            tlpnlExcludeSummary.RowCount = 2;
            tlpnlExcludeSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpnlExcludeSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpnlExcludeSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpnlExcludeSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpnlExcludeSummary.Size = new Size(262, 178);
            tlpnlExcludeSummary.TabIndex = 10;
            // 
            // gbxIgnore
            // 
            gbxIgnore.Controls.Add(rtxIgnore);
            gbxIgnore.Dock = DockStyle.Fill;
            gbxIgnore.Location = new Point(3, 3);
            gbxIgnore.Name = "gbxIgnore";
            gbxIgnore.Size = new Size(256, 83);
            gbxIgnore.TabIndex = 13;
            gbxIgnore.TabStop = false;
            gbxIgnore.Text = "Ignore";
            // 
            // gbxSummary
            // 
            gbxSummary.Controls.Add(txtSummary);
            gbxSummary.Dock = DockStyle.Fill;
            gbxSummary.Location = new Point(3, 92);
            gbxSummary.Name = "gbxSummary";
            gbxSummary.Size = new Size(256, 83);
            gbxSummary.TabIndex = 14;
            gbxSummary.TabStop = false;
            gbxSummary.Text = "Summary";
            // 
            // txtSummary
            // 
            txtSummary.Dock = DockStyle.Fill;
            txtSummary.Location = new Point(3, 19);
            txtSummary.Multiline = true;
            txtSummary.Name = "txtSummary";
            txtSummary.Size = new Size(250, 61);
            txtSummary.TabIndex = 9;
            // 
            // gbxFilePath
            // 
            gbxFilePath.Controls.Add(clstFilePath);
            gbxFilePath.Dock = DockStyle.Fill;
            gbxFilePath.Location = new Point(0, 0);
            gbxFilePath.Name = "gbxFilePath";
            gbxFilePath.Size = new Size(299, 178);
            gbxFilePath.TabIndex = 13;
            gbxFilePath.TabStop = false;
            gbxFilePath.Text = "FilePath";
            // 
            // clstFilePath
            // 
            clstFilePath.Dock = DockStyle.Fill;
            clstFilePath.FormattingEnabled = true;
            clstFilePath.Location = new Point(3, 19);
            clstFilePath.Name = "clstFilePath";
            clstFilePath.Size = new Size(293, 156);
            clstFilePath.TabIndex = 13;
            clstFilePath.ItemCheck += ClstFilePath_ItemCheck;
            // 
            // gbxFilesContent
            // 
            gbxFilesContent.Controls.Add(rtxFilesContent);
            gbxFilesContent.Dock = DockStyle.Fill;
            gbxFilesContent.Location = new Point(0, 0);
            gbxFilesContent.Name = "gbxFilesContent";
            gbxFilesContent.Size = new Size(565, 202);
            gbxFilesContent.TabIndex = 13;
            gbxFilesContent.TabStop = false;
            gbxFilesContent.Text = "FilesContent";
            // 
            // btnClearSelect
            // 
            btnClearSelect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearSelect.Location = new Point(583, 194);
            btnClearSelect.Name = "btnClearSelect";
            btnClearSelect.Size = new Size(142, 23);
            btnClearSelect.TabIndex = 13;
            btnClearSelect.Text = "Clear Select";
            btnClearSelect.UseVisualStyleBackColor = true;
            btnClearSelect.Click += BtnClearSelect_Click;
            // 
            // btnCopyIntoClipboard
            // 
            btnCopyIntoClipboard.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopyIntoClipboard.Location = new Point(583, 400);
            btnCopyIntoClipboard.Name = "btnCopyIntoClipboard";
            btnCopyIntoClipboard.Size = new Size(142, 23);
            btnCopyIntoClipboard.TabIndex = 14;
            btnCopyIntoClipboard.Text = "Copy Into Clipboard";
            btnCopyIntoClipboard.UseVisualStyleBackColor = true;
            btnCopyIntoClipboard.Click += BtnCopyIntoClipboard_Click;
            // 
            // btnSelectAll
            // 
            btnSelectAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectAll.Location = new Point(583, 165);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(142, 23);
            btnSelectAll.TabIndex = 13;
            btnSelectAll.Text = "Select All";
            btnSelectAll.UseVisualStyleBackColor = true;
            btnSelectAll.Click += BtnSelectAll_Click;
            // 
            // btnSaveMergedFile
            // 
            btnSaveMergedFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveMergedFile.Location = new Point(583, 307);
            btnSaveMergedFile.Name = "btnSaveMergedFile";
            btnSaveMergedFile.Size = new Size(142, 23);
            btnSaveMergedFile.TabIndex = 15;
            btnSaveMergedFile.Text = "Save Merged File";
            btnSaveMergedFile.UseVisualStyleBackColor = true;
            btnSaveMergedFile.Click += BtnSaveMergedFile_Click;
            // 
            // FileMerger
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 437);
            Controls.Add(btnSaveMergedFile);
            Controls.Add(btnCopyIntoClipboard);
            Controls.Add(btnSelectAll);
            Controls.Add(btnClearSelect);
            Controls.Add(splMain);
            Controls.Add(btnMerge);
            Controls.Add(btnOpen);
            Controls.Add(txtFolderPath);
            Name = "FileMerger";
            Text = "FileMerger";
            FormClosing += ImportDialog_FormClosing;
            splMain.Panel1.ResumeLayout(false);
            splMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splMain).EndInit();
            splMain.ResumeLayout(false);
            splTop.Panel1.ResumeLayout(false);
            splTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splTop).EndInit();
            splTop.ResumeLayout(false);
            tlpnlExcludeSummary.ResumeLayout(false);
            gbxIgnore.ResumeLayout(false);
            gbxSummary.ResumeLayout(false);
            gbxSummary.PerformLayout();
            gbxFilePath.ResumeLayout(false);
            gbxFilesContent.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFolderPath;
        private Button btnOpen;
        private RichTextBox rtxIgnore;
        private Button btnMerge;
        private RichTextBox rtxFilesContent;
        private SplitContainer splMain;
        private TextBox txtSummary;
        private SplitContainer splTop;
        private TableLayoutPanel tlpnlExcludeSummary;
        private GroupBox gbxIgnore;
        private GroupBox gbxSummary;
        private GroupBox gbxFilePath;
        private GroupBox gbxFilesContent;
        private CustomCheckedListBox clstFilePath;
        private Button btnClearSelect;
        private Button btnCopyIntoClipboard;
        private Button btnSelectAll;
        private Button btnSaveMergedFile;
    }
}