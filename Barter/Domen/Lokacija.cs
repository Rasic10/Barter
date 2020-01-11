using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Lokacija
    {
        private int ptt;
        private string nazivOpstine;

        public int Ptt { get => ptt; set => ptt = value; }
        public string NazivOpstine { get => nazivOpstine; set => nazivOpstine = value; }

        public override string ToString()
        {
            return NazivOpstine + " " + Ptt;
        }
    }
}
