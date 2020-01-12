using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Roba
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

        public override string ToString()
        {
            return NazivRobe;
        }
    }
}
