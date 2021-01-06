using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_WinForms
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game made by me. Have fun!");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turnCount = 0;
            Application.Restart();
        }

        private void button_click(object sender, EventArgs e)
        {

            Button b = (Button)sender;

            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }

            b.Enabled = false;
            turnCount++;
            checkForWinner();
            checkForDraw();
            turn = !turn;
        }

        private void checkForWinner()
        {

            bool isWinner = false;

            if (A1.Text == A2.Text && A2.Text == A3.Text && !A1.Enabled) //horizontal checks
            {
                isWinner = true;
            }
            else if (B1.Text == B2.Text && B2.Text == B3.Text && !B1.Enabled)
            {
                isWinner = true;
            }
            else if (C1.Text == C2.Text && C2.Text == C3.Text && !C1.Enabled)
            {
                isWinner = true;
            }
            else if (A1.Text == B1.Text && B1.Text == C1.Text && !A1.Enabled && !C1.Enabled) //vertical checks
            {
                isWinner = true;

            }
            else if (A2.Text == B2.Text && B2.Text == C2.Text && !A2.Enabled && !C2.Enabled)
            {
                isWinner = true;
            }
            else if (A3.Text == B3.Text && B3.Text == C3.Text && !A3.Enabled)
            {
                isWinner = true;

            }
            else if (A1.Text == B2.Text && B2.Text == C3.Text && !A1.Enabled) //diagonal checks
            {

                isWinner = true;

            }
            else if (A3.Text == B2.Text && B2.Text == C1.Text && !A3.Enabled)
            {
                isWinner = true;

            }

            if (isWinner)
            {
                disableButtons();
                string winner = "";

                if (turn)
                {
                    winner = "X";
                }
                else
                {
                    winner = "O";
                }

                MessageBox.Show($"The winner is player {winner}!");
            }

        }

        private void checkForDraw()
        {
            bool isDraw = false;

            if (turnCount == 9)
            {
                isDraw = true;

            }

            if (isDraw)
            {
                MessageBox.Show("Draw!", "Let's go again!");
                
            }

        }

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }

            }
            catch
            {

            }

        }
    }
}
