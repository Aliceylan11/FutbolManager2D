namespace Futbol
{
    partial class Form2
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
            cmbEvSahibi = new ComboBox();
            cmbDeplasman = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            btnMacaBasla = new Button();
            pcbEvLogo = new PictureBox();
            pcbDepLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pcbEvLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbDepLogo).BeginInit();
            SuspendLayout();
            // 
            // cmbEvSahibi
            // 
            cmbEvSahibi.FormattingEnabled = true;
            cmbEvSahibi.Location = new Point(172, 101);
            cmbEvSahibi.Name = "cmbEvSahibi";
            cmbEvSahibi.Size = new Size(121, 23);
            cmbEvSahibi.TabIndex = 0;
            cmbEvSahibi.SelectedIndexChanged += cmbEvSahibi_SelectedIndexChanged;
            // 
            // cmbDeplasman
            // 
            cmbDeplasman.FormattingEnabled = true;
            cmbDeplasman.Location = new Point(377, 101);
            cmbDeplasman.Name = "cmbDeplasman";
            cmbDeplasman.Size = new Size(121, 23);
            cmbDeplasman.TabIndex = 1;
            cmbDeplasman.SelectedIndexChanged += cmbDeplasman_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(172, 67);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 2;
            label1.Text = "Ev Sahibi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(377, 67);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 3;
            label2.Text = "Deplasman";
            // 
            // btnMacaBasla
            // 
            btnMacaBasla.Location = new Point(291, 186);
            btnMacaBasla.Name = "btnMacaBasla";
            btnMacaBasla.Size = new Size(91, 23);
            btnMacaBasla.TabIndex = 4;
            btnMacaBasla.Text = "Maça Başla";
            btnMacaBasla.UseVisualStyleBackColor = true;
            btnMacaBasla.Click += btnMacaBasla_Click;
            // 
            // pcbEvLogo
            // 
            pcbEvLogo.Location = new Point(66, 101);
            pcbEvLogo.Name = "pcbEvLogo";
            pcbEvLogo.Size = new Size(100, 80);
            pcbEvLogo.TabIndex = 5;
            pcbEvLogo.TabStop = false;
            pcbEvLogo.Click += pcbEvLogo_Click;
            // 
            // pcbDepLogo
            // 
            pcbDepLogo.Location = new Point(518, 101);
            pcbDepLogo.Name = "pcbDepLogo";
            pcbDepLogo.Size = new Size(100, 80);
            pcbDepLogo.TabIndex = 6;
            pcbDepLogo.TabStop = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(656, 348);
            Controls.Add(pcbDepLogo);
            Controls.Add(pcbEvLogo);
            Controls.Add(btnMacaBasla);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbDeplasman);
            Controls.Add(cmbEvSahibi);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pcbEvLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbDepLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbEvSahibi;
        private ComboBox cmbDeplasman;
        private Label label1;
        private Label label2;
        private Button btnMacaBasla;
        private PictureBox pcbEvLogo;
        private PictureBox pcbDepLogo;
    }
}