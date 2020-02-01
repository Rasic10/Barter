using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class RazmenaRobe : IDomenskiObjekat
    {
        private int razmenaID;
        private DateTime datumRazmeneRobe;
        private double kolicinaRobe;
        private Korisnik korisnikTrazeneRobe;
        private Korisnik korisnikUlozeneRobe;
        private Roba trazenaRoba;
        private List<Roba> ulozenaRoba;

        public int RazmenaID { get => razmenaID; set => razmenaID = value; }
        public DateTime DatumRazmeneRobe { get => datumRazmeneRobe; set => datumRazmeneRobe = value; }
        public double KolicinaRobe { get => kolicinaRobe; set => kolicinaRobe = value; }
        public Korisnik KorisnikTrazeneRobe { get => korisnikTrazeneRobe; set => korisnikTrazeneRobe = value; }
        public Korisnik KorisnikUlozeneRobe { get => korisnikUlozeneRobe; set => korisnikUlozeneRobe = value; }
        public Roba TrazenaRoba { get => trazenaRoba; set => trazenaRoba = value; }
        public List<Roba> UlozenaRoba { get => ulozenaRoba; set => ulozenaRoba = value; }

        public string PostaviVrednostiAtributa()
        {
            throw new NotImplementedException();
        }

        public void PostaviPoddomen(IDomenskiObjekat domenskiObjekat, int broj)
        {
            throw new NotImplementedException();
        }

        // ...#...
        public string VratiImeKlase()
        {
            return "RazmenaRobe";
        }

        // ...#...
        public string VratiImePrimarnogKljuca()
        {
            return "inserted.RazmenaID";
        }

        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public IDomenskiObjekat VratiObjekat(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        // ...#...
        public IDomenskiObjekat VratiPoddomen(int broj)
        {
            if (broj == 1) return TrazenaRoba;
            return null;
        }

        public string VratiSlozenUslov(string operacija)
        {
            throw new NotImplementedException();
        }

        // ...#...
        public string VratiVrednostiAtributa()
        {
            return $"'{DatumRazmeneRobe}', {KolicinaRobe}, {KorisnikTrazeneRobe.KorisnikID}, {KorisnikUlozeneRobe.KorisnikID}, {TrazenaRoba.RobaID}";
        }

        public string VratiUslovPoIDu()
        {
            throw new NotImplementedException();
        }

        // ...#...
        public IEnumerable<IDomenskiObjekat> VratiSlabeObjekte()
        {
            return UlozenaRoba;
        }
    }
}
