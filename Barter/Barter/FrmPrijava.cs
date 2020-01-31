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

        // zavrseno
        private void bttPrijaviSe_Click(object sender, EventArgs e)
        {
            try
            {
                string korIme = tbKorisnickoIme.Text;
                string sifra = tbSifra.Text;
                Korisnik korisnik = new Korisnik
                {
                    UsernameKorisnika = korIme,
                    Sifra = sifra
                };
                //Korisnik k = Kontroler.Kontroler.Instance.Prijava(korisnik); //staro
                Korisnik k = Komunikacija.Instance.PrijavaKorisnika(korisnik);
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
            catch (ExceptionServer es)
            {
                MessageBox.Show(es.Message, "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // zavrseno
        private void llRegistrujSe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                FrmRegistracija forma = new FrmRegistracija("REGISTRACIJA");
                forma.ShowDialog();
            }
            catch (ExceptionServer)
            {
                this.Close();
            }
        }

        // zavrseno
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // zavrseno
        private void FrmPrijava_Load(object sender, EventArgs e)
        {
            if (Komunikacija.Instance.PoveziSe())
            {
                MessageBox.Show("Uspesno ste povezani na server!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Neuspesno povezivanje na server!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
