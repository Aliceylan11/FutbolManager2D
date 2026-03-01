using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
namespace Futbol
{ 
    public enum SahaBolgesi { KendiCezaSahasi, KendiYariSahamiz, OrtaAlanMerkez, RakipYariSaha, RakipCezaSahasi, Korner, SerbestVurus, Tac }
    public enum DefansTipi { SolStoper, SagStoper, SolBek, SagBek }
    public enum OrtaSahaTipi { Defansif, Merkez, Ofansif }
    public enum HucumTipi { Santrafor, SagKanat, SolKanat }

    public partial class Form1 : Form
    { 
        Takim evSahibi;
        Takim deplasman;

        List<string> evGoller = new List<string>();
        List<string> depGoller = new List<string>();

        int evSahibiGol = 0, deplasmanGol = 0;
        int dakika = 1, bitisDakikasi = 90;
         
        bool topEvSahibindeMi = true;

        bool uzatmaVerildiMi = false, macBittiMi = false;
        bool ilkYariBittiMi = false, ilkYariUzatmaVerildiMi = false;
        int ilkYariBitis = 45;

        private int _evId, _depId;
        private string _evAd, _depAd;
        private string _evRenk, _depRenk;

        SahaBolgesi topunYeri = SahaBolgesi.OrtaAlanMerkez;
        int evToplamPas = 0, evIsabetliPas = 0, evToplamSut = 0, evIsabetliSut = 0;
        int depToplamPas = 0, depIsabetliPas = 0, depToplamSut = 0, depIsabetliSut = 0;

        private int topX = 200;
        private int topY = 125;
         
        public Form1(int evId, string evAd, string evRenk, int depId, string depAd, string depRenk)
        {
            InitializeComponent();
            this._evId = evId;
            this._evAd = evAd;
            this._evRenk = evRenk;
            this._depId = depId;
            this._depAd = depAd;
            this._depRenk = depRenk;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            macTimer.Interval = 1500;
            TakimlariKur();
            TaktikselDizilisiAyarla();
            ArayuzuGuncelle();  

            lstSpiker.Items.Add("DEV DERBİ BAŞLIYOR! İki takıma da başarılar...");
            lstSpiker.Items.Add($"{_evAd} ve {_depAd} sahaya çıkıyor!");
            lstSpiker.Items.Add("--------------------------------------------------");
        }

        private void TakimlariKur()
        {
            evSahibi = Veritabani.TakimCek(_evId, _evAd);
            deplasman = Veritabani.TakimCek(_depId, _depAd);
        }
        private void pnlRadar_Paint(object sender, PaintEventArgs e)
        { 
            SahaCizici.SahayiVeOyunculariCiz(
                e.Graphics,
                pnlRadar.Width, pnlRadar.Height,
                evSahibi, deplasman,
                Color.FromName(_evRenk), Color.FromName(_depRenk),
                topX, topY
            );
        }

       

        private void btnOyna_Click(object sender, EventArgs e)
        {
            if (macTimer.Enabled)
            {
                macTimer.Stop();
                btnOyna.Text = "Maça Devam Et";
            }
            else
            {
                macTimer.Start();
                btnOyna.Text = "Maçı Duraklat";
            }
        }

        private void btnHamle_Click(object sender, EventArgs e)
        {
            if (!macTimer.Enabled && !macBittiMi)
            {
                macTimer_Tick(sender, e);
            }
        }

        private void btnAsistan_Click(object sender, EventArgs e)
        {
            if (macTimer.Enabled)
            {
                MessageBox.Show("Değişiklik yapmak için önce maçı duraklatmalısınız!",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AsistanDegisiklikYap(evSahibi);
            AsistanDegisiklikYap(deplasman);
            ArayuzuGuncelle();
            lstSpiker.TopIndex = lstSpiker.Items.Count - 1;
        }

        private void GolEfektiGoster(bool evSahibiMi)
        { 
            macTimer.Stop();

            pnlGolEfekti.Visible = true;
            pnlGolEfekti.BringToFront(); 

            if (evSahibiMi)
            {
                pnlGolEfekti.BackColor = Color.FromName(_evRenk);
                if(evSahibiGol>deplasmanGol)
                    lblGolMesaji.Text = $"GOOOOOL! \n{_evAd} \nÖNE GEÇTİ!";
                else if(evSahibiGol==deplasmanGol)
                    lblGolMesaji.Text = $"GOOOOOL! \n{_evAd} \nEŞİTİĞİ SAĞLADI!";
                else
                    lblGolMesaji.Text = $"GOOOOOL! \n{_evAd} \nFARKI AZALTTI!";
                if (System.IO.File.Exists(evSahibi.LogoYolu))
                    picGolLogo.ImageLocation = evSahibi.LogoYolu;
            }
            else
            {
                pnlGolEfekti.BackColor = Color.FromName(_depRenk);
                if(deplasmanGol>evSahibiGol)
                    lblGolMesaji.Text = $"GOOOOOL! \n{_depAd} \nÖNE GEÇTİ!";
                else if(deplasmanGol==evSahibiGol)
                    lblGolMesaji.Text = $"GOOOOOL! \n{_depAd} \nEŞİTİĞİ SAĞLADI!";
                else 
                    lblGolMesaji.Text = $"GOOOOOL! \n{_depAd} \nFARKI AZALTTI!";
                if (System.IO.File.Exists(deplasman.LogoYolu))
                    picGolLogo.ImageLocation = deplasman.LogoYolu;
            }

            picGolLogo.SizeMode = PictureBoxSizeMode.Zoom;
            golEfektTimer.Start(); 
        }
         
        private void golEfektTimer_Tick(object sender, EventArgs e)
        {
            golEfektTimer.Stop();
            pnlGolEfekti.Visible = false;
            macTimer.Start();  
        }

        private void SahayiGuncelle()
        {
            int w = pnlRadar.Width;
            int h = pnlRadar.Height;

            // 1. TOPUN YERİNİ BELİRLE (Spikerin anlattığı bölgeye göre)
            switch (topunYeri)
            {
                case SahaBolgesi.KendiCezaSahasi: topX = topEvSahibindeMi ? (int)(w * 0.15) : (int)(w * 0.85); break;
                case SahaBolgesi.KendiYariSahamiz: topX = topEvSahibindeMi ? (int)(w * 0.30) : (int)(w * 0.70); break;
                case SahaBolgesi.OrtaAlanMerkez: topX = w / 2; break;
                case SahaBolgesi.RakipYariSaha: topX = topEvSahibindeMi ? (int)(w * 0.70) : (int)(w * 0.30); break;
                case SahaBolgesi.RakipCezaSahasi: topX = topEvSahibindeMi ? (int)(w * 0.85) : (int)(w * 0.15); break;
            }
            topY = (h / 2) + new Random().Next(-40, 40); // Top biraz seker

            // 2. HER OYUNCU İÇİN BAĞIMSIZ HEDEF BELİRLE
            var tumOyuncular = new List<Futbolcu> {
        evSahibi.Kaleci, evSahibi.SolBek, evSahibi.SolStoper, evSahibi.SagStoper, evSahibi.SagBek, evSahibi.DOS, evSahibi.MOS, evSahibi.OOS, evSahibi.SolKanat, evSahibi.SagKanat, evSahibi.Santrafor,
        deplasman.Kaleci, deplasman.SolBek, deplasman.SolStoper, deplasman.SagStoper, deplasman.SagBek, deplasman.DOS, deplasman.MOS, deplasman.OOS, deplasman.SolKanat, deplasman.SagKanat, deplasman.Santrafor
    };

            foreach (var o in tumOyuncular)
            {
                if (o == null) continue;
                 
                bool benimTakimimHucumda = (evSahibi.KadroIceriyorMu(o) && topEvSahibindeMi) || (deplasman.KadroIceriyorMu(o) && !topEvSahibindeMi);

                // MEVKİSEL YZ KARARLARI
                if (o is Kaleci)
                {
                    // Kaleci evinde durur, çok az öne çıkar
                    o.HedefX = o.BaseX;
                    o.HedefY = o.BaseY;
                }
                else if (o is Defans)
                {
                    // Bekler çizgiden ileri koşar, Stoperler merkezde kalır ama biraz öne çıkar
                    int itme = benimTakimimHucumda ? 60 : -20; // Ataktayken 60 birim öne çık
                    int yon = evSahibi.KadroIceriyorMu(o) ? 1 : -1;
                    o.HedefX = o.BaseX + (itme * yon);
                    o.HedefY = o.BaseY; // Defans sağa sola çok sapmaz
                }
                else if (o is OrtaSaha)
                {
                    // Orta sahalar topu takip eder! (Top neredeyse o tarafa yaklaşırlar)
                    int itme = benimTakimimHucumda ? 100 : -40;
                    int yon = evSahibi.KadroIceriyorMu(o) ? 1 : -1;
                    o.HedefX = o.BaseX + (itme * yon);

                    // Topun Y eksenine (aşağı/yukarı) doğru biraz kayarlar (Topa pres)
                    o.HedefY = o.BaseY + ((topY - o.BaseY) / 3);
                }
                else if (o is Forvet)
                {
                    // Forvetler gol arar, top rakip ceza sahasındaysa direkt ceza sahasına koşarlar
                    int itme = benimTakimimHucumda ? 150 : 0;
                    int yon = evSahibi.KadroIceriyorMu(o) ? 1 : -1;

                    // Eğer kanat oyuncusuysa (SolKanat/SagKanat) Y ekseninde kendi çizgisinde kalır
                    // Santrafor ise topun olduğu yere (X ve Y) koşturur.
                    if (((Forvet)o).Rol == HucumTipi.Santrafor)
                    {
                        o.HedefX = o.BaseX + (itme * yon);
                        o.HedefY = (topY + o.BaseY) / 2; // Topun hizasına girer
                    }
                    else
                    {
                        // Kanat oyuncusu çizgisinden yardırır
                        o.HedefX = o.BaseX + (itme * yon);
                        o.HedefY = o.BaseY;
                    }
                }

                // 3. HEDEFE DOĞRU YÜRÜ (Animasyon Kısmı)
                o.HedefeYuru();
            }

            pnlRadar.Invalidate();
        }
        private void TaktikselDizilisiAyarla()
        {
            int w = pnlRadar.Width;
            int h = pnlRadar.Height;
            Random rnd = new Random();

            // Kodu kısaltmak ve temiz tutmak için yerel bir yardımcı metot yazıyoruz
            void Konumla(Futbolcu f, double oranX, double oranY)
            {
                if (f == null) return;

                // 1. Asıl taktiksel yuvası (Oyuncunun evi burası)
                f.BaseX = (int)(w * oranX);
                f.BaseY = (int)(h * oranY);

                // 2. Sahaya dizilirken biraz doğal dursun diye +- 5 piksel rastgele sapma (X ve Y için)
                f.X = f.BaseX + rnd.Next(-5, 6);
                f.Y = f.BaseY + rnd.Next(-5, 6);
            }

            // --- EV SAHİBİ (Soldan Sağa Hücum Eder) ---
            Konumla(evSahibi.Kaleci, 0.05, 0.50);

            // Defans Dörtlüsü
            Konumla(evSahibi.SolBek, 0.20, 0.15);
            Konumla(evSahibi.SolStoper, 0.15, 0.35);
            Konumla(evSahibi.SagStoper, 0.15, 0.65);
            Konumla(evSahibi.SagBek, 0.20, 0.85);

            // İkili Orta Saha (DOS ve MOS)
            Konumla(evSahibi.DOS, 0.30, 0.35);
            Konumla(evSahibi.MOS, 0.30, 0.65);

            // İleri Üçlü (Kanatlar ve OOS)
            Konumla(evSahibi.SolKanat, 0.40, 0.15);
            Konumla(evSahibi.OOS, 0.40, 0.50);
            Konumla(evSahibi.SagKanat, 0.40, 0.85);

            // Santrafor
            Konumla(evSahibi.Santrafor, 0.48, 0.50);

            // --- DEPLASMAN (Sağdan Sola Hücum Eder) ---
            Konumla(deplasman.Kaleci, 0.95, 0.50);

            // Defans Dörtlüsü
            Konumla(deplasman.SolBek, 0.80, 0.85);
            Konumla(deplasman.SolStoper, 0.85, 0.65);
            Konumla(deplasman.SagStoper, 0.85, 0.35);
            Konumla(deplasman.SagBek, 0.80, 0.15);

            // İkili Orta Saha
            Konumla(deplasman.DOS, 0.70, 0.65);
            Konumla(deplasman.MOS, 0.70, 0.35);

            // İleri Üçlü
            Konumla(deplasman.SolKanat, 0.60, 0.85);
            Konumla(deplasman.OOS, 0.60, 0.50);
            Konumla(deplasman.SagKanat, 0.60, 0.15);

            // Santrafor
            Konumla(deplasman.Santrafor, 0.52, 0.50);
        }
    }
}