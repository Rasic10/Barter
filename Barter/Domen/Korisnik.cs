using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Korisnik
    {
        private int korisnikID;
        private string usernameKorisnika;
        private string imeKorisnika;
        private string prezimeKorisnika;
        private string email;
        private string sifra;
        private DateTime datumRodjenja;
        private string adresa;
        private Lokacija lokacija;

        public int KorisnikID { get => korisnikID; set => korisnikID = value; }
        public string UsernameKorisnika { get => usernameKorisnika; set => usernameKorisnika = value; }
        public string ImeKorisnika { get => imeKorisnika; set => imeKorisnika = value; }
        public string PrezimeKorisnika { get => prezimeKorisnika; set => prezimeKorisnika = value; }
        public string Email { get => email; set => email = value; }
        public string Sifra { get => sifra; set => sifra = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public Lokacija Lokacija { get => lokacija; set => lokacija = value; }

        public override string ToString()
        {
            return $"{ImeKorisnika} {PrezimeKorisnika}";
        }
    }
}
