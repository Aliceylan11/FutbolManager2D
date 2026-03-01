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
            SuspendLayout();
            // 
            // lblEvAd
            // 
            lblEvAd.AutoSize = true;
            lblEvAd.Font = new Font("Segoe UI", 18F);
            lblEvAd.Location = new Point(189, 35);
            lblEvAd.Name = "lblEvAd";
            lblEvAd.Size = new Size(107, 32);
            lblEvAd.TabIndex = 0;
            lblEvAd.Text = "Ev sahibi";
            // 
            // lblDepAd
            // 
            lblDepAd.AutoSize = true;
            lblDepAd.Font = new Font("Segoe UI", 18F);
            lblDepAd.Location = new Point(508, 35);
            lblDepAd.Name = "lblDepAd";
            lblDepAd.Size = new Size(133, 32);
            lblDepAd.TabIndex = 2;
            lblDepAd.Text = "Deplasman";
            // 
            // lblSkor
            // 
            lblSkor.AutoSize = true;
            lblSkor.Font = new Font("Segoe UI", 18F);
            lblSkor.Location = new Point(373, 35);
            lblSkor.Name = "lblSkor";
            lblSkor.Size = new Size(50, 32);
            lblSkor.TabIndex = 3;
            lblSkor.Text = "0-0";
            // 
            // lstEvGoller
            // 
            lstEvGoller.FormattingEnabled = true;
            lstEvGoller.ItemHeight = 15;
            lstEvGoller.Location = new Point(31, 81);
            lstEvGoller.Name = "lstEvGoller";
            lstEvGoller.Size = new Size(122, 259);
            lstEvGoller.TabIndex = 4;
            // 
            // lstDepGoller
            // 
            lstDepGoller.FormattingEnabled = true;
            lstDepGoller.ItemHeight = 15;
            lstDepGoller.Location = new Point(508, 81);
            lstDepGoller.Name = "lstDepGoller";
            lstDepGoller.Size = new Size(120, 259);
            lstDepGoller.TabIndex = 5;
            // 
            // btnMenuyeDon
            // 
            btnMenuyeDon.Location = new Point(354, 365);
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
            EvMacIstk.Location = new Point(177, 81);
            EvMacIstk.Name = "EvMacIstk";
            EvMacIstk.Size = new Size(119, 259);
            EvMacIstk.TabIndex = 8;
            // 
            // DepMacIstk
            // 
            DepMacIstk.FormattingEnabled = true;
            DepMacIstk.ItemHeight = 15;
            DepMacIstk.Location = new Point(655, 81);
            DepMacIstk.Name = "DepMacIstk";
            DepMacIstk.Size = new Size(121, 259);
            DepMacIstk.TabIndex = 9;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DepMacIstk);
            Controls.Add(EvMacIstk);
            Controls.Add(btnMenuyeDon);
            Controls.Add(lstDepGoller);
            Controls.Add(lstEvGoller);
            Controls.Add(lblSkor);
            Controls.Add(lblDepAd);
            Controls.Add(lblEvAd);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
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
    }
}