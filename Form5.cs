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
    public partial class Form5 : Form

    {
        string foodname = string.Empty;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");

            DataTable ds = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter("select FName from Tbl_Food order by FName desc", con);
            sa.Fill(ds);
            comboBox1.ValueMember = "Fid";
            comboBox1.DisplayMember = "FName";
            comboBox1.DataSource = ds;
            Random rnd = new Random();
            int number = rnd.Next(1000,9999);
            textBox1.Text = number.ToString();

     
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foodname = comboBox1.Text;
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("select Fprice from Tbl_Food where FName=@foodname", con);
            cmd.Parameters.AddWithValue("@foodname", foodname);
        
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Close();
            da.Fill(dt);
         

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    pricetextbox.Text = (dr["Fprice"]).ToString();
                    amounttext.Text= (dr["Fprice"]).ToString();
                }         

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                foodname = comboBox1.Text;
                decimal price = decimal.Parse(pricetextbox.Text);
                int qauntity = int.Parse(textBox3.Text);
                decimal totalamount = price * qauntity;
                amounttext.Text = totalamount.ToString();
            }
        }

        private void amounttext_TextChanged(object sender, EventArgs e)
        {

        }
        public void billingtable()
        {

            foodname = comboBox1.Text;
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

            SqlCommand cmd = new SqlCommand("insert into Tbl_billing (billno,fid,price,quantity,amount)   values (@billno,@Fid,@Fprice,@Fquantity,@amount)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@billno",int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Fid",foodid);
            cmd.Parameters.AddWithValue("@Fprice",Decimal.Parse(pricetextbox.Text));
            cmd.Parameters.AddWithValue("@Fquantity",int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@amount", Decimal.Parse(amounttext.Text));
          
            
            int x = cmd.ExecuteNonQuery();

             if (x == 1)
            {

                MessageBox.Show("insertd successfully");

            }

            else
            {

                MessageBox.Show("delete failed");
            }
            con.Close();



        }
        private void button1_Click(object sender, EventArgs e)
        {


            billingtable();
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8EA69B37\SQLEXPRESS;Initial Catalog=logindb;Integrated Security=True");
            con.Open();


            SqlCommand cmdss = new SqlCommand("select fid,price,quantity,amount from Tbl_billing where billno=@billno", con);
            cmdss.Parameters.AddWithValue("@billno", int.Parse(textBox1.Text));

            SqlDataAdapter ad = new SqlDataAdapter(cmdss);
            DataTable DT=new DataTable();
            ad.Fill(DT);
           
            dataGridView1.DataSource = DT;
            SqlCommand cmd = new SqlCommand("select Sum(amount) as total from Tbl_billing where billno=@billno", con);
            cmd.Parameters.AddWithValue("@billno", int.Parse(textBox1.Text));
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);


            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    totalamount.Text = (dr["total"]).ToString(); 
                  
                }

            }
            con.Close();
            //comboBox1.Text;
            //pricetextbox.Text ;
            //
            //;


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pricetextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
