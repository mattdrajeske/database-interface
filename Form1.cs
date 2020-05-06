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
                MessageBox.Show("Login Existing User");
            }
            if (comboBox1.SelectedIndex == 1)
            {
                MessageBox.Show("Create New User");
            }
            if (comboBox1.SelectedIndex == 2)
            {
                MessageBox.Show("Delete Account");
            }
            if (comboBox1.SelectedIndex == 3)
            {
                MessageBox.Show("Modify Account");
            }
        }
    }
}
