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

namespace UceBeaute.Forms
{
    public partial class personel : Form
    {
        public personel()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand komut;

        void griddoldur()
        {
            con = new SqlConnection("Data Source=CERENSERIN;Initial Catalog=beauty;Integrated Security=SSPI");
            da = new SqlDataAdapter("Select *From personel", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "personel");
            dataGridView1.DataSource = ds.Tables["personel"];
            con.Close();
        }

        void KayıtSil(int numara)
        {
            string sql = "DELETE FROM personel WHERE ID=@ID";
            komut = new SqlCommand(sql, con);
            komut.Parameters.AddWithValue("@ID", numara);
            con.Open();
            komut.ExecuteNonQuery();
            con.Close();
        }

        private void personel_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows) 
            {
                int numara = Convert.ToInt32(drow.Cells[0].Value);
                KayıtSil(numara);
            }

            MessageBox.Show("Personel Başarıyla Silindi");

            griddoldur();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Insert into personel (adsoyad,telno,izingun,alan) Values ('" + textBox1.Text.ToString() + "' , '" + maskedTextBox1.Text.ToString() + "' , '" + textBox2.Text.ToString() + "' , '" + textBox3.Text.ToString() + " ' ) ", con);
            komut.ExecuteNonQuery();
            con.Close();
            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
            textBox3.Clear();
            MessageBox.Show("Personel Başarıyla Eklendi");
            griddoldur();
        }

       

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
