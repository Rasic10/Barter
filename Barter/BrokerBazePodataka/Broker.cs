using Domen;
using System;
using System.Collections.Generic;
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
            finally
            {
                connection.Close();
            }
        }






    }
}
