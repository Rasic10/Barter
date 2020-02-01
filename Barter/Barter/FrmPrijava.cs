using Domen;
using Kontroler;
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
    public partial class FrmPrijava : Form
    {
        KKIPrijava kontroler = new KKIPrijava();

        // end
        public FrmPrijava()
        {
            InitializeComponent();
            kontroler.FrmClose += FrmClose;
        }

        // end
        private void bttPrijaviSe_Click(object sender, EventArgs e)
        {
            kontroler.PrijaviSe(tbKorisnickoIme.Text, tbSifra.Text);
        }

        // end
        private void llRegistrujSe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kontroler.RegistrujSe();
        }

        // end
        private void btnClose_Click(object sender, EventArgs e)
        {
            FrmClose();
        }

        // end
        private void FrmPrijava_Load(object sender, EventArgs e)
        {
            kontroler.PoveziSe();
        }

        // end
        private void FrmClose()
        {
            this.Close();
        }
    }
}
