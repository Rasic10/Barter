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
    public class KKIGlavna
    {
        public event Action FrmClose;
        private BindingList<Roba> listaRobe = new BindingList<Roba>();
        private Korisnik korisnik = null;

        // end
        internal void SrediFormu(Korisnik k, DataGridView dgvGlavna)
        {
            try
            {
                korisnik = k;
                listaRobe = new BindingList<Roba>(Komunikacija.Instance.VratiListuRobe(korisnik, "!=").Where(r => r.RazmenaUlozeneRobe.RazmenaID == -1).ToList());
                dgvGlavna.DataSource = listaRobe;

                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                button.Name = "Razmena";
                button.HeaderText = "Razmena";
                button.Text = "Razmeni";
                button.UseColumnTextForButtonValue = true; //ova linija je obavezna

                dgvGlavna.Columns.Add(button);
            }
            catch (ExceptionServer es)
            {
                FrmClose();
                throw new ExceptionServer(es.Message);
            }
        }

        // end
        internal void OtvoriFormuUnosRobe()
        {
            try
            {
                FrmUnosRobe forma = new FrmUnosRobe();
                forma.ShowDialog();
            }
            catch (ExceptionServer es)
            {
                FrmClose();
                throw new ExceptionServer(es.Message);
            }
        }

        // end
        internal void OtvoriFormuRazmena(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                try
                {
                    FrmRazmena frmRazmena = new FrmRazmena(Sesija.Instance.Korisnik, listaRobe[e.RowIndex]);
                    frmRazmena.ShowDialog();
                }
                catch (ExceptionServer es)
                {
                    FrmClose();
                    throw new ExceptionServer(es.Message);
                }
            }
        }

        // end
        internal void OtvoriFormuRoba()
        {
            try
            {
                FrmRoba frmRoba = new FrmRoba();
                frmRoba.ShowDialog();
            }
            catch (ExceptionServer es)
            {
                FrmClose();
                throw new ExceptionServer(es.Message);
            }
        }

        // end
        internal void OtvoriFormuProfil()
        {
            try
            {
                FrmRegistracija forma = new FrmRegistracija("PROFIL", Sesija.Instance.Korisnik);
                forma.ShowDialog();
            }
            catch (ExceptionServer es)
            {
                FrmClose();
                throw new ExceptionServer(es.Message);
            }
        }
    }
}
