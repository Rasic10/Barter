using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class VratiSveKategorijeSO : OpstaSistemskaOperacija
    {
        public List<Kategorija> Kateogrije { get; private set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            Kateogrije = broker.VratiSve(objekat).Cast<Kategorija>().ToList();
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Kategorija))
            {
                throw new ArgumentException();
            }
        }
    }
}
