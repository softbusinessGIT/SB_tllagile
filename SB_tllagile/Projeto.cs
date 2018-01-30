using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB_tllagile
{
    class Projeto
    {
        public String nome { get; set; }
        public DateTime data_ini { get; set; }
        public DateTime data_fim { get; set; }
        public String id_projeto { get; set; }

        //metodo que retorna informação de um objeto Projeto
        public string dadosProjeto
        {
            get
            {
                return $"{nome}, {data_ini}, {data_ini}";
            }
        }
    }
}
