using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kitaplık_Proje
{
    public partial class Yönetici_Girişi : Form
    {
        public Yönetici_Girişi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                OleDbConnection baglantii = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source= YöneticiListesi.mdb");
                baglantii.Open();
                OleDbCommand sorguu = new OleDbCommand("select Kullanıcııd,sifre from Yöneticiler where Kullanıcııd=@kad and sifre=@sifre", baglantii);
                sorguu.Parameters.AddWithValue("@kad", textBox1.Text);
                sorguu.Parameters.AddWithValue("@sifre", textBox2.Text);
                OleDbDataReader dr;
                dr = sorguu.ExecuteReader();

                if (dr.Read())
                {
                    Yönetici_Anasayfası frmm = new Yönetici_Anasayfası();
                    frmm.Show();
                    this.Visible = false;
                }
                else
                {
                    baglantii.Close();
                    MessageBox.Show("Yalnış Kullanıcı ID veya Şifresi. Lütfen tekrar deneyiniz!");
                }
            }

           catch
            {
                MessageBox.Show("Yalnış Kullanıcı ID veya Şifresi girdiniz. Lütfen tekrar deneyiniz!");
            }
            finally
            {
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
