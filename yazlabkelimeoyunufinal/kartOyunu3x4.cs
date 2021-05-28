using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace yazlabkelimeoyunufinal
{
    public partial class kartOyunu3x4 : Form
    {
        int dakika = 2, saniye = 60,puan=0;
        Image[] resim =
        {
            Properties.Resources.saksıbitki,
            Properties.Resources.saksiaycicegi,
            Properties.Resources.saksicicek,
            Properties.Resources.palmiye,
            Properties.Resources.kaktüs,
            Properties.Resources.portakalsaksi,
        };
        int[] indeks =
        {
            0,0,1,1,2,2,3,3,4,4,5,5
        };
        PictureBox ilkKutu;
        int ilkIndeksNo;
        int bulunan = 0;
        public kartOyunu3x4()
        {
            InitializeComponent();
        }
        private void resimKaristir()
        {
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int random = r.Next(10);
                int gecici = indeks[i];
                indeks[i] = indeks[random];
                indeks[random] = gecici;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string sesDizini = Application.StartupPath + "\\basarili.wav";
            ses.SoundLocation = sesDizini;
            SoundPlayer ses2 = new SoundPlayer();
            string sesDizini2 = Application.StartupPath + "\\basarisiz.wav";
            ses2.SoundLocation = sesDizini2;
            PictureBox picBox = (PictureBox)sender;
            int picBoxNo = int.Parse(picBox.Name.Substring(10));
            int indeksNo = indeks[picBoxNo - 1];
            picBox.Image = resim[indeksNo];
            picBox.Refresh();
            if (ilkKutu == null)
            {
                ilkKutu = picBox;
                ilkIndeksNo = indeksNo;
            }
            else
            {
                System.Threading.Thread.Sleep(500);
                ilkKutu.Image = null;
                picBox.Image = null;
                if (ilkIndeksNo == indeksNo)
                {
                    ses.Play();
                    bulunan++;
                    label2.Text = bulunan.ToString();
                    label3.Text = "Bir çift buldun";
                    puan = puan + 10;
                    label2.Text = puan.ToString();
                    ilkKutu.Visible = false;
                    picBox.Visible = false;
                    if (bulunan == 6)
                    {
                        timer1.Stop();
                        MessageBox.Show("Tebrikler bütün hepsini buldunuz.Puanınız:" + puan);
                        label2.Text = "0";
                        puan = 0;
                        bulunan = 0;
                        foreach (Control kontrol in Controls)
                        {
                            kontrol.Visible = true;
                        }
                        resimKaristir();

                    }
                }
                else
                {
                    puan = puan - 5;
                    label2.Text = puan.ToString();
                    label3.Text = "Bir çift bulamadın";
                    ses2.Play();
                }
                ilkKutu = null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            saniye = saniye - 1;
            lblSaniye.Text = saniye.ToString();
            lblDakika.Text = dakika.ToString();
            if (saniye == 0)
            {
                dakika = dakika - 1;
                lblDakika.Text = dakika.ToString();
                saniye = 60;
            }
            if (lblDakika.Text == "-1")
            {
                timer1.Stop();
                lblDakika.Text = "00";
                lblSaniye.Text = "00";
                MessageBox.Show("Süreniz bitti!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            kartOyunuGiris k1 = new kartOyunuGiris();
            k1.Show();
        }

        private void kartOyunu3x4_Load(object sender, EventArgs e)
        {
            resimKaristir();
            timer1.Start();
        }
    }
}
