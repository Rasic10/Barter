using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Kategorija : IDomenskiObjekat
    {
        private int kategorijaID;
        private string vrstaKategorije;

        public int KategorijaID { get => kategorijaID; set => kategorijaID = value; }
        public string VrstaKategorije { get => vrstaKategorije; set => vrstaKategorije = value; }

        public override string ToString()
        {
            return VrstaKategorije;
        }

        // ...#...
        public string VratiImeKlase()
        {
            return "Kategorija";
        }

        // ...#...
        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            List<IDomenskiObjekat> kategorije = new List<IDomenskiObjekat>();

            while (reader.Read())
            {
                Kategorija kategorija = new Kategorija
                {
                    KategorijaID = reader.GetInt32(0),
                    VrstaKategorije = reader.GetString(1)
                };
                kategorije.Add(kategorija);
            }
            return kategorije;
        }

        // ...#...
        public IDomenskiObjekat VratiObjekat(SqlDataReader reader)
        {
            Kategorija kategorija = null;
            while (reader.Read())
            {
                kategorija = new Kategorija
                {
                    KategorijaID = reader.GetInt32(0),
                    VrstaKategorije = reader.GetString(1)
                };
            }
            return kategorija;
        }

        // ...#...
        public IDomenskiObjekat VratiPoddomen(int broj)
        {
            return null;
        }

        public void PostaviPoddomen(IDomenskiObjekat domenskiObjekat, int broj)
        {
            throw new NotImplementedException();
        }

        // ...
        public string VratiSlozenUslov(string operacija)
        {
            return $"KategorijaID > 0";
        }

        // ...#...
        public string VratiVrednostiAtributa()
        {
            return $"'{VrstaKategorije}'";
        }

        // ...#...
        public string VratiImePrimarnogKljuca()
        {
            return "inserted.KategorijaID";
        }

        public string PostaviVrednostiAtributa()
        {
            throw new NotImplementedException();
        }

        // ...#...
        public string VratiUslovPoIDu()
        {
            return $"KategorijaID = {KategorijaID}";
        }

        public IEnumerable<IDomenskiObjekat> VratiSlabeObjekte()
        {
            throw new NotImplementedException();
        }
    }
}
