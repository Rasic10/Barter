using Domen;
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
    public partial class FrmRazmena : Form
    {
        BindingList<Roba> robaKorisnika = new BindingList<Roba>();
        BindingList<Roba> ulozenaRoba = new BindingList<Roba>();

        public FrmRazmena()
        {

        }

        public FrmRazmena(Korisnik korisnik, Roba roba)
        {
            InitializeComponent();
            SredjivanjeFrmRazmena(korisnik, roba);
        }

        // ...#...
        private void SredjivanjeFrmRazmena(Korisnik korisnik, Roba roba)
        {
            tbKorisnikRobe.Text = roba.KorisnikRobe.UsernameKorisnika;
            dtpDatumRazmeneRobe.Value = DateTime.Now;
            tbNazivRobe.Text = roba.NazivRobe;
            tbCenaRobe.Text = roba.CenaRobe.ToString();
            tbDostupnaKolicina.Text = roba.KolicinaRobe.ToString();
            dgvUlozenaRoba.DataSource = ulozenaRoba;
            robaKorisnika = Kontroler.Kontroler.Instance.VratiListuRobe(Sesija.Instance.Korisnik, "=");
        }

        // ...#...
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ...#...
        private void tbTrazenaKolicinaRobe_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(tbTrazenaKolicinaRobe.Text, out int trazenaKolicinaRobe))
            {
                if (trazenaKolicinaRobe <= Convert.ToDouble(tbDostupnaKolicina.Text))
                {
                    tbTrazenaKolicinaRobe.BackColor = Color.Green;
                    lblNapomena.Text = "";
                    tbUkupnaCena.Text = (Convert.ToDouble(tbCenaRobe.Text) * trazenaKolicinaRobe).ToString();
                }
                else
                {
                    tbTrazenaKolicinaRobe.BackColor = Color.Red;
                    lblNapomena.Text = "(nije dostupna trazena kolicina)";
                    tbUkupnaCena.Text = "";
                }
            }
            else
            {
                tbTrazenaKolicinaRobe.BackColor = Color.Red;
                lblNapomena.Text = "(morate uneti broj)";
                tbUkupnaCena.Text = "";
            }
        }

        private void btnDodajRobu_Click(object sender, EventArgs e)
        {
            FrmDodajNovuRobu frmDodajNovuRobu = new FrmDodajNovuRobu(robaKorisnika, ulozenaRoba);
            frmDodajNovuRobu.ShowDialog();
        }

        private void btnObrisiRobu_Click(object sender, EventArgs e)
        {

        }
    }
}
