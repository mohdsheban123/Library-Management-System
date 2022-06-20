using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            
            textBox2.MaxLength = 4;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null && textBox2.Text ==null)
            {
                MessageBox.Show("details");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="D:\software\LIBRARY MANAGEMENT SYSTEM\Source Code\WindowsFormsApplication3\LMS.mdf";Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from logindata where username='" + textBox1.Text + "' and password = '" + textBox2.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    Dashboard f = new Dashboard();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please check username and password");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form12 b = new Form12();
            b.Show();
            this.Hide();

        }

       
    }
}
