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
    public partial class Form7 : Form
    {
        public Form7()
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
            Dashboard f = new Dashboard();
            f.Show();
            this.Hide();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

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
             if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5
               .Text == "" && comboBox1.Text == "")
            {
                MessageBox.Show("enter details");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Student id");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Student name");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Enter contact");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Enter Department");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Enter Adress");
            }
             else if(comboBox1.Text == "")
            {
                MessageBox.Show("Enter Gender");
            }
            
            else
            {
             
           
                SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\oms\Documents\login.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlDataAdapter da = new SqlDataAdapter("select * from Student_information where Student_id='" + textBox1.Text + "'", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Already exist");
                }
                else
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Student_information values (@Student_id,@Student_name,@Contact,@Department,@Adress,@Gender)", cn);
                    cmd.Parameters.AddWithValue("@Student_id", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@Student_name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Contact",textBox3.Text);
                    cmd.Parameters.AddWithValue("@Department", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Adress", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Successfully Added");
                    SqlCommand cmd2 = new SqlCommand("select * from Student_information where Student_id=@Student_id", cn);
                    cmd2.Parameters.AddWithValue("@Student_id", int.Parse(textBox1.Text));
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    dataGridView1.DataSource = dt1;
                }
             
            }
        }
    
            
          
            
        

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5
              .Text == "" && comboBox1.Text == "")
            {
                MessageBox.Show("Only Enter Student id");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show(" Only Enter Student id");
            }
            else
            {
                SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\oms\Documents\login.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                cn.Open();
                if (textBox1.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select Student_id from Student_information where Student_id=@Student_id", cn);
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
                        SqlCommand cmd2 = new SqlCommand("delete Student_information where Student_id=@Student_id", cn);
                        cmd2.Parameters.AddWithValue("@Student_id", int.Parse(textBox1.Text));
                        cmd2.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Successfully Deleted");
                        SqlCommand cmd3 = new SqlCommand("select * from Student_information where Student_id=@Student_id", cn);
                        cmd3.Parameters.AddWithValue("@Student_id", int.Parse(textBox1.Text));
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd3);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        dataGridView1.DataSource = dt1;
                       
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5
               .Text == "" && comboBox1.Text == "")
            {
                MessageBox.Show("enter details");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Student id");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Student name");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Enter contact");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Enter Department");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Enter Adress");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Enter Gender");
            }
            else
            {
                SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\oms\Documents\login.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                cn.Open();
                if (textBox1.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select Student_id from Student_information where Student_id=@Student_id", cn);
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
                        SqlCommand cmd2 = new SqlCommand("update Student_information set  Student_name=@Student_name, Contact=@Contact, Department=@Department, Adress= @adress, Gender=@Gender  where Student_id=@Student_id", cn);
                        cmd2.Parameters.AddWithValue("@Student_id", int.Parse(textBox1.Text));
                        cmd2.Parameters.AddWithValue("@Student_name", textBox2.Text);
                        cmd2.Parameters.AddWithValue("@Contact",textBox3.Text);
                        cmd2.Parameters.AddWithValue("@Department", textBox4.Text);
                        cmd2.Parameters.AddWithValue("@Adress", textBox5.Text);
                        cmd2.Parameters.AddWithValue("@Gender", comboBox1.Text);
                        cmd2.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Successfully Updated");
                        SqlCommand cmd3 = new SqlCommand("select * from Student_information where Student_id=@Student_id", cn);
                        cmd3.Parameters.AddWithValue("@Student_id", int.Parse(textBox1.Text));
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

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Text = "";

        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = "";

        }

        private void textBox1_Enter_1(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }
      
    }
}
