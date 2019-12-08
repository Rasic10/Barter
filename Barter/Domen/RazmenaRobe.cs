using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class RazmenaRobe
    {
        private int razmenaID;
        private DateTime datumRazmeneRobe;
        private double kolicinaRobe;
        private Korisnik korisnikTrazeneRobe;
        private Korisnik korisnikUlozeneRobe;
        private Roba trazenaRoba;

        public int RazmenaID { get => razmenaID; set => razmenaID = value; }
        public DateTime DatumRazmeneRobe { get => datumRazmeneRobe; set => datumRazmeneRobe = value; }
        public double KolicinaRobe { get => kolicinaRobe; set => kolicinaRobe = value; }
        public Korisnik KorisnikTrazeneRobe { get => korisnikTrazeneRobe; set => korisnikTrazeneRobe = value; }
        public Korisnik KorisnikUlozeneRobe { get => korisnikUlozeneRobe; set => korisnikUlozeneRobe = value; }
        public Roba TrazenaRoba { get => trazenaRoba; set => trazenaRoba = value; }
    }
}
