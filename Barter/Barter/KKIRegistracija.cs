using Domen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barter
{
    public class KKIRegistracija
    {
        public event Action FrmClose;

        internal void PrikazRegistracije(Label lblTitle, string title, GroupBox gbSifra, Label lblStaraSifra, TextBox tbStaraSifra, Label lblNovaSifra, Label lblPotvrdaNoveSifre, ComboBox cbLokacija)
        {
            lblTitle.Text = title;
            if (title == "REGISTRACIJA")
            {
                lblTitle.Location = new Point(152, 2);
                SredjivanjeFrmRegistracija(gbSifra, lblStaraSifra, tbStaraSifra, lblNovaSifra, lblPotvrdaNoveSifre, cbLokacija);
            }
            else
            {
                MessageBox.Show("Došlo je do greške!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmClose();
            }
        }

        internal void PrikazProfila(Label lblTitle, Korisnik k, string title, TextBox tbKorisnickoIme, TextBox tbEmail, TextBox tbIme, TextBox tbPrezime, TextBox tbAdresa, DateTimePicker dtpDatumRodjenja, ComboBox cbLokacija)
        {
            lblTitle.Text = title;
            if (title == "PROFIL")
            {
                lblTitle.Location = new Point(212, 3);
                SredjivanjeFrmProfil(k, title, tbKorisnickoIme, tbEmail, tbIme, tbPrezime, tbAdresa, dtpDatumRodjenja, cbLokacija);
            }
            else
            {
                MessageBox.Show("Došlo je do greške!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmClose();
            }
        }

        private void SredjivanjeFrmProfil(Korisnik k, string title, TextBox tbKorisnickoIme, TextBox tbEmail, TextBox tbIme, TextBox tbPrezime, TextBox tbAdresa, DateTimePicker dtpDatumRodjenja, ComboBox cbLokacija)
        {
            try
            {
                tbKorisnickoIme.Text = k.UsernameKorisnika;
                tbKorisnickoIme.Enabled = false;
                tbEmail.Text = k.Email;
                tbEmail.Enabled = false;
                tbIme.Text = k.ImeKorisnika;
                tbPrezime.Text = k.PrezimeKorisnika;
                tbAdresa.Text = k.Adresa;
                dtpDatumRodjenja.Value = k.DatumRodjenja;
                // Problem: postavi lokaciju na datu lokaciju
                // cbLokacija.DataSource = Kontroler.Kontroler.Instance.VratiSveLokacije();
                cbLokacija.DataSource = Komunikacija.Instance.VratiLokacije();
            }
            catch (ExceptionServer es)
            {
                FrmClose();
                throw new ExceptionServer(es.Message);
            }
        }

        private void SredjivanjeFrmRegistracija(GroupBox gbSifra, Label lblStaraSifra, TextBox tbStaraSifra, Label lblNovaSifra, Label lblPotvrdaNoveSifre, ComboBox cbLokacija)
        {
            try
            {
                gbSifra.Text = "Šifra:";
                lblStaraSifra.Visible = false;
                tbStaraSifra.Visible = false;
                lblNovaSifra.Text = "Šifra:*";
                lblPotvrdaNoveSifre.Text = "Potvrda šifre:*";
                cbLokacija.DataSource = Komunikacija.Instance.VratiLokacije();
            }
            catch (ExceptionServer es)
            {
                MessageBox.Show(es.Message, "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmClose();
                throw new ExceptionServer("");
            }
        }

        internal void Potvrdi(Label lblTitle, TextBox tbKorisnickoIme, TextBox tbEmail, TextBox tbIme, TextBox tbPrezime, TextBox tbAdresa, DateTimePicker dtpDatumRodjenja, ComboBox cbLokacija, TextBox tbNovaSifra, TextBox tbPotvrdaNoveSifre, TextBox tbStaraSifra)
        {
            // Registracija - end
            try
            {
                if (lblTitle.Text == "REGISTRACIJA")
                {
                    if (ValidacijaRegistracije(tbKorisnickoIme, tbEmail, tbNovaSifra, tbPotvrdaNoveSifre))
                    {
                        DateTime datumRodjenja = dtpDatumRodjenja.Value;
                        if (datumRodjenja.Year > DateTime.Now.Year - 18)
                        {
                            MessageBox.Show("Korisnik mora da bude stariji od 18 godina!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        Lokacija lokacija = (Lokacija)cbLokacija.SelectedItem;

                        Korisnik k = new Korisnik
                        {
                            UsernameKorisnika = tbKorisnickoIme.Text,
                            ImeKorisnika = tbIme.Text,
                            PrezimeKorisnika = tbPrezime.Text,
                            Email = tbEmail.Text,
                            Sifra = tbNovaSifra.Text,
                            DatumRodjenja = datumRodjenja,
                            Adresa = tbAdresa.Text,
                            Lokacija = lokacija
                        };

                        bool uspesnaRegistracija = Komunikacija.Instance.Registracija(k);

                        if (uspesnaRegistracija)
                        {
                            MessageBox.Show($"Novi korisnik je dodat u sistem!", "Registracija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FrmClose();
                        }
                        else
                        {
                            MessageBox.Show("Neuspešna registracija, pokušajte ponovo!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (ExceptionServer es)
            {
                MessageBox.Show(es.Message, "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmClose();
                throw new ExceptionServer("");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Profil - end
            try
            {
                if (lblTitle.Text == "PROFIL")
                {
                    Korisnik noviPodaci = new Korisnik();

                    if (PromenaSifre(tbNovaSifra, tbPotvrdaNoveSifre, tbStaraSifra))
                    {
                        noviPodaci.Sifra = tbNovaSifra.Text;
                    }
                    else
                    {
                        noviPodaci.Sifra = Sesija.Instance.Korisnik.Sifra;
                    }

                    DateTime datumRodjenja = dtpDatumRodjenja.Value;
                    if (datumRodjenja.Year > DateTime.Now.Year - 18)
                    {
                        MessageBox.Show("Korisnik mora da bude stariji od 18 godina!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    Lokacija lokacija = (Lokacija)cbLokacija.SelectedItem;

                    noviPodaci.KorisnikID = Sesija.Instance.Korisnik.KorisnikID;
                    noviPodaci.UsernameKorisnika = Sesija.Instance.Korisnik.UsernameKorisnika;
                    noviPodaci.Email = Sesija.Instance.Korisnik.Email;
                    noviPodaci.ImeKorisnika = tbIme.Text;
                    noviPodaci.PrezimeKorisnika = tbPrezime.Text;
                    noviPodaci.DatumRodjenja = datumRodjenja;
                    noviPodaci.Adresa = tbAdresa.Text;
                    noviPodaci.Lokacija = lokacija;

                    bool uspesnaIzmenaProfila = Komunikacija.Instance.IzmenaProfila(noviPodaci);

                    if (uspesnaIzmenaProfila)
                    {
                        MessageBox.Show($"Uspešno ste izmenili podatke profila {Sesija.Instance.Korisnik.UsernameKorisnika}", "Profil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Sesija.Instance.Korisnik = noviPodaci;
                        FrmClose();
                    }
                    else
                    {
                        MessageBox.Show("Neuspešna izmena podataka profila, pokušajte ponovo!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (ExceptionServer es)
            {
                FrmClose();
                throw new ExceptionServer(es.Message);
            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message, "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private bool PromenaSifre(TextBox tbNovaSifra, TextBox tbPotvrdaNoveSifre, TextBox tbStaraSifra)
        {
            if (tbNovaSifra.Text != "")
            {
                if (tbStaraSifra.Text == Sesija.Instance.Korisnik.Sifra)
                {
                    if (tbNovaSifra.Text == tbPotvrdaNoveSifre.Text)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("Poklapanje nove šifre nije uspešno!");
                    }
                }
                else
                {
                    throw new Exception("Poklapanje stare šifre nije uspešno!");
                }
            }
            else
            {
                return false;
            }
        }

        private bool ValidacijaRegistracije(TextBox tbKorisnickoIme, TextBox tbEmail, TextBox tbNovaSifra, TextBox tbPotvrdaNoveSifre)
        {
            if (tbKorisnickoIme.Text != "" && tbEmail.Text != "" && tbNovaSifra.Text != "" && tbPotvrdaNoveSifre.Text != "")
            {
                try
                {
                    //if (!Kontroler.Kontroler.Instance.ProveraKorisnikaIMaila(new Korisnik { UsernameKorisnika = tbKorisnickoIme.Text, Email = tbEmail.Text }))
                    if (!Komunikacija.Instance.ProveraKorisnikaIMaila(new Korisnik { UsernameKorisnika = tbKorisnickoIme.Text, Email = tbEmail.Text }))
                    {
                        if (tbNovaSifra.Text == tbPotvrdaNoveSifre.Text)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Uparivanje šifre nije uspešno, pokušajte ponovo!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Postoji korisnik sa datim korisničkim imenom ili email adresom!", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                catch (ExceptionServer es)
                {
                    throw new ExceptionServer(es.Message);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Niste uneli obavezna polja koja su obelezena sa * !", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}
