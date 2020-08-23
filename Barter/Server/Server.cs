using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private FrmServer frmServer;
        private List<Obrada> klijenti = new List<Obrada>();
        private Socket osluskujuciSoket;
        private List<Thread> nitiKlijenata = new List<Thread>();

        private BindingList<Korisnik> listaKorisnika = new BindingList<Korisnik>();

        // ...#...
        public Server(FrmServer frmServer)
        {
            this.frmServer = frmServer;
        }
        
        // ...#...
        internal bool Pokreni()
        {
            try
            {
                osluskujuciSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                osluskujuciSoket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9876));
                osluskujuciSoket.Listen(5);

                Thread nit = new Thread(Osluskuj);
                nit.IsBackground = true;
                nit.Start();
                return true;
            }
            catch (SocketException e)
            {
                Debug.WriteLine(">>> " + e.Message);
                return false;
            }
        }

        // ...#...
        private void Osluskuj()
        {
            bool kraj = false;
            while (!kraj)
            {
                try
                {
                    Socket klijent = osluskujuciSoket.Accept();
                    Obrada obrada = new Obrada(klijent, frmServer);
                    klijenti.Add(obrada);
                    Thread nit = new Thread(obrada.ObradiKlijenta);
                    nit.IsBackground = true;
                    nitiKlijenata.Add(nit);
                    nit.Start();
                }
                catch (ThreadInterruptedException e)
                {
                    string s = e.Message;
                    kraj = true;
                }
                catch (SocketException e)
                {
                    string s = e.Message;
                    kraj = true;
                }
            }
        }

        // zavrseno
        internal bool Zaustavi()
        {
            try
            {
                for (int i = 0; i < klijenti.Count; i++)
                {
                    try
                    {
                        klijenti[i].IskljuciKlijentaIProslediPorukuKraj();
                        nitiKlijenata[i].Abort();
                    }
                    catch (IOException)
                    {
                    }
                }
                klijenti = new List<Obrada>();
                osluskujuciSoket.Close();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(">>> " + e.Message);
                return false;
            }

        }
    
    }   
}
