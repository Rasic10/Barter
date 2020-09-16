using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerBazePodataka
{
    public class Broker
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public Broker()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Barter;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public void OtvoriKonekciju()
        {
            connection.Open();
        }

        public void ZatvoriKonekciju()
        {
            connection.Close();
        }

        public void PokreniTransakciju()
        {
            transaction = connection.BeginTransaction();
        }
                
        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }
        
        public IDomenskiObjekat VratiJedan(IDomenskiObjekat objekat)
        {
            IDomenskiObjekat rezultat;
            SqlCommand command = new SqlCommand($"SELECT * FROM {objekat.VratiImeKlase()} WHERE {objekat.VratiUslovPoIDu()}", connection, transaction);
            SqlDataReader reader = command.ExecuteReader();
            rezultat = objekat.VratiObjekat(reader);
            reader.Close();

            int broj = 1;
            while (rezultat.VratiPoddomen(broj) != null)
            {
                rezultat.PostaviPoddomen(VratiJedan(rezultat.VratiPoddomen(broj)), broj);
                broj++;
            }

            return rezultat;
        }

        public List<IDomenskiObjekat> VratiSve(IDomenskiObjekat objekat, string operacija)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM {objekat.VratiImeKlase()} WHERE {objekat.VratiSlozenUslov(operacija)}", connection, transaction);
            SqlDataReader reader = command.ExecuteReader();
            List<IDomenskiObjekat> rezultat = objekat.VratiListu(reader);
            reader.Close();
            
            int broj = 1;
            foreach (IDomenskiObjekat rez in rezultat)
            {
                broj = 1;
                
                while (rez.VratiPoddomen(broj) != null)
                {
                    rez.PostaviPoddomen(VratiJedan(rez.VratiPoddomen(broj)), broj);
                    broj++;
                }
            }
            return rezultat;
        }

        //
        public List<IDomenskiObjekat> VratiRazmenuRobe(IDomenskiObjekat objekat, string operacija)
        {
            SqlCommand command = new SqlCommand($"SELECT RazmenaRobe.*, Roba.* FROM {objekat.VratiImeKlase()} JOIN Roba ON RazmenaRobe.RazmenaID = Roba.RazmenaUlozeneRobe WHERE {objekat.VratiSlozenUslov(operacija)}", connection, transaction);
            SqlDataReader reader = command.ExecuteReader();
            List<IDomenskiObjekat> rezultat = objekat.VratiListu(reader);
            reader.Close();

            int broj = 1;
            foreach (IDomenskiObjekat rez in rezultat)
            {
                broj = 1;

                while (rez.VratiPoddomen(broj) != null)
                {
                    rez.PostaviPoddomen(VratiJedan(rez.VratiPoddomen(broj)), broj);
                    broj++;
                }
            }
            return rezultat;
        }

        // ...#...
        public List<IDomenskiObjekat> VratiPretragu(IDomenskiObjekat objekat, string tekst)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM {objekat.VratiImeKlase()} WHERE {objekat.VratiPretragu(tekst)}", connection, transaction);
            SqlDataReader reader = command.ExecuteReader();
            List<IDomenskiObjekat> rezultat = objekat.VratiListu(reader);
            reader.Close();

            int broj = 1;
            foreach (IDomenskiObjekat rez in rezultat)
            {
                broj = 1;

                while (rez.VratiPoddomen(broj) != null)
                {
                    rez.PostaviPoddomen(VratiJedan(rez.VratiPoddomen(broj)), broj);
                    broj++;
                }
            }
            return rezultat;
        }

        // ...#...
        public int Sacuvaj(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand($"INSERT INTO {objekat.VratiImeKlase()} VALUES ({objekat.VratiVrednostiAtributa()})", connection, transaction);
            return command.ExecuteNonQuery();
        }

        // ...#...
        public bool SacuvajSlozen(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand($"INSERT INTO {objekat.VratiImeKlase()} OUTPUT {objekat.VratiImePrimarnogKljuca()} VALUES ({objekat.VratiVrednostiAtributa()})", connection, transaction);

            int id = (int)command.ExecuteScalar();
            foreach (IDomenskiObjekat o in objekat.VratiSlabeObjekte())
            {
                // smanjiti robu sa update preko where uslova za korisnika i naziv robe
                // na primer UPDATE Roba SET KolicinaRobe = KolicinaRobe - 100 WHERE NazivRobe = 'Secer' AND KorisnikRobe = 2 AND RazmenaUlozeneRobe IS NULL
                SqlCommand command3 = new SqlCommand($"UPDATE {o.VratiImeKlase()} SET KolicinaRobe = KolicinaRobe - {((Roba)o).KolicinaRobe} WHERE NazivRobe = '{((Roba)o).NazivRobe}' AND KorisnikRobe = {((Roba)o).KorisnikRobe.KorisnikID} AND RazmenaUlozeneRobe IS NULL", connection, transaction);
                var i = command3.ExecuteNonQuery();

                SqlCommand command2 = new SqlCommand($"INSERT INTO {o.VratiImeKlase()} VALUES ({o.VratiVrednostiAtributa()}, {id})", connection, transaction);
                command2.ExecuteScalar();
            }

            IDomenskiObjekat trazenaRoba = objekat.VratiPoddomen(3);
            if (Izmeni(trazenaRoba) != 1)
            {
                throw new Exception();
            }

            return true;
        }

        // ...#...
        public int SacuvajIUzvratiID(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand($"INSERT INTO {objekat.VratiImeKlase()} OUTPUT {objekat.VratiImePrimarnogKljuca()} VALUES({objekat.VratiVrednostiAtributa()})", connection, transaction);
            return (int)command.ExecuteScalar();
        }

        // ...#...
        public int Izmeni(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand($"UPDATE {objekat.VratiImeKlase()} SET {objekat.PostaviVrednostiAtributa()} WHERE {objekat.VratiUslovPoIDu()}", connection, transaction);
            return command.ExecuteNonQuery();
        }

        // ...#....
        public int Obrisi(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand($"DELETE FROM {objekat.VratiImeKlase()} WHERE {objekat.VratiUslovPoIDu()}", connection, transaction);
            return command.ExecuteNonQuery();
        }

        // ponistena razmena
        public int PonistiSlozen(IDomenskiObjekat objekat)
        {
            RazmenaRobe rr = (RazmenaRobe)objekat;
            int ret = 0;

            Izmeni(objekat);

            foreach(Roba r in rr.UlozenaRoba)
            {
                SqlCommand command1 = new SqlCommand($"UPDATE {r.VratiImeKlase()} SET KolicinaRobe = KolicinaRobe + {r.KolicinaRobe} WHERE NazivRobe = '{r.NazivRobe}' AND KorisnikRobe = {rr.KorisnikUlozeneRobe.KorisnikID} AND RazmenaUlozeneRobe IS NULL", connection, transaction);
                ret = command1.ExecuteNonQuery();
            }

            SqlCommand command2 = new SqlCommand($"UPDATE {rr.TrazenaRoba.VratiImeKlase()} SET KolicinaRobe = KolicinaRobe + {rr.KolicinaRobe} WHERE NazivRobe = '{rr.TrazenaRoba.NazivRobe}' AND KorisnikRobe = {rr.KorisnikTrazeneRobe.KorisnikID} AND RazmenaUlozeneRobe IS NULL", connection, transaction);
            return command2.ExecuteNonQuery() + ret;
        }

    }
}
