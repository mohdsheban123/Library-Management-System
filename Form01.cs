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
    public partial class Form01 : Form
    {
        public Form01()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(5);
            if(progressBar1.Value>=90)
            {
               
                Login f = new Login();
                f.Show();
                this.Hide();
                timer1.Stop();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
