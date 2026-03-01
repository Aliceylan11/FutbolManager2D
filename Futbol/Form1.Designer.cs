namespace Futbol
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lstSpiker = new ListBox();
            lblEvSahibiAd = new Label();
            lblDeplasmanAd = new Label();
            btnOyna = new Button();
            label3 = new Label();
            lblSkor = new Label();
            lblDakika = new Label();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            macTimer = new System.Windows.Forms.Timer(components);
            btnHamle = new Button();
            btnAsistan = new Button();
            pnlRadar = new Panel();
            pnlGolEfekti = new Panel();
            lblGolMesaji = new Label();
            picGolLogo = new PictureBox();
            golEfektTimer = new System.Windows.Forms.Timer(components);
            pcbEvLogo2 = new PictureBox();
            pcbDepLogo2 = new PictureBox();
            pnlGolEfekti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picGolLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbEvLogo2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbDepLogo2).BeginInit();
            SuspendLayout();
            // 
            // lstSpiker
            // 
            lstSpiker.FormattingEnabled = true;
            lstSpiker.ItemHeight = 15;
            lstSpiker.Location = new Point(68, 464);
            lstSpiker.Name = "lstSpiker";
            lstSpiker.Size = new Size(493, 109);
            lstSpiker.TabIndex = 1;
            // 
            // lblEvSahibiAd
            // 
            lblEvSahibiAd.AutoSize = true;
            lblEvSahibiAd.BackColor = Color.Transparent;
            lblEvSahibiAd.Location = new Point(297, 36);
            lblEvSahibiAd.Name = "lblEvSahibiAd";
            lblEvSahibiAd.Size = new Size(38, 15);
            lblEvSahibiAd.TabIndex = 2;
            lblEvSahibiAd.Text = "label1";
            lblEvSahibiAd.Click += lblEvSahibiAd_Click;
            // 
            // lblDeplasmanAd
            // 
            lblDeplasmanAd.AutoSize = true;
            lblDeplasmanAd.BackColor = Color.Transparent;
            lblDeplasmanAd.Location = new Point(458, 36);
            lblDeplasmanAd.Name = "lblDeplasmanAd";
            lblDeplasmanAd.Size = new Size(38, 15);
            lblDeplasmanAd.TabIndex = 3;
            lblDeplasmanAd.Text = "label2";
            // 
            // btnOyna
            // 
            btnOyna.Location = new Point(740, 531);
            btnOyna.Name = "btnOyna";
            btnOyna.Size = new Size(150, 23);
            btnOyna.TabIndex = 4;
            btnOyna.Text = "Oyna";
            btnOyna.UseVisualStyleBackColor = true;
            btnOyna.Click += btnOyna_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(1052, 531);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 5;
            label3.Text = "Tek Tek Hamle Yap";
            // 
            // lblSkor
            // 
            lblSkor.AutoSize = true;
            lblSkor.BackColor = Color.Transparent;
            lblSkor.Location = new Point(391, 34);
            lblSkor.Name = "lblSkor";
            lblSkor.Size = new Size(24, 15);
            lblSkor.TabIndex = 9;
            lblSkor.Text = "0-0";
            // 
            // lblDakika
            // 
            lblDakika.AutoSize = true;
            lblDakika.BackColor = Color.Transparent;
            lblDakika.Location = new Point(391, 59);
            lblDakika.Name = "lblDakika";
            lblDakika.Size = new Size(33, 15);
            lblDakika.TabIndex = 10;
            lblDakika.Text = "Dk: 0";
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.DarkSlateGray;
            listBox1.ForeColor = SystemColors.MenuBar;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(740, 34);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(221, 469);
            listBox1.TabIndex = 12;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // listBox2
            // 
            listBox2.BackColor = Color.DarkSlateGray;
            listBox2.ForeColor = SystemColors.MenuBar;
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(981, 34);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(220, 469);
            listBox2.TabIndex = 13;
            // 
            // macTimer
            // 
            macTimer.Tick += macTimer_Tick;
            // 
            // btnHamle
            // 
            btnHamle.Location = new Point(1035, 550);
            btnHamle.Name = "btnHamle";
            btnHamle.Size = new Size(150, 23);
            btnHamle.TabIndex = 14;
            btnHamle.Text = "Hamle";
            btnHamle.UseVisualStyleBackColor = true;
            btnHamle.Click += btnHamle_Click;
            // 
            // btnAsistan
            // 
            btnAsistan.Location = new Point(1035, 579);
            btnAsistan.Name = "btnAsistan";
            btnAsistan.Size = new Size(150, 23);
            btnAsistan.TabIndex = 15;
            btnAsistan.Text = "Yardımcı Antrenörü Çağır ";
            btnAsistan.UseVisualStyleBackColor = true;
            btnAsistan.Click += btnAsistan_Click;
            // 
            // pnlRadar
            // 
            pnlRadar.BackColor = Color.DarkGreen;
            pnlRadar.Location = new Point(68, 189);
            pnlRadar.Name = "pnlRadar";
            pnlRadar.Size = new Size(400, 250);
            pnlRadar.TabIndex = 16;
            pnlRadar.Paint += pnlRadar_Paint;
            // 
            // pnlGolEfekti
            // 
            pnlGolEfekti.Controls.Add(lblGolMesaji);
            pnlGolEfekti.Controls.Add(picGolLogo);
            pnlGolEfekti.Location = new Point(483, 187);
            pnlGolEfekti.Name = "pnlGolEfekti";
            pnlGolEfekti.Size = new Size(251, 135);
            pnlGolEfekti.TabIndex = 17;
            pnlGolEfekti.Visible = false;
            // 
            // lblGolMesaji
            // 
            lblGolMesaji.AutoSize = true;
            lblGolMesaji.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblGolMesaji.ForeColor = SystemColors.ButtonFace;
            lblGolMesaji.Location = new Point(6, 16);
            lblGolMesaji.Name = "lblGolMesaji";
            lblGolMesaji.Size = new Size(72, 30);
            lblGolMesaji.TabIndex = 1;
            lblGolMesaji.Text = "label1";
            // 
            // picGolLogo
            // 
            picGolLogo.Location = new Point(0, 2);
            picGolLogo.Name = "picGolLogo";
            picGolLogo.Size = new Size(249, 131);
            picGolLogo.TabIndex = 0;
            picGolLogo.TabStop = false;
            // 
            // golEfektTimer
            // 
            golEfektTimer.Interval = 300;
            // 
            // pcbEvLogo2
            // 
            pcbEvLogo2.Location = new Point(186, 34);
            pcbEvLogo2.Name = "pcbEvLogo2";
            pcbEvLogo2.Size = new Size(90, 90);
            pcbEvLogo2.SizeMode = PictureBoxSizeMode.AutoSize;
            pcbEvLogo2.TabIndex = 18;
            pcbEvLogo2.TabStop = false;
            // 
            // pcbDepLogo2
            // 
            pcbDepLogo2.Location = new Point(542, 34);
            pcbDepLogo2.Name = "pcbDepLogo2";
            pcbDepLogo2.Size = new Size(90, 90);
            pcbDepLogo2.SizeMode = PictureBoxSizeMode.AutoSize;
            pcbDepLogo2.TabIndex = 19;
            pcbDepLogo2.TabStop = false;
            pcbDepLogo2.Click += pcbDepLogo2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuBar;
            BackgroundImage = Properties.Resources.StadyumArkaplan;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1197, 614);
            Controls.Add(pcbDepLogo2);
            Controls.Add(pcbEvLogo2);
            Controls.Add(pnlGolEfekti);
            Controls.Add(pnlRadar);
            Controls.Add(btnAsistan);
            Controls.Add(btnHamle);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(lblDakika);
            Controls.Add(lblSkor);
            Controls.Add(label3);
            Controls.Add(btnOyna);
            Controls.Add(lblDeplasmanAd);
            Controls.Add(lblEvSahibiAd);
            Controls.Add(lstSpiker);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            pnlGolEfekti.ResumeLayout(false);
            pnlGolEfekti.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picGolLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbEvLogo2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbDepLogo2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox lstSpiker;
        private Label lblEvSahibiAd;
        private Label lblDeplasmanAd;
        private Button btnOyna;
        private Label label3;
        private Label lblSkor;
        private Label lblDakika;
        private ListBox listBox1;
        private ListBox listBox2;
        private System.Windows.Forms.Timer macTimer;
        private Button btnHamle;
        private Button btnAsistan;
        private Panel pnlRadar;
        private Panel pnlGolEfekti;
        private Label lblGolMesaji;
        private PictureBox picGolLogo;
        private System.Windows.Forms.Timer golEfektTimer;
        private PictureBox pcbEvLogo2;
        private PictureBox pcbDepLogo2;
    }
}
