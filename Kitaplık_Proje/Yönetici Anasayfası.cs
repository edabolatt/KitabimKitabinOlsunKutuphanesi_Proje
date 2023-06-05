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
    public partial class Yönetici_Anasayfası : Form
    {
        public Yönetici_Anasayfası()
        {
            InitializeComponent();
        }

        string durum = "";
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut1 = new OleDbCommand("insert into Kitaplar (Kitapad,Yazar,Tur,Sayfa,Durum,Sahipid) values " +
                "(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut1.Parameters.AddWithValue("@p1", txtkitapad.Text);
            komut1.Parameters.AddWithValue("@p2", txtkitapyazar.Text);
            komut1.Parameters.AddWithValue("@p3", cmbtur.Text);
            komut1.Parameters.AddWithValue("@p4", txtkitapsayfa.Text);
            komut1.Parameters.AddWithValue("@p5", durum);
            komut1.Parameters.AddWithValue("@p6", txtüyeıd.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.jet.oledb.4.0;Data Source=Kitaplik.mdb");

        void listele()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from Kitaplar", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void Yönetici_Anasayfası_Load(object sender, EventArgs e)
        {
            listele();

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            durum = "0";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            durum = "1";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtkitapid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtkitapad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtkitapyazar.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbtur.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtkitapsayfa.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            if (dataGridView1.Rows[secilen].Cells[5].Value.ToString() == "True")
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
            }
            txtüyeıd.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

       
        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand sil = new OleDbCommand("Delete from Kitaplar where Kitapid=@p0", baglanti);
            sil.Parameters.AddWithValue("@p0", txtkitapid.Text);
            sil.ExecuteNonQuery();
            MessageBox.Show("Kitap Listeden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
            listele();
            
                

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            OleDbCommand komut4 = new OleDbCommand("update Kitaplar set Kitapad=@p1, Yazar=@p2,Tur=@p3,Sayfa=@4,Durum=@p5, Sahipid=@p7 where Kitapid=@p6",baglanti);
            komut4.Parameters.AddWithValue("@p1", txtkitapad.Text);
            komut4.Parameters.AddWithValue("@p2", txtkitapyazar.Text);
            komut4.Parameters.AddWithValue("@p3", cmbtur.Text);
            komut4.Parameters.AddWithValue("@p4", txtkitapsayfa.Text);
            if(radioButton1.Checked== true)
            {
                komut4.Parameters.AddWithValue("@p5", durum);
            }
            if(radioButton2.Checked ==true)
            {
                komut4.Parameters.AddWithValue("@p5", durum);
            }
            komut4.Parameters.AddWithValue("@p7", txtüyeıd.Text);
            komut4.Parameters.AddWithValue("@p6", txtkitapid.Text);
            
            komut4.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Kayıt Güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            listele();
        }

        private void btniade_Click(object sender, EventArgs e)
        {
            
        }
    }
}
