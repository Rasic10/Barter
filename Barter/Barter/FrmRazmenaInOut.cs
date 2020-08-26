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
            kontroler.SrediFormu(title, dgvRazmena, lblTitle);
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
            kontroler.exportGridToPdf(dgvRazmena, "Tabela");
            //kontroler.PretragaRobe(tbPretraga.Text, dgvRazmena, lblTitle.Text);
        }

        // end
        private void dgvRazmenaInOut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            kontroler.OnClick(sender, e);
        }
    }
}
