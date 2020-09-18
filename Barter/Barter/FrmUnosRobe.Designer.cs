namespace Barter
{
    partial class FrmUnosRobe
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNazivRobe = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbKategorija = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDatumUnosaRobe = new System.Windows.Forms.DateTimePicker();
            this.tbCenaRobe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbKolicinaRobe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUnesiKategoriju = new System.Windows.Forms.Button();
            this.tbNazivKategorije = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUnesiRobu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Barter.Properties.Resources.plusKutija;
            this.pictureBox3.Location = new System.Drawing.Point(12, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(122, 118);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(204, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(183, 31);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "UNOS ROBE";
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
            this.btnClose.Location = new System.Drawing.Point(546, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 38);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 21);
            this.label1.TabIndex = 23;
            this.label1.Text = "Naziv robe:*";
            // 
            // tbNazivRobe
            // 
            this.tbNazivRobe.Font = new System.Drawing.Font("Cooper Black", 14.25F);
            this.tbNazivRobe.Location = new System.Drawing.Point(277, 73);
            this.tbNazivRobe.Name = "tbNazivRobe";
            this.tbNazivRobe.Size = new System.Drawing.Size(299, 29);
            this.tbNazivRobe.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbKategorija);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpDatumUnosaRobe);
            this.groupBox1.Controls.Add(this.tbCenaRobe);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbKolicinaRobe);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Cooper Black", 11.25F);
            this.groupBox1.Location = new System.Drawing.Point(12, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 178);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podaci o robi";
            // 
            // cbKategorija
            // 
            this.cbKategorija.Font = new System.Drawing.Font("Cooper Black", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKategorija.FormattingEnabled = true;
            this.cbKategorija.Location = new System.Drawing.Point(132, 143);
            this.cbKategorija.Name = "cbKategorija";
            this.cbKategorija.Size = new System.Drawing.Size(160, 25);
            this.cbKategorija.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 21);
            this.label3.TabIndex = 30;
            this.label3.Text = "Kategorija:*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 21);
            this.label7.TabIndex = 29;
            this.label7.Text = "Datum unosa robe:";
            // 
            // dtpDatumUnosaRobe
            // 
            this.dtpDatumUnosaRobe.CustomFormat = "                         dd.MM.yyyy.";
            this.dtpDatumUnosaRobe.Enabled = false;
            this.dtpDatumUnosaRobe.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatumUnosaRobe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumUnosaRobe.Location = new System.Drawing.Point(10, 111);
            this.dtpDatumUnosaRobe.Name = "dtpDatumUnosaRobe";
            this.dtpDatumUnosaRobe.Size = new System.Drawing.Size(282, 26);
            this.dtpDatumUnosaRobe.TabIndex = 28;
            this.dtpDatumUnosaRobe.Value = new System.DateTime(2019, 12, 14, 14, 18, 39, 0);
            // 
            // tbCenaRobe
            // 
            this.tbCenaRobe.Font = new System.Drawing.Font("Cooper Black", 11.25F);
            this.tbCenaRobe.Location = new System.Drawing.Point(110, 56);
            this.tbCenaRobe.Name = "tbCenaRobe";
            this.tbCenaRobe.Size = new System.Drawing.Size(182, 25);
            this.tbCenaRobe.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 28;
            this.label2.Text = "Cena:*";
            // 
            // tbKolicinaRobe
            // 
            this.tbKolicinaRobe.Font = new System.Drawing.Font("Cooper Black", 11.25F);
            this.tbKolicinaRobe.Location = new System.Drawing.Point(110, 21);
            this.tbKolicinaRobe.Name = "tbKolicinaRobe";
            this.tbKolicinaRobe.Size = new System.Drawing.Size(182, 25);
            this.tbKolicinaRobe.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 21);
            this.label4.TabIndex = 26;
            this.label4.Text = "Kolicina:*";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUnesiKategoriju);
            this.groupBox2.Controls.Add(this.tbNazivKategorije);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Cooper Black", 11.25F);
            this.groupBox2.Location = new System.Drawing.Point(319, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 129);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Unos kategorije";
            // 
            // btnUnesiKategoriju
            // 
            this.btnUnesiKategoriju.Location = new System.Drawing.Point(47, 87);
            this.btnUnesiKategoriju.Name = "btnUnesiKategoriju";
            this.btnUnesiKategoriju.Size = new System.Drawing.Size(160, 30);
            this.btnUnesiKategoriju.TabIndex = 34;
            this.btnUnesiKategoriju.Text = "Unesi kategoriju";
            this.btnUnesiKategoriju.UseVisualStyleBackColor = true;
            this.btnUnesiKategoriju.Click += new System.EventHandler(this.btnUnesiKategoriju_Click);
            // 
            // tbNazivKategorije
            // 
            this.tbNazivKategorije.Font = new System.Drawing.Font("Cooper Black", 11.25F);
            this.tbNazivKategorije.Location = new System.Drawing.Point(10, 52);
            this.tbNazivKategorije.Name = "tbNazivKategorije";
            this.tbNazivKategorije.Size = new System.Drawing.Size(241, 25);
            this.tbNazivKategorije.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 21);
            this.label5.TabIndex = 33;
            this.label5.Text = "Naziv kategorije:";
            // 
            // btnUnesiRobu
            // 
            this.btnUnesiRobu.BackColor = System.Drawing.Color.Transparent;
            this.btnUnesiRobu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUnesiRobu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnUnesiRobu.FlatAppearance.BorderSize = 5;
            this.btnUnesiRobu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnUnesiRobu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnUnesiRobu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnesiRobu.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnesiRobu.Location = new System.Drawing.Point(366, 279);
            this.btnUnesiRobu.Name = "btnUnesiRobu";
            this.btnUnesiRobu.Size = new System.Drawing.Size(210, 41);
            this.btnUnesiRobu.TabIndex = 33;
            this.btnUnesiRobu.Text = "Unesi robu";
            this.btnUnesiRobu.UseVisualStyleBackColor = false;
            this.btnUnesiRobu.Click += new System.EventHandler(this.btnUnesiRobu_Click);
            // 
            // FrmUnosRobe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(588, 331);
            this.Controls.Add(this.btnUnesiRobu);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNazivRobe);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUnosRobe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUnosRobe";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNazivRobe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbCenaRobe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbKolicinaRobe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDatumUnosaRobe;
        private System.Windows.Forms.ComboBox cbKategorija;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUnesiKategoriju;
        private System.Windows.Forms.TextBox tbNazivKategorije;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUnesiRobu;
    }
}