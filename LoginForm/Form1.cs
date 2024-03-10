using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            string mysqlcon = "server=localhost;user=root;database=login;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlcon);

            try
            {
                mySqlConnection.Open();
                MessageBox.Show("Successful");
            } catch (Exception e) 
            {
                MessageBox.Show(e.Message);
            } finally
            {
                mySqlConnection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
