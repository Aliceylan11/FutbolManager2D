using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Futbol
{
    public partial class Form3 : Form
    {
        string _skor, _evAd, _depAd;
        List<string> _evGoller, _depGoller;
        int _evSut, _depSut, _evPas, _depPas;

        // HATA BURADAYDI: Kartları tutan değişkenler int değil, List<string> olmalıydı.
        List<string> _evSari, _evKirmizi, _depSari, _depKirmizi;

        // CONSTRUCTOR: Parametreler de List<string> olarak güncellendi.
        public Form3(string skor, string evAd, string depAd, List<string> evGoller, List<string> depGoller,
                  int evSut, int depSut, int evPas, int depPas,
                  List<string> evSari, List<string> evKirmizi, List<string> depSari, List<string> depKirmizi)
        {
            InitializeComponent();
            _skor = skor;
            _evAd = evAd;
            _depAd = depAd;
            _evGoller = evGoller;
            _depGoller = depGoller;
            _evSut = evSut;
            _depSut = depSut;
            _evPas = evPas;
            _depPas = depPas;

            _evSari = evSari;
            _evKirmizi = evKirmizi;
            _depSari = depSari;
            _depKirmizi = depKirmizi;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lblSkor.Text = _skor;
            lblEvAd.Text = _evAd;
            lblDepAd.Text = _depAd;

            lstEvGoller.Items.Clear();
            foreach (var gol in _evGoller) lstEvGoller.Items.Add(gol);

            lstDepGoller.Items.Clear();
            foreach (var gol in _depGoller) lstDepGoller.Items.Add(gol);

          

            EvMacIstk.Items.Add("Şut : " + _evSut);
            EvMacIstk.Items.Add("Pas : " + _evPas);
            DepMacIstk.Items.Add("Şut : " + _depSut);
            DepMacIstk.Items.Add("Pas : " + _depPas);
            // Ev Sahibi Kartları
            foreach (var sari in _evSari)
            {
                EvMacIstk.Items.Add($"🟨 {sari}");
            }
            foreach (var kirmizi in _evKirmizi)
            {
                EvMacIstk.Items.Add($"🟥 {kirmizi}");
            }

            // Deplasman Kartları
            foreach (var sari in _depSari)
            {
                DepMacIstk.Items.Add($"🟨 {sari}");
            }
            foreach (var kirmizi in _depKirmizi)
            {
                DepMacIstk.Items.Add($"🟥 {kirmizi}");
            }
        }

        private void btnMenuyeDon_Click(object sender, EventArgs e)
        {
            Form2 anaMenu = new Form2();
            anaMenu.Show();
            this.Close();
        }
    }
}