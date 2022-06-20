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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dashboard m = new Dashboard();
            m.Show();
            this.Hide();

        }


        private void textBox1_Enter_1(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("details");
            }
          
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\oms\Documents\login.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
             
                if (radioButton1.Checked == true && textBox1.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select Student_name from Student_information where Student_name=@Student_name", con);
                    cmd.Parameters.AddWithValue("@Student_name", textBox1.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Data");
                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("select * from Student_information where Student_name=@Student_name", con);
                        cmd2.Parameters.AddWithValue("@Student_name", textBox1.Text);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        dataGridView1.DataSource = dt1;
                    }
                    
                }

                else if (radioButton2.Checked == true && textBox1.Text != "")
                {
                    SqlCommand cmd3 = new SqlCommand("select Student_id from Student_information where Student_id=@Student_id", con);
                    cmd3.Parameters.AddWithValue("@Student_id", int.Parse(textBox1.Text));
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    if (dt2.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Data");
                    }
                    else
                    {
                        SqlCommand cmd4 = new SqlCommand("select * from Student_information where Student_id=@Student_id", con);
                        cmd4.Parameters.AddWithValue("@Student_id", int.Parse(textBox1.Text));
                        SqlDataAdapter da3 = new SqlDataAdapter(cmd4);
                        DataTable dt3 = new DataTable();
                        da3.Fill(dt3);
                        dataGridView1.DataSource = dt3;

                    }



                    con.Close();
                }
            }
        }
    }
