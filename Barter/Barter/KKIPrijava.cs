using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barter
{
    public class KKIPrijava
    {
        public event Action FrmClose;

        // end
        internal void PrijaviSe(string korisnickoIme, string korisnikSifra)
        {
            try
            {
                Korisnik korisnik = new Korisnik
                {
                    UsernameKorisnika = korisnickoIme,
                    Sifra = korisnikSifra
                };
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
            }
            catch (ExceptionServer es)
            {
                MessageBox.Show(es.Message, "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmClose();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // end
        internal void RegistrujSe()
        {
            try
            {
                FrmRegistracija forma = new FrmRegistracija("REGISTRACIJA");
                forma.ShowDialog();
            }
            catch (ExceptionServer)
            {
                FrmClose();
            }
        }

        // end
        internal void PoveziSe()
        {
            if (Komunikacija.Instance.PoveziSe())
            {
                MessageBox.Show("Uspesno ste povezani na server!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Neuspesno povezivanje na server!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmClose();
            }
        }
    }
}
