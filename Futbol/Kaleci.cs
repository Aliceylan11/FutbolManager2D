using System;

namespace Futbol
{
    public class Kaleci : Futbolcu
    { 

        public bool KurtarisiYap(Futbolcu rakipVurucu)
        {
            Random rasgele = new Random();
            double benimFormum = this.AnlikFormCarpani();
            double rakipFormu = rakipVurucu.AnlikFormCarpani();

            int engKatsayi = Convert.ToInt32((this.Kalecilik * 0.6 + this.KararAlma * 0.2 + this.Hiz * 0.2) * benimFormum);
            int golKatsayi = Convert.ToInt32((rakipVurucu.Bitiricilik * 0.5 + rakipVurucu.Sogukkanlilik * 0.3 + rakipVurucu.Guc * 0.2) * rakipFormu);

            if (rasgele.Next(0, golKatsayi + engKatsayi) < golKatsayi)
                return false;
            else
                return true;
        }
         
        public bool PenaltiKurtar(Futbolcu rakipVurucu)
        {
            Random rasgele = new Random();
            double benimFormum = this.AnlikFormCarpani();
            double rakipFormu = rakipVurucu.AnlikFormCarpani();

            int kurtaris = Convert.ToInt32((this.Kalecilik * 0.5 + this.Sogukkanlilik * 0.3 + this.KararAlma * 0.2) * benimFormum);
            int sutGucu = Convert.ToInt32((rakipVurucu.Bitiricilik * 0.5 + rakipVurucu.Sogukkanlilik * 0.5) * rakipFormu);

            return rasgele.Next(0, kurtaris + sutGucu + 20) < kurtaris;
        }
         
        public bool KisaPasVer(Futbolcu rakipBaski)
        {
            Random rasgele = new Random();
            double benimFormum = this.AnlikFormCarpani();
            double rakipFormu = rakipBaski.AnlikFormCarpani(); 

            int kisaPasGucu = Convert.ToInt32((this.Pas * 0.5 + this.Sogukkanlilik * 0.3 + this.KararAlma * 0.2) * benimFormum);
            int baskiGucu = Convert.ToInt32((rakipBaski.Hiz * 0.4 + rakipBaski.Agresiflik * 0.4 + rakipBaski.Def * 0.2) * rakipFormu);
            
            return rasgele.Next(0, kisaPasGucu + baskiGucu + 25) < (kisaPasGucu + 40);
        }
         
        public bool UzunPasVer(Futbolcu rakipKesici)
        {
            Random rasgele = new Random();
            double benimFormum = this.AnlikFormCarpani();
            double rakipFormu = rakipKesici.AnlikFormCarpani();
             
            int uzunPasGucu = Convert.ToInt32((this.Guc * 0.4 + this.Vizyon * 0.4 + this.Teknik * 0.2) * benimFormum);
            int kesmeGucu = Convert.ToInt32((rakipKesici.Guc * 0.5 + rakipKesici.Def * 0.3 + rakipKesici.KararAlma * 0.2) * rakipFormu);
 
            return rasgele.Next(0, uzunPasGucu + kesmeGucu) < uzunPasGucu;
        }
    }
}