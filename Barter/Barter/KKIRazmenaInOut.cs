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
        internal void SrediFormu(string title, DataGridView dgvRazmena)
        {
            // Razmena in - end
            if (title == "RAZMENA IN")
            {
                dgvRazmena.DataSource = new BindingList<RazmenaRobe>(Komunikacija.Instance.VratiListuRazmeneRobe(Sesija.Instance.Korisnik, "KorisnikUlozeneRobe ="));
            }

            // Razmena Out - end
            if (title == "RAZMENA OUT")
            {
                dgvRazmena.DataSource = new BindingList<RazmenaRobe>(Komunikacija.Instance.VratiListuRazmeneRobe(Sesija.Instance.Korisnik, "KorisnikTrazeneRobe ="));
            }
        }
    }
}
