using System.Collections.Generic;
using System.Windows.Forms;
using ScoreScreen3;

namespace TicTacToe
{
    partial class Game_window
    {
        private List<System.Windows.Forms.Button> buttons = new List<System.Windows.Forms.Button>();
        public void addButtons()
        {
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            buttons.Add(button10);
            buttons.Add(button11);
            buttons.Add(button12);
            buttons.Add(button13);
            buttons.Add(button14);
            buttons.Add(button15);
            buttons.Add(button16);
            buttons.Add(button17);
            buttons.Add(button18);
            buttons.Add(button19);
            buttons.Add(button20);
            buttons.Add(button21);
            buttons.Add(button22);
            buttons.Add(button23);
            buttons.Add(button24);
            buttons.Add(button25);
            buttons.Add(button26);
            buttons.Add(button27);
            buttons.Add(button28);
            buttons.Add(button29);
            buttons.Add(button30);
            buttons.Add(button31);
            buttons.Add(button32);
            buttons.Add(button33);
            buttons.Add(button34);
            buttons.Add(button35);
            buttons.Add(button36);
            buttons.Add(button37);
            buttons.Add(button38);
            buttons.Add(button39);
            buttons.Add(button40);
            buttons.Add(button41);
            buttons.Add(button42);
            buttons.Add(button43);
            buttons.Add(button44);
            buttons.Add(button45);
            buttons.Add(button46);
            buttons.Add(button47);
            buttons.Add(button48);
            buttons.Add(button49);
            buttons.Add(button50);
            buttons.Add(button51);
            buttons.Add(button52);
            buttons.Add(button53);
            buttons.Add(button54);
            buttons.Add(button55);
            buttons.Add(button56);
            buttons.Add(button57);
            buttons.Add(button58);
            buttons.Add(button59);
            buttons.Add(button60);
            buttons.Add(button61);
            buttons.Add(button62);
            buttons.Add(button63);
            buttons.Add(button64);
        }
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
        public void makeMove(int move, char char_move)
        {
            makeMove(move, char_move.ToString());
        }

        public void makeMove(int move, string char_move)
        {
            System.Diagnostics.Debug.WriteLine(move);
            if (buttons[move].Text == "X" || buttons[move].Text == "O")
            {
                return;
            }
            buttons[move].Text = char_move;
            buttons[move].BackColor = System.Drawing.Color.Crimson;
            buttons[move].FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleVioletRed;
            board.move('X', move);
            //if board game over here
            if (board.gameOver() == 'X')
            {
                isWinner = true;
                System.Diagnostics.Debug.WriteLine("PLAYER WINS");
                Form you_won = new Form()
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    Width = 350,
                    Height = 150,
                    BackColor = System.Drawing.Color.LightCyan,
                };

                Label confirm_text = new Label() { Left = 40, Top = 20, Text = "You Won! Do you want to play again?", Width = 300 };
                confirm_text.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Button yes = new Button();
                Button no = new Button();

                yes.BackColor = System.Drawing.Color.MediumAquamarine;
                yes.FlatAppearance.BorderColor = System.Drawing.Color.White;
                yes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
                yes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                yes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                yes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
                yes.Location = new System.Drawing.Point(80, 60);
                yes.Text = " Yes !";

                no.BackColor = System.Drawing.Color.MediumAquamarine;
                no.FlatAppearance.BorderColor = System.Drawing.Color.White;
                no.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
                no.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                no.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                no.ForeColor = System.Drawing.SystemColors.ControlLightLight;
                no.Location = new System.Drawing.Point(180, 60);
                no.Text = " No !";

                yes.Click += (sender_2, e_2) => {
                    ScoreScreen.updateScores(initials);
                    isWinner = false;
                    you_won.Close();
                    board = new Board();
                    foreach (Button button in buttons)
                    {
                        button.Text = "";
                        button.BackColor = System.Drawing.Color.MediumAquamarine;
                        button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
                    }
                };
                no.Click += (sender_2, e_2) => {
                    ScoreScreen.updateScores(initials);
                    you_won.Close();
                    this.Close();
                    isWinner = false;
                };
                you_won.Controls.Add(confirm_text);
                you_won.Controls.Add(yes);
                you_won.Controls.Add(no);
                you_won.Show();
            }
            int aiMove = board.findBestMove('O', 2);
            System.Diagnostics.Debug.WriteLine(aiMove);
            buttons[aiMove].Text = "O";
            buttons[aiMove].BackColor = System.Drawing.Color.DarkSlateGray;
            buttons[aiMove].FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            board.move('O', aiMove);
            //if board game over here
            if (board.gameOver() == 'O')
            {
                System.Diagnostics.Debug.WriteLine("PLAYER LOSES");
                Form you_lost = new Form()
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    Width = 350,
                    Height = 150,
                    BackColor = System.Drawing.Color.LightCyan,
                };
                Label confirm_text = new Label() { Left = 50, Top = 20, Text = "You Lost! Do you want to play again?", Width = 300 };
                confirm_text.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Button yes = new Button();
                Button no = new Button();

                yes.BackColor = System.Drawing.Color.MediumAquamarine;
                yes.FlatAppearance.BorderColor = System.Drawing.Color.White;
                yes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
                yes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                yes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                yes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
                yes.Location = new System.Drawing.Point(80, 60);
                yes.Text = " Yes !";

                no.BackColor = System.Drawing.Color.MediumAquamarine;
                no.FlatAppearance.BorderColor = System.Drawing.Color.White;
                no.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
                no.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                no.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                no.ForeColor = System.Drawing.SystemColors.ControlLightLight;
                no.Location = new System.Drawing.Point(180, 60);
                no.Text = " No !";

                yes.Click += (sender_2, e_2) => {
                    you_lost.Close();
                    board = new Board();
                    foreach (Button button in buttons){
                        button.Text = "";
                        button.BackColor = System.Drawing.Color.MediumAquamarine;
                        button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
                    }
                };
                no.Click += (sender_2, e_2) => {
                    you_lost.Close();
                    this.Close();
                };
                you_lost.Controls.Add(confirm_text);
                you_lost.Controls.Add(yes);
                you_lost.Controls.Add(no);
                you_lost.Show();
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game_window));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.button36 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button40 = new System.Windows.Forms.Button();
            this.button41 = new System.Windows.Forms.Button();
            this.button42 = new System.Windows.Forms.Button();
            this.button43 = new System.Windows.Forms.Button();
            this.button44 = new System.Windows.Forms.Button();
            this.button45 = new System.Windows.Forms.Button();
            this.button46 = new System.Windows.Forms.Button();
            this.button47 = new System.Windows.Forms.Button();
            this.button48 = new System.Windows.Forms.Button();
            this.button49 = new System.Windows.Forms.Button();
            this.button50 = new System.Windows.Forms.Button();
            this.button51 = new System.Windows.Forms.Button();
            this.button52 = new System.Windows.Forms.Button();
            this.button53 = new System.Windows.Forms.Button();
            this.button54 = new System.Windows.Forms.Button();
            this.button55 = new System.Windows.Forms.Button();
            this.button56 = new System.Windows.Forms.Button();
            this.button57 = new System.Windows.Forms.Button();
            this.button58 = new System.Windows.Forms.Button();
            this.button59 = new System.Windows.Forms.Button();
            this.button60 = new System.Windows.Forms.Button();
            this.button61 = new System.Windows.Forms.Button();
            this.button62 = new System.Windows.Forms.Button();
            this.button63 = new System.Windows.Forms.Button();
            this.button64 = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(77, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(221, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 66;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(359, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 67;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Location = new System.Drawing.Point(497, 61);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 68;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.Location = new System.Drawing.Point(94, 96);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 69;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button6.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button6.Location = new System.Drawing.Point(233, 96);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 70;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button7.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button7.Location = new System.Drawing.Point(370, 96);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 71;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button8.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button8.Location = new System.Drawing.Point(511, 96);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 72;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button9.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button9.Location = new System.Drawing.Point(110, 130);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 73;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button10.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button10.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button10.Location = new System.Drawing.Point(259, 130);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 74;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button11.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button11.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button11.Location = new System.Drawing.Point(397, 130);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 75;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button12.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button12.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button12.Location = new System.Drawing.Point(538, 130);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 76;
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button13.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button13.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button13.Location = new System.Drawing.Point(137, 167);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 77;
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button14.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button14.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button14.Location = new System.Drawing.Point(276, 167);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 78;
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button15.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button15.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button15.Location = new System.Drawing.Point(418, 167);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 23);
            this.button15.TabIndex = 79;
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button16.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button16.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button16.Location = new System.Drawing.Point(552, 167);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 23);
            this.button16.TabIndex = 80;
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button17.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button17.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button17.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button17.Location = new System.Drawing.Point(77, 213);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 23);
            this.button17.TabIndex = 81;
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button18
            // 
            this.button18.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button18.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button18.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button18.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button18.Location = new System.Drawing.Point(221, 213);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(75, 23);
            this.button18.TabIndex = 82;
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button19
            // 
            this.button19.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button19.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button19.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button19.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button19.Location = new System.Drawing.Point(359, 213);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(75, 23);
            this.button19.TabIndex = 83;
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button20.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button20.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button20.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button20.Location = new System.Drawing.Point(497, 213);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(75, 23);
            this.button20.TabIndex = 84;
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button21
            // 
            this.button21.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button21.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button21.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button21.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button21.Location = new System.Drawing.Point(94, 246);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(75, 23);
            this.button21.TabIndex = 85;
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button22
            // 
            this.button22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button22.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button22.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button22.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button22.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button22.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button22.Location = new System.Drawing.Point(233, 246);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(75, 23);
            this.button22.TabIndex = 86;
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button23
            // 
            this.button23.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button23.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button23.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button23.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button23.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button23.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button23.Location = new System.Drawing.Point(370, 246);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(75, 23);
            this.button23.TabIndex = 87;
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button24
            // 
            this.button24.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button24.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button24.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button24.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button24.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button24.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button24.Location = new System.Drawing.Point(511, 246);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(75, 23);
            this.button24.TabIndex = 88;
            this.button24.UseVisualStyleBackColor = false;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // button25
            // 
            this.button25.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button25.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button25.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button25.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button25.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button25.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button25.Location = new System.Drawing.Point(110, 280);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(75, 23);
            this.button25.TabIndex = 89;
            this.button25.UseVisualStyleBackColor = false;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // button26
            // 
            this.button26.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button26.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button26.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button26.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button26.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button26.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button26.Location = new System.Drawing.Point(259, 280);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(75, 23);
            this.button26.TabIndex = 90;
            this.button26.UseVisualStyleBackColor = false;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // button27
            // 
            this.button27.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button27.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button27.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button27.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button27.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button27.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button27.Location = new System.Drawing.Point(397, 280);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(75, 23);
            this.button27.TabIndex = 91;
            this.button27.UseVisualStyleBackColor = false;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // button28
            // 
            this.button28.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button28.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button28.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button28.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button28.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button28.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button28.Location = new System.Drawing.Point(538, 280);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(75, 23);
            this.button28.TabIndex = 92;
            this.button28.UseVisualStyleBackColor = false;
            this.button28.Click += new System.EventHandler(this.button28_Click);
            // 
            // button29
            // 
            this.button29.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button29.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button29.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button29.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button29.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button29.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button29.Location = new System.Drawing.Point(137, 317);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(75, 23);
            this.button29.TabIndex = 93;
            this.button29.UseVisualStyleBackColor = false;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            // 
            // button30
            // 
            this.button30.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button30.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button30.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button30.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button30.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button30.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button30.Location = new System.Drawing.Point(276, 317);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(75, 23);
            this.button30.TabIndex = 94;
            this.button30.UseVisualStyleBackColor = false;
            this.button30.Click += new System.EventHandler(this.button30_Click);
            // 
            // button31
            // 
            this.button31.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button31.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button31.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button31.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button31.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button31.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button31.Location = new System.Drawing.Point(418, 317);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(75, 23);
            this.button31.TabIndex = 95;
            this.button31.UseVisualStyleBackColor = false;
            this.button31.Click += new System.EventHandler(this.button31_Click);
            // 
            // button32
            // 
            this.button32.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button32.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button32.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button32.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button32.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button32.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button32.Location = new System.Drawing.Point(552, 317);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(75, 23);
            this.button32.TabIndex = 96;
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // button33
            // 
            this.button33.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button33.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button33.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button33.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button33.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button33.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button33.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button33.Location = new System.Drawing.Point(77, 362);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(75, 23);
            this.button33.TabIndex = 97;
            this.button33.UseVisualStyleBackColor = false;
            this.button33.Click += new System.EventHandler(this.button33_Click);
            // 
            // button34
            // 
            this.button34.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button34.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button34.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button34.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button34.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button34.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button34.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button34.Location = new System.Drawing.Point(221, 362);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(75, 23);
            this.button34.TabIndex = 98;
            this.button34.UseVisualStyleBackColor = false;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            // 
            // button35
            // 
            this.button35.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button35.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button35.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button35.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button35.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button35.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button35.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button35.Location = new System.Drawing.Point(359, 362);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(75, 23);
            this.button35.TabIndex = 99;
            this.button35.UseVisualStyleBackColor = false;
            this.button35.Click += new System.EventHandler(this.button35_Click);
            // 
            // button36
            // 
            this.button36.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button36.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button36.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button36.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button36.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button36.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button36.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button36.Location = new System.Drawing.Point(497, 362);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(75, 23);
            this.button36.TabIndex = 100;
            this.button36.UseVisualStyleBackColor = false;
            this.button36.Click += new System.EventHandler(this.button36_Click);
            // 
            // button37
            // 
            this.button37.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button37.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button37.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button37.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button37.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button37.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button37.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button37.Location = new System.Drawing.Point(94, 395);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(75, 23);
            this.button37.TabIndex = 101;
            this.button37.UseVisualStyleBackColor = false;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            // 
            // button38
            // 
            this.button38.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button38.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button38.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button38.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button38.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button38.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button38.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button38.Location = new System.Drawing.Point(233, 395);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(75, 23);
            this.button38.TabIndex = 102;
            this.button38.UseVisualStyleBackColor = false;
            this.button38.Click += new System.EventHandler(this.button38_Click);
            // 
            // button39
            // 
            this.button39.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button39.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button39.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button39.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button39.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button39.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button39.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button39.Location = new System.Drawing.Point(370, 395);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(75, 23);
            this.button39.TabIndex = 103;
            this.button39.UseVisualStyleBackColor = false;
            this.button39.Click += new System.EventHandler(this.button39_Click);
            // 
            // button40
            // 
            this.button40.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button40.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button40.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button40.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button40.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button40.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button40.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button40.Location = new System.Drawing.Point(511, 395);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(75, 23);
            this.button40.TabIndex = 104;
            this.button40.UseVisualStyleBackColor = false;
            this.button40.Click += new System.EventHandler(this.button40_Click);
            // 
            // button41
            // 
            this.button41.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button41.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button41.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button41.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button41.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button41.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button41.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button41.Location = new System.Drawing.Point(110, 431);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(75, 23);
            this.button41.TabIndex = 105;
            this.button41.UseVisualStyleBackColor = false;
            this.button41.Click += new System.EventHandler(this.button41_Click);
            // 
            // button42
            // 
            this.button42.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button42.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button42.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button42.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button42.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button42.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button42.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button42.Location = new System.Drawing.Point(259, 431);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(75, 23);
            this.button42.TabIndex = 106;
            this.button42.UseVisualStyleBackColor = false;
            this.button42.Click += new System.EventHandler(this.button42_Click);
            // 
            // button43
            // 
            this.button43.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button43.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button43.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button43.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button43.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button43.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button43.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button43.Location = new System.Drawing.Point(397, 431);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(75, 23);
            this.button43.TabIndex = 107;
            this.button43.UseVisualStyleBackColor = false;
            this.button43.Click += new System.EventHandler(this.button43_Click);
            // 
            // button44
            // 
            this.button44.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button44.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button44.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button44.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button44.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button44.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button44.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button44.Location = new System.Drawing.Point(538, 431);
            this.button44.Name = "button44";
            this.button44.Size = new System.Drawing.Size(75, 23);
            this.button44.TabIndex = 108;
            this.button44.UseVisualStyleBackColor = false;
            this.button44.Click += new System.EventHandler(this.button44_Click);
            // 
            // button45
            // 
            this.button45.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button45.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button45.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button45.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button45.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button45.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button45.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button45.Location = new System.Drawing.Point(137, 467);
            this.button45.Name = "button45";
            this.button45.Size = new System.Drawing.Size(75, 23);
            this.button45.TabIndex = 109;
            this.button45.UseVisualStyleBackColor = false;
            this.button45.Click += new System.EventHandler(this.button45_Click);
            // 
            // button46
            // 
            this.button46.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button46.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button46.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button46.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button46.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button46.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button46.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button46.Location = new System.Drawing.Point(276, 467);
            this.button46.Name = "button46";
            this.button46.Size = new System.Drawing.Size(75, 23);
            this.button46.TabIndex = 110;
            this.button46.UseVisualStyleBackColor = false;
            this.button46.Click += new System.EventHandler(this.button46_Click);
            // 
            // button47
            // 
            this.button47.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button47.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button47.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button47.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button47.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button47.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button47.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button47.Location = new System.Drawing.Point(418, 467);
            this.button47.Name = "button47";
            this.button47.Size = new System.Drawing.Size(75, 23);
            this.button47.TabIndex = 111;
            this.button47.UseVisualStyleBackColor = false;
            this.button47.Click += new System.EventHandler(this.button47_Click);
            // 
            // button48
            // 
            this.button48.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button48.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button48.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button48.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button48.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button48.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button48.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button48.Location = new System.Drawing.Point(552, 467);
            this.button48.Name = "button48";
            this.button48.Size = new System.Drawing.Size(75, 23);
            this.button48.TabIndex = 112;
            this.button48.UseVisualStyleBackColor = false;
            this.button48.Click += new System.EventHandler(this.button48_Click);
            // 
            // button49
            // 
            this.button49.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button49.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button49.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button49.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button49.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button49.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button49.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button49.Location = new System.Drawing.Point(77, 511);
            this.button49.Name = "button49";
            this.button49.Size = new System.Drawing.Size(75, 23);
            this.button49.TabIndex = 113;
            this.button49.UseVisualStyleBackColor = false;
            this.button49.Click += new System.EventHandler(this.button49_Click);
            // 
            // button50
            // 
            this.button50.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button50.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button50.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button50.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button50.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button50.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button50.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button50.Location = new System.Drawing.Point(221, 511);
            this.button50.Name = "button50";
            this.button50.Size = new System.Drawing.Size(75, 23);
            this.button50.TabIndex = 114;
            this.button50.UseVisualStyleBackColor = false;
            this.button50.Click += new System.EventHandler(this.button50_Click);
            // 
            // button51
            // 
            this.button51.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button51.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button51.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button51.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button51.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button51.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button51.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button51.Location = new System.Drawing.Point(359, 511);
            this.button51.Name = "button51";
            this.button51.Size = new System.Drawing.Size(75, 23);
            this.button51.TabIndex = 115;
            this.button51.UseVisualStyleBackColor = false;
            this.button51.Click += new System.EventHandler(this.button51_Click);
            // 
            // button52
            // 
            this.button52.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button52.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button52.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button52.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button52.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button52.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button52.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button52.Location = new System.Drawing.Point(497, 511);
            this.button52.Name = "button52";
            this.button52.Size = new System.Drawing.Size(75, 23);
            this.button52.TabIndex = 116;
            this.button52.UseVisualStyleBackColor = false;
            this.button52.Click += new System.EventHandler(this.button52_Click);
            // 
            // button53
            // 
            this.button53.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button53.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button53.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button53.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button53.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button53.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button53.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button53.Location = new System.Drawing.Point(94, 546);
            this.button53.Name = "button53";
            this.button53.Size = new System.Drawing.Size(75, 23);
            this.button53.TabIndex = 117;
            this.button53.UseVisualStyleBackColor = false;
            this.button53.Click += new System.EventHandler(this.button53_Click);
            // 
            // button54
            // 
            this.button54.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button54.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button54.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button54.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button54.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button54.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button54.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button54.Location = new System.Drawing.Point(233, 546);
            this.button54.Name = "button54";
            this.button54.Size = new System.Drawing.Size(75, 23);
            this.button54.TabIndex = 118;
            this.button54.UseVisualStyleBackColor = false;
            this.button54.Click += new System.EventHandler(this.button54_Click);
            // 
            // button55
            // 
            this.button55.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button55.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button55.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button55.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button55.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button55.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button55.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button55.Location = new System.Drawing.Point(370, 546);
            this.button55.Name = "button55";
            this.button55.Size = new System.Drawing.Size(75, 23);
            this.button55.TabIndex = 119;
            this.button55.UseVisualStyleBackColor = false;
            this.button55.Click += new System.EventHandler(this.button55_Click);
            // 
            // button56
            // 
            this.button56.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button56.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button56.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button56.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button56.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button56.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button56.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button56.Location = new System.Drawing.Point(511, 546);
            this.button56.Name = "button56";
            this.button56.Size = new System.Drawing.Size(75, 23);
            this.button56.TabIndex = 120;
            this.button56.UseVisualStyleBackColor = false;
            this.button56.Click += new System.EventHandler(this.button56_Click);
            // 
            // button57
            // 
            this.button57.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button57.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button57.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button57.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button57.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button57.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button57.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button57.Location = new System.Drawing.Point(110, 581);
            this.button57.Name = "button57";
            this.button57.Size = new System.Drawing.Size(75, 23);
            this.button57.TabIndex = 121;
            this.button57.UseVisualStyleBackColor = false;
            this.button57.Click += new System.EventHandler(this.button57_Click);
            // 
            // button58
            // 
            this.button58.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button58.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button58.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button58.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button58.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button58.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button58.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button58.Location = new System.Drawing.Point(259, 581);
            this.button58.Name = "button58";
            this.button58.Size = new System.Drawing.Size(75, 23);
            this.button58.TabIndex = 122;
            this.button58.UseVisualStyleBackColor = false;
            this.button58.Click += new System.EventHandler(this.button58_Click);
            // 
            // button59
            // 
            this.button59.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button59.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button59.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button59.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button59.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button59.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button59.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button59.Location = new System.Drawing.Point(397, 581);
            this.button59.Name = "button59";
            this.button59.Size = new System.Drawing.Size(75, 23);
            this.button59.TabIndex = 123;
            this.button59.UseVisualStyleBackColor = false;
            this.button59.Click += new System.EventHandler(this.button59_Click);
            // 
            // button60
            // 
            this.button60.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button60.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button60.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button60.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button60.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button60.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button60.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button60.Location = new System.Drawing.Point(538, 581);
            this.button60.Name = "button60";
            this.button60.Size = new System.Drawing.Size(75, 23);
            this.button60.TabIndex = 124;
            this.button60.UseVisualStyleBackColor = false;
            this.button60.Click += new System.EventHandler(this.button60_Click);
            // 
            // button61
            // 
            this.button61.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button61.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button61.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button61.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button61.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button61.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button61.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button61.Location = new System.Drawing.Point(137, 616);
            this.button61.Name = "button61";
            this.button61.Size = new System.Drawing.Size(75, 23);
            this.button61.TabIndex = 125;
            this.button61.UseVisualStyleBackColor = false;
            this.button61.Click += new System.EventHandler(this.button61_Click);
            // 
            // button62
            // 
            this.button62.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button62.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button62.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button62.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button62.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button62.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button62.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button62.Location = new System.Drawing.Point(276, 616);
            this.button62.Name = "button62";
            this.button62.Size = new System.Drawing.Size(75, 23);
            this.button62.TabIndex = 126;
            this.button62.UseVisualStyleBackColor = false;
            this.button62.Click += new System.EventHandler(this.button62_Click);
            // 
            // button63
            // 
            this.button63.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button63.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button63.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button63.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button63.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button63.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button63.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button63.Location = new System.Drawing.Point(418, 616);
            this.button63.Name = "button63";
            this.button63.Size = new System.Drawing.Size(75, 23);
            this.button63.TabIndex = 127;
            this.button63.UseVisualStyleBackColor = false;
            this.button63.Click += new System.EventHandler(this.button63_Click);
            // 
            // button64
            // 
            this.button64.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button64.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button64.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button64.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button64.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button64.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button64.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button64.Location = new System.Drawing.Point(552, 616);
            this.button64.Name = "button64";
            this.button64.Size = new System.Drawing.Size(75, 23);
            this.button64.TabIndex = 128;
            this.button64.UseVisualStyleBackColor = false;
            this.button64.Click += new System.EventHandler(this.button64_Click);
            // 
            // quitButton
            // 
            this.quitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.quitButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.quitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.quitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.quitButton.Location = new System.Drawing.Point(280, 665);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(120, 35);
            this.quitButton.TabIndex = 65;
            this.quitButton.Text = "Main Menu";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quit_Click);
            // 
            // Game_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(684, 711);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.button64);
            this.Controls.Add(this.button63);
            this.Controls.Add(this.button62);
            this.Controls.Add(this.button61);
            this.Controls.Add(this.button60);
            this.Controls.Add(this.button59);
            this.Controls.Add(this.button58);
            this.Controls.Add(this.button57);
            this.Controls.Add(this.button56);
            this.Controls.Add(this.button55);
            this.Controls.Add(this.button54);
            this.Controls.Add(this.button53);
            this.Controls.Add(this.button52);
            this.Controls.Add(this.button51);
            this.Controls.Add(this.button50);
            this.Controls.Add(this.button49);
            this.Controls.Add(this.button48);
            this.Controls.Add(this.button47);
            this.Controls.Add(this.button46);
            this.Controls.Add(this.button45);
            this.Controls.Add(this.button44);
            this.Controls.Add(this.button43);
            this.Controls.Add(this.button42);
            this.Controls.Add(this.button41);
            this.Controls.Add(this.button40);
            this.Controls.Add(this.button39);
            this.Controls.Add(this.button38);
            this.Controls.Add(this.button37);
            this.Controls.Add(this.button36);
            this.Controls.Add(this.button35);
            this.Controls.Add(this.button34);
            this.Controls.Add(this.button33);
            this.Controls.Add(this.button32);
            this.Controls.Add(this.button31);
            this.Controls.Add(this.button30);
            this.Controls.Add(this.button29);
            this.Controls.Add(this.button28);
            this.Controls.Add(this.button27);
            this.Controls.Add(this.button26);
            this.Controls.Add(this.button25);
            this.Controls.Add(this.button24);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(700, 750);
            this.MinimumSize = new System.Drawing.Size(700, 750);
            this.Name = "Game_window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tic Tac Toe";
            this.Load += new System.EventHandler(this.Game_window_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Button button38;
        private System.Windows.Forms.Button button39;
        private System.Windows.Forms.Button button40;
        private System.Windows.Forms.Button button41;
        private System.Windows.Forms.Button button42;
        private System.Windows.Forms.Button button43;
        private System.Windows.Forms.Button button44;
        private System.Windows.Forms.Button button45;
        private System.Windows.Forms.Button button46;
        private System.Windows.Forms.Button button47;
        private System.Windows.Forms.Button button48;
        private System.Windows.Forms.Button button49;
        private System.Windows.Forms.Button button50;
        private System.Windows.Forms.Button button51;
        private System.Windows.Forms.Button button52;
        private System.Windows.Forms.Button button53;
        private System.Windows.Forms.Button button54;
        private System.Windows.Forms.Button button55;
        private System.Windows.Forms.Button button56;
        private System.Windows.Forms.Button button57;
        private System.Windows.Forms.Button button58;
        private System.Windows.Forms.Button button59;
        private System.Windows.Forms.Button button60;
        private System.Windows.Forms.Button button61;
        private System.Windows.Forms.Button button62;
        private System.Windows.Forms.Button button63;
        private System.Windows.Forms.Button button64;
        private System.Windows.Forms.Button quitButton;
        public string initials = "";
    }
}
