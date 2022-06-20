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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_ChangeUICues(object sender, UICuesEventArgs e)
        {
            
        }

        private void textBox1_ChangeUICues(object sender, UICuesEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form11 b = new Form11();
            b.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Student id");
            }
            else if (textBox13.Text == "")
            {
                MessageBox.Show("Please give Return id to Student");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\oms\Documents\login.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from Book__return where Return_id='" + textBox13.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Returned id already given to a student");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("insert into Book__return values (@Return_id,@Student_id,@Student_name,@Contact,@Department,@Adress,@Gender,@Book_id,@Book_name,@Author_name,@Book_price,@Book_issue_date,@Book_return_date)", con);
                    cmd.Parameters.AddWithValue("@Return_id", int.Parse(textBox13.Text));
                    cmd.Parameters.AddWithValue("@Student_id", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@Student_name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Contact",textBox3.Text);
                    cmd.Parameters.AddWithValue("@Department", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Adress", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Gender", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Book_id", int.Parse(textBox7.Text));
                    cmd.Parameters.AddWithValue("@Book_name", textBox8.Text);
                    cmd.Parameters.AddWithValue("@Author_name", textBox9.Text);
                    cmd.Parameters.AddWithValue("@Book_price", int.Parse(textBox10.Text));
                    cmd.Parameters.AddWithValue("@Book_issue_date", textBox11.Text);
                    cmd.Parameters.AddWithValue("@Book_return_date", dateTimePicker1.Value.ToString());
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand("update Book_information set Book_quantity=Book_quantity+1 where Book_id=@Book_id", con);
                    cmd2.Parameters.AddWithValue("@Book_id", int.Parse(textBox7.Text));
                    cmd2.ExecuteNonQuery();
                    SqlCommand cmd3 = new SqlCommand("delete Book__issue where Student_id=@Student_id", con);
                    cmd3.Parameters.AddWithValue("@Student_id", int.Parse(textBox1.Text));
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("Successfully Returned");
                    SqlCommand cmd4 = new SqlCommand("select * from Book__return where return_id=@return_id", con);
                    cmd4.Parameters.AddWithValue("@return_id", int.Parse(textBox13.Text));
                    SqlDataAdapter dm = new SqlDataAdapter(cmd4);
                    DataTable dc = new DataTable();
                    dm.Fill(dc);
                    dataGridView1.DataSource = dc;
                    con.Close();
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Student id");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\oms\Documents\login.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                if (textBox1.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select * from Book__issue where Student_id=@Student_id", con);
                    cmd.Parameters.AddWithValue("@Student_id", int.Parse(textBox1.Text));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Data");
                    }
                    else if (textBox1.Text != "")
                    {
                        SqlCommand cmd2 = new SqlCommand("select Student_name, Contact, Department, Adress, Gender, Book_id, Book_name, Author_name, Book_price, Book_issue_date from Book__issue where Student_id=@Student_id", con);
                        cmd2.Parameters.AddWithValue("@Student_id", int.Parse(textBox1.Text));
                        SqlDataReader da1 = cmd2.ExecuteReader();
                        while (da1.Read())
                        {
                            textBox2.Text = da1.GetValue(0).ToString();
                            textBox3.Text = da1.GetValue(1).ToString();
                            textBox4.Text = da1.GetValue(2).ToString();
                            textBox5.Text = da1.GetValue(3).ToString();
                            textBox6.Text = da1.GetValue(4).ToString();
                            textBox7.Text = da1.GetValue(5).ToString();
                            textBox8.Text = da1.GetValue(6).ToString();
                            textBox9.Text = da1.GetValue(7).ToString();
                            textBox10.Text = da1.GetValue(8).ToString();
                            textBox11.Text = da1.GetValue(9).ToString();

                        }

                    }
                    con.Close();
                }
            }
        }    
        private void textBox13_Enter(object sender, EventArgs e)
        {
            textBox13.Text = "";

        }

      
    }
}
