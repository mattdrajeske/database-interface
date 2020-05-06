using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                string[] promptValue = Prompt.ShowDialog("Username", "Password", "Login");
            }
            if (comboBox1.SelectedIndex == 1)
            {
                string[] promptValue = Prompt.ShowDialog("Username", "Email", "Create New User");
            }
            if (comboBox1.SelectedIndex == 2)
            {
                string[] promptValue = Prompt2.ShowDialog("Username", "Delete Account");
            }
            if (comboBox1.SelectedIndex == 3)
            {
                string[] promptValue = Prompt.ShowDialog("Username", "New Email", "Modify Account");
            }
            if (comboBox1.SelectedIndex == 4)
            {
                string[] promptValue = Prompt.ShowDialog("Trail Name", "Location", "Add Trail");
            }
            if (comboBox1.SelectedIndex == 5)
            {
                string[] promptValue = Prompt2.ShowDialog("Trail Name", "Remove Trail");
            }
            if (comboBox1.SelectedIndex == 6)
            {
                string[] promptValue = Prompt.ShowDialog("Serial No.", "Trail Name", "Add Sensor");
            }
            if (comboBox1.SelectedIndex == 7)
            {
                string[] promptValue = Prompt2.ShowDialog("Serial No.", "Remove Sensor");
            }
        }
    }

    public static class Prompt
    {
        public static string[] ShowDialog(string text1, string text2, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 350;
            prompt.Height = 300;
            prompt.Text = caption;
            Label textLabel1 = new Label() { Left = 125, Top = 20, Text = text1 };
            Label textLabel2 = new Label() { Left = 125, Top = 80, Text = text2 };
            TextBox inputBox1 = new TextBox() { Left = 50, Top = 50, Width = 200 };
            TextBox inputBox2 = new TextBox() { Left = 50, Top = 110, Width = 200 };
            Button confirmation = new Button() { Text = "Ok", Left = 100, Width = 100, Top = 150 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel1);
            prompt.Controls.Add(textLabel2);
            prompt.Controls.Add(inputBox1);
            prompt.Controls.Add(inputBox2);
            prompt.ShowDialog();
            string[] arr = { inputBox1.Text, inputBox2.Text };
            return arr;
        }
    }

    public static class Prompt2
    {
        public static string[] ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 350;
            prompt.Height = 200;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 125, Top = 20, Text = text };
            TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
            Button confirmation = new Button() { Text = "Ok", Left = 100, Width = 100, Top = 100 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.ShowDialog();
            string[] arr = { inputBox.Text };
            return arr;
        }
    }
}
