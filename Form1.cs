using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
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

    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "proxy19.rt3.io:33014";
            database = "trailcountersdb";
            uid = "dbtester";
            password = "gominers";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert(string query)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update(string query)
        {
            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public List<string>[] Select(string query)
        {
            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        //Count statement
        public int Count(string query)
        {
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }
    }
}

