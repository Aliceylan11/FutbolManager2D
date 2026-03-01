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
            pnlGolEfekti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picGolLogo).BeginInit();
            SuspendLayout();
            // 
            // lstSpiker
            // 
            lstSpiker.FormattingEnabled = true;
            lstSpiker.ItemHeight = 15;
            lstSpiker.Location = new Point(45, 388);
            lstSpiker.Name = "lstSpiker";
            lstSpiker.Size = new Size(482, 214);
            lstSpiker.TabIndex = 1;
            // 
            // lblEvSahibiAd
            // 
            lblEvSahibiAd.AutoSize = true;
            lblEvSahibiAd.Location = new Point(68, 34);
            lblEvSahibiAd.Name = "lblEvSahibiAd";
            lblEvSahibiAd.Size = new Size(38, 15);
            lblEvSahibiAd.TabIndex = 2;
            lblEvSahibiAd.Text = "label1";
            // 
            // lblDeplasmanAd
            // 
            lblDeplasmanAd.AutoSize = true;
            lblDeplasmanAd.Location = new Point(430, 34);
            lblDeplasmanAd.Name = "lblDeplasmanAd";
            lblDeplasmanAd.Size = new Size(38, 15);
            lblDeplasmanAd.TabIndex = 3;
            lblDeplasmanAd.Text = "label2";
            // 
            // btnOyna
            // 
            btnOyna.Location = new Point(811, 531);
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
            label3.Location = new Point(699, 564);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 5;
            label3.Text = "Tek Tek Hamle Yap";
            // 
            // lblSkor
            // 
            lblSkor.AutoSize = true;
            lblSkor.Location = new Point(257, 34);
            lblSkor.Name = "lblSkor";
            lblSkor.Size = new Size(24, 15);
            lblSkor.TabIndex = 9;
            lblSkor.Text = "0-0";
            // 
            // lblDakika
            // 
            lblDakika.AutoSize = true;
            lblDakika.Location = new Point(257, 59);
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
            btnHamle.Location = new Point(811, 560);
            btnHamle.Name = "btnHamle";
            btnHamle.Size = new Size(150, 23);
            btnHamle.TabIndex = 14;
            btnHamle.Text = "Hamle";
            btnHamle.UseVisualStyleBackColor = true;
            btnHamle.Click += btnHamle_Click;
            // 
            // btnAsistan
            // 
            btnAsistan.Location = new Point(994, 560);
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
            pnlRadar.Location = new Point(68, 92);
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
            picGolLogo.Location = new Point(3, 3);
            picGolLogo.Name = "picGolLogo";
            picGolLogo.Size = new Size(245, 132);
            picGolLogo.TabIndex = 0;
            picGolLogo.TabStop = false;
            // 
            // golEfektTimer
            // 
            golEfektTimer.Interval = 300;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuBar;
            ClientSize = new Size(1197, 614);
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
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            pnlGolEfekti.ResumeLayout(false);
            pnlGolEfekti.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picGolLogo).EndInit();
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
    }
}
