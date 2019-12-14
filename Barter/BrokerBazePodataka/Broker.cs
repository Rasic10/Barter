using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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

        public Korisnik Prijava(string korIme, string sifra)
        {
            try
            {
                connection.Open();
                Korisnik k = null;
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM Korisnik WHERE UsernameKorisnika='{korIme}' AND sifra='{sifra}'";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    k = new Korisnik
                    {
                        KorisnikID = reader.GetInt32(0),
                        UsernameKorisnika = reader.GetString(1),
                        ImeKorisnika = reader.GetString(2),
                        PrezimeKorisnika = reader.GetString(3),
                        Email = reader.GetString(4),
                        Sifra = reader.GetString(5),
                        DatumRodjenja = reader.GetDateTime(6),
                        Adresa = reader.GetString(7),
                    };
                    break;
                }
                reader.Close();
                return k;
            }
            catch (Exception e)
            {
                //ispisati gresku na konzoli
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public BindingList<Roba> VratiListuRobe(Korisnik korisnik)
        {
            try
            {
                connection.Open();
                BindingList<Roba> listaRobe = new BindingList<Roba>();
                Roba r;
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM Roba r JOIN Korisnik k ON (r.KorisnikRobe = k.KorisnikID) JOIN Kategorija kat ON (r.KategorijaRobe = kat.KategorijaID) WHERE r.KorisnikRobe != {korisnik.KorisnikID}";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    r = new Roba
                    {
                        RobaID = reader.GetInt32(0),
                        NazivRobe = reader.GetString(1),
                        KolicinaRobe = reader.GetDouble(2),
                        CenaRobe = reader.GetDouble(3),
                        DatumUnosaRobe = reader.GetDateTime(4),
                        KorisnikRobe = new Korisnik
                        {
                            KorisnikID = reader.GetInt32(8),
                            UsernameKorisnika = reader.GetString(9),
                            ImeKorisnika = reader.GetString(10),
                            PrezimeKorisnika = reader.GetString(11),
                            Email = reader.GetString(12),
                            Sifra = reader.GetString(13),
                            DatumRodjenja = reader.GetDateTime(14),
                            Adresa = reader.GetString(15)
                            // ...#...treba dodati za lokaciju
                        },
                        KategorijaRobe = new Kategorija
                        {
                            KategorijaID = reader.GetInt32(17)
                            // ...#...treba dodati u vezi enumeratora
                        }
                        // ...#...treba dodati za razmenu
                    };
                    listaRobe.Add(r);
                }
                reader.Close();
                return listaRobe;
            }
            catch (Exception e)
            {
                //ispisati gresku na konzoli
                return null;
            }
            finally
            {
                connection.Close();
            }
        }



    }
}
