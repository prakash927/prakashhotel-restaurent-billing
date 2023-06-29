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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into login values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "' ,'" + textBox4.Text + "','" + textBox5.Text + "'," + textBox6.Text + ")", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Register successfully");

            Form1 lg = new Form1();
            lg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }
    }
}

