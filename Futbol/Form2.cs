using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;  
using System.Linq;
using System.Windows.Forms;

namespace Futbol
{
    public partial class Form2 : Form
    {
        List<Takim> tumTakimlar = new List<Takim>();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            TakimlariGetir();
        }

        private void TakimlariGetir()
        {
            tumTakimlar = Veritabani.TumTakimlariGetir();

            cmbEvSahibi.Items.Clear();
            cmbDeplasman.Items.Clear();

            foreach (var takim in tumTakimlar)
            {
                cmbEvSahibi.Items.Add(takim.Isim);
                cmbDeplasman.Items.Add(takim.Isim);
            }
        }

        private void cmbEvSahibi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEvSahibi.SelectedItem == null) return;

            var secilen = tumTakimlar.FirstOrDefault(t => t.Isim == cmbEvSahibi.SelectedItem.ToString());

            if (secilen != null)
            {
                if (!string.IsNullOrEmpty(secilen.LogoYolu) && System.IO.File.Exists(secilen.LogoYolu))
                {
                    pcbEvLogo.ImageLocation = secilen.LogoYolu;
                    pcbEvLogo.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pcbEvLogo.Image = null;
                }
            }
        }

        private void cmbDeplasman_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeplasman.SelectedItem == null) return;

            var secilen = tumTakimlar.FirstOrDefault(t => t.Isim == cmbDeplasman.SelectedItem.ToString());

            if (secilen != null)
            {
                if (!string.IsNullOrEmpty(secilen.LogoYolu) && System.IO.File.Exists(secilen.LogoYolu))
                {
                    pcbDepLogo.ImageLocation = secilen.LogoYolu;
                    pcbDepLogo.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pcbDepLogo.Image = null;
                }
            }
        }

        private void btnMacaBasla_Click(object sender, EventArgs e)
        {
            if (cmbEvSahibi.SelectedItem == null || cmbDeplasman.SelectedItem == null)
            {
                MessageBox.Show("Lütfen her iki takımı da seçin!");
                return;
            }

            var ev = tumTakimlar.First(t => t.Isim == cmbEvSahibi.SelectedItem.ToString());
            var dep = tumTakimlar.First(t => t.Isim == cmbDeplasman.SelectedItem.ToString());

            if (ev.TakimID == dep.TakimID)
            {
                MessageBox.Show("Bir takım kendisiyle maç yapamaz!");
                return;
            }

            Form1 macEkrani = new Form1(ev.TakimID, ev.Isim, ev.Renk1, dep.TakimID, dep.Isim, dep.Renk1);
            macEkrani.Show();
            this.Hide();
        }

        private void pcbEvLogo_Click(object sender, EventArgs e)
        {

        }
    }
}