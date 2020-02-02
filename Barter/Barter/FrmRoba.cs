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
        KKIRoba kontroler = new KKIRoba();

        private BindingList<Roba> listaRobe = new BindingList<Roba>();

        // end
        public FrmRoba()
        {
            InitializeComponent();
            kontroler.FrmClose += FrmClose;

            kontroler.SrediFormu(dgvRoba);
        }

        // end
        private void btnClose_Click(object sender, EventArgs e)
        {
            FrmClose();
        }

        // end
        private void btnObrisiRobu_Click(object sender, EventArgs e)
        {
            kontroler.ObrisiRobu(dgvRoba);
        }

        // end
        private void button1_Click(object sender, EventArgs e)
        {
            kontroler.IzmeniRobu(dgvRoba);
        }

        // end
        private void FrmClose()
        {
            this.Close();
        }
    }
}
