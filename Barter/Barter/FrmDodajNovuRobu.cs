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
    public partial class FrmDodajNovuRobu : Form
    {
        KKIDodajNovuRobu kontroler = new KKIDodajNovuRobu();

        // end
        public FrmDodajNovuRobu()
        {
            InitializeComponent();
            kontroler.FrmClose += FrmClose;
        }

        // end
        public FrmDodajNovuRobu(BindingList<Roba> robaKorisnika, BindingList<Roba> ulozenaRoba, TextBox tbRazlikaUCeni)
        {
            InitializeComponent();
            kontroler.FrmClose += FrmClose;

            kontroler.SrediFormu(cbNaziv, robaKorisnika, ulozenaRoba);
        }

        // end
        private void tbKolicina_TextChanged(object sender, EventArgs e)
        {
            kontroler.ProveraDostupnostiKolicine(tbKolicina, cbNaziv, lblNapomena);
        }

        // end
        private void btnClose_Click(object sender, EventArgs e)
        {
            FrmClose();
        }

        // end
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            kontroler.DodajRobu(tbKolicina, cbNaziv);
        }

        // end
        private void FrmClose()
        {
            this.Close();
        }
    }
}
