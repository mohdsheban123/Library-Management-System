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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dashboard f = new Dashboard();
            f.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null && radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                MessageBox.Show("First choose an option and Enter details");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\oms\Documents\login.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                 if (radioButton1.Checked == true && textBox1.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select Book_name from Book_information where Book_name=@Book_name", con);
                    cmd.Parameters.AddWithValue("@Book_name", textBox1.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Data");
                    }
                    else
                    {

                        SqlCommand cmd2 = new SqlCommand("select * from Book_information where Book_name=@Book_name", con);
                        cmd2.Parameters.AddWithValue("@Book_name", textBox1.Text);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        dataGridView1.DataSource = dt1;

                    }
                }

                else if (radioButton2.Checked == true && textBox1.Text != "")
                {
                    SqlCommand cmd3 = new SqlCommand("select Author_name from Book_information where Author_name=@Author_name", con);
                    cmd3.Parameters.AddWithValue("@Author_name", textBox1.Text);
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    if (dt2.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Data");
                    }
                    else
                    {
                        SqlCommand cmd4 = new SqlCommand("select * from Book_information where Author_name=@Author_name", con);
                        cmd4.Parameters.AddWithValue("@Author_name", textBox1.Text);
                        SqlDataAdapter da3 = new SqlDataAdapter(cmd4);
                        DataTable dt3 = new DataTable();
                        da3.Fill(dt3);
                        dataGridView1.DataSource = dt3;
                    }
                }

                else if (radioButton3.Checked == true && textBox1.Text != "")
                {
                    SqlCommand cmd5 = new SqlCommand("select Book_id from Book_information where Book_id=@Book_id", con);
                    cmd5.Parameters.AddWithValue("@Book_id", int.Parse(textBox1.Text));
                    SqlDataAdapter da4 = new SqlDataAdapter(cmd5);
                    DataTable dt4 = new DataTable();
                    da4.Fill(dt4);
                    if (dt4.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Data");
                    }
                    else
                    {


                        SqlCommand cmd6 = new SqlCommand("select * from Book_information where Book_id=@Book_id", con);
                        cmd6.Parameters.AddWithValue("@Book_id", textBox1.Text);
                        SqlDataAdapter da5 = new SqlDataAdapter(cmd6);
                        DataTable dt5 = new DataTable();
                        da5.Fill(dt5);
                        dataGridView1.DataSource = dt5;
                        con.Close();
                    }
                }
            }

        }
        
        
            
        

        private void button5_Click(object sender, EventArgs e)
        {
            Form9 j = new Form9();
            j.Show();
            this.Hide();
        }
    }
}
