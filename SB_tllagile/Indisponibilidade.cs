using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB_tllagile
{
    class Indisponibilidade
    {
        //metodos set & get
        public string id_colab { get; set; }
        public DateTime data_ndisp_inicio { get; set; }
        public DateTime data_ndisp_fim { get; set; }
        public string motivo { get; set; }

        //historico equipa
        public string id_projeto { get; set; }
        public DateTime data_ini { get; set; }
        public DateTime data_fim { get; set; }
    }
}
