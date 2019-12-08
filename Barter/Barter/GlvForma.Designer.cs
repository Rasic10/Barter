namespace Barter
{
    partial class GlvForma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlvForma));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.robaIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nazivRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kolicinaRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cenaRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datumUnosaRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.korisnikRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kategorijaRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razmenaUlozeneRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.robaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.robaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.robaIDDataGridViewTextBoxColumn,
            this.nazivRobeDataGridViewTextBoxColumn,
            this.kolicinaRobeDataGridViewTextBoxColumn,
            this.cenaRobeDataGridViewTextBoxColumn,
            this.datumUnosaRobeDataGridViewTextBoxColumn,
            this.korisnikRobeDataGridViewTextBoxColumn,
            this.kategorijaRobeDataGridViewTextBoxColumn,
            this.razmenaUlozeneRobeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.robaBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(262, 222);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(666, 291);
            this.dataGridView1.TabIndex = 0;
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
            // razmenaUlozeneRobeDataGridViewTextBoxColumn
            // 
            this.razmenaUlozeneRobeDataGridViewTextBoxColumn.DataPropertyName = "RazmenaUlozeneRobe";
            this.razmenaUlozeneRobeDataGridViewTextBoxColumn.HeaderText = "Razmena";
            this.razmenaUlozeneRobeDataGridViewTextBoxColumn.Name = "razmenaUlozeneRobeDataGridViewTextBoxColumn";
            this.razmenaUlozeneRobeDataGridViewTextBoxColumn.ReadOnly = true;
            this.razmenaUlozeneRobeDataGridViewTextBoxColumn.Width = 80;
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 5;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1040, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 69);
            this.button1.TabIndex = 9;
            this.button1.Text = "Profil";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 5;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1040, 216);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 69);
            this.button2.TabIndex = 10;
            this.button2.Text = "Roba";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.BorderSize = 5;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1040, 291);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 69);
            this.button3.TabIndex = 11;
            this.button3.Text = "Unos\r\nrobe";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button4.FlatAppearance.BorderSize = 5;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(1040, 366);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 69);
            this.button4.TabIndex = 12;
            this.button4.Text = "Razmena\r\nIn";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button5.FlatAppearance.BorderSize = 5;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(1040, 441);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(128, 69);
            this.button5.TabIndex = 13;
            this.button5.Text = "Razmena\r\nOut";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // GlvForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1180, 585);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GlvForma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.robaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn robaIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazivRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kolicinaRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cenaRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumUnosaRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn korisnikRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kategorijaRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razmenaUlozeneRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource robaBindingSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

