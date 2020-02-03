using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
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

        // ...#...
        public string PostaviVrednostiAtributa()
        {
            return $"NazivRobe = '{NazivRobe}', KolicinaRobe = {KolicinaRobe}, CenaRobe = {CenaRobe}, DatumUnosaRobe = '{DatumUnosaRobe}', KorisnikRobe = '{KorisnikRobe.KorisnikID}', KategorijaRobe = {KategorijaRobe.KategorijaID}";
        }

        // ...#...
        public void PostaviPoddomen(IDomenskiObjekat domenskiObjekat, int broj)
        {
            if (broj == 1) KorisnikRobe = (Korisnik)domenskiObjekat;
            if (broj == 2) KategorijaRobe = (Kategorija)domenskiObjekat;
        }

        // ...#...
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

        // ...#...
        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            List<IDomenskiObjekat> robe = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                Roba roba = new Roba
                {
                    RobaID = reader.GetInt32(0),
                    NazivRobe = reader.GetString(1),
                    KolicinaRobe = reader.GetDouble(2),
                    CenaRobe = reader.GetDouble(3),
                    DatumUnosaRobe = reader.GetDateTime(4),
                    KorisnikRobe = new Korisnik
                    {
                        KorisnikID = reader.GetInt32(5)
                    },
                    KategorijaRobe = new Kategorija
                    {
                        KategorijaID = reader.GetInt32(6)
                    }
                };

                if (!reader.IsDBNull(7))
                {
                    roba.RazmenaUlozeneRobe = new RazmenaRobe { RazmenaID = reader.GetInt32(7) };
                }
                else
                {
                    roba.razmenaUlozeneRobe = new RazmenaRobe { RazmenaID = -1 };
                }

                robe.Add(roba);
            }
            return robe;

            //if (!SqlReader.IsDBNull(indexFirstName))
            //{
            //    employee.FirstName = sqlreader.GetString(indexFirstName);
            //}
        }

        // ...#...
        public IDomenskiObjekat VratiObjekat(SqlDataReader reader)
        {
            Roba roba = null;
            while (reader.Read())
            {
                roba = new Roba
                {
                    RobaID = reader.GetInt32(0),
                    NazivRobe = reader.GetString(1),
                    KolicinaRobe = reader.GetDouble(2),
                    CenaRobe = reader.GetDouble(3),
                    DatumUnosaRobe = reader.GetDateTime(4)
                };
            }
            return roba;
        }

        // ...#...
        public IDomenskiObjekat VratiPoddomen(int broj)
        {
            if (broj == 1) return KorisnikRobe;
            if (broj == 2) return KategorijaRobe;
            
            return null;
        }

        // ...#...
        public string VratiSlozenUslov(string operacija)
        {
            return $"KorisnikRobe {operacija} {KorisnikRobe.KorisnikID}";
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

        // ...#...
        public string VratiUslovPoIDu()
        {
            return $"RobaID = {RobaID}";
        }

        public IEnumerable<IDomenskiObjekat> VratiSlabeObjekte()
        {
            throw new NotImplementedException();
        }

        // ...#...
        public string VratiPretragu(string tekst)
        {
            return $"KorisnikRobe != {KorisnikRobe.KorisnikID} AND NazivRobe LIKE '%{tekst}%'";
        }
    }
}
