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
        private bool? potvrdaRazmene;

        public int RazmenaID { get => razmenaID; set => razmenaID = value; }
        public DateTime DatumRazmeneRobe { get => datumRazmeneRobe; set => datumRazmeneRobe = value; }
        public double KolicinaRobe { get => kolicinaRobe; set => kolicinaRobe = value; }
        public Korisnik KorisnikTrazeneRobe { get => korisnikTrazeneRobe; set => korisnikTrazeneRobe = value; }
        public Korisnik KorisnikUlozeneRobe { get => korisnikUlozeneRobe; set => korisnikUlozeneRobe = value; }
        public Roba TrazenaRoba { get => trazenaRoba; set => trazenaRoba = value; }
        public List<Roba> UlozenaRoba { get => ulozenaRoba; set => ulozenaRoba = value; }
        public bool? PotvrdaRazmene { get => potvrdaRazmene; set => potvrdaRazmene = value; }

        // 
        public string PostaviVrednostiAtributa()
        {
            if(PotvrdaRazmene == true)
                return $"PotvrdaRazmene = 1";
            if(PotvrdaRazmene == false)
                return $"PotvrdaRazmene = 0";
            return $"PotvrdaRazmene = 0";
        }

        // ...#...
        public void PostaviPoddomen(IDomenskiObjekat domenskiObjekat, int broj)
        {
            if (broj == 1) KorisnikTrazeneRobe = (Korisnik)domenskiObjekat;
            if (broj == 2) KorisnikUlozeneRobe = (Korisnik)domenskiObjekat;
            if (broj == 3) TrazenaRoba = (Roba)domenskiObjekat;
            if (broj > 3) UlozenaRoba[broj - 4] = (Roba)domenskiObjekat;
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

        // ...#...
        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            List<IDomenskiObjekat> razmenaRobe = new List<IDomenskiObjekat>();
            RazmenaRobe roba = null;
            while (reader.Read())
            {
                if(roba != null && roba.RazmenaID == reader.GetInt32(0))
                {
                    roba.ulozenaRoba.Add(new Roba { RobaID = reader.GetInt32(7) });
                    continue;
                }

                roba = new RazmenaRobe
                {
                    RazmenaID = reader.GetInt32(0),
                    DatumRazmeneRobe = reader.GetDateTime(1),
                    KolicinaRobe = reader.GetDouble(2),
                    KorisnikTrazeneRobe = new Korisnik
                    {
                        KorisnikID = reader.GetInt32(3)
                    },
                    KorisnikUlozeneRobe = new Korisnik
                    {
                        KorisnikID = reader.GetInt32(4)
                    },
                    TrazenaRoba = new Roba
                    {
                        RobaID = reader.GetInt32(5)
                    },
                    UlozenaRoba = new List<Roba>
                    {
                        new Roba
                        {
                            RobaID = reader.GetInt32(7),
                        }
                    },
                };

                if (!reader.IsDBNull(6)) roba.potvrdaRazmene = reader.GetBoolean(6);

                razmenaRobe.Add(roba);
            }
            return razmenaRobe;
        }

        public IDomenskiObjekat VratiObjekat(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        // ...#...
        public IDomenskiObjekat VratiPoddomen(int broj)
        {
            if (broj == 1) return KorisnikTrazeneRobe;
            if (broj == 2) return KorisnikUlozeneRobe;
            if (broj == 3) return TrazenaRoba;
            if (broj - 4 >= 0 && broj - 4 < UlozenaRoba.Count()) return UlozenaRoba[broj - 4];
            return null;
        }

        // ...#...
        public string VratiSlozenUslov(string operacija)
        {
            if (operacija.Split(' ')[0] == "KorisnikTrazeneRobe")
                return $"KorisnikTrazeneRobe {operacija.Split(' ')[1]} {KorisnikTrazeneRobe.KorisnikID}";
            if (operacija.Split(' ')[0] == "KorisnikUlozeneRobe")
                return $"KorisnikUlozeneRobe {operacija.Split(' ')[1]} {KorisnikUlozeneRobe.KorisnikID}";
            return $"1 = 1";
        }

        // ...#...
        public string VratiVrednostiAtributa()
        {
            return $"'{DatumRazmeneRobe}', {KolicinaRobe}, {KorisnikTrazeneRobe.KorisnikID}, {KorisnikUlozeneRobe.KorisnikID}, {TrazenaRoba.RobaID}, 0";
        }

        // ...#...
        public string VratiUslovPoIDu()
        {
            return $"RazmenaID = {RazmenaID}";
        }

        // ...#...
        public IEnumerable<IDomenskiObjekat> VratiSlabeObjekte()
        {
            return UlozenaRoba;
        }

        // 
        public string VratiPretragu(string tekst)
        {
            throw new NotImplementedException();
        }
    }
}
