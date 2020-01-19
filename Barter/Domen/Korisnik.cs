using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Korisnik : IDomenskiObjekat
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

        // ...#...
        public string VratiImeKlase()
        {
            return "Korisnik";
        }

        // ...#...
        public string VratiSlozenUslov(string operacija)
        {
            return $"UsernameKorisnika = '{UsernameKorisnika}' {operacija}";
        }

        // ...#...
        public IDomenskiObjekat VratiObjekat(SqlDataReader reader)
        {
            Korisnik korisnik = null;
            while (reader.Read())
            {
                korisnik = new Korisnik
                {
                    KorisnikID = reader.GetInt32(0),
                    UsernameKorisnika = reader.GetString(1),
                    ImeKorisnika = reader.GetString(2),
                    PrezimeKorisnika = reader.GetString(3),
                    Email = reader.GetString(4),
                    Sifra = reader.GetString(5),
                    DatumRodjenja = reader.GetDateTime(6),
                    Adresa = reader.GetString(7)
                };
            }
            return korisnik;
        }

        // ...#...
        public string VratiVrednostiAtributa()
        {
            return $"'{UsernameKorisnika}', '{ImeKorisnika}', '{PrezimeKorisnika}', '{Email}', '{Sifra}', '{DatumRodjenja}', '{Adresa}', {Lokacija.Ptt}";
        }

        // ...#...
        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            List<IDomenskiObjekat> korisnici = new List<IDomenskiObjekat>();

            while (reader.Read())
            {
                Korisnik korisnik = new Korisnik
                {
                    KorisnikID = reader.GetInt32(0),
                    UsernameKorisnika = reader.GetString(1),
                    ImeKorisnika = reader.GetString(2),
                    PrezimeKorisnika = reader.GetString(3),
                    Email = reader.GetString(4),
                    Sifra = reader.GetString(5),
                    DatumRodjenja = reader.GetDateTime(6),
                    Adresa = reader.GetString(7)
                };
                korisnici.Add(korisnik);
            }
            return korisnici;
        }

        public IDomenskiObjekat VratiUgnjezdeni(int broj)
        {
            return null;
        }

        public void setujUgnjezdeni(IDomenskiObjekat domenskiObjekat, int broj)
        {
            throw new NotImplementedException();
        }

        public string VratiImePrimarnogKljuca()
        {
            throw new NotImplementedException();
        }

        // ...#...
        public string PostaviVrednostiAtributa()
        {
            return $"ImeKorisnika = '{ImeKorisnika}', PrezimeKorisnika = '{PrezimeKorisnika}', sifra = '{Sifra}', DatumRodjenja = '{DatumRodjenja}', Adresa = '{Adresa}', Lokacija = {Lokacija.Ptt}";
        }

        // ...#...
        public string VratiUslovPoIDu()
        {
            return $"KorisnikID = {KorisnikID}";
        }

        public IEnumerable<IDomenskiObjekat> VratiSlabeObjekte()
        {
            throw new NotImplementedException();
        }
    }
}
