namespace WinformsDemo.BusinessLogic
{
    public static class Operations
    {
        private static string? clipBoardText;

        public static void CopyText(string text)
        {
            clipBoardText = text;
        }
        public static void CutText(TextBox textBox)
        {
            CopyText(textBox.Text);
            DeleteText(textBox);
        }
        public static void PasteText(TextBox textBox)
        {
            textBox.Text += clipBoardText;
        }
        public static void DeleteText(TextBox textBox)
        {
            textBox.Text = string.Empty;
        }
    }
}
