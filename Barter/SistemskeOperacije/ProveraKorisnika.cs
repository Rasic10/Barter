using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class ProveraKorisnika : OpstaSistemskaOperacija
    {
        public bool Postoji { get; private set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            if (broker.VratiSve(objekat, $"OR email = '{((Korisnik)objekat).Email}'").Count > 0)
            {
                Postoji = true;
            }
            else
            {
                Postoji = false;
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Korisnik))
            {
                throw new ArgumentException();
            }
        }
    }
}
