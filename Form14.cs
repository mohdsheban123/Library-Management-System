using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System .Data.SqlClient;

namespace WindowsFormsApplication3
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\oms\Documents\login.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from logindata where username='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Incorrect username");
            }
            else
            {
                SqlDataAdapter db = new SqlDataAdapter("select * from logindata where password='" + textBox2.Text + "'", con);
                DataTable dc = new DataTable();
                db.Fill(dc);
                if (dc.Rows.Count == 0)
                {
                    MessageBox.Show("Incorrect password");
                }
                else
                {
                    Form13 v = new Form13();
                    v.Show();
                    this.Hide();
                }
                con.Close();

            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";

        }

        private void Form14_Load(object sender, EventArgs e)
        {

        }
    }
}