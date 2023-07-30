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

namespace Hastane_Yönetim_Otomasyon
{
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit1 frHK = new FrmHastaKayit1();
            frHK.Show();    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut  = new SqlCommand("Select * from Tbl_Hastalar where HastaTC=@p1 and HastaSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2",textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader ();
            if (dr.Read())
            {
                FrmHastaDetay frHD = new FrmHastaDetay();
                frHD.tc = maskedTextBox1.Text;
                frHD.Show();


            }
            else
            {
                MessageBox.Show("Hatalı Şifre Veya TC");
            }
            bgl.baglanti().Close();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void FrmHastaGiris_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
