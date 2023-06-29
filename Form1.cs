using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select username, password from login where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Form3 frm = new Form3();
                frm.Show();
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("Invalid User");
            }
            con.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 rg = new Form2();
            rg.Show();

        }
    }
}
