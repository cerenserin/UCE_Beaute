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
    public partial class Randevular : Form
    {
        public Randevular()
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
            da = new SqlDataAdapter("Select *From RandevuKayit", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "RandevuKayit");
            dataGridView1.DataSource = ds.Tables["RandevuKayit"];
            con.Close();
        }

        void KayıtSil(int numara)
        {
            string sql = "DELETE FROM RandevuKayit WHERE No=@No";
            komut = new SqlCommand(sql, con);
            komut.Parameters.AddWithValue("@No", numara);
            con.Open();
            komut.ExecuteNonQuery();
            con.Close();
        }

        private void randevular_Load(object sender, EventArgs e)
        {
            griddoldur();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int numara = Convert.ToInt32(drow.Cells[0].Value);
                KayıtSil(numara);
            }

            MessageBox.Show("Randevu Başarıyla Silindi");

            griddoldur();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
