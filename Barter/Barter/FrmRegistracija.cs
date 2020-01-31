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
        // Info: Konstruktor za registraciju - zavrseno
        public FrmRegistracija(string title)
        {
            InitializeComponent();
            lblTitle.Text = title;
            if (title == "REGISTRACIJA")
            {
                lblTitle.Location = new Point(152, 2);
                SredjivanjeFrmRegistracija();
            }
        }

        // Info: Konstruktor za profil - zavrseno
        public FrmRegistracija(string title, Korisnik k)
        {
            InitializeComponent();
            lblTitle.Text = title;
            if (title == "PROFIL")
            {
                lblTitle.Location = new Point(212, 3);
                SredjivanjeFrmProfil(k);
            }
        }

        // zavrseno - Problem: postavljenje lokacije
        private void SredjivanjeFrmProfil(Korisnik k)
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
                this.Close();
                throw new ExceptionServer(es.Message);
            }
        }

        // zavrseno
        private void SredjivanjeFrmRegistracija()
        {
            try
            {
                gbSifra.Text = "Sifra:";
                lblStaraSifra.Visible = false;
                tbStaraSifra.Visible = false;
                lblNovaSifra.Text = "Sifra:*";
                lblPotvrdaNoveSifre.Text = "Potvrda sifre:*";
                //cbLokacija.DataSource = Kontroler.Kontroler.Instance.VratiSveLokacije();
                cbLokacija.DataSource = Komunikacija.Instance.VratiLokacije();
            }
            catch (ExceptionServer es)
            {
                MessageBox.Show(es.Message, "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                throw new ExceptionServer("");
            }
        }

        // zavrseno
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // zavrseno
        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            // Registracija - zavrseno
            try
            {
                if (lblTitle.Text == "REGISTRACIJA")
                {
                    if (ValidacijaRegistracije())
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
                        // bool uspesnaReg = Kontroler.Kontroler.Instance.Registracija(k);
                        bool uspesnaReg = Komunikacija.Instance.Registracija(k);
                        if (uspesnaReg)
                        {
                            MessageBox.Show($"Uspesno ste registrovani {k.UsernameKorisnika}", "Registracija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Neuspesna registracija, pokusajte ponovo!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(es.Message, "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                throw new ExceptionServer("");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Profil - zavrseno
            try
            {
                if (lblTitle.Text == "PROFIL")
                {
                    Korisnik noviPodaci = new Korisnik();
                
                    if (PromenaSifre())
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

                    // bool uspesnaIzmenaProfila = Kontroler.Kontroler.Instance.IzmenaProfila(noviPodaci);
                    bool uspesnaIzmenaProfila = Komunikacija.Instance.IzmenaProfila(noviPodaci);

                    if (uspesnaIzmenaProfila)
                    {
                        MessageBox.Show($"Uspesno ste izmenili podatke profila {Sesija.Instance.Korisnik.UsernameKorisnika}", "Profil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Sesija.Instance.Korisnik = noviPodaci;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Neuspesna izmena podataka profila, pokusajte ponovo!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (ExceptionServer es)
            {
                this.Close();
                throw new ExceptionServer(es.Message);
            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message, "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        // zavrseno
        private bool PromenaSifre()
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
                        throw new Exception("Poklapanje nove sifre nije uspesno!");
                    }
                }
                else
                {
                    throw new Exception("Poklapanje stare sifre nije uspesno!");
                }
            }
            else
            {
                return false;
            }
        }

        // zavrseno
        private bool ValidacijaRegistracije()
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
                            MessageBox.Show("Uparivanje sifre nije uspesno, pokusajte ponovo!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Postoji korisnik sa datim korisnickim imenom ili email adresom!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                catch (ExceptionServer es)
                {
                    throw new ExceptionServer("Server je zaustavljen!");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
