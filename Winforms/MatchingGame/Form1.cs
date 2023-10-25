namespace MatchingGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<string> icons = new List<string>()
{
    "!", "!", "N", "N", ",", ",", "k", "k",
    "b", "b", "v", "v", "w", "w", "z", "z"
};
        public Form1()
        {
            InitializeComponent();
            AssignIconsToLables();
        }

        private void AssignIconsToLables()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label? label = (Label)control;
                if (label != null)
                {
                    int randomnum = random.Next(0, icons.Count);
                    label.Text = icons[randomnum];
                    label.ForeColor = label.BackColor;
                    icons.RemoveAt(randomnum);
                }
            }
        }
        Label? firstClicked = null;
        Label? secondClicked = null;
        private void label1_Click(object sender, EventArgs e)
        {
            Label? clickedLabel = (Label)sender;
            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    clickedLabel.ForeColor = Color.Black;
                }
                else if (secondClicked == null)
                {
                    secondClicked = clickedLabel;
                    clickedLabel.ForeColor = Color.Black;
                    CheckIfIconsMatched();
                }
            }
        }

        private void CheckIfIconsMatched()
        {
            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
                CheckForWinner();
            }
            else
                timer1.Start();
        }

        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            MessageBox.Show("Congrats!You found all matches");
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }
    }
}