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
                    MessageBox.Show($"Uspešno prijavljen {k.UsernameKorisnika}!");
                    Sesija.Instance.Korisnik = k;
                    FrmGlavna forma = new FrmGlavna(k);
                    forma.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Pogrešno korisničko ime ili šifra!");
                }
            }
            catch (ExceptionServer es)
            {
                MessageBox.Show(es.Message, "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmClose();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        internal void PoveziSe()
        {
            if (Komunikacija.Instance.PoveziSe())
            {
                MessageBox.Show("Uspešno ste povezani na server!", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Neuspešno povezivanje na server!", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmClose();
            }
        }
    }
}
