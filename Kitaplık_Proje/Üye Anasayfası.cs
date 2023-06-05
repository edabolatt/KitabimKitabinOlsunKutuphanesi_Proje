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
    public partial class Üye_Anasayfası : Form
    {
        public Üye_Anasayfası()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        OleDbConnection baglanti6 = new OleDbConnection("Provider=microsoft.jet.oledb.4.0;data source=Kitaplik.mdb");

        void görüntüle()
        {
            DataTable dt6 = new DataTable();
            OleDbDataAdapter da6 = new OleDbDataAdapter("Select * from Kitaplar", baglanti6);
            da6.Fill(dt6);
            dataGridView1.DataSource = dt6;
        }
        private void Üye_Anasayfası_Load(object sender, EventArgs e)
        {
            görüntüle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti6.Open();
            OleDbCommand komut6 = new OleDbCommand("Update Kitaplar set Sahipid=@p9 where Kitapid=@p10", baglanti6);
            komut6.Parameters.AddWithValue("@p9", textBox1.Text);
            komut6.Parameters.AddWithValue("@p10", textBox2.Text);
            komut6.ExecuteNonQuery();
            baglanti6.Close();
            MessageBox.Show("Kitap Sahiplenildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            görüntüle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int isaretlenen = dataGridView1.SelectedCells[0].RowIndex;

            textBox2.Text = dataGridView1.Rows[isaretlenen].Cells[0].Value.ToString();
        }
    }
}
