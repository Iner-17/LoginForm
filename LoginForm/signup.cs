using MySql.Data.MySqlClient;
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

namespace LoginForm
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }
        private void lbl_login_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();

            this.Close();
        }
        public void signup_() {
            string query = "INSERT INTO userlogin (Username, Password) VALUES (@username, @password)";
            MySqlConnection conn = DBConnection.getConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", lbl_userame.Text);
            cmd.Parameters.AddWithValue("@password", lbl_password.Text);

            if(lbl_password.Text == txt_cpassword.Text)
            {
                if(!IsUsernameAvailable(lbl_userame.Text))
                {
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data Inserted Successfully");
                        }
                        else
                        {
                            MessageBox.Show("Data Insertin failed");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                } 
                
            } 
            else
            {
                MessageBox.Show("Incorrect details");
            }
                
        }

        private bool IsUsernameAvailable(string username)
        {
            string query = "SELECT * FROM userlogin WHERE Username = @username";
            MySqlConnection conn = DBConnection.getConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue ("@username", username);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            try
            {
                
                if (reader.HasRows)
                {
                    MessageBox.Show("Username already exists");
                    return true;
                } else
                {
                    
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            } 
            finally
            {
                conn.Close();
            }
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            signup_();
            lbl_userame.Text = "";
            lbl_password.Text = "";
            txt_cpassword.Text = "";
        }
    }
}
