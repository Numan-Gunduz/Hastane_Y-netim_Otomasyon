using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Yönetim_Otomasyon
{
    public partial class FrmGirisler : Form
    {
        public FrmGirisler()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmHastaGiris frH = new FrmHastaGiris();
            frH.Show ();
           // this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDoktorGirisPaneli frD = new FrmDoktorGirisPaneli();
            frD.Show ();
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSekreterGiriş frS=new FrmSekreterGiriş();
            frS.Show ();
           // this.Hide ();
        }
    }
}
