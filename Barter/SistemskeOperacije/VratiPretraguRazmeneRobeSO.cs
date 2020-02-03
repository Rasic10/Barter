using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class VratiPretraguRazmeneRobeSO : OpstaSistemskaOperacija
    {
        public List<RazmenaRobe> RazmeneRobe { get; private set; }
        public string Operacija { get; set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            List<RazmenaRobe> robaRazmene = broker.VratiSve(objekat, Operacija).Cast<RazmenaRobe>().ToList();
            RazmeneRobe = robaRazmene.Where(rr => rr.TrazenaRoba.NazivRobe.Contains(Operacija.Split(' ')[2])).ToList();
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
