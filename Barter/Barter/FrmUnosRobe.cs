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
        KKIUnosRobe kontroler = new KKIUnosRobe();
        BindingList<Kategorija> kategorije;

        // end
        public FrmUnosRobe()
        {
            InitializeComponent();
            kontroler.FrmClose += FrmClose;
            kontroler.SrediFormu(dtpDatumUnosaRobe, cbKategorija);
        }

        // end
        private void btnClose_Click(object sender, EventArgs e)
        {
            FrmClose();
        }

        // end
        private void btnUnesiKategoriju_Click(object sender, EventArgs e)
        {
            kontroler.UnesiKategoriju(tbNazivKategorije, cbKategorija);
        }

        // end
        private void btnUnesiRobu_Click(object sender, EventArgs e)
        {
            kontroler.UnesiRobu(tbNazivRobe, tbKolicinaRobe, tbCenaRobe, dtpDatumUnosaRobe, cbKategorija);
        }

        // end
        private void FrmClose()
        {
            this.Close();
        }
    }
}
