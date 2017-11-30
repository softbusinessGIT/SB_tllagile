using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper; //libraria para ligação a BD
using System.Data;

namespace SB_tllagile
{
    // Classe com as funções de pesquisa, edição e inserção na BD
    class DataAccess
    {
        public List<Colaborador> GetPessoa(int disponibilidade)
        {
            //using faz a ligação a BD e no fim dá KILL ao processo, para evitar loops e inconsistências
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.ConVal("tllagileDB")))
            {
                var output = connection.Query<Colaborador>($" select * from colaborador where disponibilidade = '{disponibilidade}'").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @disponibiidade", new {disponibiidade = disponibiidade}).ToList();
                return output;
            }
            //throw new NotImplementedException();

        }
        public List<Colaborador> GetTodosColab()
        {
            //using faz a ligação a BD e no fim dá KILL ao processo, para evitar loops e inconsistências
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.ConVal("tllagileDB")))
            {
                var output = connection.Query<Colaborador>($" select * from colaborador").ToList();
                return output;
            }
            //throw new NotImplementedException();

        }
        public void InsertColabBd(string nomeIn, string disponibilidadeIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.ConVal("tllagileDB")))
            {
                List<Colaborador> listaColab = new List<Colaborador>();
                listaColab.Add(new Colaborador { nome = nomeIn, disponibilidade = disponibilidadeIn });

                connection.Execute($"insert into colaborador(nome,disponibilidade) values(@nome, @disponibilidade)", listaColab);
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                //return outputQueryUserBd;
            }

        }
        public void AlterColabBd(String id_colabIn, string disponibilidadeIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.ConVal("tllagileDB")))
            {
                List<Colaborador> listaColab = new List<Colaborador>();
                listaColab.Add(new Colaborador { id_colab = id_colabIn, disponibilidade = disponibilidadeIn });

                connection.Execute($"UPDATE colaborador SET disponibilidade = @disponibilidade WHERE id_colab = @id_colab", listaColab);
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                //return outputQueryUserBd;
            }

        }

        public List<Utilizador> SearchUserBd(string username, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.ConVal("tllagileDB")))
            {
                var outputQueryUserBd = connection.Query<Utilizador>($" select * from utilizador where username = '{username}'and password = '{password}'").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                return outputQueryUserBd;
            }

        }


        public void InsertProjetoBd(string nomeIn, DateTime data_iniIn, DateTime data_fimIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.ConVal("tllagileDB")))
            {
                List<Projeto> listaProjeto = new List<Projeto>();
                listaProjeto.Add(new Projeto { nome = nomeIn, data_ini = data_iniIn, data_fim = data_fimIn });

                connection.Execute($"insert into projeto(nome,data_ini,data_fim) values(@nome,@data_ini,@data_fim)", listaProjeto);
            }

        }
    }
}
