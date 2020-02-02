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
    public partial class FrmRazmena : Form
    {
        KKIRazmena kontroler = new KKIRazmena();

        // end
        public FrmRazmena()
        {
            InitializeComponent();
            kontroler.FrmClose += FrmClose;
        }

        // end
        public FrmRazmena(Korisnik korisnik, Roba roba)
        {
            InitializeComponent();
            kontroler.FrmClose += FrmClose;
            kontroler.SrediFormu(korisnik, roba, tbKorisnikRobe, dtpDatumRazmeneRobe, tbNazivRobe, tbCenaRobe, tbDostupnaKolicina, dgvUlozenaRoba);
        }

        // end
        private void btnClose_Click(object sender, EventArgs e)
        {
            FrmClose();
        }

        // end
        private void tbTrazenaKolicinaRobe_TextChanged(object sender, EventArgs e)
        {
            kontroler.ProveraDostupnostiTrazeneRobe(tbTrazenaKolicinaRobe, tbDostupnaKolicina, lblNapomena, tbRazlikaUCeni, tbCenaRobe, tBarPoklapanjeCene);
        }

        // end
        private void btnDodajRobu_Click(object sender, EventArgs e)
        {
            kontroler.DodajNovuRobu(tbRazlikaUCeni);
        }

        // end
        private void btnObrisiRobu_Click(object sender, EventArgs e)
        {
            kontroler.ObrisiRobu(dgvUlozenaRoba, tbRazlikaUCeni);
        }

        // end
        private void btnPotvrdiRazmenu_Click(object sender, EventArgs e)
        {
            kontroler.PotvrdiRazmenu(tbTrazenaKolicinaRobe, dtpDatumRazmeneRobe);
        }

        // end
        private void FrmClose()
        {
            this.Close();
        }

        // end
        private void dgvUlozenaRoba_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            kontroler.SrediRazlikuUCeni(sender, e, tbRazlikaUCeni);
        }

        // end
        private void tbRazlikaUCeni_TextChanged(object sender, EventArgs e)
        {
            kontroler.SrediTrackBar(tBarPoklapanjeCene, tbRazlikaUCeni);
        }
    }
}
