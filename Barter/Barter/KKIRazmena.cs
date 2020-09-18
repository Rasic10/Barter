using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

        internal void SrediFormu(IDomenskiObjekat iKorisnik, IDomenskiObjekat iRoba, TextBox tbKorisnikRobe, DateTimePicker dtpDatumRazmeneRobe, TextBox tbNazivRobe, TextBox tbCenaRobe, TextBox tbDostupnaKolicina, DataGridView dgvUlozenaRoba)
        {
            try
            {
                Roba roba;
                Korisnik korisnik;
                if (!(iKorisnik is Korisnik) || !(iRoba is Roba))
                {
                    throw new Exception("Nisu prosleđeni pravi objekti");
                }
                else
                {
                    roba = (Roba)iRoba;
                    korisnik = (Korisnik)iKorisnik;
                }
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
            catch (Exception e)
            {
                Debug.WriteLine(">>> " + e.Message);
                FrmClose();
            }
        }

        internal void DodajNovuRobu(TextBox tbRazlikaUCeni)
        {
            FrmDodajNovuRobu frmDodajNovuRobu = new FrmDodajNovuRobu(robaKorisnika, ulozenaRoba, tbRazlikaUCeni);
            frmDodajNovuRobu.ShowDialog();
        }

        internal void ObrisiRobu(DataGridView dgvUlozenaRoba, TextBox tbRazlikaUCeni)
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

                // smanjivanje razlike u ceni
                tbRazlikaUCeni.Text = (Convert.ToDouble(tbRazlikaUCeni.Text) + robaZaBrisanje.KolicinaRobe * robaZaBrisanje.CenaRobe).ToString(); 
            }
        }

        internal void SrediTrackBar(TrackBar tBarPoklapanjeCene, TextBox tbRazlikaUCeni)
        {
            double razlikaUCeni = Convert.ToDouble(tbRazlikaUCeni.Text);

            if (Math.Abs(Convert.ToInt32(razlikaUCeni) / 10) > 30)
            {
                tBarPoklapanjeCene.Value = Math.Sign(razlikaUCeni) * 30 + 30;
            }
            else
            {
                tBarPoklapanjeCene.Value = Convert.ToInt32(razlikaUCeni) / 10 + 30;
            }
        }

        internal void SrediRazlikuUCeni(object sender, DataGridViewRowsAddedEventArgs e, TextBox tbRazlikaUCeni)
        {
            Roba r = ulozenaRoba[e.RowIndex];
            double razlikaUCeni = Convert.ToDouble(tbRazlikaUCeni.Text);
            razlikaUCeni -= r.KolicinaRobe * r.CenaRobe;
            tbRazlikaUCeni.Text = razlikaUCeni.ToString();
        }

        internal void PotvrdiRazmenu(TextBox tbTrazenaKolicinaRobe, DateTimePicker dtpDatumRazmeneRobe)
        {
            if (MessageBox.Show("Da li želite da izvršite razmenu?", "Pitanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                        UlozenaRoba = ulozenaRoba.ToList(),
                    };

                    bool uspesno = Komunikacija.Instance.SacuvajRazmenu(rr);

                    if (uspesno)
                    {
                        MessageBox.Show("Uspešno sačuvana razmena!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmClose();
                    }
                    else
                    {
                        MessageBox.Show("Neuspešno sačuvana razmena!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Tražena roba nije lepo uneta!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        internal void ProveraDostupnostiTrazeneRobe(TextBox tbTrazenaKolicinaRobe, TextBox tbDostupnaKolicina, Label lblNapomena, TextBox tbRazlikaUCeni, TextBox tbCenaRobe, TrackBar tBarPoklapanjeCene)
        {
            if (int.TryParse(tbTrazenaKolicinaRobe.Text, out int trazenaKolicinaRobe))
            {
                if (trazenaKolicinaRobe <= Convert.ToDouble(tbDostupnaKolicina.Text))
                {
                    tbTrazenaKolicinaRobe.BackColor = Color.Green;
                    lblNapomena.Text = "";

                    double razlikaUCeni = (Convert.ToDouble(tbCenaRobe.Text) * trazenaKolicinaRobe);
                    foreach(var r in ulozenaRoba)
                    {
                        razlikaUCeni -= r.CenaRobe * r.KolicinaRobe;
                    }
                    tbRazlikaUCeni.Text = razlikaUCeni.ToString();
                }
                else
                {
                    tbTrazenaKolicinaRobe.BackColor = Color.Red;
                    lblNapomena.Text = "(nije dostupna tražena količina)";
                    tbRazlikaUCeni.Text = "0";
                }
            }
            else
            {
                tbTrazenaKolicinaRobe.BackColor = Color.Red;
                lblNapomena.Text = "(morate uneti broj)";
                tbRazlikaUCeni.Text = "0";
            }
        }
    }
}
