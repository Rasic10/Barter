using Domen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Obrada
    {
        private Socket klijent;
        private FrmServer frmServer;
        private NetworkStream klijentskiTok;
        private BinaryFormatter formatter = new BinaryFormatter();
        private bool kraj;

        // ...#...
        public Obrada(Socket klijent, FrmServer frmServer)
        {
            this.klijent = klijent;
            this.frmServer = frmServer;
            this.klijentskiTok = new NetworkStream(klijent);
        }

        // ...
        public void Obradjuj()
        {
            kraj = false;
            while (!kraj)
            {
                try
                {
                    Zahtev z = (Zahtev)formatter.Deserialize(klijentskiTok);
                    Odgovor odg = new Odgovor();
                    switch (z.Operacija)
                    {
                        case Operacija.Operacija1:
                            //pozivanje metoda
                            break;
                    }
                    ProslediOdgovor(odg);
                }
                catch (ThreadInterruptedException e)
                {
                    kraj = false;
                }
                catch (IOException e)
                {
                    kraj = false;
                }
            }
        }

        // ...#...
        private void ProslediOdgovor(Odgovor odgovor)
        {
            formatter.Serialize(klijentskiTok, odgovor);
        }
    }
}
