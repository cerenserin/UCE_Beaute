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
    public partial class Islemler : Form
    {
        public Islemler()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand komut;

        private void Islemler_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        void griddoldur()
        {
            con = new SqlConnection("Data Source=CERENSERIN;Initial Catalog=beauty;Integrated Security=SSPI");
            da = new SqlDataAdapter("Select *From islemler", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "islemler");
            dataGridView1.DataSource = ds.Tables["islemler"];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Insert into islemler (islemad,fiyat) Values ('" + textBox1.Text.ToString() + "' , '"   + textBox2.Text.ToString() + " ' ) ", con);
            komut.ExecuteNonQuery();
            con.Close();
            textBox1.Clear();
            textBox2.Clear();
            MessageBox.Show("Yeni İşlem Başarıyla Eklendi");
            griddoldur();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string islemad = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();
            string fiyat = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();

            textBox1.Text = islemad;
            textBox2.Text = fiyat;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand("update islemler set fiyat='" + textBox2.Text + "' where islemad='" + textBox1.Text + "'", con);
            komut.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("İşlem Başarıyla Güncellendi");
            griddoldur();
        }


        void KayıtSil(int numara)
        {
            string sql = "DELETE FROM islemler WHERE fiyat=@fiyat";
            komut = new SqlCommand(sql, con);
            komut.Parameters.AddWithValue("@fiyat", numara);
            con.Open();
            komut.ExecuteNonQuery();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  
            {
                int numara = Convert.ToInt32(drow.Cells[1].Value);
                KayıtSil(numara);

            }

            MessageBox.Show("İşlem Başarıyla Silindi");

            griddoldur();
        }

        
    }
}
