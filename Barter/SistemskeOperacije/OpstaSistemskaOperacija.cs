using BrokerBazePodataka;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public abstract class OpstaSistemskaOperacija
    {
        protected Broker broker = new Broker();

        protected abstract void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat);

        protected abstract void Validacija(IDomenskiObjekat objekat);

        public void Izvrsi(IDomenskiObjekat objekat)
        {
            try
            {
                Validacija(objekat);
                broker.OtvoriKonekciju();
                broker.PokreniTransakciju();
                IzvrsiKonkretnuOperaciju(objekat);
                broker.Commit();
            }
            catch (Exception e)
            {
                broker.Rollback();
                throw;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }
    }
}
