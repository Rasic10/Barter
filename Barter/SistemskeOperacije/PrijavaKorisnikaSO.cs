using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class PrijavaKorisnikaSO : OpstaSistemskaOperacija
    {
        public Korisnik Korisnik { get; private set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            List<IDomenskiObjekat> korisnik = broker.VratiSve(objekat, $"AND sifra = '{((Korisnik)objekat).Sifra}'");
            if (korisnik.Count == 0)
                Korisnik = null;
            else
                Korisnik = (Korisnik)korisnik[0];
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Korisnik))
                throw new ArgumentException();
        }
    }
}
