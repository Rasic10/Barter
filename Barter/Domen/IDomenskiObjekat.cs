using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public interface IDomenskiObjekat
    {
        string VratiImeKlase();

        string VratiUslovZaNadjiSlog();

        IDomenskiObjekat VratiObjekat(SqlDataReader reader);

        string VratiVrednostiAtributa();
        
        //string PostaviVrednostiAtributa();
        //string VratiUslovZaNadjiSlogove(string text);
        //List<IDomenskiObjekat> VratiListu(SqlDataReader reader);
        //IDomenskiObjekat VratiUgnjezdeni();
        //void setujUgnjezdeni(IDomenskiObjekat domenskiObjekat);
        //object VratiImePrimarnogKljuca();
        //IEnumerable<IDomenskiObjekat> VratiSlabeObjekte();
    }
}
