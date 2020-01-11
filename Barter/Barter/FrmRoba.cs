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

        public FrmRoba()
        {
            InitializeComponent();

            listaRobe = Kontroler.Kontroler.Instance.VratiListuRobe(Sesija.Instance.Korisnik, "=");
            dgvRoba.DataSource = listaRobe;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
