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
    public partial class FrmGlavna : Form
    {
        KKIGlavna kontroler = new KKIGlavna();

        // end
        public FrmGlavna()
        {
            InitializeComponent();
            kontroler.FrmClose += FrmClose;
        }

        // end
        public FrmGlavna(Korisnik k)
        {
            InitializeComponent();
            kontroler.FrmClose += FrmClose;
            kontroler.SrediFormu(k, dgvGlavna);
        }

        // end
        private void button1_Click(object sender, EventArgs e)
        {
            FrmClose();
        }

        // end
        private void bttProfil_Click(object sender, EventArgs e)
        {
            kontroler.OtvoriFormuProfil();
        }

        // end
        private void bttUnosRobe_Click(object sender, EventArgs e)
        {
            kontroler.OtvoriFormuUnosRobe();
        }

        // end
        private void bttRoba_Click(object sender, EventArgs e)
        {
            kontroler.OtvoriFormuRoba();
        }

        // end
        private void dgvGlavna_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            kontroler.OtvoriFormuRazmena(sender, e);
        }

        // end
        private void FrmClose()
        {
            this.Close();
        }

        // end
        private void bttRazmenaIn_Click(object sender, EventArgs e)
        {
            kontroler.OtvoriFormuRazmenaInOut("RAZMENA IN");
        }

        // end
        private void bttRazmenaOut_Click(object sender, EventArgs e)
        {
            kontroler.OtvoriFormuRazmenaInOut("RAZMENA OUT");
        }

        // end
        private void btnPretraga_Click(object sender, EventArgs e)
        {
            kontroler.PretragaRobe(tbPretraga.Text, dgvGlavna);
        }
    }
}
