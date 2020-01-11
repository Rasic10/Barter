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
            // Problem: postavi datum na datum rodjenja
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
                if (ValidacijaProfila())
                {

                }
                else
                {
                    return;
                }
            }
        }

        private bool ValidacijaProfila()
        {
            return false;
        }

        private bool ValidacijaRegistracije()
        {
            if (tbKorisnickoIme.Text != "" && tbEmail.Text != "" && tbNovaSifra.Text != "" && tbPotvrdaNoveSifre.Text != "")
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
                MessageBox.Show("Niste uneli obavezna polja koja su obelezena sa * !", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}
