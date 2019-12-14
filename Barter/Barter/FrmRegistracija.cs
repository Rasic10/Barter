using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barter
{
    public partial class FrmRegistracija : Form
    {
        public FrmRegistracija(string title)
        {
            InitializeComponent();
            lblTitle.Text = title;
            if (title == "REGISTRACIJA")
            {
                lblTitle.Location = new Point(152, 2);
                // treba ukloniti labelu textBox za NovuSifru
                // Problem: pozadina FrmRegistracije treba da funkcionise i za profil i za registraciju
            } else
            {
                lblTitle.Location = new Point(212, 3);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
