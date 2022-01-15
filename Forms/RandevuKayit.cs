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
    public partial class RandevuKayit : Form
    {
        public RandevuKayit()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection ("Data Source=CERENSERIN;Initial Catalog=beauty;Integrated Security=True");

        private void button1_Click_1(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert into RandevuKayit (Ad,Soyad,CepNo,Email,Tarih,Saat,İslem) Values ('" + textBox1.Text.ToString() + "' , '" + textBox2.Text.ToString() + "' , '" + maskedTextBox1.Text.ToString() + "' , '" + textBox3.Text.ToString() + "' , '" + maskedTextBox2.Text.ToString() + "' , '" + maskedTextBox3.Text.ToString() + "' , '" + richTextBox1.Text.ToString() +  " ' ) ", baglan);
            komut.ExecuteNonQuery ();
            baglan.Close();
            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
            textBox3.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            richTextBox1.Clear();
            MessageBox.Show("Randevu Başarıyla Olşturuldu");




        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void FormRandevuKayit_Load(object sender, EventArgs e)
        {

        }

       
    }
}
