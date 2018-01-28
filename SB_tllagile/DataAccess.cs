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
        //Método pequisa na base de dados todos os colaboradores por estado/estado
        public List<Colaborador> getPessoa(int estado)
        {
            //using faz a ligação a BD e no fim dá KILL ao processo, para evitar loops e inconsistências
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                var output = connection.Query<Colaborador>($" select * from colaborador where estado = '{estado}'").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @disponibiidade", new {disponibiidade = disponibiidade}).ToList();
                return output;
            }
            //throw new NotImplementedException();

        }
        //Método pequisa na base de dados um colavorador
        public List<Colaborador> getColaborador(String idIn)
        {
            //using faz a ligação a BD e no fim dá KILL ao processo, para evitar loops e inconsistências
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                var output = connection.Query<Colaborador>($" select * from colaborador where id_colab = '{idIn}'").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @disponibiidade", new {disponibiidade = disponibiidade}).ToList();
                return output;
            }
        }
        //Método pequisa na base de dados um colaborador
        public List<Indisponibilidade> getIndispColaborador(String idIn)
        {
            //using faz a ligação a BD e no fim dá KILL ao processo, para evitar loops e inconsistências
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                var output = connection.Query<Indisponibilidade>($" select * from indisponibilidade where id_colab = '{idIn}'").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @disponibiidade", new {disponibiidade = disponibiidade}).ToList();
                return output;
            }  
        }
        //Método que pequisa na base de dados todos os colaboradores
        public List<Colaborador> getTodosColab()
        {
            //using faz a ligação a BD e no fim dá KILL ao processo, para evitar loops e inconsistências
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                var output = connection.Query<Colaborador>($" select * from colaborador").ToList();
                return output;
            }

        }
        //Método que insere na base de dados um colaborador
        public void insertColabBd(String nomeIn, String estadoIn, DateTime data_inscricaoIn, DateTime data_nascimentoIn, String emailIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                List<Colaborador> listaColab = new List<Colaborador>();
                listaColab.Add(new Colaborador { nome = nomeIn, estado = estadoIn, data_inscricao = data_inscricaoIn, data_nascimento = data_nascimentoIn, email = emailIn });

                connection.Execute($"insert into colaborador(nome,estado,data_inscricao,data_nascimento,email ) values(@nome, @estado,@data_inscricao,@data_nascimento,@email)", listaColab);
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                //return outputQueryUserBd;
            }

        }
        //Método que insere na base de dados uma indisponibilidade de um certo colaborador
        public void insertIndispColabBd(String id_colabIn, DateTime data_ndisp_inicioIn, DateTime data_ndisp_fimIn, String motivoIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                List<Indisponibilidade> listaIndispColab = new List<Indisponibilidade>();
                listaIndispColab.Add(new Indisponibilidade {id_colab = id_colabIn, data_ndisp_inicio = data_ndisp_inicioIn, data_ndisp_fim = data_ndisp_fimIn, motivo = motivoIn});

                connection.Execute($"insert into indisponibilidade(id_colab,data_ndisp_inicio,data_ndisp_fim,motivo) values(@id_colab, @data_ndisp_inicio,@data_ndisp_fim,@motivo)", listaIndispColab);
            }

        }
        //Método que Altera (Update) o estado/estado de um colaborador
        public void alterColabBd(String id_colabIn, String estadoIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                List<Colaborador> listaColab = new List<Colaborador>();
                listaColab.Add(new Colaborador { id_colab = id_colabIn, estado = estadoIn });

                connection.Execute($"UPDATE colaborador SET estado = @estado WHERE id_colab = @id_colab", listaColab);
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                //return outputQueryUserBd;
            }

        }
        //Método que Pesquisa os utilizadores na bd
        public List<Utilizador> SearchUserBd(String username, String password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                var outputQueryUserBd = connection.Query<Utilizador>($" select * from utilizador where username = '{username}'and password = '{password}'").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                return outputQueryUserBd;
            }

        }
        //Método que Altera (Update) o estado/estado de um colaborador
        public void alterUserPasswordBd(String username, String password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                List<Utilizador> listaAlterUser = new List<Utilizador>();
                listaAlterUser.Add(new Utilizador { username = username, password = password });

                connection.Execute($"UPDATE utilizador SET password = @password WHERE username = @username", listaAlterUser);
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                //return outputQueryUserBd;
            }
        }
        //Método que insere os projetos na base de dados
        public void InsertProjetoBd(String nomeIn, DateTime data_iniIn, DateTime data_fimIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                List<Projeto> listaProjeto = new List<Projeto>();
                listaProjeto.Add(new Projeto { nome = nomeIn, data_ini = data_iniIn, data_fim = data_fimIn });

                connection.Execute($"insert into projeto(nome,data_ini,data_fim) values(@nome,@data_ini,@data_fim)", listaProjeto);
            }

        }

        //Método que Pesquisa equipas por estado
        public List<Equipa> searchEquipaBd(int estadoIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                var outputQueryBd = connection.Query<Equipa>($" select distinct E.nome, P.nome as nomeProj, E.estado from equipa E, colaborador C, projeto P, funcao F where E.estado = '{estadoIn}'and E.id_projeto = P.id_projeto").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                return outputQueryBd;


            }
        }
    }
}
