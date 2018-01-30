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
        public string estado { get; set; }
        public DateTime data_nascimento { get; set; }
        public string email { get; set; }
        public DateTime data_inscricao { get; set; }
        public string estado_equipa { get; set; }

        //Criterios de Avaliação

        public double resultadoAhp { get; set; }

        public string colab_nome { get; set; }
        public string tipo { get; set; }
        public double prog_lang_skill { get; set; }
        public double problem_solving { get; set; }
        public double testing_skill { get; set; }
        public double integration_tool { get; set; }
        public double refact_concept { get; set; }
        public double db_knowledge { get; set; }
        public double big_data_knowledge { get; set; }
        public double communication { get; set; }
        public double know_business_model { get; set; }
        public double know_industry_field { get; set; }
        public double enterpreneur_ability { get; set; }
        public double financial_know { get; set; }
        public double proj_management_tool { get; set; }
        public double dev_environment_setup { get; set; }
        public double motivation_ability { get; set; }
        public double coordination_skill { get; set; }
        public double communication_master { get; set; }
        public double integration_tool_master { get; set; }
    
        //metodo que retorna informação de um objeto Colaborador
        public string dadosPesquisaBasica
        {
            get
            {
                String estadoString;
                // exemplo: Alexandre, A1, 912121772, (1)
                //$"{nome}, {codigo}, {telefone}, ({estado})";
                if (this.estado.Equals("True"))
                {
                    estadoString = "Disponivel";
                }
                else
                {
                    estadoString = "Indisponivel";
                }
                String id_colab_retorno = id_colab.PadRight(25 - id_colab.Length) +"\t\t";
                String nome_retorno = nome.PadRight(25 - nome.Length)+"\t\t";


                return $"{id_colab_retorno}|{nome_retorno}|{estadoString}";
            }
        }
        public string dadosPesquisaColabAtivos
        {
            get
            {
                
                // exemplo: Alexandre, A1, 912121772, (1)
                //$"{nome}, {codigo}, {telefone}, ({estado})";
 
                String id_colab_retorno = id_colab.PadRight(25 - id_colab.Length) + "\t\t";
                String nome_retorno = nome.PadRight(25 - nome.Length) + "\t\t";
                String email_retorno = email.PadRight(25 - nome.Length) + "\t\t";


                return $"{id_colab_retorno}|{nome_retorno}|{email_retorno}";
            }
        }

    }
}
