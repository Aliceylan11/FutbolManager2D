using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol
{
    public class OrtaSaha : Futbolcu
    {
        public OrtaSahaTipi Rol;

        public bool TopuIleriTasi(Futbolcu rakipBaskisi)
        {
            Random r = new Random();
            double benimFormum = this.AnlikFormCarpani();
            double rakipFormu = rakipBaskisi.AnlikFormCarpani();
             
            int tasimaGucu = Convert.ToInt32((this.Teknik * 0.4 + this.Dayaniklilik * 0.4 + this.KararAlma * 0.2) * benimFormum);
            int baskiGucu = Convert.ToInt32((rakipBaskisi.Def * 0.5 + rakipBaskisi.Agresiflik * 0.3 + rakipBaskisi.Hiz * 0.2) * rakipFormu);

            return r.Next(0, tasimaGucu + baskiGucu) < tasimaGucu;
        }
         
        public bool OyunKur(Futbolcu rakip)
        {
            Random r = new Random();
            double benimFormum = this.AnlikFormCarpani();
            double rakipFormu = rakip.AnlikFormCarpani();
             
            int oyunKurmaGucu = Convert.ToInt32((this.Vizyon * 0.4 + this.Pas * 0.4 + this.Teknik * 0.2) * benimFormum);
            int kesmeGucu = Convert.ToInt32((rakip.KararAlma * 0.4 + rakip.Def * 0.4 + rakip.Hiz * 0.2) * rakipFormu);

            return r.Next(0, oyunKurmaGucu + kesmeGucu) < oyunKurmaGucu;
        }
         
        public bool FrikikKullan(Kaleci rakipKaleci)
        {
            Random r = new Random();
            double benimFormum = this.AnlikFormCarpani();
            double kaleciFormu = rakipKaleci.AnlikFormCarpani();
             
            int frikikGucu = Convert.ToInt32((this.Teknik * 0.6 + this.Bitiricilik * 0.2 + this.Sogukkanlilik * 0.2) * benimFormum);
            int kurtaris = Convert.ToInt32((rakipKaleci.Kalecilik * 0.6 + rakipKaleci.KararAlma * 0.2 + rakipKaleci.Hiz * 0.2) * kaleciFormu);

            return r.Next(0, frikikGucu + kurtaris) < frikikGucu;
        }
         
        public bool KisaPasAt(Futbolcu rakip)
        {
            Random rasgele = new Random();
            double benimFormum = this.AnlikFormCarpani();
            double rakipFormu = rakip.AnlikFormCarpani();

            int pasKatsayi = Convert.ToInt32((this.Pas * 0.6 + this.Sogukkanlilik * 0.4) * benimFormum);
            int kesmeKatsayi = Convert.ToInt32((rakip.Def * 0.5 + rakip.KararAlma * 0.5) * rakipFormu);
             
            return rasgele.Next(0, pasKatsayi + kesmeKatsayi + 10) < (pasKatsayi + 30);
        }
         
        public bool UzunPasAt(Futbolcu rakip)
        {
            Random rasgele = new Random();
            double benimFormum = this.AnlikFormCarpani();
            double rakipFormu = rakip.AnlikFormCarpani();
             
            int pasKatsayi = Convert.ToInt32((this.Guc * 0.4 + this.Pas * 0.3 + this.Vizyon * 0.3) * benimFormum);
            int kesmeKatsayi = Convert.ToInt32((rakip.Guc * 0.4 + rakip.Def * 0.4 + rakip.KararAlma * 0.2) * rakipFormu);
             
            return rasgele.Next(0, pasKatsayi + kesmeKatsayi + 10) < pasKatsayi;
        }
         
        public bool AraPasiAt(Futbolcu rakip)
        {
            Random rasgele = new Random();
            double benimFormum = this.AnlikFormCarpani();
            double rakipFormu = rakip.AnlikFormCarpani();
             
            int pasKatsayi = Convert.ToInt32((this.Vizyon * 0.5 + this.Pas * 0.3 + this.Teknik * 0.2) * benimFormum);
             
            int kesmeKatsayi = Convert.ToInt32((rakip.KararAlma * 0.4 + rakip.Def * 0.3 + rakip.Hiz * 0.3) * rakipFormu);
             
            return rasgele.Next(0, pasKatsayi + kesmeKatsayi + 20) < (pasKatsayi+20);
        }
         
        public bool OrtaAc(Futbolcu rakipDefans)
        {
            Random rasgele = new Random();
            double benimFormum = this.AnlikFormCarpani();
            double rakipFormu = rakipDefans.AnlikFormCarpani();
             
            int ortaKatsayi = Convert.ToInt32((this.Teknik * 0.5 + this.Vizyon * 0.3 + this.Pas * 0.2) * benimFormum);
            int kesmeKatsayi = Convert.ToInt32((rakipDefans.Def * 0.4 + rakipDefans.Guc * 0.4 + rakipDefans.KararAlma * 0.2) * rakipFormu);

            return rasgele.Next(0, ortaKatsayi + kesmeKatsayi) < ortaKatsayi;
        }
        public int OyunTercihiYap(Futbolcu rakipBaski)
        {
            Random r = new Random();
            double form = this.AnlikFormCarpani();
             
            int kararGucu = Convert.ToInt32((this.KararAlma * 0.6 + this.Vizyon * 0.4) * form);
            int baskiGucu = Convert.ToInt32((rakipBaski.Agresiflik * 0.7 + rakipBaski.Hiz * 0.3));

            int zar = r.Next(0, 100);

            if (zar < 20) return -1; // RİSKLİ: Topu kaptırdı! (Hata payı)
            if (kararGucu > baskiGucu + 20) return 1; // ZEKİCE: Dikine/Final pası deneyecek (Hızlı atak)
            if (kararGucu < baskiGucu) return 2; // GARANTİCİ: Pas kanalı kapalı, geriye defansa dönecek

            return 0; 
        }
    }
}