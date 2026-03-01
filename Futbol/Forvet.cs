using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol
{
    public class Forvet : Futbolcu
    {
        public HucumTipi Rol;
         
      
         
        public bool KafaVurusuYap(Kaleci rakipKaleci)
        {
            Random rasgele = new Random();
            double benimFormum = this.AnlikFormCarpani();
            double kaleciFormu = rakipKaleci.AnlikFormCarpani();
             
            double benimBoyAvantajim = this.boy / 100.0;
            double kaleciBoyAvantaji = rakipKaleci.boy / 100.0;
             
            int kafaGucu = Convert.ToInt32(((this.Guc * 0.4 + this.Bitiricilik * 0.4 + this.Agresiflik * 0.2) * benimBoyAvantajim) * benimFormum);
            int uzanmaGucu = Convert.ToInt32(((rakipKaleci.Kalecilik * 0.6 + rakipKaleci.Hiz * 0.4) * kaleciBoyAvantaji) * kaleciFormu);

            return rasgele.Next(0, kafaGucu + uzanmaGucu) < (kafaGucu + 5);
        } 

        public bool CizgiyeInipOrtaAc(Futbolcu rakipBek)
        {
            Random r = new Random();
            double benimFormum = this.AnlikFormCarpani();
            double rakipFormu = rakipBek.AnlikFormCarpani(); 

            int kanatGucu = Convert.ToInt32((this.Hiz * 0.5 + this.Teknik * 0.3 + this.Vizyon * 0.2) * benimFormum); 
            int bekGucu = Convert.ToInt32((rakipBek.Hiz * 0.4 + rakipBek.Def * 0.4 + rakipBek.KararAlma * 0.2) * rakipFormu);

            return r.Next(0, kanatGucu + bekGucu) < kanatGucu;
        }
    }
}