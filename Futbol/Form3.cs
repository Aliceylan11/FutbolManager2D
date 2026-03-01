using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Futbol
{
    public partial class Form3 : Form
    {
        string _skor, _evAd, _depAd;
        List<string> _evGoller, _depGoller;

        // YENİ: Hem Toplam Hem İsabetli verileri ayrı ayrı tutuyoruz
        int _evTopSut, _evIsabSut, _depTopSut, _depIsabSut;
        int _evTopPas, _evIsabPas, _depTopPas, _depIsabPas;

        List<string> _evSari, _evKirmizi, _depSari, _depKirmizi;
        string _evLogoYolu, _depLogoYolu;

        // CONSTRUCTOR (Kurucu Metot) GÜNCELLENDİ
        public Form3(string skor, string evAd, string depAd, List<string> evGoller, List<string> depGoller,
                  int evTopSut, int evIsabSut, int depTopSut, int depIsabSut,
                  int evTopPas, int evIsabPas, int depTopPas, int depIsabPas,
                  List<string> evSari, List<string> evKirmizi, List<string> depSari, List<string> depKirmizi,
                  string evLogoYolu, string depLogoYolu)
        {
            InitializeComponent();
            _skor = skor; _evAd = evAd; _depAd = depAd;
            _evGoller = evGoller; _depGoller = depGoller;

            _evTopSut = evTopSut; _evIsabSut = evIsabSut;
            _depTopSut = depTopSut; _depIsabSut = depIsabSut;
            _evTopPas = evTopPas; _evIsabPas = evIsabPas;
            _depTopPas = depTopPas; _depIsabPas = depIsabPas;

            _evSari = evSari; _evKirmizi = evKirmizi; _depSari = depSari; _depKirmizi = depKirmizi;
            _evLogoYolu = evLogoYolu; _depLogoYolu = depLogoYolu;
        }

        private void Form3_Load(object sender, EventArgs e)
        { 
            lblSkor.BackColor = Color.Transparent; lblSkor.ForeColor = Color.White;
            lblEvAd.BackColor = Color.Transparent; lblEvAd.ForeColor = Color.White;
            lblDepAd.BackColor = Color.Transparent; lblDepAd.ForeColor = Color.White;

            lstEvGoller.BackColor = Color.DarkSlateGray; lstEvGoller.ForeColor = Color.White; lstEvGoller.BorderStyle = BorderStyle.None;
            lstDepGoller.BackColor = Color.DarkSlateGray; lstDepGoller.ForeColor = Color.White; lstDepGoller.BorderStyle = BorderStyle.None;
            EvMacIstk.BackColor = Color.DarkSlateGray; EvMacIstk.ForeColor = Color.White; EvMacIstk.BorderStyle = BorderStyle.None;
            DepMacIstk.BackColor = Color.DarkSlateGray; DepMacIstk.ForeColor = Color.White; DepMacIstk.BorderStyle = BorderStyle.None;

            if (!string.IsNullOrEmpty(_evLogoYolu) && System.IO.File.Exists(_evLogoYolu))
            {
                pcbEvLogo3.ImageLocation = _evLogoYolu;
                pcbEvLogo3.SizeMode = PictureBoxSizeMode.Zoom;
                pcbEvLogo3.BackColor = Color.Transparent;
            }
            if (!string.IsNullOrEmpty(_depLogoYolu) && System.IO.File.Exists(_depLogoYolu))
            {
                pcbDepLogo3.ImageLocation = _depLogoYolu;
                pcbDepLogo3.SizeMode = PictureBoxSizeMode.Zoom;
                pcbDepLogo3.BackColor = Color.Transparent;
            } 

            lblSkor.Text = _skor;
            lblEvAd.Text = _evAd;
            lblDepAd.Text = _depAd;

            lstEvGoller.Items.Clear(); foreach (var gol in _evGoller) lstEvGoller.Items.Add(gol);
            lstDepGoller.Items.Clear(); foreach (var gol in _depGoller) lstDepGoller.Items.Add(gol);
             
            int toplamPasGenel = _evTopPas + _depTopPas;
            int evTopaSahip = toplamPasGenel > 0 ? (_evTopPas * 100) / toplamPasGenel : 50;
            int depTopaSahip = 100 - evTopaSahip;

            int evPasYuzde = _evTopPas > 0 ? (_evIsabPas * 100) / _evTopPas : 0;
            int depPasYuzde = _depTopPas > 0 ? (_depIsabPas * 100) / _depTopPas : 0;

            EvMacIstk.Items.Clear();
            DepMacIstk.Items.Clear();
             
            EvMacIstk.Items.Add($"Topa Sahip Olma: %{evTopaSahip}");
            EvMacIstk.Items.Add($"Şut (İsabetli): {_evTopSut} ({_evIsabSut})");
            EvMacIstk.Items.Add($"Pas (İsabetli): {_evTopPas} ({_evIsabPas})");
            EvMacIstk.Items.Add($"Pas İsabeti: %{evPasYuzde}");
            EvMacIstk.Items.Add("------------------------");

            // DEPLASMAN EKRANI
            DepMacIstk.Items.Add($"Topa Sahip Olma: %{depTopaSahip}");
            DepMacIstk.Items.Add($"Şut (İsabetli): {_depTopSut} ({_depIsabSut})");
            DepMacIstk.Items.Add($"Pas (İsabetli): {_depTopPas} ({_depIsabPas})");
            DepMacIstk.Items.Add($"Pas İsabeti: %{depPasYuzde}");
            DepMacIstk.Items.Add("------------------------");

            // KARTLAR
            foreach (var sari in _evSari) EvMacIstk.Items.Add($"[SARI] {sari}");
            foreach (var kirmizi in _evKirmizi) EvMacIstk.Items.Add($"[KIRMIZI] {kirmizi}");

            foreach (var sari in _depSari) DepMacIstk.Items.Add($"[SARI] {sari}");
            foreach (var kirmizi in _depKirmizi) DepMacIstk.Items.Add($"[KIRMIZI] {kirmizi}");
        }

        private void btnMenuyeDon_Click(object sender, EventArgs e)
        {
            Form2 anaMenu = new Form2();
            anaMenu.Show();
            this.Close();
        }
    }
}