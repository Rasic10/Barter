using Domen;
using Kontroler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barter
{
    public partial class FrmRegistracija : Form
    {
        KKIRegistracija kontroler = new KKIRegistracija();

        // Info: Konstruktor za registraciju - end
        public FrmRegistracija(string title)
        {
            InitializeComponent();
            kontroler.FrmClose += FrmClose;

            kontroler.PrikazRegistracije(lblTitle, title, gbSifra, lblStaraSifra, tbStaraSifra, lblNovaSifra, lblPotvrdaNoveSifre, cbLokacija);
        }

        // Info: Konstruktor za profil - end
        public FrmRegistracija(string title, Korisnik k)
        {
            InitializeComponent();
            kontroler.FrmClose += FrmClose;

            kontroler.PrikazProfila(lblTitle, k, title, tbKorisnickoIme, tbEmail, tbIme, tbPrezime, tbAdresa, dtpDatumRodjenja, cbLokacija);
        }

        // end
        private void btnClose_Click(object sender, EventArgs e)
        {
            FrmClose();
        }

        // end
        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            kontroler.Potvrdi(lblTitle, tbKorisnickoIme, tbEmail, tbIme, tbPrezime, tbAdresa, dtpDatumRodjenja, cbLokacija, tbNovaSifra, tbPotvrdaNoveSifre, tbStaraSifra);
        }

        // end
        private void FrmClose()
        {
            this.Close();
        }
    }
}
