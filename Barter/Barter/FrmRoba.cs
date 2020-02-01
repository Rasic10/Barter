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
    public partial class FrmRoba : Form
    {
        private BindingList<Roba> listaRobe = new BindingList<Roba>();

        // zavrseno
        public FrmRoba()
        {
            InitializeComponent();

            //listaRobe = new BindingList<Roba>(Kontroler.Kontroler.Instance.VratiListuRobe(Sesija.Instance.Korisnik, "="));
            try
            {
                listaRobe = new BindingList<Roba>(Komunikacija.Instance.VratiListuRobe(Sesija.Instance.Korisnik, "=").Where(lr => lr.RazmenaUlozeneRobe.RazmenaID == -1).ToList());
                dgvRoba.DataSource = listaRobe;
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
        private void btnObrisiRobu_Click(object sender, EventArgs e)
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
                    this.Close();
                    throw new ExceptionServer(es.Message);
                }
            } 
            else
            {
                MessageBox.Show("Niste oznacili robu za brisanje!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
