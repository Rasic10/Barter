using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class VratiSveLokacijeSO : OpstaSistemskaOperacija
    {
        public List<Lokacija> Lokacije { get; private set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            Lokacije = broker.VratiSve(objekat).Cast<Lokacija>().ToList();
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Lokacija))
            {
                throw new ArgumentException();
            }
        }
    }
}
