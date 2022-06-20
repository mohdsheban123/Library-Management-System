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
    public partial class Form4 : Form
    {


        public Form4()
        {
            InitializeComponent();
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

      

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";

        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("Enter details");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Book id");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Book name");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Enter Author name");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Enter Book price");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Enter Book quantity");
            }
            else
            {
                          
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\oms\Documents\login.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlDataAdapter da = new SqlDataAdapter("select * from Book_information where Book_id='"+textBox1.Text+"'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Already exist");
                }
                else
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT  INTO Book_information values (@Book_id,@Book_name,@Author_name,@Book_price,@Book_quantity )", con);
                    cmd.Parameters.AddWithValue("@Book_id", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@Book_name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Author_name", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Book_price", int.Parse(textBox4.Text));
                    cmd.Parameters.AddWithValue("@Book_quantity", int.Parse(textBox5.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Book added successfully");
                    SqlCommand cmd2 = new SqlCommand("select * from Book_information where Book_id=@Book_id", con);
                    cmd2.Parameters.AddWithValue("@Book_id", int.Parse(textBox1.Text));
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    dataGridView1.DataSource = dt1;
                }

            }
           
      
        }
    


        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "")
            {
                MessageBox.Show("Enter details");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\oms\Documents\login.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                if (textBox1.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select Book_id from Book_information where Book_id=@Book_id", con);
                    cmd.Parameters.AddWithValue("@Book_id", int.Parse(textBox1.Text));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Data");
                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("delete Book_information where Book_id=@Book_id", con);
                        cmd2.Parameters.AddWithValue("@Book_id", int.Parse(textBox1.Text));
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Successfully Deleted");
                        SqlCommand cmd3 = new SqlCommand("select * from Book_information where Book_id=@Book_id", con);
                        cmd3.Parameters.AddWithValue("@Book_id", int.Parse(textBox1.Text));
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd3);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        dataGridView1.DataSource = dt1;
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "")
            {
                MessageBox.Show("Enter details");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\oms\Documents\login.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                if (textBox1.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select Book_id from Book_information where Book_id=@Book_id", con);
                    cmd.Parameters.AddWithValue("@Book_id", int.Parse(textBox1.Text));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Data");
                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("Update Book_information set  Book_name=@Book_name, Author_name=@Author_name, Book_price= @Book_price, Book_quantity=@Book_quantity where Book_id=@Book_id", con);
                        cmd2.Parameters.AddWithValue("@Book_id", int.Parse(textBox1.Text));
                        cmd2.Parameters.AddWithValue("@Book_name", textBox2.Text);
                        cmd2.Parameters.AddWithValue("@Author_name", textBox3.Text);
                        cmd2.Parameters.AddWithValue("@Book_price", int.Parse(textBox4.Text));
                        cmd2.Parameters.AddWithValue("@Book_quantity", int.Parse(textBox5.Text));
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Updated Successfully");
                        SqlCommand cmd3 = new SqlCommand("select * from Book_information where Book_id=@Book_id", con);
                        cmd3.Parameters.AddWithValue("@Book_id", int.Parse(textBox1.Text));
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd3);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        dataGridView1.DataSource = dt1;
                    }
                   
                }
            }
        }

        private void textBox3_Enter_1(object sender, EventArgs e)
        {
            textBox3.Text = "";


        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = "";

        }
        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Text = "";

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }   
        }
    }
}