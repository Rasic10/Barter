using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class VratiPretraguRobeSO : OpstaSistemskaOperacija
    {
        public List<Roba> Pretraga { get; private set; }
        public string Tekst { get; set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            Pretraga = broker.VratiPretragu(objekat, Tekst).Cast<Roba>().ToList();
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
