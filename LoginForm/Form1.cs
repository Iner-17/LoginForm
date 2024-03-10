using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        String connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;";

        public void login() 
        { 
            string query = "SELECT * FROM userlogin WHERE username='" + lbl_userame.Text + "' AND password='" + lbl_password.Text + "'";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int userId = reader.GetInt32("ID");
                        string username = reader.GetString("Username");
                        MessageBox.Show("Login Successful. Welcome user " + userId + ": " + username);
                    }
                }
                else 
                {
                    MessageBox.Show("Login Failed");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }
    }
}
