using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login g = new Login();
            g.Show();
            this.Hide();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The LIBRARY MANAGEMENT SYSTEM is designed & developed for a receipt and issuance of books in the library along with the student’s details. The books received in the library are entered in Books Entry form and the new student is entered in the student entry form. When the student wants to get the desired book the same is issued on the availability basis to the student.");
 

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 a = new Form4();
            a.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form11 l = new Form11();
            l.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 a = new Form6();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 a = new Form7();
            a.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 a = new Form8();
            a.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form10 b = new Form10();
            b.Show();
            this.Hide();
        }
       
    }
}
