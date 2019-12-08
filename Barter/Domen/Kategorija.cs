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
        private VrstaKategorijeEnum vrstaKategorije;

        public int KategorijaID { get => kategorijaID; set => kategorijaID = value; }
        public VrstaKategorijeEnum VrstaKategorije { get => vrstaKategorije; set => vrstaKategorije = value; }
    }

    public enum VrstaKategorijeEnum
    {
        Povrce,
        Voce,
        Zitarice,
        Masine,
        Odeca,
        Obuca
    };
}
