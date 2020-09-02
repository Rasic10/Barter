using Domen;
using Kontroler;
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
        public NetworkStream klijentskiTok;
        private BinaryFormatter formatter = new BinaryFormatter();
        public bool kraj;
        private Korisnik korisnik = null;
   

        // ...#...
        public Obrada(Socket klijent, FrmServer frmServer)
        {
            this.klijent = klijent;
            this.frmServer = frmServer;
            this.klijentskiTok = new NetworkStream(klijent);
        }

        // ...#...
        public void ObradiKlijenta()
        {
            kraj = false;
            while (!kraj)
            {
                try
                {
                    Zahtev zahtev = (Zahtev)formatter.Deserialize(klijentskiTok);
                    Odgovor odgovor = new Odgovor();
                    switch (zahtev.Operacija)
                    {
                        case Operacija.PrijaviKorisnika:
                            odgovor = PrijaviKorisnika((Korisnik)zahtev.Objekat);
                            break;
                        case Operacija.VratiLokacije:
                            odgovor = VratiLokacije();
                            break;
                        case Operacija.Registracija:
                            odgovor = Registracija((Korisnik)zahtev.Objekat);
                            break;
                        case Operacija.ProveraKorisnika:
                            odgovor = ProveraKorisnika((Korisnik)zahtev.Objekat);
                            break;
                        case Operacija.VratiListuRobe:
                            odgovor = VratiListuRobe((Korisnik)zahtev.Objekat, zahtev.Text);
                            break;
                        case Operacija.IzmenaProfila:
                            odgovor = IzmenaProfila((Korisnik)zahtev.Objekat);
                            break;
                        case Operacija.VratiKategorije:
                            odgovor = VratiKategorije();
                            break;
                        case Operacija.UnesiKategoriju:
                            odgovor = UnesiKategoriju((Kategorija)zahtev.Objekat);
                            break;
                        case Operacija.UnesiRobu:
                            odgovor = UnesiRobu((Roba)zahtev.Objekat);
                            break;
                        case Operacija.DodajRazmenu:
                            odgovor = DodajRazmenu((RazmenaRobe)zahtev.Objekat);
                            break;
                        case Operacija.ObrisiRobu:
                            odgovor = ObrisiRobu((Roba)zahtev.Objekat);
                            break;
                        case Operacija.VratiListuRazmeneRobe:
                            odgovor = VratiListuRazmeneRobe((Korisnik)zahtev.Objekat, zahtev.Text);
                            break;
                        case Operacija.IzmeniRobu:
                            odgovor = IzmeniRobu((Roba)zahtev.Objekat);
                            break;
                        case Operacija.VratiPretraguRobe:
                            odgovor = VratiPretraguRobe((Korisnik)zahtev.Objekat, zahtev.Text);
                            break;
                        case Operacija.VratiPretraguRazmene:
                            odgovor = VratiPretraguRazmene((Korisnik)zahtev.Objekat, zahtev.Text);
                            break;
                        case Operacija.PotvrdiRazmenuRobe:
                            odgovor = PotvrdaRazmeneRobe((RazmenaRobe)zahtev.Objekat);
                            break;
                    }
                    ProslediOdgovor(odgovor);
                }
                catch(IOException ioe)
                {
                    string s = ioe.Message;
                    kraj = true;
                    if ( korisnik != null) frmServer.Invoke(new Action(() => frmServer.listaKorisnika.Remove(korisnik)));
                }
                catch (Exception e)
                {
                    string s = e.Message;
                    kraj = true;
                }
            }
        }

        // 
        private Odgovor PotvrdaRazmeneRobe(RazmenaRobe razmenaRobe)
        {
            bool izmena = Kontroler.Kontroler.Instance.PotvrdiRazmenuRobe(razmenaRobe);
            Odgovor odgovor = new Odgovor();
            if (izmena == true)
            {
                odgovor.Signal = Signal.Ok;
            }
            else
            {
                odgovor.Signal = Signal.Error;
            }
            return odgovor;
        }

        // ...#...
        private Odgovor VratiPretraguRazmene(Korisnik objekat, string text)
        {
            List<RazmenaRobe> razmeneRobe = Kontroler.Kontroler.Instance.VratiPretraguRazmene(objekat, text);
            Odgovor odgovor = new Odgovor();
            odgovor.Objekat = razmeneRobe;
            if (odgovor.Objekat == null)
                odgovor.Signal = Signal.Error;
            else
                odgovor.Signal = Signal.Ok;
            return odgovor;
        }

        // ...#...
        private Odgovor VratiPretraguRobe(Korisnik objekat, string text)
        {
            List<Roba> pretragaRobe = Kontroler.Kontroler.Instance.VratiPretraguRobe(objekat, text);
            Odgovor odgovor = new Odgovor();
            odgovor.Objekat = pretragaRobe;
            if (odgovor.Objekat == null)
                odgovor.Signal = Signal.Error;
            else
                odgovor.Signal = Signal.Ok;
            return odgovor;
        }

        // ...#...
        private Odgovor IzmeniRobu(Roba roba)
        {
            bool izmena = Kontroler.Kontroler.Instance.IzmeniRobu(roba);
            Odgovor odgovor = new Odgovor();
            if (izmena == true)
            {
                odgovor.Signal = Signal.Ok;
            }
            else
            {
                odgovor.Signal = Signal.Error;
            }
            return odgovor;
        }

        // ...#...
        private Odgovor ObrisiRobu(Roba roba)
        {
            bool uspesno = Kontroler.Kontroler.Instance.ObrisiRobu(roba);
            Odgovor odgovor = new Odgovor();
            if (uspesno == true)
            {
                odgovor.Signal = Signal.Ok;
            }
            else
            {
                odgovor.Signal = Signal.Error;
            }
            return odgovor;
        }

        // ...#...
        private Odgovor DodajRazmenu(RazmenaRobe razmenaRobe)
        {
            bool uspesno = Kontroler.Kontroler.Instance.SacuvajRazmenu(razmenaRobe);
            Odgovor odgovor = new Odgovor();
            if (uspesno == true)
            {
                odgovor.Signal = Signal.Ok;
            }
            else
            {
                odgovor.Signal = Signal.Error;
            }
            return odgovor;
        }

        // ...#...
        private Odgovor UnesiRobu(Roba roba)
        {
            bool uspesno = Kontroler.Kontroler.Instance.UnesiRobu(roba);
            Odgovor odgovor = new Odgovor();
            if (uspesno == true)
            {
                odgovor.Signal = Signal.Ok;
            }
            else
            {
                odgovor.Signal = Signal.Error;
            }
            return odgovor;
        }

        // ...#...
        private Odgovor VratiKategorije()
        {
            List<Kategorija> kateogrije = Kontroler.Kontroler.Instance.VratiListuKategorija();
            Odgovor odgovor = new Odgovor();
            odgovor.Objekat = kateogrije;
            if (kateogrije.Count == 0)
                odgovor.Signal = Signal.Error;
            else
                odgovor.Signal = Signal.Ok;
            return odgovor;
        }

        // ...#...
        private Odgovor VratiListuRobe(Korisnik objekat, string text)
        {
            List<Roba> robe = Kontroler.Kontroler.Instance.VratiListuRobe(objekat, text);
            Odgovor odgovor = new Odgovor();
            odgovor.Objekat = robe;
            if (odgovor.Objekat == null)
                odgovor.Signal = Signal.Error;
            else
                odgovor.Signal = Signal.Ok;
            return odgovor;
        }

        // ...#...
        private Odgovor VratiListuRazmeneRobe(Korisnik objekat, string text)
        {
            List<RazmenaRobe> razmeneRobe = Kontroler.Kontroler.Instance.VratiListuRazmeneRobe(objekat, text);
            Odgovor odgovor = new Odgovor();
            odgovor.Objekat = razmeneRobe;
            if (odgovor.Objekat == null)
                odgovor.Signal = Signal.Error;
            else
                odgovor.Signal = Signal.Ok;
            return odgovor;
        }

        // ...#...
        private Odgovor ProveraKorisnika(Korisnik korisnik)
        {
            bool postoji = Kontroler.Kontroler.Instance.ProveraKorisnikaIMaila(korisnik);
            Odgovor odgovor = new Odgovor();
            if (postoji == true)
            {
                odgovor.Signal = Signal.Ok;
            }
            else
            {
                odgovor.Signal = Signal.Error;
            }
            return odgovor;
        }

        // ...#...
        internal void IskljuciKlijentaIProslediPorukuKraj()
        {
            //ProslediOdgovor(new Odgovor { Signal = Signal.Kraj });
            klijent.Close();
        }

        // ...#...
        private Odgovor Registracija(Korisnik korisnik)
        {
            bool uspesno = Kontroler.Kontroler.Instance.Registracija(korisnik);
            Odgovor odgovor = new Odgovor();
            if (uspesno == true)
            {
                odgovor.Signal = Signal.Ok;
            }
            else
            {
                odgovor.Signal = Signal.Error;
            }
            return odgovor;
        }

        // ...#...
        private Odgovor VratiLokacije()
        {
            List<Lokacija> lokacije = Kontroler.Kontroler.Instance.VratiSveLokacije();
            Odgovor odgovor = new Odgovor();
            odgovor.Objekat = lokacije;
            if (odgovor.Objekat == null)
                odgovor.Signal = Signal.Error;
            else
                odgovor.Signal = Signal.Ok;
            return odgovor;
        }

        // ...#...
        private Odgovor PrijaviKorisnika(Korisnik korisnik)
        {
            Korisnik k = Kontroler.Kontroler.Instance.Prijava(korisnik);
            Odgovor odgovor = new Odgovor();
            if (k == null)
            {
                odgovor.Signal = Signal.Error;
                odgovor.Poruka = "Korisnik nije pronadjen!";
                odgovor.Objekat = new Korisnik();
            }
            else
            {
                odgovor.Signal = Signal.Ok;
                odgovor.Poruka = "Korisnik je pronadjen!";
                odgovor.Objekat = k;
                this.korisnik = k;
                frmServer.Invoke(new Action(() => frmServer.listaKorisnika.Add(k) ));
                //frmServer.listaKorisnika.Add(k);
            }
            return odgovor;
        }

        // ...#...
        private void ProslediOdgovor(Odgovor odgovor)
        {
            formatter.Serialize(klijentskiTok, odgovor);
        }

        // ...#...
        private Odgovor IzmenaProfila(Korisnik korisnik)
        {
            bool izmena = Kontroler.Kontroler.Instance.IzmenaProfila(korisnik);
            Odgovor odgovor = new Odgovor();
            if (izmena == true)
            {
                odgovor.Signal = Signal.Ok;
            }
            else
            {
                odgovor.Signal = Signal.Error;
            }
            return odgovor;
        }

        // ...#...
        private Odgovor UnesiKategoriju(Kategorija kategorija)
        {
            int uspesno = Kontroler.Kontroler.Instance.UnesiKategoriju(kategorija);
            Odgovor odgovor = new Odgovor();
            if (uspesno != -1)
            {
                odgovor.Signal = Signal.Ok;
            }
            else
            {
                odgovor.Signal = Signal.Error;
            }
            return odgovor;
        }

    }
}
