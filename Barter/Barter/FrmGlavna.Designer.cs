namespace Barter
{
    partial class FrmGlavna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGlavna));
            this.dgvGlavna = new System.Windows.Forms.DataGridView();
            this.robaIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nazivRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kolicinaRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cenaRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datumUnosaRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.korisnikRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kategorijaRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.robaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.bttProfil = new System.Windows.Forms.Button();
            this.bttRoba = new System.Windows.Forms.Button();
            this.bttUnosRobe = new System.Windows.Forms.Button();
            this.bttRazmenaIn = new System.Windows.Forms.Button();
            this.bttRazmenaOut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlavna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.robaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGlavna
            // 
            this.dgvGlavna.AllowUserToAddRows = false;
            this.dgvGlavna.AllowUserToDeleteRows = false;
            this.dgvGlavna.AutoGenerateColumns = false;
            this.dgvGlavna.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvGlavna.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGlavna.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.robaIDDataGridViewTextBoxColumn,
            this.nazivRobeDataGridViewTextBoxColumn,
            this.kolicinaRobeDataGridViewTextBoxColumn,
            this.cenaRobeDataGridViewTextBoxColumn,
            this.datumUnosaRobeDataGridViewTextBoxColumn,
            this.korisnikRobeDataGridViewTextBoxColumn,
            this.kategorijaRobeDataGridViewTextBoxColumn});
            this.dgvGlavna.DataSource = this.robaBindingSource;
            this.dgvGlavna.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvGlavna.Location = new System.Drawing.Point(248, 227);
            this.dgvGlavna.Name = "dgvGlavna";
            this.dgvGlavna.ReadOnly = true;
            this.dgvGlavna.Size = new System.Drawing.Size(680, 286);
            this.dgvGlavna.TabIndex = 0;
            // 
            // robaIDDataGridViewTextBoxColumn
            // 
            this.robaIDDataGridViewTextBoxColumn.DataPropertyName = "RobaID";
            this.robaIDDataGridViewTextBoxColumn.HeaderText = "RobaID";
            this.robaIDDataGridViewTextBoxColumn.Name = "robaIDDataGridViewTextBoxColumn";
            this.robaIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.robaIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nazivRobeDataGridViewTextBoxColumn
            // 
            this.nazivRobeDataGridViewTextBoxColumn.DataPropertyName = "NazivRobe";
            this.nazivRobeDataGridViewTextBoxColumn.HeaderText = "Naziv";
            this.nazivRobeDataGridViewTextBoxColumn.Name = "nazivRobeDataGridViewTextBoxColumn";
            this.nazivRobeDataGridViewTextBoxColumn.ReadOnly = true;
            this.nazivRobeDataGridViewTextBoxColumn.Width = 120;
            // 
            // kolicinaRobeDataGridViewTextBoxColumn
            // 
            this.kolicinaRobeDataGridViewTextBoxColumn.DataPropertyName = "KolicinaRobe";
            this.kolicinaRobeDataGridViewTextBoxColumn.HeaderText = "Kolicina";
            this.kolicinaRobeDataGridViewTextBoxColumn.Name = "kolicinaRobeDataGridViewTextBoxColumn";
            this.kolicinaRobeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cenaRobeDataGridViewTextBoxColumn
            // 
            this.cenaRobeDataGridViewTextBoxColumn.DataPropertyName = "CenaRobe";
            this.cenaRobeDataGridViewTextBoxColumn.HeaderText = "Cena";
            this.cenaRobeDataGridViewTextBoxColumn.Name = "cenaRobeDataGridViewTextBoxColumn";
            this.cenaRobeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // datumUnosaRobeDataGridViewTextBoxColumn
            // 
            this.datumUnosaRobeDataGridViewTextBoxColumn.DataPropertyName = "DatumUnosaRobe";
            this.datumUnosaRobeDataGridViewTextBoxColumn.HeaderText = "Datum unosa robe";
            this.datumUnosaRobeDataGridViewTextBoxColumn.Name = "datumUnosaRobeDataGridViewTextBoxColumn";
            this.datumUnosaRobeDataGridViewTextBoxColumn.ReadOnly = true;
            this.datumUnosaRobeDataGridViewTextBoxColumn.Width = 120;
            // 
            // korisnikRobeDataGridViewTextBoxColumn
            // 
            this.korisnikRobeDataGridViewTextBoxColumn.DataPropertyName = "KorisnikRobe";
            this.korisnikRobeDataGridViewTextBoxColumn.HeaderText = "Korisnik";
            this.korisnikRobeDataGridViewTextBoxColumn.Name = "korisnikRobeDataGridViewTextBoxColumn";
            this.korisnikRobeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kategorijaRobeDataGridViewTextBoxColumn
            // 
            this.kategorijaRobeDataGridViewTextBoxColumn.DataPropertyName = "KategorijaRobe";
            this.kategorijaRobeDataGridViewTextBoxColumn.HeaderText = "KategorijaRobe";
            this.kategorijaRobeDataGridViewTextBoxColumn.Name = "kategorijaRobeDataGridViewTextBoxColumn";
            this.kategorijaRobeDataGridViewTextBoxColumn.ReadOnly = true;
            this.kategorijaRobeDataGridViewTextBoxColumn.Visible = false;
            // 
            // robaBindingSource
            // 
            this.robaBindingSource.DataSource = typeof(Domen.Roba);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Barter.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(955, 141);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Barter.Properties.Resources.transportna_kutija_600x400x400mm;
            this.pictureBox2.Location = new System.Drawing.Point(955, 216);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 69);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Barter.Properties.Resources.plusKutija;
            this.pictureBox3.Location = new System.Drawing.Point(955, 291);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(76, 69);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Barter.Properties.Resources._0003808_e005_smjer_300;
            this.pictureBox4.Location = new System.Drawing.Point(955, 366);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(76, 69);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::Barter.Properties.Resources._5006_500x500;
            this.pictureBox5.Location = new System.Drawing.Point(955, 441);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(76, 69);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // bttProfil
            // 
            this.bttProfil.BackColor = System.Drawing.Color.Transparent;
            this.bttProfil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bttProfil.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bttProfil.FlatAppearance.BorderSize = 5;
            this.bttProfil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bttProfil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.bttProfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttProfil.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttProfil.Location = new System.Drawing.Point(1040, 141);
            this.bttProfil.Name = "bttProfil";
            this.bttProfil.Size = new System.Drawing.Size(128, 69);
            this.bttProfil.TabIndex = 9;
            this.bttProfil.Text = "Profil";
            this.bttProfil.UseVisualStyleBackColor = false;
            this.bttProfil.Click += new System.EventHandler(this.bttProfil_Click);
            // 
            // bttRoba
            // 
            this.bttRoba.BackColor = System.Drawing.Color.Transparent;
            this.bttRoba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bttRoba.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bttRoba.FlatAppearance.BorderSize = 5;
            this.bttRoba.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bttRoba.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.bttRoba.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttRoba.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttRoba.Location = new System.Drawing.Point(1040, 216);
            this.bttRoba.Name = "bttRoba";
            this.bttRoba.Size = new System.Drawing.Size(128, 69);
            this.bttRoba.TabIndex = 10;
            this.bttRoba.Text = "Roba";
            this.bttRoba.UseVisualStyleBackColor = false;
            this.bttRoba.Click += new System.EventHandler(this.bttRoba_Click);
            // 
            // bttUnosRobe
            // 
            this.bttUnosRobe.BackColor = System.Drawing.Color.Transparent;
            this.bttUnosRobe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bttUnosRobe.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bttUnosRobe.FlatAppearance.BorderSize = 5;
            this.bttUnosRobe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bttUnosRobe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.bttUnosRobe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttUnosRobe.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttUnosRobe.Location = new System.Drawing.Point(1040, 291);
            this.bttUnosRobe.Name = "bttUnosRobe";
            this.bttUnosRobe.Size = new System.Drawing.Size(128, 69);
            this.bttUnosRobe.TabIndex = 11;
            this.bttUnosRobe.Text = "Unos\r\nrobe";
            this.bttUnosRobe.UseVisualStyleBackColor = false;
            this.bttUnosRobe.Click += new System.EventHandler(this.bttUnosRobe_Click);
            // 
            // bttRazmenaIn
            // 
            this.bttRazmenaIn.BackColor = System.Drawing.Color.Transparent;
            this.bttRazmenaIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bttRazmenaIn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bttRazmenaIn.FlatAppearance.BorderSize = 5;
            this.bttRazmenaIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bttRazmenaIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.bttRazmenaIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttRazmenaIn.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttRazmenaIn.Location = new System.Drawing.Point(1040, 366);
            this.bttRazmenaIn.Name = "bttRazmenaIn";
            this.bttRazmenaIn.Size = new System.Drawing.Size(128, 69);
            this.bttRazmenaIn.TabIndex = 12;
            this.bttRazmenaIn.Text = "Razmena\r\nIn";
            this.bttRazmenaIn.UseVisualStyleBackColor = false;
            // 
            // bttRazmenaOut
            // 
            this.bttRazmenaOut.BackColor = System.Drawing.Color.Transparent;
            this.bttRazmenaOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bttRazmenaOut.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bttRazmenaOut.FlatAppearance.BorderSize = 5;
            this.bttRazmenaOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bttRazmenaOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.bttRazmenaOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttRazmenaOut.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttRazmenaOut.Location = new System.Drawing.Point(1040, 441);
            this.bttRazmenaOut.Name = "bttRazmenaOut";
            this.bttRazmenaOut.Size = new System.Drawing.Size(128, 69);
            this.bttRazmenaOut.TabIndex = 13;
            this.bttRazmenaOut.Text = "Razmena\r\nOut";
            this.bttRazmenaOut.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 5;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1138, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 38);
            this.button1.TabIndex = 14;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmGlavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1180, 585);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bttRazmenaOut);
            this.Controls.Add(this.bttRazmenaIn);
            this.Controls.Add(this.bttUnosRobe);
            this.Controls.Add(this.bttRoba);
            this.Controls.Add(this.bttProfil);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvGlavna);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGlavna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barter";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlavna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.robaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGlavna;
        private System.Windows.Forms.BindingSource robaBindingSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button bttProfil;
        private System.Windows.Forms.Button bttRoba;
        private System.Windows.Forms.Button bttUnosRobe;
        private System.Windows.Forms.Button bttRazmenaIn;
        private System.Windows.Forms.Button bttRazmenaOut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn robaIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazivRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kolicinaRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cenaRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumUnosaRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn korisnikRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kategorijaRobeDataGridViewTextBoxColumn;
    }
}

