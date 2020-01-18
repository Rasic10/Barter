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
        Roba trazenaRoba;
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
            trazenaRoba = roba;
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

        // ...#...
        private void btnDodajRobu_Click(object sender, EventArgs e)
        {
            FrmDodajNovuRobu frmDodajNovuRobu = new FrmDodajNovuRobu(robaKorisnika, ulozenaRoba);
            frmDodajNovuRobu.ShowDialog();
        }

        // ...#...
        private void btnObrisiRobu_Click(object sender, EventArgs e)
        {
            if (dgvUlozenaRoba.SelectedRows.Count > 0)
            {
                Roba robaZaBrisanje = (Roba)dgvUlozenaRoba.SelectedRows[0].DataBoundItem;
                foreach(var r in robaKorisnika)
                {
                    if (r.NazivRobe == robaZaBrisanje.NazivRobe)
                    {
                        r.KolicinaRobe += robaZaBrisanje.KolicinaRobe;
                        break;
                    }
                }
                ulozenaRoba.Remove(robaZaBrisanje);
            }
        }

        // ...
        private void btnPotvrdiRazmenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Da li zelite da izvrsite razmenu?", "Pitanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (tbTrazenaKolicinaRobe.BackColor == Color.Green)
                {
                    RazmenaRobe rr = new RazmenaRobe
                    {
                        DatumRazmeneRobe = dtpDatumRazmeneRobe.Value,
                        KolicinaRobe = Convert.ToInt32(tbTrazenaKolicinaRobe.Text),
                        KorisnikTrazeneRobe = trazenaRoba.KorisnikRobe,
                        KorisnikUlozeneRobe = Sesija.Instance.Korisnik,
                        TrazenaRoba = trazenaRoba
                    };

                    bool uspesno = Kontroler.Kontroler.Instance.SacuvajRazmenu(rr, ulozenaRoba);

                    if (uspesno)
                    {
                        MessageBox.Show("Uspesno sacuvana razmena!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Neuspesno sacuvana razmena!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Trazena roba nije lepo uneta!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
        }
    }
}
