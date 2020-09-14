using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class VratiSveRazmeneRobeSO : OpstaSistemskaOperacija
    {
        public List<RazmenaRobe> RazmeneRobe { get; private set; }
        public string Operacija { get; set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            RazmeneRobe = broker.VratiRazmenuRobe(objekat, Operacija).Cast<RazmenaRobe>().ToList();
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is RazmenaRobe))
                throw new ArgumentException();
        }
    }
}
