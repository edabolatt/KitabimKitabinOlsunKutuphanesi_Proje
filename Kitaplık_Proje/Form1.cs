using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitaplık_Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Yönetici_Girişi yönetici_Girişi = new Yönetici_Girişi();
            yönetici_Girişi.Show();

            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Üye_Girişi üye_Girişi = new Üye_Girişi();
            üye_Girişi.Show();

            this.Hide();

        }
    }
}
