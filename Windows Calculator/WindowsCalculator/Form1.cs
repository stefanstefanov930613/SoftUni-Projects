using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsCalculator
{
    public partial class Form1 : Form
    {
        double value1 = 0;
        double value2 = 0;
        string operation = "";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Result.Text == "0")
            {
                Result.Clear();
            }

            Result.Text = Result.Text + "1";

        }

        private void button17_Click(object sender, EventArgs e)
        {
            Result.Clear();
            Result.Text = Result.Text + "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (Result.Text == "0")
            {
                Result.Clear();
            }

            Result.Text = Result.Text + "2";

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (Result.Text == "0")
            {
                Result.Clear();
            }
            Result.Text = Result.Text + "3";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Result.Text == "0")
            {
                Result.Clear();
            }
            Result.Text = Result.Text + "4";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Result.Text == "0")
            {
                Result.Clear();
            }
            Result.Text = Result.Text + "5";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Result.Text == "0")
            {
                Result.Clear();
            }
            Result.Text = Result.Text + "6";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Result.Text == "0")
            {
                Result.Clear();
            }
            Result.Text = Result.Text + "7";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Result.Text == "0")
            {
                Result.Clear();
            }
            Result.Text = Result.Text + "8";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Result.Text == "0")
            {
                Result.Clear();
            }
            Result.Text = Result.Text + "9";

        }

        private void operator_click(object sender, EventArgs e)
        {

            string name = ((System.Windows.Forms.Control)sender).Name;

            if (name == Addition.Name)
            {
                operation = "+";
            }
            else if (name == Subtraction.Name)
            {
                operation = "-";
            }
            else if (name == Multiplication.Name)
            {
                operation = "*";
            }
            else if (name == Division.Name)
            {
                operation = "/";
            }

            string lastElement = Result.Text.Last().ToString();
            string textBox = Result.Text;
            if (textBox == "0" && textBox.Length == 1 && operation == "-")
            {
                textBox = operation;
            }
            else if (lastElement == "+" || lastElement == "-" || lastElement == "*" || lastElement == "/")
            {
                textBox = textBox.Remove(textBox.Length - 1);
                textBox += operation;

            }
            else
            {
                textBox += operation;

            }

            Result.Text = textBox;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Result.Text == "0")
            {
                Result.Clear();
            }
            Result.Text = Result.Text + "0";
        }

        private void button18_Click(object sender, EventArgs e)
        {

            string text = Result.Text;

            if (text.Length > 0 && text != "0")
            {
                text = text.Remove(text.Length - 1);

            }
            if (text.Length == 0)
            {
                text = "0";
            }

            Result.Text = text;

        }

        private void button16_Click(object sender, EventArgs e)
        {

            var operators = new List<char>();

            foreach (char operant in Result.Text)
            {
                if (Char.IsSymbol(operant) || operant == '*' || operant == '-' || operant == '/')
                {
                    operators.Add(operant);
                }

            }

            var tokens = Result.Text.Split(operators.ToArray());

            value1 = double.Parse(tokens[0]);

            for (int i = 0; i < operators.Count; i++)
            {
                string operation = operators[i].ToString();
                value2 = double.Parse(tokens[i + 1]);

                switch (operation)
                {
                    case "+":
                        value1 += value2;

                        break;

                    case "-":
                        value1 -= value2;

                        break;

                    case "/":
                        value1 /= value2;

                        break;

                    case "*":
                        value1 *= value2;

                        break;

                    default:
                        break;
                }
            }

            Result.Text = value1.ToString();
        }
 
    }
}
