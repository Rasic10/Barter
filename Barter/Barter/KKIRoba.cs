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
    public class KKIRoba
    {
        public event Action FrmClose;
        private BindingList<Roba> listaRobe = new BindingList<Roba>();

        // end
        internal void SrediFormu(DataGridView dgvRoba)
        {
            try
            {
                listaRobe = new BindingList<Roba>(Komunikacija.Instance.VratiListuRobe(Sesija.Instance.Korisnik, "=").Where(lr => lr.RazmenaUlozeneRobe.RazmenaID == -1).ToList());
                dgvRoba.DataSource = listaRobe;
            }
            catch (ExceptionServer es)
            {
                FrmClose();
                throw new ExceptionServer(es.Message);
            }
        }

        // end
        internal void ObrisiRobu(DataGridView dgvRoba)
        {
            if (dgvRoba.SelectedRows.Count > 0)
            {
                try
                {
                    Roba robaZaBrisanje = (Roba)dgvRoba.SelectedRows[0].DataBoundItem;
                    if (Komunikacija.Instance.ObrisiRobu(robaZaBrisanje))
                    {
                        listaRobe.Remove(robaZaBrisanje);
                        MessageBox.Show("Roba je uspesno obrisana!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Roba nije uspesno obrisana!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (ExceptionServer es)
                {
                    FrmClose();
                    throw new ExceptionServer(es.Message);
                }
            }
            else
            {
                MessageBox.Show("Niste oznacili robu za brisanje!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 
        internal void IzmeniRobu(DataGridView dgvRoba)
        {
            if (dgvRoba.SelectedRows.Count > 0)
            {
                try
                {
                    Roba robaZaIzmenu = (Roba)dgvRoba.SelectedRows[0].DataBoundItem;
                    robaZaIzmenu.DatumUnosaRobe = DateTime.Now;
                    if (Komunikacija.Instance.IzmeniRobu(robaZaIzmenu))
                    {
                        MessageBox.Show("Roba je uspesno izmenjena!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Roba nije uspesno izmenjena!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (ExceptionServer es)
                {
                    FrmClose();
                    throw new ExceptionServer(es.Message);
                }
            }
            else
            {
                MessageBox.Show("Niste oznacili robu za brisanje!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
