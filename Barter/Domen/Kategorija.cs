using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Kategorija
    {
        private int kategorijaID;
        private string vrstaKategorije;

        public int KategorijaID { get => kategorijaID; set => kategorijaID = value; }
        public string VrstaKategorije { get => vrstaKategorije; set => vrstaKategorije = value; }

        public override string ToString()
        {
            return VrstaKategorije;
        }
    }
}
