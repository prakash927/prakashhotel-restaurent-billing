using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");

            DataTable ds = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter("select FName from Tbl_Food order by FName desc", con);
            sa.Fill(ds);
            comboBox1.ValueMember = "Fid";
            comboBox1.DisplayMember = "FName";
            comboBox1.DataSource = ds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
          
                DateTime startdate = dateTimePicker1.Value;
                DateTime endstart = dateTimePicker2.Value;
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Tbl_billing where billdate between @startdate and @enddate ", con);

                cmd.Parameters.AddWithValue("@startdate", startdate);
                cmd.Parameters.AddWithValue("@enddate", endstart);
                DataTable ds = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(ds);
                con.Close();
                dataGridView1.DataSource = ds;
            txtbox();





        }
        public void txtbox()
        {

            string foodname = comboBox1.Text;
            int foodid = 0;
            SqlConnection cons = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");
            cons.Open();
            SqlCommand cmds = new SqlCommand("select Fid from Tbl_Food where FName=@foodname", cons);
            cmds.Parameters.AddWithValue("@foodname", foodname);

            SqlDataAdapter da = new SqlDataAdapter(cmds);
            DataTable dt = new DataTable();
            cons.Close();
            da.Fill(dt);


            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    foodid = int.Parse(dr["Fid"].ToString());
                }


            }
            DateTime startdate = dateTimePicker1.Value;
            DateTime endstart = dateTimePicker2.Value;
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");
            con.Open();

            SqlCommand cmdss = new SqlCommand("select Sum(amount) as amount,Sum(quantity) as totalquantity from Tbl_billing where  billdate between @startdate and @enddate ", con);

            cmdss.Parameters.AddWithValue("@startdate", startdate);
            cmdss.Parameters.AddWithValue("@enddate", endstart);
            
            DataTable dts = new DataTable();
            SqlDataAdapter das = new SqlDataAdapter(cmdss);

            das.Fill(dts);


            if (dts != null)
            {
                foreach (DataRow dr in dts.Rows)
                {
                    textBox2.Text = (dr["amount"]).ToString();
                    textBox1.Text = (dr["totalquantity"]).ToString();

                }

            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string foodname = comboBox1.Text;
            int foodid = 0;
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");
            con.Open();
            SqlCommand cmds = new SqlCommand("select Fid from Tbl_Food where FName=@foodname", con);
            cmds.Parameters.AddWithValue("@foodname", foodname);

            SqlDataAdapter da = new SqlDataAdapter(cmds);
            DataTable dt = new DataTable();
            con.Close();
            da.Fill(dt);


            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    foodid = int.Parse(dr["Fid"].ToString());
                }


            }
            DateTime startdate = dateTimePicker1.Value;
            DateTime endstart = dateTimePicker2.Value;
            SqlConnection cons = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");
            cons.Open();
            SqlCommand cmd = new SqlCommand("select * from Tbl_billing where billdate between @startdate and @enddate and fid=@foodid", con);

            cmd.Parameters.AddWithValue("@startdate", startdate);
            cmd.Parameters.AddWithValue("@enddate", endstart);
            cmd.Parameters.AddWithValue("@foodid", foodid);
            DataTable ds = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(ds);
            cons.Close();
            dataGridView1.DataSource = ds;
            textboxload();



        }
        public void textboxload()
        {
            string foodname = comboBox1.Text;
            int foodid = 0;
            SqlConnection cons = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");
            cons.Open();
            SqlCommand cmds = new SqlCommand("select Fid from Tbl_Food where FName=@foodname", cons);
            cmds.Parameters.AddWithValue("@foodname", foodname);

            SqlDataAdapter da = new SqlDataAdapter(cmds);
            DataTable dt = new DataTable();
            cons.Close();
            da.Fill(dt);


            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    foodid = int.Parse(dr["Fid"].ToString());
                }


            }
            DateTime startdate = dateTimePicker1.Value;
            DateTime endstart = dateTimePicker2.Value;
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");
            con.Open();
 
            SqlCommand cmdss = new SqlCommand("select Sum(amount) as amount,Sum(quantity) as totalquantity from Tbl_billing where  fid=@foodid and billdate between @startdate and @enddate ", con);

            cmdss.Parameters.AddWithValue("@startdate", startdate);
            cmdss.Parameters.AddWithValue("@enddate", endstart);
            cmdss.Parameters.AddWithValue("@foodid", foodid);
            DataTable dts = new DataTable();
            SqlDataAdapter das = new SqlDataAdapter(cmdss);

            das.Fill(dts);


            if (dts != null)
            {
                foreach (DataRow dr in dts.Rows)
                {
                    textBox2.Text = (dr["amount"]).ToString();
                    textBox1.Text = (dr["totalquantity"]).ToString();

                }

            }
            con.Close();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
