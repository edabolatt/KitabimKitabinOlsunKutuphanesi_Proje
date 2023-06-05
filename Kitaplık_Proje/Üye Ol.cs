using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitaplık_Proje
{
    public partial class Üye_Ol : Form
    {
        public Üye_Ol()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti7 = new OleDbConnection("Provider=Microsoft.jet.oledb.4.0;Data Source=ÜyeListesi.mdb");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti7.Open();

            OleDbCommand komut77 = new OleDbCommand("insert into Üyeler (Üyeid,Sifre) values (@p1,@p2)", baglanti7);
            komut77.Parameters.AddWithValue("@p1", textBox1.Text);
            komut77.Parameters.AddWithValue("@p2", textBox2.Text);
            komut77.ExecuteNonQuery();

            baglanti7.Close();

            MessageBox.Show("Üye Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
    }
}
