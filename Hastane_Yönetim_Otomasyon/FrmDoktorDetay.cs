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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        public String TC;
        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            label2.Text = TC;
            //Doktor ADSoyad
            SqlCommand komut = new SqlCommand("Select  DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",label2.Text);
            SqlDataReader dr = komut.ExecuteReader ();
            while (dr.Read())
            {
                label4.Text = dr [0]+" "+dr[1];
            }
            bgl.baglanti().Close();
            //Randevular
           DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where RandevuDoktor='"+label4.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            


           

 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDüzenle fdd = new FrmDoktorBilgiDüzenle();
            fdd.TCno = TC;
            fdd.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDuyurular frd = new FrmDuyurular();
            frd.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richTextBox1.Text = dataGridView1.Rows [secilen].Cells[7].Value.ToString();
        }
    }
}
