using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace loginsonhali
{
    public partial class Giris : Form
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;
        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            con = new SqlConnection("Data Source=CERENSERIN;Initial Catalog=beauty;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select*From Kullanici_Bilgi where kullanici_adi='" + textBox1.Text +
                "' And sifre='" + textBox2.Text + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
               
                UceBeaute.Form1 f2 = new UceBeaute.Form1();
                f2.Show();
                
            }

            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı Ve Şifre");
            }

           
        }

        private void LoginDeneme_Load(object sender, EventArgs e)
        {

        }
    }
}
