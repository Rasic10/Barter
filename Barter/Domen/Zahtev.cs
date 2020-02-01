using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Zahtev
    {
        public Operacija Operacija { get; set; }
        public object Objekat { get; set; }
        public string Text { get; set; }
    }

    public enum Operacija
    {
        PrijaviKorisnika,
        VratiLokacije,
        Registracija,
        ProveraKorisnika,
        VratiListuRobe,
        IzmenaProfila,
        VratiKategorije,
        UnesiKategoriju,
        UnesiRobu,
        DodajRazmenu,
        ObrisiRobu,
        VratiListuRazmeneRobe,
    }
}
