using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Game_window : Form
    {
        public Game_window()
        {
            InitializeComponent();
            addButtons();
        }
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Black, 2F);
        private Board board = new Board();

        private void drawPlane(object sender, int plane, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            System.Drawing.Point[] p = new System.Drawing.Point[4];
            p[0].X = 590;
            p[0].Y = 60 + (plane * 150);
            p[1].X = 20;
            p[1].Y = 60 + (plane * 150); ;
            p[2].X = 80;
            p[2].Y = 200 + (plane * 150); ;
            p[3].X = 675;
            p[3].Y = 200 + (plane * 150); ;

            g.DrawPolygon(pen1, p);
        }


        private void drawPolygons(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            drawPlane(sender, 0, e);
            drawPlane(sender, 1, e);
            drawPlane(sender, 2, e);
            drawPlane(sender, 3, e);
        }

        private void drawLines(object sender, int plane, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(pen1, 30 + 140, 60 + (150 * plane), 90 + 144, 200 + (150 * plane));
            g.DrawLine(pen1, 30 + 142 * 2, 60 + (150 * plane), 90 + 146 * 2, 200 + (150 * plane));
            g.DrawLine(pen1, 30 + 144 * 3, 60 + (150 * plane), 90 + 149 * 3, 200 + (150 * plane));
            g.DrawLine(pen1, 35, 90 + (150 * plane), 610, 90 + (150 * plane));
            g.DrawLine(pen1, 50, 125 + (150 * plane), 628, 125 + (150 * plane));
            g.DrawLine(pen1, 65, 160 + (150 * plane), 650, 160 + (150 * plane));
        }

        private void drawLines(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            drawLines(sender, 0, e);
            drawLines(sender, 1, e);
            drawLines(sender, 2, e);
            drawLines(sender, 3, e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            drawPolygons(this, e);
            drawLines(this, e);
        }

        private void Game_window_Load(object sender, EventArgs e)
        {

        }

        private void quit_Click(object sender, EventArgs e)
        {
            Form quit_confirm = new Form()
            {
                StartPosition = FormStartPosition.CenterScreen,
                Width = 300,
                Height = 150,
                BackColor = System.Drawing.Color.LightCyan,
            };

            Label confirm_text = new Label() { Left = 40, Top = 20, Text = "Are you sure you want to quit?", Width = 300};
            confirm_text.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Button yes = new Button();
            Button no = new Button();

            yes.BackColor = System.Drawing.Color.MediumAquamarine;
            yes.FlatAppearance.BorderColor = System.Drawing.Color.White;
            yes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            yes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            yes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            yes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            yes.Location = new System.Drawing.Point(50, 60);
            yes.Text = " Yes !";

            no.BackColor = System.Drawing.Color.MediumAquamarine;
            no.FlatAppearance.BorderColor = System.Drawing.Color.White;
            no.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            no.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            no.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            no.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            no.Location = new System.Drawing.Point(150, 60);
            no.Text = " No !";

            yes.Click += (sender_2, e_2) => { quit_confirm.Close(); this.Close(); };
            no.Click += (sender_2, e_2) => { quit_confirm.Close(); };
            quit_confirm.Controls.Add(confirm_text);
            quit_confirm.Controls.Add(yes);
            quit_confirm.Controls.Add(no);
            quit_confirm.Show();
        }

        private void button64_Click(object sender, EventArgs e)
        {
            makeMove(63, 'X');
        }

        private void button63_Click(object sender, EventArgs e)
        {
            makeMove(62, 'X');
        }

        private void button62_Click(object sender, EventArgs e)
        {
            makeMove(61, 'X');
        }

        private void button61_Click(object sender, EventArgs e)
        {
            makeMove(60, 'X');
        }

        private void button60_Click(object sender, EventArgs e)
        {
            makeMove(59, 'X');
        }

        private void button59_Click(object sender, EventArgs e)
        {
            makeMove(58, 'X');
        }

        private void button58_Click(object sender, EventArgs e)
        {
            makeMove(57, 'X');
        }

        private void button57_Click(object sender, EventArgs e)
        {
            makeMove(56, 'X');
        }

        private void button56_Click(object sender, EventArgs e)
        {
            makeMove(55, 'X');
        }

        private void button55_Click(object sender, EventArgs e)
        {
            makeMove(54, 'X');
        }

        private void button54_Click(object sender, EventArgs e)
        {
            makeMove(53, 'X');
        }

        private void button53_Click(object sender, EventArgs e)
        {
            makeMove(52, 'X');
        }

        private void button52_Click(object sender, EventArgs e)
        {
            makeMove(51, 'X');
        }

        private void button51_Click(object sender, EventArgs e)
        {
            makeMove(50, 'X');
        }

        private void button50_Click(object sender, EventArgs e)
        {
            makeMove(49, 'X');
        }

        private void button49_Click(object sender, EventArgs e)
        {
            makeMove(48, 'X');
        }

        private void button48_Click(object sender, EventArgs e)
        {
            makeMove(47, 'X');
        }

        private void button47_Click(object sender, EventArgs e)
        {
            makeMove(46, 'X');
        }

        private void button46_Click(object sender, EventArgs e)
        {
            makeMove(45, 'X');
        }

        private void button45_Click(object sender, EventArgs e)
        {
            makeMove(44, 'X');
        }

        private void button44_Click(object sender, EventArgs e)
        {
            makeMove(43, 'X');
        }

        private void button43_Click(object sender, EventArgs e)
        {
            makeMove(42, 'X');
        }

        private void button42_Click(object sender, EventArgs e)
        {
            makeMove(41, 'X');
        }

        private void button41_Click(object sender, EventArgs e)
        {
            makeMove(40, 'X');
        }

        private void button40_Click(object sender, EventArgs e)
        {
            makeMove(39, 'X');
        }

        private void button39_Click(object sender, EventArgs e)
        {
            makeMove(38, 'X');
        }

        private void button38_Click(object sender, EventArgs e)
        {
            makeMove(37, 'X');
        }

        private void button37_Click(object sender, EventArgs e)
        {
            makeMove(36, 'X');
        }

        private void button36_Click(object sender, EventArgs e)
        {
            makeMove(35, 'X');
        }

        private void button35_Click(object sender, EventArgs e)
        {
            makeMove(34, 'X');
        }

        private void button34_Click(object sender, EventArgs e)
        {
            makeMove(33, 'X');
        }

        private void button33_Click(object sender, EventArgs e)
        {
            makeMove(32, 'X');
        }

        private void button32_Click(object sender, EventArgs e)
        {
            makeMove(31, 'X');
        }

        private void button31_Click(object sender, EventArgs e)
        {
            makeMove(30, 'X');
        }

        private void button30_Click(object sender, EventArgs e)
        {
            makeMove(29, 'X');
        }

        private void button29_Click(object sender, EventArgs e)
        {
            makeMove(28, 'X');
        }

        private void button28_Click(object sender, EventArgs e)
        {
            makeMove(27, 'X');
        }

        private void button27_Click(object sender, EventArgs e)
        {
            makeMove(26, 'X');
        }

        private void button26_Click(object sender, EventArgs e)
        {
            makeMove(25, 'X');
        }

        private void button25_Click(object sender, EventArgs e)
        {
            makeMove(24, 'X');
        }

        private void button24_Click(object sender, EventArgs e)
        {
            makeMove(23, 'X');
        }

        private void button23_Click(object sender, EventArgs e)
        {
            makeMove(22, 'X');
        }

        private void button22_Click(object sender, EventArgs e)
        {
            makeMove(21, 'X');
        }

        private void button21_Click(object sender, EventArgs e)
        {
            makeMove(20, 'X');
        }

        private void button20_Click(object sender, EventArgs e)
        {
            makeMove(19, 'X');
        }

        private void button19_Click(object sender, EventArgs e)
        {
            makeMove(18, 'X');
        }

        private void button18_Click(object sender, EventArgs e)
        {
            makeMove(17, 'X');
        }

        private void button17_Click(object sender, EventArgs e)
        {
            makeMove(16, 'X');
        }

        private void button16_Click(object sender, EventArgs e)
        {
            makeMove(15, 'X');
        }

        private void button15_Click(object sender, EventArgs e)
        {
            makeMove(14, 'X');
        }

        private void button14_Click(object sender, EventArgs e)
        {
            makeMove(13, 'X');
        }

        private void button13_Click(object sender, EventArgs e)
        {
            makeMove(12, 'X');
        }

        private void button12_Click(object sender, EventArgs e)
        {
            makeMove(11, 'X');
        }

        private void button11_Click(object sender, EventArgs e)
        {
            makeMove(10, 'X');
        }

        private void button10_Click(object sender, EventArgs e)
        {
            makeMove(9, 'X');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            makeMove(8, 'X');
        }

        private void button8_Click(object sender, EventArgs e)
        {
            makeMove(7, 'X');
        }

        private void button7_Click(object sender, EventArgs e)
        {
            makeMove(6, 'X');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            makeMove(5, 'X');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            makeMove(4, 'X');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            makeMove(3, 'X');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            makeMove(2, 'X');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            makeMove(1, 'X');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            makeMove(0, 'X');
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
                FlatAppearance = { MouseOverBackColor = Color.MediumSeaGreen, BorderColor = Color.White },
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
            else if (textBox.Text.Length <= 3 && textBox.Text != "") return textBox.Text.ToUpper();
            else textBox.Text = queryInitials(); //query again if invalid input

            return "exit";
        }

        public bool isWinner = false;
    }
}
