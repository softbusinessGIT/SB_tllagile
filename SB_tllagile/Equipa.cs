using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB_tllagile
{
    class Equipa
    {
        public string nome{ get; set; }
        public string nomeProj{ get; set; }
        public string estado{ get; set; }
        public string id_colab{ get; set; }
        public string id_projeto{ get; set; }
        public string id_funcao{ get; set; }
        // public string id_avaliacao{ get; set; }

        //metodo que retorna informação de um objeto Equipa
        public string dadosEquipa
        {
            get
            {
                String estadoEquipa;
                // exemplo: Alexandre, A1, 912121772, (1)
                //$"{nome}, {codigo}, {telefone}, ({estado})";
                if (estado.Equals("True"))
                {
                    estadoEquipa = "Disponivel";
                }
                else
                {
                    estadoEquipa = "Indesponivel";
                }
                String estadoEquipa_retorno = estadoEquipa.PadRight(25 - estadoEquipa.Length) + "\t\t";
                String nome_retorno = nome.PadRight(25 - nome.Length) + "\t\t";


                return $"{nome_retorno}|{nomeProj}|{estadoEquipa_retorno}";
            }
        }
    }



}


