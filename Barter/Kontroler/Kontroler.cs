using BrokerBazePodataka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontroler
{
    public class Kontroler
    {
        private Broker broker = new Broker();
        private static Kontroler _instance;

        public static Kontroler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Kontroler();
                }
                return _instance;
            }
        }
        private Kontroler()
        {
        }


    }
}
