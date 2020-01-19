using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class DodajKategorijuSO : OpstaSistemskaOperacija
    {
        public int ID { get; private set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            ID = broker.SacuvajIUzvratiID(objekat);
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
