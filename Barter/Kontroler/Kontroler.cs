using BrokerBazePodataka;
using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontroler
{
    public class Kontroler
    {
        private Broker broker = new Broker();
        private static Kontroler _instance;

        public static Kontroler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Kontroler();
                }
                return _instance;
            }
        }
        
        private Kontroler()
        {
        }

        public Korisnik Prijava(string korIme, string sifra)
        {
            return broker.Prijava(korIme, sifra);
        }

        public BindingList<Roba> VratiListuRobe(Korisnik korisnik)
        {
            return broker.VratiListuRobe(korisnik);
        }

        public List<Lokacija> VratiSveLokacije()
        {
            return broker.VratiSveLokacije();
        }

        public bool Registracija(Korisnik k)
        {
            try
            {
                broker.OtvoriKonekciju();
                broker.Registracija(k);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(">>> " + e.Message);
                return false;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }
    }
}
