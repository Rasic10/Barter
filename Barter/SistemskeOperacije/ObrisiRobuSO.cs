using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class ObrisiRobuSO : OpstaSistemskaOperacija
    {
        public bool Obrisano { get; private set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            if (broker.Obrisi(objekat) != 1)
                Obrisano = false;
            else
                Obrisano = true;
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Roba))
                throw new ArgumentException();
        }
    }
}
