using System;
using System.Collections.Generic; // List yapısı için şart!
using System.Data.SqlClient;

namespace Futbol
{
    public class Veritabani
    {
        static string connectionString = @"Server=localhost;Database=FutbolMenajerDB;Trusted_Connection=True;";

        // --- FORM 2 İÇİN TÜM TAKIMLARI LİSTELEME ---
        public static List<Takim> TumTakimlariGetir()
        {
            List<Takim> liste = new List<Takim>();
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                string sorgu = "SELECT TakimID, TakimIsmi, LogoYolu, Renk1, Renk2 FROM Takimlar";
                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    SqlDataReader oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        liste.Add(new Takim()
                        {
                            TakimID = Convert.ToInt32(oku["TakimID"]),
                            Isim = oku["TakimIsmi"].ToString(),
                            LogoYolu = oku["LogoYolu"]?.ToString(),
                            Renk1 = oku["Renk1"]?.ToString(),
                            Renk2 = oku["Renk2"]?.ToString()
                        });
                    }
                }
            }
            return liste;
        }

        // --- FORM 1 İÇİN DETAYLI TAKIM VE OYUNCU VERİSİ ÇEKME ---
        public static Takim TakimCek(int takimId, string takimIsmi)
        {
            // Constructor'ına göre Takim nesnesini oluşturuyoruz
            Takim takim = new Takim(takimIsmi);
            takim.TakimID = takimId; // ID atamasını başta bir kez yapalım

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                string sorgu = "SELECT * FROM Oyuncular WHERE TakimID = @id";

                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@id", takimId);
                    using (SqlDataReader oku = komut.ExecuteReader())
                    {
                        while (oku.Read())
                        {
                            string rol = oku["Rol"].ToString();
                            string isim = oku["Isim"].ToString();

                            // Özellikleri çekiyoruz
                            int hiz = Convert.ToInt32(oku["Hiz"]);
                            int guc = Convert.ToInt32(oku["Guc"]);
                            int dayaniklilik = Convert.ToInt32(oku["Dayaniklilik"]);
                            int kararAlma = Convert.ToInt32(oku["KararAlma"]);
                            int agresiflik = Convert.ToInt32(oku["Agresiflik"]);
                            int sogukkanlilik = Convert.ToInt32(oku["Sogukkanlilik"]);
                            int vizyon = Convert.ToInt32(oku["Vizyon"]);
                            int teknik = Convert.ToInt32(oku["Teknik"]);
                            int pas = Convert.ToInt32(oku["Pas"]);
                            int topCalma = Convert.ToInt32(oku["TopCalma"]);
                            int defansGucu = Convert.ToInt32(oku["DefansGucu"]);
                            int bitiricilik = Convert.ToInt32(oku["Bitiricilik"]);
                            int kalecilik = Convert.ToInt32(oku["Kalecilik"]);
                            int boy = Convert.ToInt32(oku["Boy"]);

                            // --- MEVKİ ATAMALARI ---
                            if (rol == "Kaleci")
                            {
                                var o = new Kaleci() { isim = isim, Kalecilik = kalecilik, KararAlma = kararAlma, Sogukkanlilik = sogukkanlilik, Hiz = hiz, Pas = pas, Vizyon = vizyon, Moral = 100, Kondisyon = 100 };
                                if (takim.Kaleci == null) takim.Kaleci = o; else takim.Yedekler.Add(o);
                            }
                            else if (rol == "SolBek")
                            {
                                var o = new Defans() { isim = isim, Def = defansGucu, TopCalma = topCalma, Agresiflik = agresiflik, KararAlma = kararAlma, Guc = guc, Hiz = hiz, boy = boy, Moral = 100, Kondisyon = 100, Rol = DefansTipi.SolBek };
                                if (takim.SolBek == null) takim.SolBek = o; else takim.Yedekler.Add(o);
                            }
                            else if (rol == "SolStoper")
                            {
                                var o = new Defans() { isim = isim, Def = defansGucu, TopCalma = topCalma, Agresiflik = agresiflik, KararAlma = kararAlma, Guc = guc, Hiz = hiz, boy = boy, Moral = 100, Kondisyon = 100, Rol = DefansTipi.SolStoper };
                                if (takim.SolStoper == null) takim.SolStoper = o; else takim.Yedekler.Add(o);
                            }
                            else if (rol == "SagStoper")
                            {
                                var o = new Defans() { isim = isim, Def = defansGucu, TopCalma = topCalma, Agresiflik = agresiflik, KararAlma = kararAlma, Guc = guc, Hiz = hiz, boy = boy, Moral = 100, Kondisyon = 100, Rol = DefansTipi.SagStoper };
                                if (takim.SagStoper == null) takim.SagStoper = o; else takim.Yedekler.Add(o);
                            }
                            else if (rol == "SagBek")
                            {
                                var o = new Defans() { isim = isim, Def = defansGucu, TopCalma = topCalma, Agresiflik = agresiflik, KararAlma = kararAlma, Guc = guc, Hiz = hiz, boy = boy, Moral = 100, Kondisyon = 100, Rol = DefansTipi.SagBek };
                                if (takim.SagBek == null) takim.SagBek = o; else takim.Yedekler.Add(o);
                            }
                            else if (rol == "Defansif")
                            {
                                var o = new OrtaSaha() { isim = isim, Pas = pas, Teknik = teknik, Vizyon = vizyon, Dayaniklilik = dayaniklilik, KararAlma = kararAlma, Def = defansGucu, TopCalma = topCalma, Agresiflik = agresiflik, Moral = 100, Kondisyon = 100, Rol = OrtaSahaTipi.Defansif };
                                if (takim.DOS == null) takim.DOS = o; else takim.Yedekler.Add(o);
                            }
                            else if (rol == "Merkez")
                            {
                                var o = new OrtaSaha() { isim = isim, Pas = pas, Teknik = teknik, Vizyon = vizyon, Dayaniklilik = dayaniklilik, KararAlma = kararAlma, Def = defansGucu, TopCalma = topCalma, Guc = guc, Moral = 100, Kondisyon = 100, Rol = OrtaSahaTipi.Merkez };
                                if (takim.MOS == null) takim.MOS = o; else takim.Yedekler.Add(o);
                            }
                            else if (rol == "Ofansif")
                            {
                                var o = new OrtaSaha() { isim = isim, Pas = pas, Teknik = teknik, Vizyon = vizyon, Sogukkanlilik = sogukkanlilik, Bitiricilik = bitiricilik, KararAlma = kararAlma, Hiz = hiz, Moral = 100, Kondisyon = 100, Rol = OrtaSahaTipi.Ofansif };
                                if (takim.OOS == null) takim.OOS = o; else takim.Yedekler.Add(o);
                            }
                            else if (rol == "SolKanat")
                            {
                                var o = new Forvet() { isim = isim, Hiz = hiz, Teknik = teknik, Vizyon = vizyon, Guc = guc, Atak = pas, Bitiricilik = bitiricilik, Moral = 100, Kondisyon = 100, Rol = HucumTipi.SolKanat };
                                if (takim.SolKanat == null) takim.SolKanat = o; else takim.Yedekler.Add(o);
                            }
                            else if (rol == "SagKanat")
                            {
                                var o = new Forvet() { isim = isim, Hiz = hiz, Teknik = teknik, Vizyon = vizyon, Guc = guc, Atak = pas, Bitiricilik = bitiricilik, Moral = 100, Kondisyon = 100, Rol = HucumTipi.SagKanat };
                                if (takim.SagKanat == null) takim.SagKanat = o; else takim.Yedekler.Add(o);
                            }
                            else if (rol == "Santrafor")
                            {
                                var o = new Forvet() { isim = isim, Bitiricilik = bitiricilik, Sogukkanlilik = sogukkanlilik, Guc = guc, Agresiflik = agresiflik, KararAlma = kararAlma, Hiz = hiz, boy = boy, Moral = 100, Kondisyon = 100, Rol = HucumTipi.Santrafor };
                                if (takim.Santrafor == null) takim.Santrafor = o; else takim.Yedekler.Add(o);
                            }
                        }
                    }
                }
            }
            return takim;
        }
    }
}