namespace Barter
{
    partial class FrmPrijava
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbKorisnickoIme = new System.Windows.Forms.TextBox();
            this.tbSifra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bttPrijaviSe = new System.Windows.Forms.Button();
            this.llRegistrujSe = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 15.75F);
            this.label1.Location = new System.Drawing.Point(50, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Korisnicko ime:";
            // 
            // tbKorisnickoIme
            // 
            this.tbKorisnickoIme.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKorisnickoIme.Location = new System.Drawing.Point(233, 58);
            this.tbKorisnickoIme.Name = "tbKorisnickoIme";
            this.tbKorisnickoIme.Size = new System.Drawing.Size(189, 29);
            this.tbKorisnickoIme.TabIndex = 1;
            this.tbKorisnickoIme.Text = "Rasic10";
            // 
            // tbSifra
            // 
            this.tbSifra.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSifra.Location = new System.Drawing.Point(233, 94);
            this.tbSifra.Name = "tbSifra";
            this.tbSifra.PasswordChar = '*';
            this.tbSifra.Size = new System.Drawing.Size(189, 29);
            this.tbSifra.TabIndex = 3;
            this.tbSifra.Text = "rasic";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 15.75F);
            this.label2.Location = new System.Drawing.Point(50, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sifra: ";
            // 
            // bttPrijaviSe
            // 
            this.bttPrijaviSe.BackColor = System.Drawing.Color.Transparent;
            this.bttPrijaviSe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bttPrijaviSe.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bttPrijaviSe.FlatAppearance.BorderSize = 5;
            this.bttPrijaviSe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bttPrijaviSe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.bttPrijaviSe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttPrijaviSe.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttPrijaviSe.Location = new System.Drawing.Point(132, 147);
            this.bttPrijaviSe.Name = "bttPrijaviSe";
            this.bttPrijaviSe.Size = new System.Drawing.Size(210, 41);
            this.bttPrijaviSe.TabIndex = 10;
            this.bttPrijaviSe.Text = "Prijavi se";
            this.bttPrijaviSe.UseVisualStyleBackColor = false;
            this.bttPrijaviSe.Click += new System.EventHandler(this.bttPrijaviSe_Click);
            // 
            // llRegistrujSe
            // 
            this.llRegistrujSe.AutoSize = true;
            this.llRegistrujSe.BackColor = System.Drawing.Color.Transparent;
            this.llRegistrujSe.Font = new System.Drawing.Font("Cooper Black", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llRegistrujSe.Location = new System.Drawing.Point(129, 191);
            this.llRegistrujSe.Name = "llRegistrujSe";
            this.llRegistrujSe.Size = new System.Drawing.Size(98, 17);
            this.llRegistrujSe.TabIndex = 11;
            this.llRegistrujSe.TabStop = true;
            this.llRegistrujSe.Text = "Registruj se";
            this.llRegistrujSe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRegistrujSe_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClose.FlatAppearance.BorderSize = 5;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(430, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 38);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmPrijava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(472, 221);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.llRegistrujSe);
            this.Controls.Add(this.bttPrijaviSe);
            this.Controls.Add(this.tbSifra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbKorisnickoIme);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPrijava";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPrijava";
            this.Load += new System.EventHandler(this.FrmPrijava_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbKorisnickoIme;
        private System.Windows.Forms.TextBox tbSifra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bttPrijaviSe;
        private System.Windows.Forms.LinkLabel llRegistrujSe;
        private System.Windows.Forms.Button btnClose;
    }
}