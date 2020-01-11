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
    public partial class FrmUnosRobe : Form
    {
        BindingList<Kategorija> kategorije;

        public FrmUnosRobe()
        {
            InitializeComponent();
            SredjivanjeFrmUnosRobe();
        }

        // ...#...
        private void SredjivanjeFrmUnosRobe()
        {
            dtpDatumUnosaRobe.Value = DateTime.Now;
            dtpDatumUnosaRobe.Enabled = false;
            kategorije = Kontroler.Kontroler.Instance.VratiListuKategorija();
            cbKategorija.DataSource = kategorije;
        }

        // ...#...
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ...#...
        private void btnUnesiKategoriju_Click(object sender, EventArgs e)
        {
            if(tbNazivKategorije.Text != "")
            {
                Kategorija k = new Kategorija()
                {
                    VrstaKategorije = tbNazivKategorije.Text
                };
                int uspesnoUnosaKategorije = Kontroler.Kontroler.Instance.UnesiKategoriju(k);
                if(uspesnoUnosaKategorije != -1)
                {
                    MessageBox.Show($"Uspesno uneta kategorija {k.VrstaKategorije}!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    k.KategorijaID = uspesnoUnosaKategorije;
                    kategorije.Add(k);
                    cbKategorija.Refresh();
                    tbNazivKategorije.Text = "";
                }
                else
                {
                    MessageBox.Show($"Neuspesno uneta kategorija {k.VrstaKategorije}!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Niste uneli naziv kategorije!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ...#...
        private void btnUnesiRobu_Click(object sender, EventArgs e)
        {
            if(ValidacijaUnosaRobe(out float kolicina, out float cena))
            {
                DateTime datumUnosaRobe = dtpDatumUnosaRobe.Value;
                Roba r = new Roba()
                {
                    NazivRobe = tbNazivRobe.Text,
                    KolicinaRobe = kolicina,
                    CenaRobe = cena,
                    DatumUnosaRobe = datumUnosaRobe,
                    KorisnikRobe = Sesija.Instance.Korisnik,
                    KategorijaRobe = (Kategorija)cbKategorija.SelectedItem
                };
                bool uspesnoUnetaRoba = Kontroler.Kontroler.Instance.UnesiRobu(r);
                if(uspesnoUnetaRoba)
                {
                    MessageBox.Show($"Uspesno uneta roba {r.NazivRobe}!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Neuspesno uneta roba {r.NazivRobe}!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                return;
            }
        }

        // ...#...
        private bool ValidacijaUnosaRobe(out float k, out float c)
        {
            k = 0;
            c = 0;
            if(tbNazivRobe.Text != "" && tbKolicinaRobe.Text != "" && tbCenaRobe.Text != "")
            {
                if(float.TryParse(tbKolicinaRobe.Text, out float kolicina))
                {
                    if (float.TryParse(tbCenaRobe.Text, out float cena))
                    {
                        k = kolicina;
                        c = cena;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show($"Cena nije uneta u pravom formatu!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show($"Kolicina nije uneta u pravom formatu!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show($"Niste uneli sva obavezna polja oznacena sa * !", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
    }
}
