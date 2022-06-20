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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
           

        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dashboard f = new Dashboard();
            f.Show();
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

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null && textBox2.Text == null)
            {
                MessageBox.Show("Enter details");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Student id ");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Book_id");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\oms\Documents\login.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from Book__issue where Student_id='" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("A Student can only issue one book");
                }
                    else if (textBox11.Text == "0")
                    {
                        MessageBox.Show("Book not avalaible");
                    }
                    else
                    {
                        SqlCommand cmd3 = new SqlCommand("insert into Book__issue values (@Student_id,@Student_name,@Contact,@Department,@Adress,@Gender,@Book_id,@Book_name,@Author_name,@Book_price,@Book_issue_date)", con);
                        cmd3.Parameters.AddWithValue("@Student_id", int.Parse(textBox1.Text));
                        cmd3.Parameters.AddWithValue("@Student_name", textBox3.Text);
                        cmd3.Parameters.AddWithValue("@Contact", textBox4.Text);
                        cmd3.Parameters.AddWithValue("@Department", textBox5.Text);
                        cmd3.Parameters.AddWithValue("@Adress", textBox6.Text);
                        cmd3.Parameters.AddWithValue("@Gender", textBox10.Text);
                        cmd3.Parameters.AddWithValue("@Book_id", int.Parse(textBox2.Text));
                        cmd3.Parameters.AddWithValue("@Book_name", textBox7.Text);
                        cmd3.Parameters.AddWithValue("@Author_name", textBox8.Text);
                        cmd3.Parameters.AddWithValue("@Book_price", int.Parse(textBox9.Text));
                        cmd3.Parameters.AddWithValue("@Book_issue_date", dateTimePicker1.Value.ToString());
                        cmd3.ExecuteNonQuery();
                        SqlCommand cmd4 = new SqlCommand("update Book_information set Book_quantity=Book_quantity-1 where Book_id=@Book_id", con);
                        cmd4.Parameters.AddWithValue("@Book_id", int.Parse(textBox2.Text));
                        cmd4.ExecuteNonQuery();
                        MessageBox.Show("Book issued successfully");
                        SqlCommand cmd5 = new SqlCommand("select * from Book__issue where Student_id=@Student_id", con);
                        cmd5.Parameters.AddWithValue("@Student_id", int.Parse(textBox1.Text));
                        SqlDataAdapter dm = new SqlDataAdapter(cmd5);
                        DataTable dc = new DataTable();
                        dm.Fill(dc);
                        dataGridView1.DataSource = dc;
                    }
                    con.Close();


                }
            }
        

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form5 h = new Form5();
            h.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
         
             if (textBox1.Text == "")
            {
                MessageBox.Show("Enter details");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\oms\Documents\login.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                if (textBox1.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select Student_name, Contact, Department, Adress, Gender from Student_information where Student_id=@Student_id", con);
                    cmd.Parameters.AddWithValue("@Student_id", int.Parse(textBox1.Text));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Data");
                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("select Student_name, Contact, Department, Adress, Gender from Student_information where Student_id=@Student_id", con);
                        cmd2.Parameters.AddWithValue("@Student_id", int.Parse(textBox1.Text));
                        SqlDataReader da1 = cmd2.ExecuteReader();
                        while (da1.Read())
                        {
                            textBox3.Text = da1.GetValue(0).ToString();
                            textBox4.Text = da1.GetValue(1).ToString();
                            textBox5.Text = da1.GetValue(2).ToString();
                            textBox6.Text = da1.GetValue(3).ToString();
                            textBox10.Text = da1.GetValue(4).ToString();
                        }
                    }
                }

                
                con.Close();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
             if (textBox2.Text == "")
            {
                MessageBox.Show("Enter details");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\oms\Documents\login.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                if (textBox2.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select Book_name, Author_name, Book_price, Book_quantity from Book_information where Book_id=@Book_id", con);
                    cmd.Parameters.AddWithValue("@Book_id", int.Parse(textBox2.Text));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Data");
                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("select Book_name, Author_name, Book_price, Book_quantity from Book_information where Book_id=@Book_id", con);
                        cmd2.Parameters.AddWithValue("@Book_id", int.Parse(textBox2.Text));
                        SqlDataReader da1 = cmd2.ExecuteReader();
                        while (da1.Read())
                        {
                            textBox7.Text = da1.GetValue(0).ToString();
                            textBox8.Text = da1.GetValue(1).ToString();
                            textBox9.Text = da1.GetValue(2).ToString();
                            textBox11.Text = da1.GetValue(3).ToString();

                        }
                    }

                }
                con.Close();
            }
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_Enter_1(object sender, EventArgs e)
        {
            textBox2.Text = "";

        }

        }

    }

