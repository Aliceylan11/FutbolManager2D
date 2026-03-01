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
        private int hedefTopX = 200;
        private int hedefTopY = 125;
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
            this.BackgroundImage = Properties.Resources.StadyumArkaplan;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            macTimer.Interval = 1500;
            TakimlariKur();
            if (evSahibi != null && !string.IsNullOrEmpty(evSahibi.LogoYolu) && System.IO.File.Exists(evSahibi.LogoYolu))
            {
                pcbEvLogo2.ImageLocation = evSahibi.LogoYolu;
                pcbEvLogo2.SizeMode = PictureBoxSizeMode.Zoom;
            }

            if (deplasman != null && !string.IsNullOrEmpty(deplasman.LogoYolu) && System.IO.File.Exists(deplasman.LogoYolu))
            {
                pcbDepLogo2.ImageLocation = deplasman.LogoYolu;
                pcbDepLogo2.SizeMode = PictureBoxSizeMode.Zoom;
            }
            TaktikselDizilisiAyarla();
            ArayuzuGuncelle();

            lstSpiker.Items.Add("MAÇ BAŞLIYOR! İki takıma da başarılar...");
            lstSpiker.Items.Add($"{_evAd} ve {_depAd} sahaya çıkıyor!");
            lstSpiker.Items.Add("--------------------------------------------------");

            // YENİ: EKRAN TİTREMESİNİ (FLICKERING) ÖNLEYEN SİHİRLİ KOD (Double Buffering)
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, pnlRadar, new object[] { true });

            // Animasyon Timer'ımız
            System.Windows.Forms.Timer animTimer = new System.Windows.Forms.Timer();
            animTimer.Interval = 33; // Yaklaşık 30 FPS
            animTimer.Tick += AnimTimer_Tick;
            animTimer.Start();
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

            // 1. PANELİ YENİDEN BOYUTLANDIR VE ORTALA
            pnlGolEfekti.Size = new Size(255, 140); // Paneli yazının sığması için biraz genişletiyoruz
                                                    // Paneli ekranın (veya sahanın) tam ortasına hizalama
            pnlGolEfekti.Location = new Point((this.ClientSize.Width - pnlGolEfekti.Width) / 2, (this.ClientSize.Height - pnlGolEfekti.Height) / 2);

            pnlGolEfekti.Visible = true;
            pnlGolEfekti.BringToFront();

            // 2. LOGO VE YAZIYI DÜZENLE (Logo solda, Yazı sağda)
            picGolLogo.Size = new Size(80, 80);
            picGolLogo.Location = new Point(10, 15);
            picGolLogo.BackColor = Color.Transparent;

            lblGolMesaji.Location = new Point(100, 20);
            lblGolMesaji.BackColor = Color.Transparent;
            lblGolMesaji.ForeColor = Color.White; // Yazının net okunması için beyaz yapıyoruz
            lblGolMesaji.AutoSize = true;

            // 3. TAKIM RENKLERİ VE METİNLER
            if (evSahibiMi)
            {
                pnlGolEfekti.BackColor = Color.FromName(_evRenk);
                if (evSahibiGol > deplasmanGol)
                    lblGolMesaji.Text = $"GOOOOOL! \n{_evAd} \nÖNE GEÇTİ!";
                else if (evSahibiGol == deplasmanGol)
                    lblGolMesaji.Text = $"GOOOOOL! \n{_evAd} \nBeraberlik Sağlandı!";
                else
                    lblGolMesaji.Text = $"GOOOOOL! \n{_evAd} \nFarkı Azalttı!";

                if (System.IO.File.Exists(evSahibi.LogoYolu))
                    picGolLogo.ImageLocation = evSahibi.LogoYolu;
            }
            else
            {
                pnlGolEfekti.BackColor = Color.FromName(_depRenk);
                if (deplasmanGol > evSahibiGol)
                    lblGolMesaji.Text = $"GOOOOOL! \n{_depAd} \nÖNE GEÇTİ!";
                else if (deplasmanGol == evSahibiGol)
                    lblGolMesaji.Text = $"GOOOOOL! \n{_depAd} \nEŞİTLİĞİ SAĞLADI!";
                else
                    lblGolMesaji.Text = $"GOOOOOL! \n{_depAd} \nFARKI AZALTTI!";

                if (System.IO.File.Exists(deplasman.LogoYolu))
                    picGolLogo.ImageLocation = deplasman.LogoYolu;
            }

            picGolLogo.SizeMode = PictureBoxSizeMode.Zoom;

            // 4. OTOMATİK KAPANMA SİSTEMİ
            golEfektTimer.Interval = 2000; // 2 saniye ekranda kalır
            golEfektTimer.Tick -= golEfektTimer_Tick; // Çift tetiklemeyi önlemek için sil
            golEfektTimer.Tick += golEfektTimer_Tick; // Ve yeniden bağla

            golEfektTimer.Start();
        }
        private void golEfektTimer_Tick(object sender, EventArgs e)
        {
            golEfektTimer.Stop();
            pnlGolEfekti.Visible = false;

            // Motoru başlat ve arayüzdeki butonun yazısını otomatik düzelt
            btnOyna.Text = "Maçı Duraklat";
            macTimer.Start();

            // YENİ: O 1.5 saniyelik boşluğu beklemeden MAÇI ANINDA SANTRA İLE BAŞLAT!
            macTimer_Tick(null, EventArgs.Empty);
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

        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            // 1. Sarı Topun Kayarak İlerlemesi
            int topHiz = 7;
            if (topX < hedefTopX) topX += Math.Min(topHiz, hedefTopX - topX);
            else if (topX > hedefTopX) topX -= Math.Min(topHiz, topX - hedefTopX);

            if (topY < hedefTopY) topY += Math.Min(topHiz, hedefTopY - topY);
            else if (topY > hedefTopY) topY -= Math.Min(topHiz, topY - hedefTopY);

            // 2. Oyuncuların Kayarak İlerlemesi
            var tumOyuncular = new List<Futbolcu> { evSahibi.Kaleci, evSahibi.SolBek, evSahibi.SolStoper, evSahibi.SagStoper, evSahibi.SagBek, evSahibi.DOS, evSahibi.MOS, evSahibi.OOS, evSahibi.SolKanat, evSahibi.SagKanat, evSahibi.Santrafor, deplasman.Kaleci, deplasman.SolBek, deplasman.SolStoper, deplasman.SagStoper, deplasman.SagBek, deplasman.DOS, deplasman.MOS, deplasman.OOS, deplasman.SolKanat, deplasman.SagKanat, deplasman.Santrafor };

            foreach (var o in tumOyuncular)
            {
                if (o != null) o.HedefeYuru(); // abstract sınıftaki yürüme metodu
            }

            pnlRadar.Invalidate(); // Radarı saniyede 30 kez güncelliyoruz
        }
        private void HedefleriBelirle()
        {
            int w = pnlRadar.Width;
            int h = pnlRadar.Height;
            Random rnd = new Random();

            // 1. TOPUN HEDEFİNİ BELİRLE (Y ekseni eklendi!)
            switch (topunYeri)
            {
                case SahaBolgesi.KendiCezaSahasi:
                    hedefTopX = topEvSahibindeMi ? (int)(w * 0.15) : (int)(w * 0.85);
                    hedefTopY = (h / 2) + rnd.Next(-30, 30);
                    break;
                case SahaBolgesi.KendiYariSahamiz:
                    hedefTopX = topEvSahibindeMi ? (int)(w * 0.30) : (int)(w * 0.70);
                    hedefTopY = (h / 2) + rnd.Next(-60, 60);
                    break;
                case SahaBolgesi.OrtaAlanMerkez:
                    hedefTopX = w / 2;
                    hedefTopY = (h / 2) + rnd.Next(-60, 60);
                    break;
                case SahaBolgesi.RakipYariSaha:
                    hedefTopX = topEvSahibindeMi ? (int)(w * 0.70) : (int)(w * 0.30);
                    hedefTopY = (h / 2) + rnd.Next(-60, 60);
                    break;
                case SahaBolgesi.RakipCezaSahasi:
                case SahaBolgesi.SerbestVurus:
                    hedefTopX = topEvSahibindeMi ? (int)(w * 0.85) : (int)(w * 0.15);
                    hedefTopY = (h / 2) + rnd.Next(-30, 30);
                    break;
                case SahaBolgesi.Korner:
                    hedefTopX = topEvSahibindeMi ? (int)(w * 0.95) : (int)(w * 0.05);
                    hedefTopY = rnd.Next(0, 2) == 0 ? 10 : h - 10; // En üst veya en alt köşe
                    break;
                case SahaBolgesi.Tac:
                    hedefTopX = topEvSahibindeMi ? (int)(w * 0.55) : (int)(w * 0.45);
                    hedefTopY = rnd.Next(0, 2) == 0 ? 10 : h - 10; // En üst veya en alt taç çizgisi
                    break;
            }

            // 2. HER OYUNCU İÇİN BAĞIMSIZ HEDEF BELİRLE (Y ekseninde kayma eklendi!)
            var tumOyuncular = new List<Futbolcu> { evSahibi.Kaleci, evSahibi.SolBek, evSahibi.SolStoper, evSahibi.SagStoper, evSahibi.SagBek, evSahibi.DOS, evSahibi.MOS, evSahibi.OOS, evSahibi.SolKanat, evSahibi.SagKanat, evSahibi.Santrafor, deplasman.Kaleci, deplasman.SolBek, deplasman.SolStoper, deplasman.SagStoper, deplasman.SagBek, deplasman.DOS, deplasman.MOS, deplasman.OOS, deplasman.SolKanat, deplasman.SagKanat, deplasman.Santrafor };

            foreach (var o in tumOyuncular)
            {
                if (o == null) continue;
                bool benimTakimimHucumda = (evSahibi.KadroIceriyorMu(o) && topEvSahibindeMi) || (deplasman.KadroIceriyorMu(o) && !topEvSahibindeMi);

                // OYUNCULARIN TOPA DOĞRU YUKARI/AŞAĞI YÖNELMESİ (TAKTİĞİ BOZMADAN)
                int yKayma = (hedefTopY - o.BaseY) / 4;
                if (topunYeri == SahaBolgesi.Korner)
                {
                    if (o is Kaleci)
                    {
                        o.HedefX = o.BaseX;
                        o.HedefY = o.BaseY;
                        continue;
                    }

                    int rakipCezaSahasiX = topEvSahibindeMi ? (int)(w * 0.85) : (int)(w * 0.15);
                    int cezaSahasiYayiX = topEvSahibindeMi ? (int)(w * 0.70) : (int)(w * 0.30); // Dışarısı
                    int ortaYusYuvarlak = w / 2;

                    if (benimTakimimHucumda) // KORNERİ KULLANAN TAKIM
                    {
                        if (o == evSahibi.OOS || o == deplasman.OOS)
                        {
                            // 1. OOS topun başına (korner direğine) gider
                            o.HedefX = hedefTopX;
                            o.HedefY = hedefTopY;
                        }
                        else if (o == evSahibi.SolBek || o == deplasman.SolBek || o == evSahibi.SagBek || o == deplasman.SagBek)
                        {
                            // 2. İki Bek oyuncusu orta sahada kontratağı kesmek için kalır
                            o.HedefX = ortaYusYuvarlak;
                            o.HedefY = (o == evSahibi.SolBek || o == deplasman.SolBek) ? (h / 3) : (h * 2 / 3);
                        }
                        else if (o == evSahibi.DOS || o == deplasman.DOS)
                        {
                            // 3. DOS ceza sahası yayında (dışarıda) seken topu bekler
                            o.HedefX = cezaSahasiYayiX;
                            o.HedefY = h / 2;
                        }
                        else
                        {
                            // 4. Stoperler, Santrafor vs. hepsi ceza sahasına kafa vurmaya yığılır
                            o.HedefX = rakipCezaSahasiX + rnd.Next(-10, 11);
                            o.HedefY = (h / 2) + rnd.Next(-50, 51);
                        }
                    }
                    else // KORNERİ SAVUNAN TAKIM
                    {
                        if (o == evSahibi.Santrafor || o == deplasman.Santrafor || o == evSahibi.OOS || o == deplasman.OOS)
                        {
                            // 1. Santrafor ve OOS ceza sahası dışında hızlı hücum (kontra) için bekler
                            o.HedefX = cezaSahasiYayiX;
                            o.HedefY = (o == evSahibi.Santrafor || o == deplasman.Santrafor) ? (h / 3) : (h * 2 / 3);
                        }
                        else
                        {
                            // 2. Geri kalan tüm takım ceza sahasına doluşur ve etten duvar örer
                            o.HedefX = rakipCezaSahasiX + rnd.Next(-15, 16);
                            o.HedefY = (h / 2) + rnd.Next(-50, 51);
                        }
                    }
                    continue; // Korner dizilişi bitti, aşağıdaki normal oyun akışı kodlarına geçme!
                }
                if (o is Kaleci)
                {
                    o.HedefX = o.BaseX;
                    o.HedefY = o.BaseY + (yKayma / 2); // Kaleci kalede kalır, topa göre çok hafif yanlara adım atar
                }
                else if (o is Defans)
                {
                    int itme = benimTakimimHucumda ? 60 : -20;
                    int yon = evSahibi.KadroIceriyorMu(o) ? 1 : -1;

                    // YENİ ZEKİ HAMLE: TAÇ ATIŞI KONTROLÜ
                    if (topunYeri == SahaBolgesi.Tac && benimTakimimHucumda)
                    {
                        // Eğer oyuncunun orijinal yeri (BaseY) topun olduğu taç çizgisine yakınsa (Yani o kanadın beki ise)
                        if (Math.Abs(hedefTopY - o.BaseY) < 150)
                        {
                            o.HedefX = hedefTopX; // Topun X'ine git
                            o.HedefY = hedefTopY; // Topun Y'sine git (Çizgiye in)
                            continue; // Aşağıdaki normal defans kayması kodunu atla
                        }
                    }

                    // Taç değilse normal defans kaymasını yap
                    o.HedefX = o.BaseX + (itme * yon);
                    o.HedefY = o.BaseY + yKayma;
                }
                else if (o is OrtaSaha)
                {
                    int itme = benimTakimimHucumda ? 100 : -40;
                    int yon = evSahibi.KadroIceriyorMu(o) ? 1 : -1;
                    o.HedefX = o.BaseX + (itme * yon);
                    o.HedefY = o.BaseY + (yKayma * 2); // Orta saha topa daha agresif pres yapar (yKayma çarpı 2)
                }
                else if (o is Forvet)
                {
                    int itme = benimTakimimHucumda ? 150 : 0;
                    int yon = evSahibi.KadroIceriyorMu(o) ? 1 : -1;
                    o.HedefX = o.BaseX + (itme * yon);

                    if (((Forvet)o).Rol == HucumTipi.Santrafor)
                    {
                        o.HedefY = (hedefTopY + o.BaseY) / 2; // Santrafor topun tam hizasına girmeye çalışır
                    }
                    else
                    {
                        o.HedefY = o.BaseY + yKayma; // Kanatlar da içe veya dışa kat eder
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblEvSahibiAd_Click(object sender, EventArgs e)
        {

        }

        private void pcbDepLogo2_Click(object sender, EventArgs e)
        {

        }

        private void pnlGolEfekti_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}