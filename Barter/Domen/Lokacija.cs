using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Lokacija : IDomenskiObjekat
    {
        private int ptt;
        private string nazivOpstine;

        public Lokacija Self
        {
            get
            {
                return this;
            }
        }

        public int Ptt { get => ptt; set => ptt = value; }
        public string NazivOpstine { get => nazivOpstine; set => nazivOpstine = value; }

        public override string ToString()
        {
            return NazivOpstine + " " + Ptt;
        }

        // ...#...
        public string VratiImeKlase()
        {
            return "Lokacija";
        }

        // ...#...
        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lokacije = new List<IDomenskiObjekat>();

            while (reader.Read())
            {
                Lokacija lokacija = new Lokacija
                {
                    Ptt = reader.GetInt32(0),
                    NazivOpstine = reader.GetString(1),
                };
                lokacije.Add(lokacija);
            }
            return lokacije;
        }

        public IDomenskiObjekat VratiObjekat(SqlDataReader reader)
        {
            throw new NotImplementedException();
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

        // ...#
        public string VratiSlozenUslov(string operacija)
        {
            return $"Ptt > 0";
        }

        public string VratiVrednostiAtributa()
        {
            throw new NotImplementedException();
        }

        public string VratiImePrimarnogKljuca()
        {
            throw new NotImplementedException();
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

        public string VratiPretragu(string tekst)
        {
            throw new NotImplementedException();
        }
    }
}
