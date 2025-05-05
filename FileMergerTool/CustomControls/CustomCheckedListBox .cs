namespace FileMergerTool.CustomControls
{
    public class CustomCheckedListBox : CheckedListBox
    {
        private bool _laterStatus = false;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            int index = IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                // 計算 checkbox 的範圍 (假設 checkbox 約在項目左側 16 像素)
                Rectangle itemRect = GetItemRectangle(index);
                Rectangle checkBoxRect = new(itemRect.X + 1, itemRect.Y + 2, 16, itemRect.Height - 4);

                if (checkBoxRect.Contains(e.Location))
                {
                    // 若點在 checkbox 上，切換勾選狀態
                    bool isChecked = GetItemChecked(index);

                    _laterStatus = !isChecked;
                }
                else
                {
                    // 不管怎樣都設定選取項目
                    SelectedIndex = index;
                    _laterStatus = GetItemChecked(SelectedIndex);
                }
            }
            else
            {
                ClearSelected();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (SelectedIndex >= 0)
            {
                SetItemChecked(SelectedIndex, _laterStatus);
            }
        }
    }
}