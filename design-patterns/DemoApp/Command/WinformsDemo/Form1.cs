using WinformsDemo.UI;

namespace WinformsDemo
{
    public partial class Form1 : Form
    {
        MyButton copybtn,cutbtn,pastebtn,deletebtn;
        public Form1()
        {
            InitializeComponent();
            copybtn = new MyButton();
            copybtn.SetCommand(new CopyCommand(textBox1));
            cutbtn = new MyButton();
            cutbtn.SetCommand(new CutCommand(textBox1));
            pastebtn = new MyButton();
            pastebtn.SetCommand(new PasteCommand(textBox1));
            deletebtn = new MyButton();
            deletebtn.SetCommand(new DeleteCommand(textBox1));
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            copybtn.ExecuteCommand();
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            cutbtn.ExecuteCommand();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            pastebtn.ExecuteCommand();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deletebtn.ExecuteCommand();
        }
    }
}
