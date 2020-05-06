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
                string[] promptValue = Prompt.ShowDialog("Username", "Password", "123");
            }
            if (comboBox1.SelectedIndex == 1)
            {
                MessageBox.Show("Create New User");
                Form newUser = new Form();
                newUser.ShowDialog();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                MessageBox.Show("Delete Account");
                Form delAccount = new Form();
                delAccount.ShowDialog();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                MessageBox.Show("Modify Account");
                Form modify = new Form();
                modify.ShowDialog();
            }
            if (comboBox1.SelectedIndex == 4)
            {
                MessageBox.Show("Add Trail");
                Form addTrail = new Form();
                addTrail.ShowDialog();
            }
            if (comboBox1.SelectedIndex == 5)
            {
                MessageBox.Show("Remove Trail");
                Form remTrail = new Form();
                remTrail.ShowDialog();
            }
            if (comboBox1.SelectedIndex == 6)
            {
                MessageBox.Show("Add Sensor");
                Form addSens = new Form();
                addSens.ShowDialog();
            }
            if (comboBox1.SelectedIndex == 7)
            {
                MessageBox.Show("Remove Sensor");
                Form remSens = new Form();
                remSens.ShowDialog();
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
}
