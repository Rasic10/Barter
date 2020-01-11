namespace Barter
{
    partial class FrmRoba
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dgvRoba = new System.Windows.Forms.DataGridView();
            this.robaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nazivRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kolicinaRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cenaRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datumUnosaRobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KategorijaRobe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnObrisiRobu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoba)).BeginInit();
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
            this.btnClose.Location = new System.Drawing.Point(558, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 38);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Barter.Properties.Resources.transportna_kutija_600x400x400mm;
            this.pictureBox3.Location = new System.Drawing.Point(12, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(122, 118);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // dgvRoba
            // 
            this.dgvRoba.AllowUserToAddRows = false;
            this.dgvRoba.AllowUserToDeleteRows = false;
            this.dgvRoba.AutoGenerateColumns = false;
            this.dgvRoba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoba.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nazivRobeDataGridViewTextBoxColumn,
            this.kolicinaRobeDataGridViewTextBoxColumn,
            this.cenaRobeDataGridViewTextBoxColumn,
            this.datumUnosaRobeDataGridViewTextBoxColumn,
            this.KategorijaRobe});
            this.dgvRoba.DataSource = this.robaBindingSource;
            this.dgvRoba.Location = new System.Drawing.Point(12, 136);
            this.dgvRoba.Name = "dgvRoba";
            this.dgvRoba.ReadOnly = true;
            this.dgvRoba.Size = new System.Drawing.Size(576, 210);
            this.dgvRoba.TabIndex = 24;
            // 
            // robaBindingSource
            // 
            this.robaBindingSource.DataSource = typeof(Domen.Roba);
            // 
            // nazivRobeDataGridViewTextBoxColumn
            // 
            this.nazivRobeDataGridViewTextBoxColumn.DataPropertyName = "NazivRobe";
            this.nazivRobeDataGridViewTextBoxColumn.HeaderText = "Naziv";
            this.nazivRobeDataGridViewTextBoxColumn.Name = "nazivRobeDataGridViewTextBoxColumn";
            this.nazivRobeDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.datumUnosaRobeDataGridViewTextBoxColumn.Width = 130;
            // 
            // KategorijaRobe
            // 
            this.KategorijaRobe.DataPropertyName = "KategorijaRobe";
            this.KategorijaRobe.HeaderText = "Kategorija";
            this.KategorijaRobe.Name = "KategorijaRobe";
            this.KategorijaRobe.ReadOnly = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(252, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(97, 31);
            this.lblTitle.TabIndex = 25;
            this.lblTitle.Text = "ROBA";
            // 
            // btnObrisiRobu
            // 
            this.btnObrisiRobu.Font = new System.Drawing.Font("Cooper Black", 11.25F);
            this.btnObrisiRobu.Location = new System.Drawing.Point(428, 100);
            this.btnObrisiRobu.Name = "btnObrisiRobu";
            this.btnObrisiRobu.Size = new System.Drawing.Size(160, 30);
            this.btnObrisiRobu.TabIndex = 35;
            this.btnObrisiRobu.Text = "Obrisi robu";
            this.btnObrisiRobu.UseVisualStyleBackColor = true;
            // 
            // FrmRoba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(600, 358);
            this.Controls.Add(this.btnObrisiRobu);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvRoba);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRoba";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRoba";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.robaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView dgvRoba;
        private System.Windows.Forms.BindingSource robaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazivRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kolicinaRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cenaRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumUnosaRobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KategorijaRobe;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnObrisiRobu;
    }
}