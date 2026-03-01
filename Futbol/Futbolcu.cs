using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Futbol
{

    public abstract class Futbolcu
    { 
        public string isim;
        public int boy;
        public int Guc, Hiz, Dayaniklilik;
        public int KararAlma;    
        public int Vizyon;       
        public int Sogukkanlilik; 
        public int Agresiflik;   
        public int Teknik, Pas, Bitiricilik, TopCalma, Atak, Def, Kalecilik;
        public int Moral = 100;      // Gol atınca artar, top kaptırınca düşer
        public int Kondisyon = 100;  // Dakika ilerledikçe düşer
        public bool SariKartVarMi { get; set; } = false;
        public bool KirmiziKartYediMi { get; set; } = false;
        public bool SakatMi { get; set; } = false;
        public int X { get; set; }
        public int Y { get; set; }
        public int FormaNo { get; set; }

        public int BaseX { get; set; }  
        public int BaseY { get; set; }
        public int HedefX { get; set; }  
        public int HedefY { get; set; }
         
        public void HedefeYuru()
        {
            int hizAdimi = 8; 
            if (X < HedefX) X += Math.Min(hizAdimi, HedefX - X);
            else if (X > HedefX) X -= Math.Min(hizAdimi, X - HedefX);

            if (Y < HedefY) Y += Math.Min(hizAdimi, HedefY - Y);
            else if (Y > HedefY) Y -= Math.Min(hizAdimi, Y - HedefY);
        }
 
        public void Yorul(int miktar)
        {
            this.Kondisyon -= miktar;
            if (this.Kondisyon < 0) this.Kondisyon = 0; 
        } 
        public int KartGor()
        {
            // Dönüş Değerleri: 0 = Kart Yok, 1 = Sarı Kart, 2 = 2. Sarıdan Kırmızı, 3 = Direkt Kırmızı
            Random r = new Random();
            int zar = r.Next(0, 100);

            if (zar < this.Agresiflik / 2)
            {
                if (zar < 5) // Direkt Kırmızı
                {
                    this.KirmiziKartYediMi = true;
                    SahadanSil(); // Oyuncuyu etkisiz hale getir
                    return 3;
                }
                else
                {
                    if (this.SariKartVarMi) // İkinci Sarıdan Kırmızı
                    {
                        this.KirmiziKartYediMi = true;
                        SahadanSil(); // Oyuncuyu etkisiz hale getir
                        return 2;
                    }
                    else // İlk Sarı Kart
                    {
                        this.SariKartVarMi = true;
                        return 1;
                    }
                }
            }
            return 0; // Kart çıkmadı
        }    
        private void SahadanSil()
        {
            // Oyuncu kırmızı kart gördüğünde gücü 1'e düşer. 
            // Artık girdiği tüm ikili mücadeleleri ve şutları %100 kaybedecektir!
            this.Hiz = 1;
            this.Guc = 1;
            this.Def = 1;
            this.Pas = 1;
            this.TopCalma = 1;
            this.Bitiricilik = 1;
            this.KararAlma = 1;
            this.Agresiflik = 1;
            this.Sogukkanlilik = 1;
            this.Vizyon = 1;
            this.Kalecilik = 1;
        } 
        public double AnlikFormCarpani()
        {
            double carpan = 1.0;

            // Moral Etkisi
            if (Moral >= 85) carpan += 0.15;      // Moralli oyuncuya %15 bonus
            else if (Moral <= 40) carpan -= 0.20; // Morali bozuksa %20 yetenek düşüşü

            // Kondisyon Etkisi
            if (Kondisyon <= 30) carpan -= 0.15;  // Çok yorulduysa %15 düşüş

            return carpan;
        }    
        public bool CalimAt(Futbolcu gercekRakip)
        {
            Random rasgele = new Random();
             
            double benimFormum = this.AnlikFormCarpani();
            double rakipFormu = gercekRakip.AnlikFormCarpani();

            int calimKatsayi = Convert.ToInt32((this.Hiz * 0.25 + this.Teknik * 0.5 + this.Atak * 0.15 + this.Guc * 0.1) * benimFormum);
            int defansKatsayi = Convert.ToInt32((gercekRakip.Guc * 0.25 + gercekRakip.Hiz * 0.15 + gercekRakip.Def * 0.6) * rakipFormu);

            if (rasgele.Next(0, calimKatsayi + defansKatsayi) < calimKatsayi)
                return true;
            else
                return false;
        }
        public bool PasAt(Futbolcu gercekRakipBaskisi)
        {
            Random rasgele = new Random();

            double benimFormum = this.AnlikFormCarpani();
            double rakipFormu = gercekRakipBaskisi.AnlikFormCarpani();
             
            int pasKatsayi = Convert.ToInt32((this.Pas * 0.5 + this.Vizyon * 0.3 + this.Teknik * 0.2) * benimFormum);
             
            int kesmeKatsayi = Convert.ToInt32((gercekRakipBaskisi.Def * 0.5 + gercekRakipBaskisi.Hiz * 0.3 + gercekRakipBaskisi.KararAlma * 0.2) * rakipFormu);
             
            if (rasgele.Next(0, pasKatsayi + kesmeKatsayi + 20) < pasKatsayi + 20)
                return true;
            else
                return false;
        }
        public bool SutAt(Kaleci rakipKaleci)
        {
            Random rasgele = new Random();
            double benimFormum = this.AnlikFormCarpani();
            double kaleciFormu = rakipKaleci.AnlikFormCarpani();

            int sutGucu = Convert.ToInt32((this.Bitiricilik * 0.5 + this.Sogukkanlilik * 0.3 + this.Guc * 0.2) * benimFormum);
            int kurtaris = Convert.ToInt32((rakipKaleci.Kalecilik * 0.6 + rakipKaleci.KararAlma * 0.2 + rakipKaleci.Hiz * 0.2) * kaleciFormu);

            return rasgele.Next(0, sutGucu + kurtaris) < (sutGucu + 30);
        }
    }
}