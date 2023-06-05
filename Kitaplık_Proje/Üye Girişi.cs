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
    public partial class Üye_Girişi : Form
    {
        public Üye_Girişi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection baglanti5 = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source= ÜyeListesi.mdb");
                baglanti5.Open();
                OleDbCommand sorgu5 = new OleDbCommand("select Üyeid,Sifre from Üyeler where Üyeid=@üid and Sifre=@sifre", baglanti5);
                sorgu5.Parameters.AddWithValue("@üid", textBox1.Text);
                sorgu5.Parameters.AddWithValue("@sifre", textBox2.Text);
                OleDbDataReader dr;
                dr = sorgu5.ExecuteReader();


                if (dr.Read())
                {
                    Üye_Anasayfası frm5 = new Üye_Anasayfası();
                    frm5.Show();
                    this.Visible = false;
                }
                else
                {
                    baglanti5.Close();
                    MessageBox.Show("Yalnış Üye ID veya Şifresi. Lütfen tekrar deneyiniz!");
                }
            }
            catch
            {
                MessageBox.Show("Yalnış Üye ID veya Şifresi girdiniz. Lütfen tekrar deneyiniz!");
            }
            finally
            {
                textBox1.Clear();
                textBox2.Clear();
            }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            Üye_Ol üye_Ol = new Üye_Ol();
            üye_Ol.Show();

            this.Hide();

        }
    }
}
