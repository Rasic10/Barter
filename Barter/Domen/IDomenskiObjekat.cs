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

        string VratiSlozenUslov();

        IDomenskiObjekat VratiObjekat(SqlDataReader reader);

        string VratiVrednostiAtributa();

        List<IDomenskiObjekat> VratiListu(SqlDataReader reader);

        IDomenskiObjekat VratiUgnjezdeni();

        void setujUgnjezdeni(IDomenskiObjekat domenskiObjekat);

        string VratiImePrimarnogKljuca();

        string PostaviVrednostiAtributa();
        
        string VratiUslovPoIDu();

        IEnumerable<IDomenskiObjekat> VratiSlabeObjekte();
        //string VratiUslovZaNadjiSlogove(string text);

    }
}
