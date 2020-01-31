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

        // zavrseno Problem: treba ucitati samo onu robu koja nije za razmenu
        public FrmRoba()
        {
            InitializeComponent();

            //listaRobe = new BindingList<Roba>(Kontroler.Kontroler.Instance.VratiListuRobe(Sesija.Instance.Korisnik, "="));
            try
            {
                listaRobe = new BindingList<Roba>(Komunikacija.Instance.VratiListuRobe(Sesija.Instance.Korisnik, "="));
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

        // 
        private void btnObrisiRobu_Click(object sender, EventArgs e)
        {

        }
    }
}
