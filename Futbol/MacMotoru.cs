using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Futbol
{
    public partial class Form1 : Form
    { 

        private string IsmiVeKartiYaz(Futbolcu o)
        {
            if (o == null) return "";
            string ikon = "";
            if (o.KirmiziKartYediMi) ikon = " 🟥";
            else if (o.SakatMi) ikon = " 🚑";
            else if (o.SariKartVarMi) ikon = " 🟨";

            return $"{o.isim}{ikon} (%{o.Kondisyon})";
        }

        private void RadarKoordinatlariniBelirle()
        {
            Random rnd = new Random();
            int rastgeleY = rnd.Next(20, 230);

            switch (topunYeri)
            {
                case SahaBolgesi.KendiCezaSahasi:
                    topX = topEvSahibindeMi ? 40 : 360;
                    topY = 125;
                    break;
                case SahaBolgesi.KendiYariSahamiz:
                    topX = topEvSahibindeMi ? 120 : 280;
                    topY = rastgeleY;
                    break;
                case SahaBolgesi.OrtaAlanMerkez:
                    topX = 200;
                    topY = rastgeleY;
                    break;
                case SahaBolgesi.RakipYariSaha:
                    topX = topEvSahibindeMi ? 280 : 120;
                    topY = rastgeleY;
                    break;
                case SahaBolgesi.RakipCezaSahasi:
                case SahaBolgesi.Korner:
                case SahaBolgesi.SerbestVurus:
                    topX = topEvSahibindeMi ? 360 : 40;
                    topY = rnd.Next(50, 200);
                    break;
                case SahaBolgesi.Tac:
                    topX = topEvSahibindeMi ? 220 : 180;
                    topY = rnd.Next(0, 2) == 0 ? 10 : 240;
                    break;
            }
        }

        private void ArayuzuGuncelle()
        {
            if (uzatmaVerildiMi && dakika >= bitisDakikasi) return;
             
            lblEvSahibiAd.Text = _evAd;
            lblDeplasmanAd.Text = _depAd;
             
            lblEvSahibiAd.BackColor = Color.FromName(_evRenk);
            lblDeplasmanAd.BackColor = Color.FromName(_depRenk);
             
            lblEvSahibiAd.ForeColor = Color.White;
            lblDeplasmanAd.ForeColor = Color.White;

            lblSkor.Text = $"{evSahibiGol} - {deplasmanGol}";
            lblDakika.Text = $"Dk: {dakika}";

            // Ev Sahibi Kadro Listeleme
            listBox1.Items.Clear();
            listBox1.Items.Add($"{evSahibi.Isim} İLK 11");
            listBox1.Items.Add($"KL: {IsmiVeKartiYaz(evSahibi.Kaleci)}");
            listBox1.Items.Add($"SLB: {IsmiVeKartiYaz(evSahibi.SolBek)}");
            listBox1.Items.Add($"SLS: {IsmiVeKartiYaz(evSahibi.SolStoper)}");
            listBox1.Items.Add($"SGS: {IsmiVeKartiYaz(evSahibi.SagStoper)}");
            listBox1.Items.Add($"SGB: {IsmiVeKartiYaz(evSahibi.SagBek)}");
            listBox1.Items.Add($"DOS: {IsmiVeKartiYaz(evSahibi.DOS)}");
            listBox1.Items.Add($"MOS: {IsmiVeKartiYaz(evSahibi.MOS)}");
            listBox1.Items.Add($"OOS: {IsmiVeKartiYaz(evSahibi.OOS)}");
            listBox1.Items.Add($"SLK: {IsmiVeKartiYaz(evSahibi.SolKanat)}");
            listBox1.Items.Add($"SGK: {IsmiVeKartiYaz(evSahibi.SagKanat)}");
            listBox1.Items.Add($"SF: {IsmiVeKartiYaz(evSahibi.Santrafor)}");
            listBox1.Items.Add("------------------");
            foreach (var yedek in evSahibi.Yedekler) listBox1.Items.Add(IsmiVeKartiYaz(yedek));

            // Deplasman Kadro Listeleme
            listBox2.Items.Clear();
            listBox2.Items.Add($"{deplasman.Isim} İLK 11");
            listBox2.Items.Add($"KL: {IsmiVeKartiYaz(deplasman.Kaleci)}");
            listBox2.Items.Add($"SLB: {IsmiVeKartiYaz(deplasman.SolBek)}");
            listBox2.Items.Add($"SLS: {IsmiVeKartiYaz(deplasman.SolStoper)}");
            listBox2.Items.Add($"SGS: {IsmiVeKartiYaz(deplasman.SagStoper)}");
            listBox2.Items.Add($"SGB: {IsmiVeKartiYaz(deplasman.SagBek)}");
            listBox2.Items.Add($"DOS: {IsmiVeKartiYaz(deplasman.DOS)}");
            listBox2.Items.Add($"MOS: {IsmiVeKartiYaz(deplasman.MOS)}");
            listBox2.Items.Add($"OOS: {IsmiVeKartiYaz(deplasman.OOS)}");
            listBox2.Items.Add($"SLK: {IsmiVeKartiYaz(deplasman.SolKanat)}");
            listBox2.Items.Add($"SGK: {IsmiVeKartiYaz(deplasman.SagKanat)}");
            listBox2.Items.Add($"SF: {IsmiVeKartiYaz(deplasman.Santrafor)}");
            listBox2.Items.Add("------------------");
            foreach (var yedek in deplasman.Yedekler) listBox2.Items.Add(IsmiVeKartiYaz(yedek));

            RadarKoordinatlariniBelirle();
            pnlRadar.Invalidate();
        }
 
        private void AsistanDegisiklikYap(Takim t)
        {
            if (t.DegisiklikHakki <= 0) return;
            var ilk11 = new Futbolcu[] { t.Kaleci, t.SolBek, t.SolStoper, t.SagStoper, t.SagBek, t.DOS, t.MOS, t.OOS, t.SolKanat, t.SagKanat, t.Santrafor };
            Futbolcu degisecekOyuncu = null;

            foreach (var oyuncu in ilk11)
            {
                if (oyuncu != null && (oyuncu.SakatMi || oyuncu.Kondisyon < 75) && !oyuncu.KirmiziKartYediMi)
                {
                    degisecekOyuncu = oyuncu;
                    break;
                }
            }
            if (degisecekOyuncu == null) return;

            Futbolcu girenOyuncu = null;
            foreach (var yedek in t.Yedekler)
            {
                if (yedek.GetType() == degisecekOyuncu.GetType() && !yedek.KirmiziKartYediMi && !yedek.SakatMi)
                {
                    girenOyuncu = yedek;
                    break;
                }
            }

            if (girenOyuncu != null)
            {
                if (degisecekOyuncu == t.Kaleci) t.Kaleci = (Kaleci)girenOyuncu;
                else if (degisecekOyuncu == t.SolBek) t.SolBek = (Defans)girenOyuncu;
                else if (degisecekOyuncu == t.SolStoper) t.SolStoper = (Defans)girenOyuncu;
                else if (degisecekOyuncu == t.SagStoper) t.SagStoper = (Defans)girenOyuncu;
                else if (degisecekOyuncu == t.SagBek) t.SagBek = (Defans)girenOyuncu;
                else if (degisecekOyuncu == t.DOS) t.DOS = (OrtaSaha)girenOyuncu;
                else if (degisecekOyuncu == t.MOS) t.MOS = (OrtaSaha)girenOyuncu;
                else if (degisecekOyuncu == t.OOS) t.OOS = (OrtaSaha)girenOyuncu;
                else if (degisecekOyuncu == t.SolKanat) t.SolKanat = (Forvet)girenOyuncu;
                else if (degisecekOyuncu == t.SagKanat) t.SagKanat = (Forvet)girenOyuncu;
                else if (degisecekOyuncu == t.Santrafor) t.Santrafor = (Forvet)girenOyuncu;

                t.DegisiklikHakki--;
                t.Yedekler.Remove(girenOyuncu);
                lstSpiker.Items.Add($"🔄 {t.Isim} DEĞİŞİKLİK: 🔻{degisecekOyuncu.isim} ({(degisecekOyuncu.SakatMi ? "Sakatlandı" : "Yoruldu")}) 🔺{girenOyuncu.isim}");
            }
        }

        private void PasEkle(bool isabetli) { if (topEvSahibindeMi) { evToplamPas++; if (isabetli) evIsabetliPas++; } else { depToplamPas++; if (isabetli) depIsabetliPas++; } }
        private void SutEkle(bool isabetli) { if (topEvSahibindeMi) { evToplamSut++; if (isabetli) evIsabetliSut++; } else { depToplamSut++; if (isabetli) depIsabetliSut++; } }

        private void SakatlikKontrolu(Futbolcu faulYapilanAdam, Takim takimi)
        {
            if (new Random().Next(0, 100) < 20)
            {
                faulYapilanAdam.SakatMi = true;
                lstSpiker.Items.Add($"🚑 EYVAH! {faulYapilanAdam.isim} yerde kaldı ve acı içinde kıvranıyor!");
                if (takimi.DegisiklikHakki > 0)
                {
                    lstSpiker.Items.Add($"Sağlık görevlileri kenara 'değişiklik' işareti yapıyor...");
                    AsistanDegisiklikYap(takimi);
                }
                else
                {
                    lstSpiker.Items.Add($"❌ {takimi.Isim} takımının değişiklik hakkı kalmadı! {faulYapilanAdam.isim} sekerek oyuna devam edecek!");
                    faulYapilanAdam.Kondisyon -= 30;
                }
            }
        }

        private void KartIstatistikHesapla(Takim t, out List<string> sarilar, out List<string> kirmizilar)
        {
            sarilar = new List<string>();
            kirmizilar = new List<string>();
            var kadro = new List<Futbolcu>() { t.Kaleci, t.SolBek, t.SolStoper, t.SagStoper, t.SagBek, t.DOS, t.MOS, t.OOS, t.SolKanat, t.SagKanat, t.Santrafor };
            if (t.Yedekler != null) kadro.AddRange(t.Yedekler);
            foreach (var o in kadro) { if (o == null) continue; if (o.KirmiziKartYediMi) kirmizilar.Add(o.isim); else if (o.SariKartVarMi) sarilar.Add(o.isim); }
        } 
        private void GolOldu(string goluAtanIsim)
        {
            if (topEvSahibindeMi)
            {
                evSahibiGol++;
                evGoller.Add($"{goluAtanIsim} ({dakika}')");
                GolEfektiGoster(true);  
            }
            else
            {
                deplasmanGol++;
                depGoller.Add($"{goluAtanIsim} ({dakika}')");
                GolEfektiGoster(false);  
            }
             
            topEvSahibindeMi = !topEvSahibindeMi;
            topunYeri = SahaBolgesi.KendiCezaSahasi;
        }

        private void macTimer_Tick(object sender, EventArgs e)
        {
            if (macBittiMi) return;

            if (dakika >= 45 && !ilkYariBittiMi)
            {
                if (!ilkYariUzatmaVerildiMi) { ilkYariBitis = 45 + new Random().Next(1, 4); ilkYariUzatmaVerildiMi = true; lstSpiker.Items.Add($"=== İLK YARI SONUNA EN AZ +{ilkYariBitis - 45} DAKİKA İLAVE EDİLDİ ==="); }
                if (dakika >= ilkYariBitis)
                {
                    macTimer.Stop(); ilkYariBittiMi = true;
                    lstSpiker.Items.Add("==================================================");
                    lstSpiker.Items.Add($"HAKEM İLK YARIYI BİTİREN DÜDÜĞÜ ÇALDI! (Skor: {evSahibiGol} - {deplasmanGol})");
                    lstSpiker.Items.Add("👉 İkinci yarıya başlamak için 'Oyna' butonuna basın...");
                    lstSpiker.Items.Add("==================================================");
                    btnOyna.Text = "İkinci Yarıya Başla"; topunYeri = SahaBolgesi.OrtaAlanMerkez; return;
                }
            }

            if (uzatmaVerildiMi && dakika >= bitisDakikasi)
            {
                macBittiMi = true; macTimer.Stop();
                lstSpiker.Items.Add("==================================================");
                lstSpiker.Items.Add($"HAKEM MAÇI BİTİRDİ! SKOR: {evSahibiGol} - {deplasmanGol}");
                lstSpiker.Items.Add("==================================================");
                 
                List<string> evSari, evKirmizi, depSari, depKirmizi;
                KartIstatistikHesapla(evSahibi, out evSari, out evKirmizi);
                KartIstatistikHesapla(deplasman, out depSari, out depKirmizi);

                System.Windows.Forms.Timer gecisTimer = new System.Windows.Forms.Timer();
                gecisTimer.Interval = 2500;
                gecisTimer.Tick += (s, args) => {
                    gecisTimer.Stop();
                     
                    Form3 f3 = new Form3(lblSkor.Text, evSahibi.Isim, deplasman.Isim, evGoller, depGoller,
                                         evIsabetliSut, depIsabetliSut, evIsabetliPas, depIsabetliPas,
                                         evSari, evKirmizi, depSari, depKirmizi);  
                    f3.Show(); this.Hide();
                };
                gecisTimer.Start();
                return;
            }

            if (dakika >= 90 && !uzatmaVerildiMi) { bitisDakikasi = 90 + new Random().Next(3, 8); uzatmaVerildiMi = true; lstSpiker.Items.Add($"=== DÖRDÜNCÜ HAKEM TABELAYI KALDIRDI: +{bitisDakikasi - 90} DAKİKA İLAVE! ==="); }

            dakika++;

            Random r = new Random();
            bool sol = r.Next(0, 2) == 0;
            Kaleci hKaleci = topEvSahibindeMi ? evSahibi.Kaleci : deplasman.Kaleci;
            Kaleci sKaleci = topEvSahibindeMi ? deplasman.Kaleci : evSahibi.Kaleci;
            Defans hBek = topEvSahibindeMi ? (sol ? evSahibi.SolBek : evSahibi.SagBek) : (sol ? deplasman.SolBek : deplasman.SagBek);
            Forvet hKanat = topEvSahibindeMi ? (sol ? evSahibi.SolKanat : evSahibi.SagKanat) : (sol ? deplasman.SolKanat : deplasman.SagKanat);
            Defans sBek = topEvSahibindeMi ? (sol ? deplasman.SagBek : deplasman.SolBek) : (sol ? evSahibi.SagBek : evSahibi.SolBek);
            Forvet sKanat = topEvSahibindeMi ? (sol ? deplasman.SagKanat : deplasman.SolKanat) : (sol ? evSahibi.SagKanat : evSahibi.SolKanat);
            Defans hStoper = topEvSahibindeMi ? (sol ? evSahibi.SolStoper : evSahibi.SagStoper) : (sol ? deplasman.SolStoper : deplasman.SagStoper);
            Defans sStoper = topEvSahibindeMi ? (sol ? deplasman.SolStoper : deplasman.SagStoper) : (sol ? evSahibi.SolStoper : evSahibi.SagStoper);
            OrtaSaha hDOS = topEvSahibindeMi ? evSahibi.DOS : deplasman.DOS;
            OrtaSaha sDOS = topEvSahibindeMi ? deplasman.DOS : evSahibi.DOS;
            OrtaSaha hMOS = topEvSahibindeMi ? evSahibi.MOS : deplasman.MOS;
            OrtaSaha sMOS = topEvSahibindeMi ? deplasman.MOS : evSahibi.MOS;
            OrtaSaha hOOS = topEvSahibindeMi ? evSahibi.OOS : deplasman.OOS;
            OrtaSaha sOOS = topEvSahibindeMi ? deplasman.OOS : evSahibi.OOS;
            Forvet hSantrafor = topEvSahibindeMi ? evSahibi.Santrafor : deplasman.Santrafor;
            Forvet sSantrafor = topEvSahibindeMi ? deplasman.Santrafor : evSahibi.Santrafor;

            lstSpiker.Items.Add($"[{dakika}'. Dakika] Top {(topEvSahibindeMi ? evSahibi.Isim : deplasman.Isim)} takımında...");

            switch (topunYeri)
            {
                case SahaBolgesi.KendiCezaSahasi:
                    hKaleci.Yorul(1); hStoper.Yorul(1); sSantrafor.Yorul(1);
                    lstSpiker.Items.Add($"{hKaleci.isim} geriden kısa pasla topu {hStoper.isim}'e veriyor.");
                    if (hKaleci.KisaPasVer(sSantrafor)) { PasEkle(true); lstSpiker.Items.Add("Baskıyı kırdılar, atak başlıyor."); topunYeri = SahaBolgesi.KendiYariSahamiz; }
                    else { PasEkle(false); lstSpiker.Items.Add($"KRİTİK HATA! {sSantrafor.isim} araya girdi!"); topEvSahibindeMi = !topEvSahibindeMi; topunYeri = SahaBolgesi.RakipCezaSahasi; }
                    break;

                case SahaBolgesi.KendiYariSahamiz:
                    hStoper.Yorul(1); hDOS.Yorul(1); sOOS.Yorul(1);
                    lstSpiker.Items.Add($"{hStoper.isim} topu ön liberodaki {hDOS.isim}'a oynadı.");
                    if (hStoper.PasAt(sOOS)) { PasEkle(true); lstSpiker.Items.Add($"{hDOS.isim} topu kontrol edip orta sahaya taşıyor."); topunYeri = SahaBolgesi.OrtaAlanMerkez; }
                    else { PasEkle(false); lstSpiker.Items.Add("Kötü pas! Top yan çizgiden dışarı çıktı."); topEvSahibindeMi = !topEvSahibindeMi; topunYeri = SahaBolgesi.Tac; }
                    break;

                case SahaBolgesi.Tac:
                    hBek.Yorul(1); sKanat.Yorul(1); hKanat.Yorul(2); sBek.Yorul(2);
                    string taraf = sol ? "Sol" : "Sağ";
                    lstSpiker.Items.Add($"{taraf} kanattan taç atışını {hBek.isim} kullanıyor...");
                    if (hBek.TacKullan(sKanat))
                    {
                        PasEkle(true);
                        lstSpiker.Items.Add($"{hKanat.isim} topu aldı, hızla çizgiye iniyor!");
                        if (hKanat.CizgiyeInipOrtaAc(sBek))
                        {
                            lstSpiker.Items.Add($"{hKanat.isim} rakibi {sBek.isim}'i geçti! Kavisli bir orta kesti!");
                            SutEkle(true);
                            if (hSantrafor.KafaVurusuYap(sKaleci))
                            {
                                lstSpiker.Items.Add($"GOOOOOOOLLL!!! {hSantrafor.isim} harika yükseldi!");
                                GolOldu(hSantrafor.isim); 
                            }
                            else { lstSpiker.Items.Add($"Müthiş kurtarış! {sKaleci.isim} kornere çeldi."); topunYeri = SahaBolgesi.Korner; }
                        }
                        else { lstSpiker.Items.Add($"{sBek.isim} kayarak müdahale ile orta açmasına izin vermedi."); topEvSahibindeMi = !topEvSahibindeMi; topunYeri = SahaBolgesi.KendiYariSahamiz; }
                    }
                    else { PasEkle(false); lstSpiker.Items.Add("Hatalı taç atışı, top el değiştirdi."); topEvSahibindeMi = !topEvSahibindeMi; topunYeri = SahaBolgesi.Tac; }
                    break;

                case SahaBolgesi.OrtaAlanMerkez:
                    hMOS.Yorul(1); sMOS.Yorul(1);
                    lstSpiker.Items.Add($"{hMOS.isim} topu kontrol etti, oyunun yönüne bakıyor...");
                    int t = hMOS.OyunTercihiYap(sMOS);
                    if (t == 1) // Dikine Oyun
                    {
                        lstSpiker.Items.Add($"MÜTHİŞ VİZYON! {hMOS.isim} defansı tek pasla deldi!");
                        if (hMOS.AraPasiAt(sStoper)) { PasEkle(true); lstSpiker.Items.Add($"{hSantrafor.isim} bir anda kaleciyle karşı karşıya!"); topunYeri = SahaBolgesi.RakipCezaSahasi; }
                        else
                        {
                            if (new Random().Next(0, 100) < 25)
                            {
                                sDOS.Yorul(2); lstSpiker.Items.Add($"DÜDÜK SESİ! {sDOS.isim} atağa kalkan rakibi sert bir faulle durdurdu!");
                                SakatlikKontrolu(hMOS, topEvSahibindeMi ? evSahibi : deplasman);
                                int kart = sDOS.KartGor();
                                if (kart >= 2) lstSpiker.Items.Add($"🟥 KIRMIZI KART! {sDOS.isim} oyundan atıldı!"); else if (kart == 1) lstSpiker.Items.Add($"🟨 Hakem {sDOS.isim}'e sarı kart gösterdi.");
                                topunYeri = SahaBolgesi.SerbestVurus;
                            }
                            else { PasEkle(false); lstSpiker.Items.Add($"{sStoper.isim} son anda ayak koydu."); topEvSahibindeMi = !topEvSahibindeMi; topunYeri = SahaBolgesi.KendiYariSahamiz; }
                        }
                    }
                    else if (t == 2) { PasEkle(true); lstSpiker.Items.Add($"{hMOS.isim} risk almadı, topu geriye bıraktı."); topunYeri = SahaBolgesi.KendiYariSahamiz; }
                    else if (t == -1) { PasEkle(false); lstSpiker.Items.Add($"{hMOS.isim} topu KAPTIRDI!"); topEvSahibindeMi = !topEvSahibindeMi; topunYeri = SahaBolgesi.OrtaAlanMerkez; }
                    else { if (hMOS.OyunKur(sMOS)) { PasEkle(true); topunYeri = SahaBolgesi.RakipYariSaha; } else { PasEkle(false); topEvSahibindeMi = !topEvSahibindeMi; } }
                    break;

                case SahaBolgesi.RakipYariSaha:
                    hOOS.Yorul(1); sKaleci.Yorul(1);
                    if (new Random().Next(0, 100) < 35)
                    {
                        lstSpiker.Items.Add($"{hOOS.isim} kaleyi karşıdan gördü, mermi gibi vuruyor!");
                        if (hOOS.SutAt(sKaleci))
                        {
                            SutEkle(true);
                            if (sKaleci.KurtarisiYap(hOOS)) { lstSpiker.Items.Add($"{sKaleci.isim} veya direkler gole izin vermedi!"); topunYeri = SahaBolgesi.Korner; }
                            else
                            {
                                lstSpiker.Items.Add($"GOOOOLL!! {hOOS.isim} uzaktan harika yazdı!");
                                GolOldu(hOOS.isim); 
                            }
                        }
                        else { SutEkle(false); lstSpiker.Items.Add("Çok kötü bir vuruş, top tribünlere gitti."); topEvSahibindeMi = !topEvSahibindeMi; topunYeri = SahaBolgesi.KendiCezaSahasi; }
                    }
                    else { if (hOOS.AraPasiAt(sStoper)) { PasEkle(true); topunYeri = SahaBolgesi.RakipCezaSahasi; } else { PasEkle(false); topEvSahibindeMi = !topEvSahibindeMi; topunYeri = SahaBolgesi.KendiYariSahamiz; } }
                    break;

                case SahaBolgesi.RakipCezaSahasi:
                    hSantrafor.Yorul(2); sStoper.Yorul(2); sKaleci.Yorul(2);
                    lstSpiker.Items.Add($"{hSantrafor.isim} ceza sahasında şut açısı arıyor...");
                    int mud = sStoper.RiskliMudahaleEt(hSantrafor);
                    if (mud == -1) // Penaltı
                    {
                        lstSpiker.Items.Add("DÜDÜK ÇALDI! PENALTI!!! Arkadan çok sert müdahale!"); SakatlikKontrolu(hSantrafor, topEvSahibindeMi ? evSahibi : deplasman);
                        int kart = sStoper.KartGor();
                        if (kart >= 2) lstSpiker.Items.Add($"🟥 KIRMIZI! {sStoper.isim} oyundan atıldı!"); else if (kart == 1) lstSpiker.Items.Add($"🟨 Hakem {sStoper.isim}'e sarı kart gösterdi.");

                        if (!sKaleci.PenaltiKurtar(hSantrafor))
                        {
                            SutEkle(true);
                            lstSpiker.Items.Add("GOOOOOOOLL! Penaltıyı affetmiyor!");
                            GolOldu(hSantrafor.isim);  
                        }
                        else { lstSpiker.Items.Add($"İNANILMAZ! {sKaleci.isim} köşeyi doğru bildi!"); topEvSahibindeMi = !topEvSahibindeMi; topunYeri = SahaBolgesi.KendiCezaSahasi; }
                    }
                    else if (mud == -2) // Tehlikeli Yerden Frikik
                    {
                        lstSpiker.Items.Add("Hakem ceza yayı üzerinden Serbest Vuruş kararı verdi."); SakatlikKontrolu(hSantrafor, topEvSahibindeMi ? evSahibi : deplasman);
                        topunYeri = SahaBolgesi.SerbestVurus;
                    }
                    else if (hSantrafor.SutAt(sKaleci))
                    {
                        SutEkle(true);
                        if (sKaleci.KurtarisiYap(hSantrafor)) { lstSpiker.Items.Add($"SON ANDA! {sKaleci.isim} kornere çeliyor!"); topunYeri = SahaBolgesi.Korner; }
                        else
                        {
                            lstSpiker.Items.Add("GOOOLL!! Tam köşeye!");
                            GolOldu(hSantrafor.isim);  
                        }
                    }
                    else { SutEkle(false); lstSpiker.Items.Add("Tribünlere vurdu, top dışarıda."); topEvSahibindeMi = !topEvSahibindeMi; topunYeri = SahaBolgesi.KendiCezaSahasi; }
                    break;

                case SahaBolgesi.SerbestVurus:
                    hOOS.Yorul(1); sKaleci.Yorul(1);
                    lstSpiker.Items.Add($"Frikik ustası {hOOS.isim} topun başında. Baraj kuruldu...");
                    if (hOOS.FrikikKullan(sKaleci))
                    {
                        SutEkle(true);
                        lstSpiker.Items.Add($"MUAZZAM BİR GOL! Barajın üstünden astı!");
                        GolOldu(hOOS.isim); 
                    }
                    else { SutEkle(false); lstSpiker.Items.Add("Top barajdan dönüyor!"); topEvSahibindeMi = !topEvSahibindeMi; topunYeri = SahaBolgesi.KendiCezaSahasi; }
                    break;

                case SahaBolgesi.Korner:
                    hMOS.Yorul(1); hSantrafor.Yorul(2); sStoper.Yorul(2);
                    lstSpiker.Items.Add($"{hMOS.isim} kavisli bir orta kesti...");
                    if (hMOS.OrtaAc(sStoper))
                    {
                        if (hSantrafor.KafaVurusuYap(sKaleci))
                        {
                            SutEkle(true);
                            lstSpiker.Items.Add("GOOOLL!!! Kafa vuruşu ağlarda!");
                            GolOldu(hSantrafor.isim);  
                        }
                        else { lstSpiker.Items.Add($"{sKaleci.isim} çizgiden çıkardı!"); topEvSahibindeMi = !topEvSahibindeMi; topunYeri = SahaBolgesi.KendiCezaSahasi; }
                    }
                    else { lstSpiker.Items.Add($"{sStoper.isim} topu uzaklaştırdı."); topEvSahibindeMi = !topEvSahibindeMi; topunYeri = SahaBolgesi.KendiYariSahamiz; }
                    break;
            }
            SahayiGuncelle();
            ArayuzuGuncelle();
            lstSpiker.Items.Add("");
            lstSpiker.TopIndex = lstSpiker.Items.Count - 1;
        }

    }
}