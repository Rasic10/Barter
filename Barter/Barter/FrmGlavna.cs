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

        // zavrseno
        public FrmGlavna(Korisnik k)
        {
            InitializeComponent();
            try
            {
                korisnik = k;
                //listaRobe = new BindingList<Roba>(Kontroler.Kontroler.Instance.VratiListuRobe(korisnik, "!="));
                listaRobe = new BindingList<Roba>(Komunikacija.Instance.VratiListuRobe(korisnik, "!="));
                dgvGlavna.DataSource = listaRobe;

                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                button.Name = "Razmena";
                button.HeaderText = "Razmena";
                button.Text = "Razmeni";
                button.UseColumnTextForButtonValue = true; //ova linija je obavezna

                this.dgvGlavna.Columns.Add(button);
            }
            catch (ExceptionServer es)
            {
                this.Close();
                throw new ExceptionServer("");
            }
        }

        // zavrseno
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // zavrseno
        private void bttProfil_Click(object sender, EventArgs e)
        {
            try
            {
                FrmRegistracija forma = new FrmRegistracija("PROFIL", Sesija.Instance.Korisnik);
                forma.ShowDialog();
            }
            catch (ExceptionServer es)
            {
                this.Close();
                throw new ExceptionServer(es.Message);
            }
        }

        // zavrseno
        private void bttUnosRobe_Click(object sender, EventArgs e)
        {
            try
            {
                FrmUnosRobe forma = new FrmUnosRobe();
                forma.ShowDialog();
            }
            catch (ExceptionServer es)
            {
                this.Close();
                throw new ExceptionServer(es.Message);
            }
        }
        
        // 
        private void bttRoba_Click(object sender, EventArgs e)
        {
            try
            {
                FrmRoba frmRoba = new FrmRoba();
                frmRoba.ShowDialog();
            }
            catch(ExceptionServer es)
            {
                this.Close();
                throw new ExceptionServer(es.Message);
            }
        }

        // 
        private void dgvGlavna_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                try
                {
                    FrmRazmena frmRazmena = new FrmRazmena(Sesija.Instance.Korisnik, listaRobe[e.RowIndex]);
                    frmRazmena.ShowDialog();
                }
                catch (ExceptionServer es)
                {
                    this.Close();
                    throw new ExceptionServer(es.Message);
                }
            }
        }
    }
}
