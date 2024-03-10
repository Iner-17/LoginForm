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

        public void login() 
        { 
            string query = "SELECT * FROM userlogin WHERE username= @username AND password= @password";
            MySqlConnection conn = DBConnection.getConnection();

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandTimeout = 60;
            cmd.Parameters.AddWithValue("@username", lbl_userame.Text);
            cmd.Parameters.AddWithValue("@password", lbl_password.Text);
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

        private void btn_login_Click(object sender, EventArgs e)
        {
            login();
        }
    }
}
