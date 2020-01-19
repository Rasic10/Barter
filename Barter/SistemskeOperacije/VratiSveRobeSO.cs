using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class VratiSveRobeSO : OpstaSistemskaOperacija
    {
        public List<Roba> Robe { get; private set; }
        public string Operacija { get; set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            Robe = broker.VratiSve(objekat, Operacija).Cast<Roba>().ToList();
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Roba))
            {
                throw new ArgumentException();
            }
        }
    }
}
