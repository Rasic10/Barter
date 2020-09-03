namespace Barter
{
    partial class FrmRazmenaInOut
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
            this.dgvRazmena = new System.Windows.Forms.DataGridView();
            this.btnPretraga = new System.Windows.Forms.Button();
            this.tbPretraga = new System.Windows.Forms.TextBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.razmenaRobeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trazenaRobaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kolicinaRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datumRazmeneRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.korisnikTrazeneRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.korisnikUlozeneRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UlozenaRoba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccept = new System.Windows.Forms.DataGridViewImageColumn();
            this.colCancel = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnPotvrdi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnObrisi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonPdf = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRazmena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.razmenaRobeBindingSource)).BeginInit();
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
            this.btnClose.Location = new System.Drawing.Point(879, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 38);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(257, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(204, 31);
            this.lblTitle.TabIndex = 25;
            this.lblTitle.Text = "RAZMENA IN";
            // 
            // dgvRazmena
            // 
            this.dgvRazmena.AllowUserToAddRows = false;
            this.dgvRazmena.AllowUserToDeleteRows = false;
            this.dgvRazmena.AutoGenerateColumns = false;
            this.dgvRazmena.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRazmena.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.trazenaRobaDataGridViewTextBoxColumn,
            this.kolicinaRobeDataGridViewTextBoxColumn,
            this.datumRazmeneRobeDataGridViewTextBoxColumn,
            this.korisnikTrazeneRobeDataGridViewTextBoxColumn,
            this.korisnikUlozeneRobeDataGridViewTextBoxColumn,
            this.UlozenaRoba,
            this.colAccept,
            this.colCancel,
            this.btnPotvrdi,
            this.btnObrisi,
            this.buttonPdf});
            this.dgvRazmena.DataSource = this.razmenaRobeBindingSource;
            this.dgvRazmena.Location = new System.Drawing.Point(12, 84);
            this.dgvRazmena.Name = "dgvRazmena";
            this.dgvRazmena.ReadOnly = true;
            this.dgvRazmena.Size = new System.Drawing.Size(909, 268);
            this.dgvRazmena.TabIndex = 26;
            this.dgvRazmena.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRazmenaInOut_CellContentClick);
            // 
            // btnPretraga
            // 
            this.btnPretraga.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPretraga.Location = new System.Drawing.Point(549, 45);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(143, 33);
            this.btnPretraga.TabIndex = 28;
            this.btnPretraga.Text = "Pretraga";
            this.btnPretraga.UseVisualStyleBackColor = true;
            this.btnPretraga.Click += new System.EventHandler(this.btnPretraga_Click);
            // 
            // tbPretraga
            // 
            this.tbPretraga.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPretraga.Location = new System.Drawing.Point(12, 48);
            this.tbPretraga.Name = "tbPretraga";
            this.tbPretraga.Size = new System.Drawing.Size(531, 26);
            this.tbPretraga.TabIndex = 27;
            this.tbPretraga.Text = "Pretraga po nazivu robe...";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Column1";
            this.dataGridViewImageColumn1.Image = global::Barter.Properties.Resources.pngwing_com;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::Barter.Properties.Resources.pngwing_com__1_;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            // 
            // razmenaRobeBindingSource
            // 
            this.razmenaRobeBindingSource.DataSource = typeof(Domen.RazmenaRobe);
            // 
            // trazenaRobaDataGridViewTextBoxColumn
            // 
            this.trazenaRobaDataGridViewTextBoxColumn.DataPropertyName = "TrazenaRoba";
            this.trazenaRobaDataGridViewTextBoxColumn.HeaderText = "Trazena roba";
            this.trazenaRobaDataGridViewTextBoxColumn.Name = "trazenaRobaDataGridViewTextBoxColumn";
            this.trazenaRobaDataGridViewTextBoxColumn.ReadOnly = true;
            this.trazenaRobaDataGridViewTextBoxColumn.Width = 120;
            // 
            // kolicinaRobeDataGridViewTextBoxColumn
            // 
            this.kolicinaRobeDataGridViewTextBoxColumn.DataPropertyName = "KolicinaRobe";
            this.kolicinaRobeDataGridViewTextBoxColumn.HeaderText = "Kolicina robe";
            this.kolicinaRobeDataGridViewTextBoxColumn.Name = "kolicinaRobeDataGridViewTextBoxColumn";
            this.kolicinaRobeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // datumRazmeneRobeDataGridViewTextBoxColumn
            // 
            this.datumRazmeneRobeDataGridViewTextBoxColumn.DataPropertyName = "DatumRazmeneRobe";
            this.datumRazmeneRobeDataGridViewTextBoxColumn.HeaderText = "Datum";
            this.datumRazmeneRobeDataGridViewTextBoxColumn.Name = "datumRazmeneRobeDataGridViewTextBoxColumn";
            this.datumRazmeneRobeDataGridViewTextBoxColumn.ReadOnly = true;
            this.datumRazmeneRobeDataGridViewTextBoxColumn.Width = 80;
            // 
            // korisnikTrazeneRobeDataGridViewTextBoxColumn
            // 
            this.korisnikTrazeneRobeDataGridViewTextBoxColumn.DataPropertyName = "KorisnikTrazeneRobe";
            this.korisnikTrazeneRobeDataGridViewTextBoxColumn.HeaderText = "Korisnik trazene robe";
            this.korisnikTrazeneRobeDataGridViewTextBoxColumn.Name = "korisnikTrazeneRobeDataGridViewTextBoxColumn";
            this.korisnikTrazeneRobeDataGridViewTextBoxColumn.ReadOnly = true;
            this.korisnikTrazeneRobeDataGridViewTextBoxColumn.Width = 132;
            // 
            // korisnikUlozeneRobeDataGridViewTextBoxColumn
            // 
            this.korisnikUlozeneRobeDataGridViewTextBoxColumn.DataPropertyName = "KorisnikUlozeneRobe";
            this.korisnikUlozeneRobeDataGridViewTextBoxColumn.HeaderText = "Korisnik ulozene robe";
            this.korisnikUlozeneRobeDataGridViewTextBoxColumn.Name = "korisnikUlozeneRobeDataGridViewTextBoxColumn";
            this.korisnikUlozeneRobeDataGridViewTextBoxColumn.ReadOnly = true;
            this.korisnikUlozeneRobeDataGridViewTextBoxColumn.Width = 132;
            // 
            // UlozenaRoba
            // 
            this.UlozenaRoba.HeaderText = "Ulozena roba";
            this.UlozenaRoba.Name = "UlozenaRoba";
            this.UlozenaRoba.ReadOnly = true;
            // 
            // colAccept
            // 
            this.colAccept.HeaderText = "";
            this.colAccept.Image = global::Barter.Properties.Resources.pngwing_com;
            this.colAccept.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colAccept.Name = "colAccept";
            this.colAccept.ReadOnly = true;
            this.colAccept.Visible = false;
            this.colAccept.Width = 30;
            // 
            // colCancel
            // 
            this.colCancel.HeaderText = "";
            this.colCancel.Image = global::Barter.Properties.Resources.pngwing_com__1_;
            this.colCancel.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colCancel.Name = "colCancel";
            this.colCancel.ReadOnly = true;
            this.colCancel.Visible = false;
            this.colCancel.Width = 30;
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.HeaderText = "Potvrdi";
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.ReadOnly = true;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseColumnTextForButtonValue = true;
            this.btnPotvrdi.Width = 80;
            // 
            // btnObrisi
            // 
            this.btnObrisi.HeaderText = "Obrisi";
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.ReadOnly = true;
            this.btnObrisi.Text = "Obrisi";
            this.btnObrisi.UseColumnTextForButtonValue = true;
            this.btnObrisi.Width = 80;
            // 
            // buttonPdf
            // 
            this.buttonPdf.HeaderText = "PDF";
            this.buttonPdf.Name = "buttonPdf";
            this.buttonPdf.ReadOnly = true;
            this.buttonPdf.Text = "PDF";
            this.buttonPdf.UseColumnTextForButtonValue = true;
            this.buttonPdf.Width = 40;
            // 
            // btnPDF
            // 
            this.btnPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.Location = new System.Drawing.Point(778, 45);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(143, 33);
            this.btnPDF.TabIndex = 29;
            this.btnPDF.Text = "Napravi PDF";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // FrmRazmenaInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(933, 373);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnPretraga);
            this.Controls.Add(this.tbPretraga);
            this.Controls.Add(this.dgvRazmena);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRazmenaInOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRazmenaInOut";
            this.Load += new System.EventHandler(this.FrmRazmenaInOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRazmena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.razmenaRobeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvRazmena;
        private System.Windows.Forms.BindingSource razmenaRobeBindingSource;
        private System.Windows.Forms.Button btnPretraga;
        private System.Windows.Forms.TextBox tbPretraga;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn trazenaRobaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kolicinaRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumRazmeneRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn korisnikTrazeneRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn korisnikUlozeneRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UlozenaRoba;
        private System.Windows.Forms.DataGridViewImageColumn colAccept;
        private System.Windows.Forms.DataGridViewImageColumn colCancel;
        private System.Windows.Forms.DataGridViewButtonColumn btnPotvrdi;
        private System.Windows.Forms.DataGridViewButtonColumn btnObrisi;
        private System.Windows.Forms.DataGridViewButtonColumn buttonPdf;
        private System.Windows.Forms.Button btnPDF;
    }
}