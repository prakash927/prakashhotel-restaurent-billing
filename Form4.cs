using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form4 : Form
    {
        string foodtype =string.Empty;
        int ID = 0;
        string Foodname = string.Empty;
        string Foodtype = string.Empty;
        string Foodprice= string.Empty;
        string Foodavailability = string.Empty;

        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
      

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");
            foodavailability.Items.Add("M");
            foodavailability.Items.Add("A");
            foodavailability.Items.Add("E");
            foodavailability.Items.Add("N");
            //DataTable ds = new DataTable();
            //SqlDataAdapter sa = new SqlDataAdapter("select * from Tbl_Food", con);
            //sa.Fill(ds);
            //dataGridView1.DataSource = ds;

        }
        public void reload()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");
            DataTable ds = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter("select * from Tbl_Food", con);
            sa.Fill(ds);
            dataGridView1.DataSource = ds;

        }

        public void fieldbind()
        {
            foodname.Text = Foodname;
            foodprice.Text = Foodprice.ToString();
            foodavailability.Text = Foodavailability;
        
            string str = Regex.Replace(Foodtype, @"\s", "");

            if (str == "veg")
            {
                vegradio.Checked = true;


            }
            else if (str == "nonveg")
            {
                nvradio.Checked = true;
            }

        }
      
     

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");
            con.Open();
            if (vegradio.Checked)
            {
                foodtype = vegradio.Text;
            }
            else if (nvradio.Checked)
            {
                foodtype = nvradio.Text;

            }
            SqlCommand cmd = new SqlCommand("insert into Tbl_Food (FName,FType,Fprice,Favailable) values (@FName ,@FType,@Fprice,@Favailable)", con);
          
            cmd.Parameters.AddWithValue("@FName", foodname.Text);
            cmd.Parameters.AddWithValue("@FType", foodtype);
            cmd.Parameters.AddWithValue("@Fprice", int.Parse(foodprice.Text));
            cmd.Parameters.AddWithValue("@Favailable", foodavailability.SelectedItem);
            int  x=cmd.ExecuteNonQuery();
            con.Close();
            if (x==1)
            {

                MessageBox.Show("inserted successfully");
            
            }

            else
            {

                MessageBox.Show("insertion failed");
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            Foodname = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); 
              Foodtype = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); 
               Foodprice= dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
               Foodavailability = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            fieldbind();

            // ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Tbl_Food where Fid=@Fid", con);
            cmd.Parameters.AddWithValue("@Fid",ID );
            int x = cmd.ExecuteNonQuery();
            con.Close();
            if (x == 1)
            {

                MessageBox.Show("deleted successfully");
             
            }

            else
            {

                MessageBox.Show("delete failed");
            }
         

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");
            con.Open();
            if (vegradio.Checked)
            {
                foodtype = vegradio.Text;
            }
            else if (nvradio.Checked)
            {
                foodtype = nvradio.Text;

            }
            SqlCommand cmd = new SqlCommand("update  Tbl_Food set FName=@FName,FType=@FType,Fprice=@Fprice,Favailable=@Favailable where Fid=@id", con);

            cmd.Parameters.AddWithValue("@FName", foodname.Text);
            cmd.Parameters.AddWithValue("@FType", foodtype);
            cmd.Parameters.AddWithValue("@Fprice", foodprice.Text);
            cmd.Parameters.AddWithValue("@Favailable", foodavailability.SelectedItem);
            cmd.Parameters.AddWithValue("@id", ID);
            int x = cmd.ExecuteNonQuery();
            con.Close();
            if (x == 1)
            {

                MessageBox.Show("updated successfully");
             
            }

            else
            {

                MessageBox.Show("update failed");
            }
            con.Close();



        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void foodname_TextChanged(object sender, EventArgs e)
        {

        }

        private void vegradio_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
    