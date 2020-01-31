using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barter
{
    public class ExceptionServer : Exception
    {
        public ExceptionServer(string message) : base(message)
        {
        }
    }
}
