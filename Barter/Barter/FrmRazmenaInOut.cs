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
    public partial class FrmRazmenaInOut : Form
    {
        KKIRazmenaInOut kontroler = new KKIRazmenaInOut();
        public string title = "";

        // end
        public FrmRazmenaInOut()
        {
            InitializeComponent();
            kontroler.FrmClose += FrmClose;
        }

        // end
        public FrmRazmenaInOut(string title)
        {
            InitializeComponent();
            kontroler.FrmClose += FrmClose;
            this.title = title;
        }

        // end
        private void FrmClose()
        {
            this.Close();
        }

        // end
        private void btnClose_Click(object sender, EventArgs e)
        {
            FrmClose();
        }

        // end
        private void btnPretraga_Click(object sender, EventArgs e)
        {
            kontroler.PretragaRobe(tbPretraga.Text, dgvRazmenaTrazeneRobe, lblTitle.Text);
        }

        private void FrmRazmenaInOut_Load(object sender, EventArgs e)
        {
            kontroler.SrediFormu(title, lblTitle, lblOpisForme, tabControlRazmena);
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            kontroler.exportGridToPdf(dgvRazmenaTrazeneRobe, "Tabela");
        }

        private void dgvPrihvacenaRazmena_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            kontroler.OnClick(sender, e, dgvPrihvacenaRazmena);
        }

        private void dgvRazmenaTrazeneRobe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            kontroler.OnClick(sender, e, dgvRazmenaTrazeneRobe);
        }

        private void dgvOdbijenaRazmena_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            kontroler.OnClick(sender, e, dgvOdbijenaRazmena);
        }

        private void dgvZavrsenaRazmena_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            kontroler.OnClick(sender, e, dgvZavrsenaRazmena);
        }

        private void dgvArhiviranaRazmena_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            kontroler.OnClick(sender, e, dgvArhiviranaRazmena);
        }
    }
}
