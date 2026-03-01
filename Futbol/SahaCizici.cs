using System.Drawing;
using System.Collections.Generic;

namespace Futbol
{
    public class SahaCizici
    {
        // Tüm çizim yükünü bu metodun omuzlarına veriyoruz
        public static void SahayiVeOyunculariCiz(Graphics g, int w, int h, Takim ev, Takim dep, Color evRenk, Color depRenk, int topX, int topY)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 1. ZEMİN VE ÇİZGİLER
            int cizgiSayisi = 10;
            int dilimGenislik = w / cizgiSayisi;
            for (int i = 0; i < cizgiSayisi; i++)
            {
                Brush zeminFirca = (i % 2 == 0) ? new SolidBrush(Color.FromArgb(50, 150, 50)) : new SolidBrush(Color.FromArgb(60, 160, 60));
                g.FillRectangle(zeminFirca, i * dilimGenislik, 0, dilimGenislik, h);
            }

            Pen tebesir = new Pen(Color.White, 2);
            g.DrawRectangle(tebesir, 10, 10, w - 20, h - 20);
            g.DrawLine(tebesir, w / 2, 10, w / 2, h - 10);
            g.DrawEllipse(tebesir, (w / 2) - 50, (h / 2) - 50, 100, 100);
            g.DrawRectangle(tebesir, 10, (h / 2) - 100, 100, 200);
            g.DrawRectangle(tebesir, 10, (h / 2) - 50, 40, 100);
            g.DrawRectangle(tebesir, w - 110, (h / 2) - 100, 100, 200);
            g.DrawRectangle(tebesir, w - 50, (h / 2) - 50, 40, 100);

            int cap = 14;

            // 2. EV SAHİBİ ÇİZİMİ
            if (ev != null && ev.Kaleci != null) // Hata almamak için ufak bir kontrol
            {
                Brush evFirca = new SolidBrush(evRenk);
                List<Futbolcu> evKadro = new List<Futbolcu> { ev.Kaleci, ev.SolBek, ev.SolStoper, ev.SagStoper, ev.SagBek, ev.DOS, ev.MOS, ev.OOS, ev.SolKanat, ev.SagKanat, ev.Santrafor };
                foreach (var o in evKadro)
                {
                    if (o != null)
                    {
                        g.FillEllipse(evFirca, o.X - (cap / 2), o.Y - (cap / 2), cap, cap);
                        g.DrawEllipse(Pens.Black, o.X - (cap / 2), o.Y - (cap / 2), cap, cap);
                    }
                }
            }

            // 3. DEPLASMAN ÇİZİMİ
            if (dep != null && dep.Kaleci != null)
            {
                Brush depFirca = new SolidBrush(depRenk);
                List<Futbolcu> depKadro = new List<Futbolcu> { dep.Kaleci, dep.SolBek, dep.SolStoper, dep.SagStoper, dep.SagBek, dep.DOS, dep.MOS, dep.OOS, dep.SolKanat, dep.SagKanat, dep.Santrafor };
                foreach (var o in depKadro)
                {
                    if (o != null)
                    {
                        g.FillEllipse(depFirca, o.X - (cap / 2), o.Y - (cap / 2), cap, cap);
                        g.DrawEllipse(Pens.White, o.X - (cap / 2), o.Y - (cap / 2), cap, cap);
                    }
                }
            }

            // 4. TOP ÇİZİMİ
            g.FillEllipse(Brushes.Yellow, topX - 6, topY - 6, 12, 12);
            g.DrawEllipse(Pens.Black, topX - 6, topY - 6, 12, 12);
        }
    }
}