using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB_tllagile
{
    class Utilizador
    {
        //metodos set & get
        public string username { get; set; }
        public string password { get; set; }
        public string nome { get; set; }
        public string morada { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public int estado { get; set; }

        //metodo que retorna informação de um objeto Colaborador
        public string info
        {
            get
            {
                //alex, exemplo@gmail.com, Alexandre, Gaia, (1)
                return $"{username}, {email}, {nome}, {morada}, ({estado})";
            }
        }
    }
}
