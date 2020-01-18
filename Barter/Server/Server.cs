using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        //public event Action OsveziFormu;

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
                osluskujuciSoket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
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

        // ...
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
                    new Thread(obrada.Obradjuj).Start();
                }
                catch (ThreadInterruptedException e)
                {
                    kraj = true;
                }
                catch (SocketException e)
                {
                    kraj = true;
                }
            }
        }

        // ...
        internal bool Zaustavi()
        {
            try
            {
                //for (int i = 0; i < klijenti.Count; i++)
                //{
                //    klijenti[i].Ugasi();
                //}
                //klijenti = new List<Obrada>();
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
