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
    public class KKIDodajNovuRobu
    {
        public event Action FrmClose;
        BindingList<Roba> robaKor;
        BindingList<Roba> ulozRoba;

        internal void SrediFormu(ComboBox cbNaziv, BindingList<Roba> robaKorisnika, BindingList<Roba> ulozenaRoba)
        {
            cbNaziv.DataSource = robaKorisnika.ToList<Roba>();
            robaKor = robaKorisnika;
            ulozRoba = ulozenaRoba;
        }

        internal void ProveraDostupnostiKolicine(TextBox tbKolicina, ComboBox cbNaziv, Label lblNapomena)
        {
            if (double.TryParse(tbKolicina.Text, out double kolicina))
            {
                if (kolicina > 0 && kolicina <= ((Roba)cbNaziv.SelectedItem).KolicinaRobe)
                {
                    tbKolicina.BackColor = Color.Green;
                    lblNapomena.Text = "";
                }
                else
                {
                    tbKolicina.BackColor = Color.Red;
                    lblNapomena.Text = "(nije dostupna tražena količina)";
                }
            }
            else
            {
                tbKolicina.BackColor = Color.Red;
                lblNapomena.Text = "(morate uneti broj)";
            }
        }

        internal void DodajRobu(TextBox tbKolicina, ComboBox cbNaziv)
        {
            if (tbKolicina.BackColor == Color.Green)
            {
                Roba dodaj = (Roba)cbNaziv.SelectedItem;
                Roba r = new Roba
                {
                    //Dodat ID zbog update-a
                    RobaID = dodaj.RobaID,
                    NazivRobe = dodaj.NazivRobe,
                    KolicinaRobe = Convert.ToDouble(tbKolicina.Text),
                    CenaRobe = dodaj.CenaRobe,
                    DatumUnosaRobe = DateTime.Now,
                    KorisnikRobe = dodaj.KorisnikRobe,
                    KategorijaRobe = dodaj.KategorijaRobe,
                    RazmenaUlozeneRobe = new RazmenaRobe()
                };
                dodaj.KolicinaRobe -= r.KolicinaRobe;
                ulozRoba.Add(r);
            }
            else
            {
                MessageBox.Show("Neuspešno dodavanje, pokušajte ponovo!", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
