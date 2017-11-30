using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB_tllagile
{
    //classe colaborador com funções com o nome dos atributos da BD 
    class Colaborador
    {
        //metodos set & get
        public string id_colab { get; set; }
        public string nome { get; set; }
        public string disponibilidade { get; set; }
        

        //metodo que retorna informação de um objeto Colaborador
        public string DadosPesquisaBasica
        {
            get
            {
                String estado;
                // exemplo: Alexandre, A1, 912121772, (1)
                //$"{nome}, {codigo}, {telefone}, ({estado})";
                if (disponibilidade.Equals("True"))
                {
                    estado = "Disponivel";
                }
                else
                {
                    estado = "Indesponivel";
                }
                //String id_colab_retorno = id_colab.PadRight(25 - id_colab.Length) +"\t\t";
                //String nome_retorno = nome.PadRight(25 - nome.Length)+"\t\t";


                return $"{id_colab}|{nome}|{estado}";
            }
        }

    }
}
