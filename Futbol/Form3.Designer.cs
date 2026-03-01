namespace Futbol
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblEvAd = new Label();
            lblDepAd = new Label();
            lblSkor = new Label();
            lstEvGoller = new ListBox();
            lstDepGoller = new ListBox();
            btnMenuyeDon = new Button();
            EvMacIstk = new ListBox();
            DepMacIstk = new ListBox();
            pcbEvLogo3 = new PictureBox();
            pcbDepLogo3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pcbEvLogo3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbDepLogo3).BeginInit();
            SuspendLayout();
            // 
            // lblEvAd
            // 
            lblEvAd.AutoSize = true;
            lblEvAd.BackColor = Color.Transparent;
            lblEvAd.Font = new Font("Segoe UI", 18F);
            lblEvAd.ForeColor = Color.Black;
            lblEvAd.Location = new Point(189, 33);
            lblEvAd.Name = "lblEvAd";
            lblEvAd.Size = new Size(107, 32);
            lblEvAd.TabIndex = 0;
            lblEvAd.Text = "Ev sahibi";
            // 
            // lblDepAd
            // 
            lblDepAd.AutoSize = true;
            lblDepAd.BackColor = Color.Transparent;
            lblDepAd.Font = new Font("Segoe UI", 18F);
            lblDepAd.ForeColor = Color.Black;
            lblDepAd.Location = new Point(508, 33);
            lblDepAd.Name = "lblDepAd";
            lblDepAd.Size = new Size(133, 32);
            lblDepAd.TabIndex = 2;
            lblDepAd.Text = "Deplasman";
            // 
            // lblSkor
            // 
            lblSkor.AutoSize = true;
            lblSkor.BackColor = Color.Transparent;
            lblSkor.Font = new Font("Segoe UI", 18F);
            lblSkor.ForeColor = Color.Black;
            lblSkor.Location = new Point(373, 33);
            lblSkor.Name = "lblSkor";
            lblSkor.Size = new Size(50, 32);
            lblSkor.TabIndex = 3;
            lblSkor.Text = "0-0";
            // 
            // lstEvGoller
            // 
            lstEvGoller.FormattingEnabled = true;
            lstEvGoller.ItemHeight = 15;
            lstEvGoller.Location = new Point(31, 141);
            lstEvGoller.Name = "lstEvGoller";
            lstEvGoller.Size = new Size(150, 289);
            lstEvGoller.TabIndex = 4;
            // 
            // lstDepGoller
            // 
            lstDepGoller.FormattingEnabled = true;
            lstDepGoller.ItemHeight = 15;
            lstDepGoller.Location = new Point(460, 141);
            lstDepGoller.Name = "lstDepGoller";
            lstDepGoller.Size = new Size(150, 289);
            lstDepGoller.TabIndex = 5;
            // 
            // btnMenuyeDon
            // 
            btnMenuyeDon.Location = new Point(359, 100);
            btnMenuyeDon.Name = "btnMenuyeDon";
            btnMenuyeDon.Size = new Size(94, 23);
            btnMenuyeDon.TabIndex = 7;
            btnMenuyeDon.Text = " Menüye Dön";
            btnMenuyeDon.UseVisualStyleBackColor = true;
            btnMenuyeDon.Click += btnMenuyeDon_Click;
            // 
            // EvMacIstk
            // 
            EvMacIstk.FormattingEnabled = true;
            EvMacIstk.ItemHeight = 15;
            EvMacIstk.Location = new Point(212, 141);
            EvMacIstk.Name = "EvMacIstk";
            EvMacIstk.Size = new Size(150, 289);
            EvMacIstk.TabIndex = 8;
            // 
            // DepMacIstk
            // 
            DepMacIstk.FormattingEnabled = true;
            DepMacIstk.ItemHeight = 15;
            DepMacIstk.Location = new Point(654, 141);
            DepMacIstk.Name = "DepMacIstk";
            DepMacIstk.Size = new Size(150, 289);
            DepMacIstk.TabIndex = 9;
            // 
            // pcbEvLogo3
            // 
            pcbEvLogo3.Location = new Point(31, 33);
            pcbEvLogo3.Name = "pcbEvLogo3";
            pcbEvLogo3.Size = new Size(90, 90);
            pcbEvLogo3.TabIndex = 10;
            pcbEvLogo3.TabStop = false;
            // 
            // pcbDepLogo3
            // 
            pcbDepLogo3.Location = new Point(667, 33);
            pcbDepLogo3.Name = "pcbDepLogo3";
            pcbDepLogo3.Size = new Size(90, 90);
            pcbDepLogo3.TabIndex = 11;
            pcbDepLogo3.TabStop = false;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.StadyumArkaplan;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(828, 456);
            Controls.Add(pcbDepLogo3);
            Controls.Add(pcbEvLogo3);
            Controls.Add(DepMacIstk);
            Controls.Add(EvMacIstk);
            Controls.Add(btnMenuyeDon);
            Controls.Add(lstDepGoller);
            Controls.Add(lstEvGoller);
            Controls.Add(lblSkor);
            Controls.Add(lblDepAd);
            Controls.Add(lblEvAd);
            DoubleBuffered = true;
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)pcbEvLogo3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbDepLogo3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEvAd;
        private Label lblDepAd;
        private Label lblSkor;
        private ListBox lstEvGoller;
        private ListBox lstDepGoller;
        private Button btnMenuyeDon;
        private ListBox EvMacIstk;
        private ListBox DepMacIstk;
        private PictureBox pcbEvLogo3;
        private PictureBox pcbDepLogo3;
    }
}