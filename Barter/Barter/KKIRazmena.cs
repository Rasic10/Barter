using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barter
{
    public class KKIRazmena
    {
        public event Action FrmClose;
        Roba trazenaRoba;
        BindingList<Roba> robaKorisnika = new BindingList<Roba>();
        BindingList<Roba> ulozenaRoba = new BindingList<Roba>();

        // end
        internal void SrediFormu(Korisnik korisnik, Roba roba, TextBox tbKorisnikRobe, DateTimePicker dtpDatumRazmeneRobe, TextBox tbNazivRobe, TextBox tbCenaRobe, TextBox tbDostupnaKolicina, DataGridView dgvUlozenaRoba)
        {
            try
            {
                trazenaRoba = roba;
                tbKorisnikRobe.Text = roba.KorisnikRobe.UsernameKorisnika;
                dtpDatumRazmeneRobe.Value = DateTime.Now;
                tbNazivRobe.Text = roba.NazivRobe;
                tbCenaRobe.Text = roba.CenaRobe.ToString();
                tbDostupnaKolicina.Text = roba.KolicinaRobe.ToString();
                dgvUlozenaRoba.DataSource = ulozenaRoba;
                robaKorisnika = new BindingList<Roba>(Komunikacija.Instance.VratiListuRobe(Sesija.Instance.Korisnik, "=").Where(r => r.RazmenaUlozeneRobe.RazmenaID == -1).ToList());
            }
            catch (ExceptionServer es)
            {
                FrmClose();
                throw new ExceptionServer(es.Message);
            }
        }

        // end
        internal void DodajNovuRobu()
        {
            FrmDodajNovuRobu frmDodajNovuRobu = new FrmDodajNovuRobu(robaKorisnika, ulozenaRoba);
            frmDodajNovuRobu.ShowDialog();
        }

        // end
        internal void ObrisiRobu(DataGridView dgvUlozenaRoba)
        {
            if (dgvUlozenaRoba.SelectedRows.Count > 0)
            {
                Roba robaZaBrisanje = (Roba)dgvUlozenaRoba.SelectedRows[0].DataBoundItem;
                foreach (var r in robaKorisnika)
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

        // end
        internal void PotvrdiRazmenu(TextBox tbTrazenaKolicinaRobe, DateTimePicker dtpDatumRazmeneRobe)
        {
            if (MessageBox.Show("Da li zelite da izvrsite razmenu?", "Pitanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (tbTrazenaKolicinaRobe.BackColor == Color.Green)
                {
                    trazenaRoba.KolicinaRobe -= Convert.ToInt32(tbTrazenaKolicinaRobe.Text);
                    RazmenaRobe rr = new RazmenaRobe
                    {
                        DatumRazmeneRobe = dtpDatumRazmeneRobe.Value,
                        KolicinaRobe = Convert.ToInt32(tbTrazenaKolicinaRobe.Text),
                        KorisnikTrazeneRobe = trazenaRoba.KorisnikRobe,
                        KorisnikUlozeneRobe = Sesija.Instance.Korisnik,
                        TrazenaRoba = trazenaRoba,
                        UlozenaRoba = ulozenaRoba.ToList()
                    };

                    bool uspesno = Komunikacija.Instance.SacuvajRazmenu(rr);

                    if (uspesno)
                    {
                        MessageBox.Show("Uspesno sacuvana razmena!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmClose();
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

        // end
        internal void ProveraDostupnostiTrazeneRobe(TextBox tbTrazenaKolicinaRobe, TextBox tbDostupnaKolicina, Label lblNapomena, TextBox tbUkupnaCena, TextBox tbCenaRobe)
        {
            if (int.TryParse(tbTrazenaKolicinaRobe.Text, out int trazenaKolicinaRobe))
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
    }
}
