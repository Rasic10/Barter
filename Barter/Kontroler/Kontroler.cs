﻿using BrokerBazePodataka;
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

        // ...#...SO
        public Korisnik Prijava(Korisnik korisnik)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new PrijavaKorisnikaSO();
            sistemskaOperacija.Izvrsi(korisnik);
            return ((PrijavaKorisnikaSO)sistemskaOperacija).Korisnik;
        }

        // ...#...SO
        public bool Registracija(Korisnik korisnik)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new RegistrujKorisnikaSO();
            sistemskaOperacija.Izvrsi(korisnik);
            return ((RegistrujKorisnikaSO)sistemskaOperacija).Sacuvano;
        }

        // ...#...SO
        public List<Roba> VratiListuRobe(Korisnik korisnik, string operacija) // promenjeno BindingList u List
        {
            OpstaSistemskaOperacija sistemskaOperacija = new VratiSveRobeSO();
            ((VratiSveRobeSO)sistemskaOperacija).Operacija = operacija;
            sistemskaOperacija.Izvrsi(new Roba() { KorisnikRobe = korisnik });
            return ((VratiSveRobeSO)sistemskaOperacija).Robe;
        }

        // ...#...SO
        public List<RazmenaRobe> VratiListuRazmeneRobe(Korisnik korisnik, string operacija)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new VratiSveRazmeneRobeSO();
            ((VratiSveRazmeneRobeSO)sistemskaOperacija).Operacija = operacija;
            if(operacija.Split(' ')[0] == "KorisnikTrazeneRobe")
                sistemskaOperacija.Izvrsi(new RazmenaRobe() { KorisnikTrazeneRobe = korisnik });
            else if (operacija.Split(' ')[0] == "KorisnikUlozeneRobe")
                sistemskaOperacija.Izvrsi(new RazmenaRobe() { KorisnikUlozeneRobe = korisnik });
            else return new List<RazmenaRobe>();
            return ((VratiSveRazmeneRobeSO)sistemskaOperacija).RazmeneRobe;
        }

        // ...#...SO
        public List<Lokacija> VratiSveLokacije()
        {
            OpstaSistemskaOperacija sistemskaOperacija = new VratiSveLokacijeSO();
            sistemskaOperacija.Izvrsi(new Lokacija());
            return ((VratiSveLokacijeSO)sistemskaOperacija).Lokacije;
        }

        // ...#...SO
        public int UnesiKategoriju(Kategorija kategorija)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new DodajKategorijuSO();
            sistemskaOperacija.Izvrsi(kategorija);
            return ((DodajKategorijuSO)sistemskaOperacija).ID;
        }

        // ...#...SO
        public List<RazmenaRobe> VratiPretraguRazmene(Korisnik korisnik, string operacija)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new VratiPretraguRazmeneRobeSO();
            ((VratiPretraguRazmeneRobeSO)sistemskaOperacija).Operacija = operacija;
            if (operacija.Split(' ')[0] == "KorisnikTrazeneRobe")
                sistemskaOperacija.Izvrsi(new RazmenaRobe() { KorisnikTrazeneRobe = korisnik });
            else if (operacija.Split(' ')[0] == "KorisnikUlozeneRobe")
                sistemskaOperacija.Izvrsi(new RazmenaRobe() { KorisnikUlozeneRobe = korisnik });
            else return new List<RazmenaRobe>();
            return ((VratiPretraguRazmeneRobeSO)sistemskaOperacija).RazmeneRobe;
        }

        // ...#...SO
        public List<Roba> VratiPretraguRobe(Korisnik korisnik, string tekst)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new VratiPretraguRobeSO();
            ((VratiPretraguRobeSO)sistemskaOperacija).Tekst = tekst;
            sistemskaOperacija.Izvrsi(new Roba() { KorisnikRobe = korisnik });
            return ((VratiPretraguRobeSO)sistemskaOperacija).Pretraga;
        }

        // zavrseno
        public bool IzmeniRobu(Roba roba)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new IzmeniRobuSO();
            sistemskaOperacija.Izvrsi(roba);
            return ((IzmeniRobuSO)sistemskaOperacija).Izmenjeno;
        }

        // zavrseno
        public bool ObrisiRobu(Roba roba)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new ObrisiRobuSO();
            sistemskaOperacija.Izvrsi(roba);
            return ((ObrisiRobuSO)sistemskaOperacija).Obrisano;
        }

        //
        public bool PonistiRazmenuRobe(RazmenaRobe razmenaRobe)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new PonistiRazmenuRobeSO();
            sistemskaOperacija.Izvrsi(razmenaRobe);
            return ((PonistiRazmenuRobeSO)sistemskaOperacija).Izmenjeno;
        }

        //
        public bool ObrisiRazmenu(RazmenaRobe razmenaRobe)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new ObrisiRazmenuSO();
            sistemskaOperacija.Izvrsi(razmenaRobe);
            return ((ObrisiRazmenuSO)sistemskaOperacija).Obrisano;
        }

        // 
        public bool PotvrdiRazmenuRobe(RazmenaRobe razmenaRobe)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new PotvrdiRazmenuRobeSO();
            sistemskaOperacija.Izvrsi(razmenaRobe);
            return ((PotvrdiRazmenuRobeSO)sistemskaOperacija).Izmenjeno;
        }

        // ...#...SO
        public List<Kategorija> VratiListuKategorija() // promenjeno BindingList u List
        {
            OpstaSistemskaOperacija sistemskaOperacija = new VratiSveKategorijeSO();
            sistemskaOperacija.Izvrsi(new Kategorija());
            return ((VratiSveKategorijeSO)sistemskaOperacija).Kateogrije;
            //try
            //{
            //    broker.OtvoriKonekciju();
            //    return broker.VratiListuKategorija();
            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine(">>> " + e.Message);
            //    return new BindingList<Kategorija>();
            //}
            //finally
            //{
            //    broker.ZatvoriKonekciju();
            //}
        }

        // ...#...SO
        public bool UnesiRobu(Roba roba)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new DodajRobuSO();
            sistemskaOperacija.Izvrsi(roba);
            return ((DodajRobuSO)sistemskaOperacija).Sacuvano;
            //try
            //{
            //    broker.OtvoriKonekciju();
            //    broker.UnesiRobu(r);
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

        // ...#...SO
        public bool ProveraKorisnikaIMaila(Korisnik korisnik)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new ProveraKorisnika();
            sistemskaOperacija.Izvrsi(korisnik);
            return ((ProveraKorisnika)sistemskaOperacija).Postoji;
            //try
            //{
            //    broker.OtvoriKonekciju();
            //    if (broker.DaLiPostojiKorisnik(korIme, email)) return true;
            //    else return false;
            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine(">>> " + e.Message);
            //    throw new Exception("Doslo je do greske pri radu sa bazom!");
            //}
            //finally
            //{
            //    broker.ZatvoriKonekciju();
            //}
        }

        // ...#...SO
        public bool IzmenaProfila(Korisnik noviPodaci)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new IzmeniProfilSO();
            sistemskaOperacija.Izvrsi(noviPodaci);
            return ((IzmeniProfilSO)sistemskaOperacija).Izmenjeno;
            //try
            //{
            //    broker.OtvoriKonekciju();
            //    if (broker.IzmenaProfila(noviPodaci) != 1)
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        return true;
            //    }
            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine(">>> " + e.Message);
            //    throw new Exception("Doslo je do greske pri radom sa bazom!");
            //}
            //finally
            //{
            //    broker.ZatvoriKonekciju();
            //}
        }

        // ...#...SO
        public bool SacuvajRazmenu(RazmenaRobe razmenaRobe)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new DodajRazmenuSO();
            sistemskaOperacija.Izvrsi(razmenaRobe);
            return ((DodajRazmenuSO)sistemskaOperacija).Sacuvano;
            //try
            //{
            //    broker.OtvoriKonekciju();
            //    broker.PokreniTransakciju();
            //    broker.SacuvajRazmenu(rr, ulozenaRoba);
            //    broker.Commit();
            //    return true;
            //}
            //catch (Exception)
            //{
            //    broker.Rollback();
            //    return false;
            //}
            //finally
            //{
            //    broker.ZatvoriKonekciju();
            //}
        }
    }
}
