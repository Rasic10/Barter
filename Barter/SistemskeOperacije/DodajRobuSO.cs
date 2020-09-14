using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class DodajRobuSO : OpstaSistemskaOperacija
    {
        public bool Sacuvano { get; private set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            if (broker.Sacuvaj(objekat) != 1)
                Sacuvano = false;
            else
                Sacuvano = true;
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Roba))
                throw new ArgumentException();
        }
    }
}
