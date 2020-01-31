using Domen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Barter
{
    public class Komunikacija
    {
        private static Komunikacija _instance;

        public static Komunikacija Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Komunikacija();
                return _instance;
            }
        }

        private Socket klijent;
        private NetworkStream stream;
        private BinaryFormatter formatter = new BinaryFormatter();

        private Komunikacija()
        {

        }
        
        // zavrseno
        public bool PoveziSe()
        {
            try
            {
                if (klijent == null || !klijent.Connected)
                {
                    klijent = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    klijent.Connect("127.0.0.1", 9876);
                    stream = new NetworkStream(klijent);
                }
                return true;
            }
            catch (SocketException e)
            {
                Debug.WriteLine(">>> " + e.Message);
                return false;
            }
        }

        // zavrseno
        public Korisnik PrijavaKorisnika(Korisnik korisnik)
        {
            try
            {
                Zahtev zahtev = new Zahtev { Objekat = korisnik, Operacija = Operacija.PrijaviKorisnika };
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                switch (odgovor.Signal)
                {
                    case Signal.Ok:
                        return (Korisnik)odgovor.Objekat;
                    case Signal.Error:
                        return null;
                }
                return null;
            }
            catch (IOException e)
            {
                Debug.WriteLine(">>> " + e.Message);
                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }

        }

        // zavrseno
        internal List<Lokacija> VratiLokacije()
        {
            try
            {
                Zahtev zahtev = new Zahtev { Objekat = new Object(), Operacija = Operacija.VratiLokacije };
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                switch (odgovor.Signal)
                {
                    case Signal.Ok:
                        return (List<Lokacija>)odgovor.Objekat;
                    case Signal.Error:
                        return new List<Lokacija>();
                }
                return null;
            }
            catch (IOException e)
            {
                Debug.WriteLine(">>> " + e.Message);
                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }

            return null;
        }

        // zavrseno
        internal bool Registracija(Korisnik k)
        {
            try
            {
                Zahtev zahtev = new Zahtev { Objekat = k, Operacija = Operacija.Registracija };
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                switch (odgovor.Signal)
                {
                    case Signal.Ok:
                        return true;
                    case Signal.Error:
                        return false;
                }
                return false;
            }
            catch (IOException e)
            {
                Debug.WriteLine(">>> " + e.Message);
                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }

            return false;
        }

        // zavrseno
        internal bool ProveraKorisnikaIMaila(Korisnik korisnik)
        {
            try
            {
                Zahtev zahtev = new Zahtev { Objekat = korisnik, Operacija = Operacija.PrijaviKorisnika };
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                switch (odgovor.Signal)
                {
                    case Signal.Ok:
                        return true;
                    case Signal.Error:
                        return false;
                }
                return false;
            }
            catch (IOException e)
            {
                Debug.WriteLine(">>> " + e.Message);
                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }

            return false;
        }

        // zavrseno
        internal List<Roba> VratiListuRobe(Korisnik korisnik, string uslov)
        {
            try
            {
                Zahtev zahtev = new Zahtev { Objekat = korisnik, Text = uslov, Operacija = Operacija.VratiListuRobe};
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                switch (odgovor.Signal)
                {
                    case Signal.Ok:
                        return (List<Roba>)odgovor.Objekat;
                    case Signal.Error:
                        return new List<Roba>();
                }
                return null;
            }
            catch (IOException e)
            {
                Debug.WriteLine(">>> " + e.Message);
                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }

            return null;
        }

        // zavrseno
        internal bool IzmenaProfila(Korisnik noviPodaci)
        {
            try
            {
                Zahtev zahtev = new Zahtev { Objekat = noviPodaci, Operacija = Operacija.IzmenaProfila };
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                switch (odgovor.Signal)
                {
                    case Signal.Ok:
                        return true;
                    case Signal.Error:
                        return false;
                }
                return false;
            }
            catch (IOException e)
            {
                Debug.WriteLine(">>> " + e.Message);
                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }

            return false;
        }

        // zavrseno
        internal List<Kategorija> VratiListuKategorija()
        {
            try
            {
                Zahtev zahtev = new Zahtev { Objekat = new Object(), Operacija = Operacija.VratiKategorije };
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                switch (odgovor.Signal)
                {
                    case Signal.Ok:
                        return (List<Kategorija>)odgovor.Objekat;
                    case Signal.Error:
                        return new List<Kategorija>();
                }
                return null;
            }
            catch (IOException e)
            {
                Debug.WriteLine(">>> " + e.Message);
                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }

            return null;
        }

        // zavrseno
        internal int UnesiKategoriju(Kategorija kategorija)
        {
            try
            {
                Zahtev zahtev = new Zahtev { Objekat = kategorija, Operacija = Operacija.UnesiKategoriju };
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                switch (odgovor.Signal)
                {
                    case Signal.Ok:
                        return 1;
                    case Signal.Error:
                        return -1;
                }
                return -1;
            }
            catch (IOException e)
            {
                Debug.WriteLine(">>> " + e.Message);
                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }

            return -1;
        }

        // z
        internal bool UnesiRobu(Roba roba)
        {
            try
            {
                Zahtev zahtev = new Zahtev { Objekat = roba, Operacija = Operacija.UnesiKategoriju };
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                switch (odgovor.Signal)
                {
                    case Signal.Ok:
                        return true;
                    case Signal.Error:
                        return false;
                }
                return false;
            }
            catch (IOException e)
            {
                Debug.WriteLine(">>> " + e.Message);
                klijent.Close();
                throw new ExceptionServer("Server je zaustavljen!");
            }

            return false;
        }


    }
}
