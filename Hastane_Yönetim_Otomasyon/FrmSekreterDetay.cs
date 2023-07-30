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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        public String TCnumara;
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            label2.Text = TCnumara;

            //AD SOYAD ÇEKME
            SqlCommand komut1 = new SqlCommand("Select SekreterAdSoyad from Tbl_Sekreter where SekreterTC=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1",label2.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                label4.Text=dr1[0].ToString();
            }
            bgl.baglanti().Close();

            //Branşları Datagride aktarma 
              DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select BransAd from Tbl_Branslar",bgl.baglanti());
            da.Fill(dt1);
            dataGridView3.DataSource = dt1;
            //Doktorları DataGriede Aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd +' '+DoktorSoyad)as'Doktorlar',DoktorBrans  from Tbl_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView4.DataSource = dt2;
            //Branşı Comboboxa Aktarma
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2[0]);

            }
            bgl.baglanti().Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor)values (@r1,@r2,@r3,@r4)",bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@r1", maskedTextBox1.Text);
            komutkaydet.Parameters.AddWithValue("@r2",maskedTextBox2.Text);
            komutkaydet.Parameters.AddWithValue("@r3",comboBox1.Text);
            komutkaydet.Parameters.AddWithValue("@r4",comboBox2.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Başarıyla Oluşturuldu");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)

        {
            comboBox2.Items.Clear();
            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr = komut3.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0]+" "+ dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue ("@d1",richTextBox1.Text); ;
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli dp = new FrmDoktorPaneli();
            dp.Show();
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBranşPaneli bp = new FrmBranşPaneli();
            bp.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi rl = new FrmRandevuListesi();
            rl.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FrmDuyurular frd = new FrmDuyurular();
            frd.Show();
        }
    }
}

