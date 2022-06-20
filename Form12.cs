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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.PasswordChar = '*';

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.PasswordChar = '*';

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("Enter details");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\oms\Documents\login.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from logindata where username='" + textBox3.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Incorrect Details");
                }
                else
                {
                    SqlDataAdapter db = new SqlDataAdapter("select * from logindata where password='" + textBox1.Text + "'", con);
                    DataTable dc = new DataTable();
                    db.Fill(dc);
                    if (dc.Rows.Count == 0)
                    {
                        MessageBox.Show("Incorrect password");
                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("update logindata set password=@password where username=@username", con);
                        cmd2.Parameters.AddWithValue("@username", textBox3.Text);
                        cmd2.Parameters.AddWithValue("@password", textBox2.Text);
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Password updated successfully");
                    }
                    con.Close();

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login g = new Login();
            g.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";

        }

        private void Form12_Load(object sender, EventArgs e)
        {
           
        }
    }
}
