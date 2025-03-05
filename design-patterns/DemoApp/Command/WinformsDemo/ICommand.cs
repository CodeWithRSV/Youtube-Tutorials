using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformsDemo.BusinessLogic;

namespace WinformsDemo
{
    public  interface ICommand
    {
        void Execute();
    }

    public class CopyCommand : ICommand
    {
        private readonly TextBox textBox;

        public CopyCommand(TextBox textBox)
        {
            this.textBox = textBox;
        }
        public void Execute()
        {
            Operations.CopyText(textBox.Text);
        }
    }
    public class CutCommand : ICommand
    {
        private readonly TextBox textBox;

        public CutCommand(TextBox textBox)
        {
            this.textBox = textBox;
        }
        public void Execute()
        {
            Operations.CutText(textBox);
        }
    }
    public class PasteCommand : ICommand
    {
        private readonly TextBox textBox;

        public PasteCommand(TextBox textBox)
        {
            this.textBox = textBox;
        }
        public void Execute()
        {
            Operations.PasteText(textBox);
        }
    }
    public class DeleteCommand : ICommand
    {
        private readonly TextBox textBox;

        public DeleteCommand(TextBox textBox)
        {
            this.textBox = textBox;
        }
        public void Execute()
        {
            Operations.DeleteText(textBox);
        }
    }
}
