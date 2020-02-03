using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barter
{
    public class KKIRazmenaInOut
    {
        public event Action FrmClose;

        // end
        internal void SrediFormu(string title, DataGridView dgvRazmena, Label lblTitle)
        {
            try
            {
                // Razmena in - end
                if (title == "RAZMENA IN")
                {
                    dgvRazmena.DataSource = new BindingList<RazmenaRobe>(Komunikacija.Instance.VratiListuRazmeneRobe(Sesija.Instance.Korisnik, "KorisnikUlozeneRobe ="));
                }

                // Razmena Out - end
                if (title == "RAZMENA OUT")
                {
                    lblTitle.Text = title;
                    dgvRazmena.DataSource = new BindingList<RazmenaRobe>(Komunikacija.Instance.VratiListuRazmeneRobe(Sesija.Instance.Korisnik, "KorisnikTrazeneRobe ="));
                }
            }
            catch (ExceptionServer es)
            {
                FrmClose();
                throw new ExceptionServer(es.Message);
            }
        }

        // end
        internal void PretragaRobe(string text, DataGridView dgvRazmena, string title)
        {
            try
            {
                // Razmena in - end
                if (title == "RAZMENA IN")
                {
                    dgvRazmena.DataSource = new BindingList<RazmenaRobe>(Komunikacija.Instance.VratiPretraguRazmeneRobe(Sesija.Instance.Korisnik, $"KorisnikUlozeneRobe = {text}"));
                }

                // Razmena Out - end
                if (title == "RAZMENA OUT")
                {
                    dgvRazmena.DataSource = new BindingList<RazmenaRobe>(Komunikacija.Instance.VratiPretraguRazmeneRobe(Sesija.Instance.Korisnik, $"KorisnikTrazeneRobe = {text}"));
                }
            }
            catch (ExceptionServer es)
            {
                FrmClose();
                throw new ExceptionServer(es.Message);
            }
        }
    }
}
