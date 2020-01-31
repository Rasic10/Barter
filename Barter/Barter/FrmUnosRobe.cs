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

        // zavrseno
        private void SredjivanjeFrmUnosRobe()
        {
            try
            {
                dtpDatumUnosaRobe.Value = DateTime.Now;
                dtpDatumUnosaRobe.Enabled = false;
                //kategorije = new BindingList<Kategorija>(Kontroler.Kontroler.Instance.VratiListuKategorija());
                kategorije = new BindingList<Kategorija>(Komunikacija.Instance.VratiListuKategorija());
                // kategorije = Kontroler.Kontroler.Instance.VratiListuKategorija(); //stara verzija
                cbKategorija.DataSource = kategorije;
            }
            catch (ExceptionServer es)
            {
                this.Close();
                throw new ExceptionServer(es.Message);
            }
        }

        // zavrseno
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // zavrseno
        private void btnUnesiKategoriju_Click(object sender, EventArgs e)
        {
            if(tbNazivKategorije.Text != "")
            {
                Kategorija k = new Kategorija()
                {
                    VrstaKategorije = tbNazivKategorije.Text
                };
                //int uspesnoUnosaKategorije = Kontroler.Kontroler.Instance.UnesiKategoriju(k);
                int uspesanUnosKategorije = Komunikacija.Instance.UnesiKategoriju(k);
                if(uspesanUnosKategorije != -1)
                {
                    MessageBox.Show($"Uspesno uneta kategorija {k.VrstaKategorije}!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    k.KategorijaID = uspesanUnosKategorije;
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

        // zavrseno
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
                    KategorijaRobe = (Kategorija)cbKategorija.SelectedItem,
                    RazmenaUlozeneRobe = null
                };
                //bool uspesnoUnetaRoba = Kontroler.Kontroler.Instance.UnesiRobu(r);
                bool uspesnoUnetaRoba = Komunikacija.Instance.UnesiRobu(r);
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

        // zavrseno
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
