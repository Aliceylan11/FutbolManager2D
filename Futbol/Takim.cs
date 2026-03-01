using System.Collections.Generic;

namespace Futbol
{
    public class Takim
    {
        public int TakimID { get; set; }
        public string Isim { get; set; }
        public string LogoYolu { get; set; }  
        public string Renk1 { get; set; }    
        public string Renk2 { get; set; }

        public Takim(string takimIsmi)
        {
            this.Isim = takimIsmi;
        }
        public Takim() { }
        public int Gol { get; set; } = 0;
        public int ToplamPas { get; set; } = 0;
        public int IsabetliPas { get; set; } = 0;
        public int ToplamSut { get; set; } = 0;
        public int IsabetliSut { get; set; } = 0;
        public List<string> GolAtanlar { get; set; } = new List<string>();
         
        public Kaleci Kaleci { get; set; }
        public Defans SolBek { get; set; }
        public Defans SolStoper { get; set; }
        public Defans SagStoper { get; set; }
        public Defans SagBek { get; set; }
        public OrtaSaha DOS { get; set; }
        public OrtaSaha MOS { get; set; }
        public OrtaSaha OOS { get; set; }
        public Forvet SolKanat { get; set; }
        public Forvet SagKanat { get; set; }
        public Forvet Santrafor { get; set; }
        public List<Futbolcu> Yedekler { get; set; } = new List<Futbolcu>();
        public int DegisiklikHakki { get; set; } = 5;
        public bool KadroIceriyorMu(Futbolcu arananOyuncu)
        {
            if (arananOyuncu == null) return false;
             
            if (this.Kaleci == arananOyuncu ||
                this.SolBek == arananOyuncu || this.SolStoper == arananOyuncu || this.SagStoper == arananOyuncu || this.SagBek == arananOyuncu ||
                this.DOS == arananOyuncu || this.MOS == arananOyuncu || this.OOS == arananOyuncu ||
                this.SolKanat == arananOyuncu || this.SagKanat == arananOyuncu || this.Santrafor == arananOyuncu)
            {
                return true;
            }

            return false;
        }
    }
}