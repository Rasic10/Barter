using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Roba : IDomenskiObjekat
    {
        private int robaID;
        private string nazivRobe;
        private double kolicinaRobe;
        private double cenaRobe;
        private DateTime datumUnosaRobe;
        private Korisnik korisnikRobe;
        private Kategorija kategorijaRobe;
        private RazmenaRobe razmenaUlozeneRobe;

        public int RobaID { get => robaID; set => robaID = value; }
        public string NazivRobe { get => nazivRobe; set => nazivRobe = value; }
        public double KolicinaRobe { get => kolicinaRobe; set => kolicinaRobe = value; }
        public double CenaRobe { get => cenaRobe; set => cenaRobe = value; }
        public DateTime DatumUnosaRobe { get => datumUnosaRobe; set => datumUnosaRobe = value; }
        public Korisnik KorisnikRobe { get => korisnikRobe; set => korisnikRobe = value; }
        public Kategorija KategorijaRobe { get => kategorijaRobe; set => kategorijaRobe = value; }
        public RazmenaRobe RazmenaUlozeneRobe { get => razmenaUlozeneRobe; set => razmenaUlozeneRobe = value; }

        public string PostaviVrednostiAtributa()
        {
            throw new NotImplementedException();
        }

        public void setujUgnjezdeni(IDomenskiObjekat domenskiObjekat)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return NazivRobe;
        }

        // ...#...
        public string VratiImeKlase()
        {
            return "Roba";
        }

        public string VratiImePrimarnogKljuca()
        {
            throw new NotImplementedException();
        }

        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public IDomenskiObjekat VratiObjekat(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public IDomenskiObjekat VratiUgnjezdeni()
        {
            throw new NotImplementedException();
        }

        public string VratiSlozenUslov()
        {
            throw new NotImplementedException();
        }

        // ...#...
        public string VratiVrednostiAtributa()
        {
            if (RazmenaUlozeneRobe == null)
            {
                return $"'{NazivRobe}', {KolicinaRobe}, {CenaRobe}, '{DatumUnosaRobe}', {KorisnikRobe.KorisnikID}, {KategorijaRobe.KategorijaID}, NULL";
            }
            else
            {
                return $"'{NazivRobe}', {KolicinaRobe}, {CenaRobe}, '{DatumUnosaRobe}', {KorisnikRobe.KorisnikID}, {KategorijaRobe.KategorijaID}";
            }            
        }

        public string VratiUslovPoIDu()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IDomenskiObjekat> VratiSlabeObjekte()
        {
            throw new NotImplementedException();
        }
    }
}
