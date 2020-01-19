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
    public partial class FrmDodajNovuRobu : Form
    {
        BindingList<Roba> robaKor;
        BindingList<Roba> ulozRoba;

        public FrmDodajNovuRobu()
        {
            InitializeComponent();
        }

        // ...#...
        public FrmDodajNovuRobu(BindingList<Roba> robaKorisnika, BindingList<Roba> ulozenaRoba)
        {
            InitializeComponent();
            cbNaziv.DataSource = robaKorisnika.ToList<Roba>();
            robaKor = robaKorisnika;
            ulozRoba = ulozenaRoba;
        }

        // ...#...
        private void tbKolicina_TextChanged(object sender, EventArgs e)
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
                    lblNapomena.Text = "(nije dostupna trazena kolicina)";
                }
            }
            else
            {
                tbKolicina.BackColor = Color.Red;
                lblNapomena.Text = "(morate uneti broj)";
            }
        }

        // ...#...
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ...#...
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if(tbKolicina.BackColor == Color.Green)
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
                MessageBox.Show("Neuspesno dodavanje, pokusajte ponovo!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
