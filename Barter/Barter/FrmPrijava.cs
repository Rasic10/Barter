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
        public FrmPrijava()
        {
            InitializeComponent();
        }

        private void bttPrijaviSe_Click(object sender, EventArgs e)
        {
            string korIme = tbKorisnickoIme.Text;
            string sifra = tbSifra.Text;
            Korisnik k = Kontroler.Kontroler.Instance.Prijava(korIme, sifra);
            if (k != null)
            {
                MessageBox.Show($"Uspesno prijavljen {k.UsernameKorisnika}!");
                Sesija.Instance.Korisnik = k;
                FrmGlavna forma = new FrmGlavna(k);
                forma.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pogresno korisnicko ime ili sifra!");
            }
            this.Close();
        }

        private void llRegistrujSe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegistracija forma = new FrmRegistracija("REGISTRACIJA");
            forma.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
