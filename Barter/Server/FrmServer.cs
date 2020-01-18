using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        private Server server;

        public FrmServer()
        {
            InitializeComponent();
            btnPokreni.Enabled = true;
            btnZaustavi.Enabled = false;
            server = new Server(this);
        }

        // ...#...
        private void btnPokreni_Click(object sender, EventArgs e)
        {
            if (server.Pokreni())
            {
                btnPokreni.Enabled = false;
                btnZaustavi.Enabled = true;
                MessageBox.Show("Server je pokrenut", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nespesno pokretanje servera", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ...#...
        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            if (server.Zaustavi())
            {
                btnPokreni.Enabled = true;
                btnZaustavi.Enabled = false;
                MessageBox.Show("Server je zaustavljen", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nespesno zaustavljanje servera", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
