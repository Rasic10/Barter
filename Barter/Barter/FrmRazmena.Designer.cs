namespace Barter
{
    partial class FrmRazmena
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
            this.components = new System.ComponentModel.Container();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbKorisnikRobe = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDatumRazmeneRobe = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbCenaRobe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTrazenaKolicinaRobe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDodajRobu = new System.Windows.Forms.Button();
            this.btnObrisiRobu = new System.Windows.Forms.Button();
            this.dgvUlozenaRoba = new System.Windows.Forms.DataGridView();
            this.tbNazivRobe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDostupnaKolicina = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUkupnaCena = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tBarPoklapanjeCene = new System.Windows.Forms.TrackBar();
            this.btnPotvrdiRazmenu = new System.Windows.Forms.Button();
            this.lblNapomena = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.nazivRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cenaRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kolicinaRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.robaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUlozenaRoba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBarPoklapanjeCene)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.robaBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.btnClose.Location = new System.Drawing.Point(561, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 38);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(230, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(163, 31);
            this.lblTitle.TabIndex = 24;
            this.lblTitle.Text = "RAZMENA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 21);
            this.label1.TabIndex = 26;
            this.label1.Text = "Korisnik robe:";
            // 
            // tbKorisnikRobe
            // 
            this.tbKorisnikRobe.Enabled = false;
            this.tbKorisnikRobe.Font = new System.Drawing.Font("Cooper Black", 14.25F);
            this.tbKorisnikRobe.Location = new System.Drawing.Point(328, 43);
            this.tbKorisnikRobe.Name = "tbKorisnikRobe";
            this.tbKorisnikRobe.Size = new System.Drawing.Size(210, 29);
            this.tbKorisnikRobe.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(105, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(217, 21);
            this.label7.TabIndex = 31;
            this.label7.Text = "Datum razmene robe:";
            // 
            // dtpDatumRazmeneRobe
            // 
            this.dtpDatumRazmeneRobe.Enabled = false;
            this.dtpDatumRazmeneRobe.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatumRazmeneRobe.Location = new System.Drawing.Point(328, 78);
            this.dtpDatumRazmeneRobe.Name = "dtpDatumRazmeneRobe";
            this.dtpDatumRazmeneRobe.Size = new System.Drawing.Size(263, 26);
            this.dtpDatumRazmeneRobe.TabIndex = 30;
            this.dtpDatumRazmeneRobe.Value = new System.DateTime(2019, 12, 14, 14, 18, 39, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDostupnaKolicina);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbNazivRobe);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbCenaRobe);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Cooper Black", 11.25F);
            this.groupBox1.Location = new System.Drawing.Point(12, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 92);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podaci o robi";
            // 
            // tbCenaRobe
            // 
            this.tbCenaRobe.Enabled = false;
            this.tbCenaRobe.Font = new System.Drawing.Font("Cooper Black", 11.25F);
            this.tbCenaRobe.Location = new System.Drawing.Point(110, 55);
            this.tbCenaRobe.Name = "tbCenaRobe";
            this.tbCenaRobe.Size = new System.Drawing.Size(182, 25);
            this.tbCenaRobe.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 21);
            this.label4.TabIndex = 28;
            this.label4.Text = "Cena:";
            // 
            // tbTrazenaKolicinaRobe
            // 
            this.tbTrazenaKolicinaRobe.Font = new System.Drawing.Font("Cooper Black", 11.25F);
            this.tbTrazenaKolicinaRobe.Location = new System.Drawing.Point(204, 205);
            this.tbTrazenaKolicinaRobe.Name = "tbTrazenaKolicinaRobe";
            this.tbTrazenaKolicinaRobe.Size = new System.Drawing.Size(148, 25);
            this.tbTrazenaKolicinaRobe.TabIndex = 25;
            this.tbTrazenaKolicinaRobe.TextChanged += new System.EventHandler(this.tbTrazenaKolicinaRobe_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 21);
            this.label5.TabIndex = 26;
            this.label5.Text = "Trazena kolicina:*";
            // 
            // btnDodajRobu
            // 
            this.btnDodajRobu.Font = new System.Drawing.Font("Cooper Black", 11.25F);
            this.btnDodajRobu.Location = new System.Drawing.Point(116, 236);
            this.btnDodajRobu.Name = "btnDodajRobu";
            this.btnDodajRobu.Size = new System.Drawing.Size(160, 30);
            this.btnDodajRobu.TabIndex = 35;
            this.btnDodajRobu.Text = "Dodaj robu";
            this.btnDodajRobu.UseVisualStyleBackColor = true;
            this.btnDodajRobu.Click += new System.EventHandler(this.btnDodajRobu_Click);
            // 
            // btnObrisiRobu
            // 
            this.btnObrisiRobu.Font = new System.Drawing.Font("Cooper Black", 11.25F);
            this.btnObrisiRobu.Location = new System.Drawing.Point(328, 236);
            this.btnObrisiRobu.Name = "btnObrisiRobu";
            this.btnObrisiRobu.Size = new System.Drawing.Size(160, 30);
            this.btnObrisiRobu.TabIndex = 36;
            this.btnObrisiRobu.Text = "Obrisi robu";
            this.btnObrisiRobu.UseVisualStyleBackColor = true;
            this.btnObrisiRobu.Click += new System.EventHandler(this.btnObrisiRobu_Click);
            // 
            // dgvUlozenaRoba
            // 
            this.dgvUlozenaRoba.AllowUserToAddRows = false;
            this.dgvUlozenaRoba.AllowUserToDeleteRows = false;
            this.dgvUlozenaRoba.AutoGenerateColumns = false;
            this.dgvUlozenaRoba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUlozenaRoba.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nazivRobeDataGridViewTextBoxColumn,
            this.cenaRobeDataGridViewTextBoxColumn,
            this.kolicinaRobeDataGridViewTextBoxColumn});
            this.dgvUlozenaRoba.DataSource = this.robaBindingSource;
            this.dgvUlozenaRoba.Location = new System.Drawing.Point(37, 274);
            this.dgvUlozenaRoba.Name = "dgvUlozenaRoba";
            this.dgvUlozenaRoba.Size = new System.Drawing.Size(526, 150);
            this.dgvUlozenaRoba.TabIndex = 37;
            // 
            // tbNazivRobe
            // 
            this.tbNazivRobe.Enabled = false;
            this.tbNazivRobe.Font = new System.Drawing.Font("Cooper Black", 11.25F);
            this.tbNazivRobe.Location = new System.Drawing.Point(110, 24);
            this.tbNazivRobe.Name = "tbNazivRobe";
            this.tbNazivRobe.Size = new System.Drawing.Size(182, 25);
            this.tbNazivRobe.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 33;
            this.label2.Text = "Naziv:";
            // 
            // tbDostupnaKolicina
            // 
            this.tbDostupnaKolicina.Enabled = false;
            this.tbDostupnaKolicina.Font = new System.Drawing.Font("Cooper Black", 11.25F);
            this.tbDostupnaKolicina.Location = new System.Drawing.Point(334, 48);
            this.tbDostupnaKolicina.Name = "tbDostupnaKolicina";
            this.tbDostupnaKolicina.Size = new System.Drawing.Size(182, 25);
            this.tbDostupnaKolicina.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(330, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 21);
            this.label3.TabIndex = 35;
            this.label3.Text = "Dostupna kolicina:";
            // 
            // tbUkupnaCena
            // 
            this.tbUkupnaCena.Enabled = false;
            this.tbUkupnaCena.Font = new System.Drawing.Font("Cooper Black", 11.25F);
            this.tbUkupnaCena.Location = new System.Drawing.Point(362, 451);
            this.tbUkupnaCena.Name = "tbUkupnaCena";
            this.tbUkupnaCena.Size = new System.Drawing.Size(182, 25);
            this.tbUkupnaCena.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(358, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 21);
            this.label6.TabIndex = 37;
            this.label6.Text = "Ukupna cena:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(79, 427);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 21);
            this.label8.TabIndex = 38;
            this.label8.Text = "Razlika u ceni:";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 538);
            this.splitter1.TabIndex = 39;
            this.splitter1.TabStop = false;
            // 
            // tBarPoklapanjeCene
            // 
            this.tBarPoklapanjeCene.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tBarPoklapanjeCene.Enabled = false;
            this.tBarPoklapanjeCene.Location = new System.Drawing.Point(16, 451);
            this.tBarPoklapanjeCene.Maximum = 60;
            this.tBarPoklapanjeCene.Name = "tBarPoklapanjeCene";
            this.tBarPoklapanjeCene.Size = new System.Drawing.Size(282, 45);
            this.tBarPoklapanjeCene.TabIndex = 20;
            this.tBarPoklapanjeCene.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tBarPoklapanjeCene.Value = 30;
            // 
            // btnPotvrdiRazmenu
            // 
            this.btnPotvrdiRazmenu.BackColor = System.Drawing.Color.Transparent;
            this.btnPotvrdiRazmenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPotvrdiRazmenu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPotvrdiRazmenu.FlatAppearance.BorderSize = 5;
            this.btnPotvrdiRazmenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnPotvrdiRazmenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnPotvrdiRazmenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPotvrdiRazmenu.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPotvrdiRazmenu.Location = new System.Drawing.Point(362, 485);
            this.btnPotvrdiRazmenu.Name = "btnPotvrdiRazmenu";
            this.btnPotvrdiRazmenu.Size = new System.Drawing.Size(229, 41);
            this.btnPotvrdiRazmenu.TabIndex = 40;
            this.btnPotvrdiRazmenu.Text = "Potvrdi razmenu";
            this.btnPotvrdiRazmenu.UseVisualStyleBackColor = false;
            // 
            // lblNapomena
            // 
            this.lblNapomena.AutoSize = true;
            this.lblNapomena.Font = new System.Drawing.Font("Cooper Black", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNapomena.Location = new System.Drawing.Point(353, 208);
            this.lblNapomena.Name = "lblNapomena";
            this.lblNapomena.Size = new System.Drawing.Size(24, 17);
            this.lblNapomena.TabIndex = 41;
            this.lblNapomena.Text = "    ";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Barter.Properties.Resources._0003808_e005_smjer_300;
            this.pictureBox3.Location = new System.Drawing.Point(12, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(87, 83);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // nazivRobeDataGridViewTextBoxColumn
            // 
            this.nazivRobeDataGridViewTextBoxColumn.DataPropertyName = "NazivRobe";
            this.nazivRobeDataGridViewTextBoxColumn.HeaderText = "Naziv";
            this.nazivRobeDataGridViewTextBoxColumn.Name = "nazivRobeDataGridViewTextBoxColumn";
            this.nazivRobeDataGridViewTextBoxColumn.Width = 150;
            // 
            // cenaRobeDataGridViewTextBoxColumn
            // 
            this.cenaRobeDataGridViewTextBoxColumn.DataPropertyName = "CenaRobe";
            this.cenaRobeDataGridViewTextBoxColumn.HeaderText = "Cena";
            this.cenaRobeDataGridViewTextBoxColumn.Name = "cenaRobeDataGridViewTextBoxColumn";
            this.cenaRobeDataGridViewTextBoxColumn.Width = 150;
            // 
            // kolicinaRobeDataGridViewTextBoxColumn
            // 
            this.kolicinaRobeDataGridViewTextBoxColumn.DataPropertyName = "KolicinaRobe";
            this.kolicinaRobeDataGridViewTextBoxColumn.HeaderText = "Kolicina";
            this.kolicinaRobeDataGridViewTextBoxColumn.Name = "kolicinaRobeDataGridViewTextBoxColumn";
            this.kolicinaRobeDataGridViewTextBoxColumn.Width = 150;
            // 
            // robaBindingSource
            // 
            this.robaBindingSource.DataSource = typeof(Domen.Roba);
            // 
            // FrmRazmena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(603, 538);
            this.Controls.Add(this.lblNapomena);
            this.Controls.Add(this.btnPotvrdiRazmenu);
            this.Controls.Add(this.tBarPoklapanjeCene);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbUkupnaCena);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvUlozenaRoba);
            this.Controls.Add(this.btnObrisiRobu);
            this.Controls.Add(this.btnDodajRobu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpDatumRazmeneRobe);
            this.Controls.Add(this.tbTrazenaKolicinaRobe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbKorisnikRobe);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRazmena";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRazmena";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUlozenaRoba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBarPoklapanjeCene)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.robaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbKorisnikRobe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDatumRazmeneRobe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbCenaRobe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTrazenaKolicinaRobe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDodajRobu;
        private System.Windows.Forms.TextBox tbDostupnaKolicina;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNazivRobe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnObrisiRobu;
        private System.Windows.Forms.DataGridView dgvUlozenaRoba;
        private System.Windows.Forms.BindingSource robaBindingSource;
        private System.Windows.Forms.TextBox tbUkupnaCena;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TrackBar tBarPoklapanjeCene;
        private System.Windows.Forms.Button btnPotvrdiRazmenu;
        private System.Windows.Forms.Label lblNapomena;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazivRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cenaRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kolicinaRobeDataGridViewTextBoxColumn;
    }
}