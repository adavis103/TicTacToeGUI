using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ScoreScreen3
{
    public partial class ScoreScreen : Form
    {
        public ScoreScreen()
        {
            InitializeComponent();
            string[] scores = System.IO.File.ReadAllLines("highScores.txt");
            for (int i = 0; i < 5; i++)
            {
                string[] pair = scores[i].Split(' ');
                this.tableLayoutPanel1.Controls.Add(new Label()
                {
                    Text = pair[0],
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Dock = DockStyle.Fill
                }, 0, i);
                this.tableLayoutPanel1.Controls.Add(new Label()
                {
                    Text = pair[1],
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Dock = DockStyle.Fill
                }, 1, i);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void updateScores(string initials)
        {
            Dictionary<string, int> scores = new Dictionary<string, int>();
            System.IO.StreamReader readFile =   new System.IO.StreamReader("highScores.txt");
            string line;
            while ((line = readFile.ReadLine()) != null)  
            {  
                string [] pair = line.Split(' ');
                scores.Add(pair[0], Int16.Parse(pair[1]));
            }
            if (!scores.ContainsKey(initials))
            {
                scores.Add(initials, 0);
            }
            scores[initials] = scores[initials] + 1;
            readFile.Close();
            var items = from pair in scores
                orderby pair.Value descending
                select pair;          
            using (System.IO.StreamWriter writeFile = new System.IO.StreamWriter("highScores.txt", false))
            foreach (KeyValuePair<string, int> pair in items)
            {
                writeFile.WriteLine("{0} {1}", pair.Key, pair.Value);
            }   
        }

        void tableLayoutPanel1_Paint(object sender, EventArgs e)
        {

        }
    }
}
