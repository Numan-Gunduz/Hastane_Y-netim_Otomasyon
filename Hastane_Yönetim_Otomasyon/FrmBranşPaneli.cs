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
    public partial class FrmBranşPaneli : Form
    {
        public FrmBranşPaneli()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        private void FrmBranşPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Branslar (BransAd) values(@b1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@b1",textBox2.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text=dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text=dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Branslar where Bransid=@b1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@b1", textBox1.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("Branş Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komutgüncelle = new SqlCommand("update Tbl_Branslar set BransAd=@p1 where Bransid=@p2",bgl.baglanti());
            komutgüncelle.Parameters.AddWithValue("@p1",textBox2.Text);
            komutgüncelle.Parameters.AddWithValue("@p2",textBox1.Text);
            komutgüncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}
