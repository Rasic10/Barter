using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class PotvrdiRazmenuRobeSO : OpstaSistemskaOperacija
    {
        public bool Izmenjeno { get; private set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            if (broker.Izmeni(objekat) != 1)
            {
                Izmenjeno = false;
            }
            else
            {
                Izmenjeno = true;
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is RazmenaRobe))
            {
                throw new ArgumentException();
            }
        }
    }
}
