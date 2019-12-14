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
        private BindingList<Roba> listaRobe = new BindingList<Roba>();
        private Korisnik korisnik = null;

        public FrmGlavna()
        {
            InitializeComponent();

        }

        public FrmGlavna(Korisnik k)
        {
            InitializeComponent();
            korisnik = k;
            listaRobe = Kontroler.Kontroler.Instance.VratiListuRobe(korisnik);
            dataGridView1.DataSource = listaRobe;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttProfil_Click(object sender, EventArgs e)
        {
            FrmRegistracija forma = new FrmRegistracija("PROFIL");
            forma.ShowDialog();
        }

        private void bttUnosRobe_Click(object sender, EventArgs e)
        {
            FrmUnosRobe forma = new FrmUnosRobe();
            forma.ShowDialog();
        }
    }
}
