using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
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

        public IDomenskiObjekat VratiObjekat(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        // ...#...
        public IDomenskiObjekat VratiUgnjezdeni()
        {
            return null;
        }

        public void setujUgnjezdeni(IDomenskiObjekat domenskiObjekat)
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
