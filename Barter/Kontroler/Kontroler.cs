using BrokerBazePodataka;
using Domen;
using SistemskeOperacije;
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

        // ...#...
        public Korisnik Prijava(Korisnik korisnik)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new PrijavaKorisnikaSO();
            sistemskaOperacija.Izvrsi(korisnik);
            return ((PrijavaKorisnikaSO)sistemskaOperacija).Korisnik;
            //return broker.Prijava(korIme, sifra);
        }

        // ...#...
        public bool Registracija(Korisnik korisnik)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new RegistrujKorisnikaSO();
            sistemskaOperacija.Izvrsi(korisnik);
            return ((RegistrujKorisnikaSO)sistemskaOperacija).Sacuvano;
            //try
            //{
            //    broker.OtvoriKonekciju();
            //    broker.Registracija(k);
            //    return true;
            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine(">>> " + e.Message);
            //    return false;
            //}
            //finally
            //{
            //    broker.ZatvoriKonekciju();
            //}
        }

        public BindingList<Roba> VratiListuRobe(Korisnik korisnik, string operacija)
        {
            return broker.VratiListuRobe(korisnik, operacija);
        }

        public List<Lokacija> VratiSveLokacije()
        {
            return broker.VratiSveLokacije();
        }

        public int UnesiKategoriju(Kategorija k)
        {
            try
            {
                broker.OtvoriKonekciju();
                return broker.UnesiKateogoriju(k);
            }
            catch (Exception e)
            {
                Debug.WriteLine(">>> " + e.Message);
                return -1;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }

        public BindingList<Kategorija> VratiListuKategorija()
        {
            try
            {
                broker.OtvoriKonekciju();
                return broker.VratiListuKategorija();
            }
            catch (Exception e)
            {
                Debug.WriteLine(">>> " + e.Message);
                return new BindingList<Kategorija>();
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }

        public bool UnesiRobu(Roba r)
        {
            try
            {
                broker.OtvoriKonekciju();
                broker.UnesiRobu(r);
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

        public bool ProveraKorisnikaIMaila(string korIme, string email)
        {
            try
            {
                broker.OtvoriKonekciju();
                if (broker.DaLiPostojiKorisnik(korIme, email)) return true;
                else return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(">>> " + e.Message);
                throw new Exception("Doslo je do greske pri radu sa bazom!");
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }

        public bool IzmenaProfila(Korisnik noviPodaci)
        {
            try
            {
                broker.OtvoriKonekciju();
                if (broker.IzmenaProfila(noviPodaci) != 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(">>> " + e.Message);
                throw new Exception("Doslo je do greske pri radom sa bazom!");
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }

        public bool SacuvajRazmenu(RazmenaRobe rr, BindingList<Roba> ulozenaRoba)
        {
            try
            {
                broker.OtvoriKonekciju();
                broker.PokreniTransakciju();
                broker.SacuvajRazmenu(rr, ulozenaRoba);
                broker.Commit();
                return true;
            }
            catch (Exception)
            {
                broker.Rollback();
                return false;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }
    }
}
