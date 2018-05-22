using System;
using System.Drawing;
using System.Windows.Forms;
using TicTacToe;
using ScoreScreen3;
using TicTacToeGUI;

namespace mainMenu
{
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        private void mainMenu_Load(object sender, EventArgs e)
        {

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            playerInitials = queryInitials();
            if (playerInitials == "exit")
            {
                playerInitials = "";
                return;
            }
            this.Hide();
            Game_window game = new Game_window();
            game.initials = playerInitials;
            game.ShowDialog();
            isWinner = game.isWinner;

            //wait for results, update scores if winner
            if (isWinner)
            {
                ScoreScreen.updateScores(playerInitials);
                isWinner = false;
            }

            this.Show();
            playerInitials = ""; //reset player initials
        }

        private void instButton_Click(object sender, EventArgs e)
        {
            Instructions inst = new Instructions();
            this.Hide();
            inst.ShowDialog();
            this.Show();
        }

        private void hsButton_Click(object sender, EventArgs e)
        {
            ScoreScreen hs = new ScoreScreen();
            this.Hide();
            hs.ShowDialog();
            this.Show();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string queryInitials()
        {
            Form prompt = new Form()
            {
                BackColor = System.Drawing.Color.LightCyan,
                Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Width = 350,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = " ",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = "Enter your Initials (3 characters or less): ", Width = 300 };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 250 };
            Button confirmation = new Button()
            {
                BackColor = System.Drawing.Color.MediumAquamarine,
                FlatAppearance = { MouseOverBackColor = Color.MediumSeaGreen, BorderColor = Color.White},
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = SystemColors.ControlLightLight,
                Text = "Ok",
                Left = 200,
                Width = 100,
                Height = 30,
                Top = 80,
                DialogResult = DialogResult.OK
            };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            if (prompt.ShowDialog() != DialogResult.OK) return "exit";
            else if (textBox.Text.Length <= 3 && textBox.Text != "")  return textBox.Text.ToUpper();

            return textBox.Text = queryInitials(); //query again if invalid input
        }

        private string playerInitials = "";
        private bool isWinner = false;
    }
}
