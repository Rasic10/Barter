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
        // Info: Konstruktor za registraciju
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

        // Info: Konstruktor za profil
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

        // ...
        private void SredjivanjeFrmProfil(Korisnik k)
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
            cbLokacija.DataSource = Kontroler.Kontroler.Instance.VratiSveLokacije();
        }

        // ...#...
        private void SredjivanjeFrmRegistracija()
        {
            gbSifra.Text = "Sifra:";
            lblStaraSifra.Visible = false;
            tbStaraSifra.Visible = false;
            lblNovaSifra.Text = "Sifra:*";
            lblPotvrdaNoveSifre.Text = "Potvrda sifre:*";
            cbLokacija.DataSource = Kontroler.Kontroler.Instance.VratiSveLokacije();
        }

        // ...#...
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ...
        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            // Registracija
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
                    bool uspesnaReg = Kontroler.Kontroler.Instance.Registracija(k);
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

            // Profil
            if (lblTitle.Text == "PROFIL")
            {
                Korisnik noviPodaci = new Korisnik();
                try
                {
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

                    bool uspesnaIzmenaProfila = Kontroler.Kontroler.Instance.IzmenaProfila(noviPodaci);
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
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message, "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

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
                        throw new Exception("Poklapanje nove sifre nije uspenos!");
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

        private bool ValidacijaRegistracije()
        {
            if (tbKorisnickoIme.Text != "" && tbEmail.Text != "" && tbNovaSifra.Text != "" && tbPotvrdaNoveSifre.Text != "")
            {
                try
                {
                    if (!Kontroler.Kontroler.Instance.ProveraKorisnikaIMaila(tbKorisnickoIme.Text, tbEmail.Text))
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
