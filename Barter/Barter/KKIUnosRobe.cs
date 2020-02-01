using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barter
{
    public class KKIUnosRobe
    {
        public event Action FrmClose;
        BindingList<Kategorija> kategorije;

        // end
        internal void SrediFormu(DateTimePicker dtpDatumUnosaRobe, ComboBox cbKategorija)
        {
            try
            {
                dtpDatumUnosaRobe.Value = DateTime.Now;
                dtpDatumUnosaRobe.Enabled = false;
                cbKategorija.DataSource = new BindingList<Kategorija>(Komunikacija.Instance.VratiListuKategorija());
            }
            catch (ExceptionServer es)
            {
                FrmClose();
                throw new ExceptionServer(es.Message);
            }
        }

        // end
        internal void UnesiKategoriju(TextBox tbNazivKategorije, ComboBox cbKategorija)
        {
            if (tbNazivKategorije.Text != "")
            {
                Kategorija k = new Kategorija()
                {
                    VrstaKategorije = tbNazivKategorije.Text
                };

                int uspesanUnosKategorije = Komunikacija.Instance.UnesiKategoriju(k);

                if (uspesanUnosKategorije != -1)
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

        // end
        internal void UnesiRobu(TextBox tbNazivRobe, TextBox tbKolicinaRobe, TextBox tbCenaRobe, DateTimePicker dtpDatumUnosaRobe, ComboBox cbKategorija)
        {
            if (ValidacijaUnosaRobe(out float kolicina, out float cena, tbNazivRobe, tbKolicinaRobe, tbCenaRobe))
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

                bool uspesnoUnetaRoba = Komunikacija.Instance.UnesiRobu(r);

                if (uspesnoUnetaRoba)
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

        // end
        private bool ValidacijaUnosaRobe(out float k, out float c, TextBox tbNazivRobe, TextBox tbKolicinaRobe, TextBox tbCenaRobe)
        {
            k = 0;
            c = 0;
            if (tbNazivRobe.Text != "" && tbKolicinaRobe.Text != "" && tbCenaRobe.Text != "")
            {
                if (float.TryParse(tbKolicinaRobe.Text, out float kolicina))
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
