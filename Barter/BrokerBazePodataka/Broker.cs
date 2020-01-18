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

        // ...#...
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
                Debug.WriteLine(">>>" + e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        // ...#...
        public void Registracija(Korisnik k)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Korisnik VALUES(@UsernameKorisnika, @ImeKorisnika, @PrezimeKorisnika, @email, @sifra, @DatumRodjenja, @Adresa, @Lokacija)";
            command.Parameters.AddWithValue("@UsernameKorisnika", k.UsernameKorisnika);
            command.Parameters.AddWithValue("@ImeKorisnika", k.ImeKorisnika);
            command.Parameters.AddWithValue("@PrezimeKorisnika", k.PrezimeKorisnika);
            command.Parameters.AddWithValue("@email", k.Email);
            command.Parameters.AddWithValue("@sifra", k.Sifra);
            command.Parameters.AddWithValue("@DatumRodjenja", k.DatumRodjenja);
            command.Parameters.AddWithValue("@Adresa", k.Adresa);
            command.Parameters.AddWithValue("@Lokacija", k.Lokacija.Ptt);
            command.ExecuteNonQuery();
        }

        // ...#...
        public bool DaLiPostojiKorisnik(string korIme, string email)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Korisnik WHERE UsernameKorisnika = @UsernameKorisnika OR email = @email";
            command.Parameters.AddWithValue("@UsernameKorisnika", korIme);
            command.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = command.ExecuteReader();
            return reader.Read();
        }

        // ...
        public int IzmenaProfila(Korisnik k)
        {
            SqlCommand command = new SqlCommand($"UPDATE Korisnik SET ImeKorisnika = @ImeKorisnika, PrezimeKorisnika = @PrezimeKorisnika, sifra = @sifra, DatumRodjenja = @DatumRodjenja, Adresa = @Adresa, Lokacija = @Lokacija WHERE KorisnikID = @KorisnikID", connection, transaction);
            command.Parameters.AddWithValue("@ImeKorisnika", k.ImeKorisnika);
            command.Parameters.AddWithValue("@PrezimeKorisnika", k.PrezimeKorisnika);
            command.Parameters.AddWithValue("@sifra", k.Sifra);
            command.Parameters.AddWithValue("@DatumRodjenja", k.DatumRodjenja);
            command.Parameters.AddWithValue("@Adresa", k.Adresa);
            command.Parameters.AddWithValue("@Lokacija", k.Lokacija.Ptt);
            command.Parameters.AddWithValue("@KorisnikID", k.KorisnikID);
            return command.ExecuteNonQuery();
        }

        // ...#... potrebno doraditi
        public BindingList<Roba> VratiListuRobe(Korisnik korisnik, string operacija)
        {
            try
            {
                connection.Open();
                BindingList<Roba> listaRobe = new BindingList<Roba>();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM Roba r JOIN Korisnik k ON (r.KorisnikRobe = k.KorisnikID) JOIN Kategorija kat ON (r.KategorijaRobe = kat.KategorijaID) WHERE r.KorisnikRobe {operacija} {korisnik.KorisnikID}";
                SqlDataReader reader = command.ExecuteReader();
                Roba r;
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
                            KategorijaID = reader.GetInt32(17),
                            VrstaKategorije = reader.GetString(18)
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
                Debug.WriteLine(">>> " + e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        // ...#...
        public List<Lokacija> VratiSveLokacije()
        {
            try
            {
                connection.Open();
                List<Lokacija> lokacije = new List<Lokacija>();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM Lokacija";
                SqlDataReader reader = command.ExecuteReader();
                Lokacija l;
                while (reader.Read())
                {
                    l = new Lokacija
                    {
                        Ptt = reader.GetInt32(0),
                        NazivOpstine = reader.GetString(1)
                    };
                    lokacije.Add(l);
                }
                reader.Close();
                return lokacije;
            }
            catch (Exception e)
            {
                Debug.WriteLine(">>> " + e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        // ...#...
        public BindingList<Kategorija> VratiListuKategorija()
        {
            BindingList<Kategorija> kategorije = new BindingList<Kategorija>();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Kategorija";
            SqlDataReader reader = command.ExecuteReader();
            Kategorija k;
            while (reader.Read())
            {
                k = new Kategorija
                {
                    KategorijaID = reader.GetInt32(0),
                    VrstaKategorije = reader.GetString(1)
                };
                kategorije.Add(k);
            }
            reader.Close();
            return kategorije;
        }

        // ...#...
        public int UnesiKateogoriju(Kategorija k)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Kategorija OUTPUT inserted.KategorijaID VALUES(@VrstaKategorije)";
            command.Parameters.AddWithValue("@VrstaKategorije", k.VrstaKategorije);
            return (int)command.ExecuteScalar();
        }

        // ...#...
        public void UnesiRobu(Roba r)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Roba(NazivRobe, KolicinaRobe, CenaRobe, DatumUnosaRobe, KorisnikRobe, KategorijaRobe) VALUES(@NazivRobe, @KolicinaRobe, @CenaRobe, @DatumUnosaRobe, @KorisnikRobe, @KategorijaRobe)";
            command.Parameters.AddWithValue("@NazivRobe", r.NazivRobe);
            command.Parameters.AddWithValue("@KolicinaRobe", (float)r.KolicinaRobe);
            command.Parameters.AddWithValue("@CenaRobe", (float)r.CenaRobe);
            command.Parameters.AddWithValue("@DatumUnosaRobe", r.DatumUnosaRobe);
            command.Parameters.AddWithValue("@KorisnikRobe", r.KorisnikRobe.KorisnikID);
            command.Parameters.AddWithValue("@KategorijaRobe", r.KategorijaRobe.KategorijaID);
            command.ExecuteNonQuery();
        }

    }
}
