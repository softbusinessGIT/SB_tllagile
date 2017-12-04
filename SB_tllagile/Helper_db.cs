using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB_tllagile
{
    class Helper_db
    {
        //Classe que vai buscar a string connection para realizar a ligação a BD (App.config) 
            public static string conVal(string nome)
            {
                return ConfigurationManager.ConnectionStrings[nome].ConnectionString;
            }
    }
}
