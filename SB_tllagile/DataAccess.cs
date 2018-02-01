using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper; //libraria para ligação a BD
using System.Data;
using System.Windows.Forms;

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
        //Método pequisa na base de dados um colaborador
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
        
        //Método pequisa na base de dados a indisponibilidade de um colab 
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
        //Método que Altera (Update) o estado de um colaborador
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
        //Método que Altera (Update) o estado equipa (se está ou não) de um colaborador
        public void alterEstadoEquipaColabBd(String id_colabIn, String estadoIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                List<Colaborador> listaColab = new List<Colaborador>();
                listaColab.Add(new Colaborador { id_colab = id_colabIn, estado_equipa = estadoIn });

                connection.Execute($"UPDATE colaborador SET estado_equipa = @estado_equipa WHERE id_colab = @id_colab", listaColab);
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                //return outputQueryUserBd;
            }

        }
        //Método que Altera (Update) o estado da tabela equipa - criar equipa
        public void alterEstadoEquipaBd(String id_colabIn, String estadoIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                List<Equipa> listaColab = new List<Equipa>();
                listaColab.Add(new Equipa { id_colab = id_colabIn, estado = estadoIn });

                connection.Execute($"UPDATE equipa SET estado = @estado WHERE id_colab = @id_colab", listaColab);
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                //return outputQueryUserBd;
            }

        }
        //Método que Altera (Update) o estado equipa (se está ou não) de um colaborador
        public void updateEstadoEquipaColabBd(String id_colabIn, String estadoIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                List<Colaborador> listaColab = new List<Colaborador>();
                listaColab.Add(new Colaborador { id_colab = id_colabIn, estado_equipa = estadoIn });

                connection.Execute($"UPDATE colaborador SET estado_equipa = @estado_equipa WHERE id_colab = @id_colab", listaColab);
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                //return outputQueryUserBd;
            }

        }
        //Método que Altera (Update) a informação de um colaborador
        public void alterInfoColabBd(String id_colabIn, String emailIn, String nomeIn, String estadoIn, DateTime data_nascimentoIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                List<Colaborador> listaColab = new List<Colaborador>();
                listaColab.Add(new Colaborador { id_colab = id_colabIn, email = emailIn, nome = nomeIn, data_nascimento = data_nascimentoIn, estado = estadoIn });

                connection.Execute($"UPDATE colaborador SET estado = @estado, email = @email, data_nascimento = @data_nascimento, @nome = nome WHERE id_colab = @id_colab", listaColab);
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
        //Método que Pesquisa os utilizadores na bd
        public List<Utilizador> SearchUser(String username)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                var outputQueryUserBd = connection.Query<Utilizador>($" select * from utilizador where username = '{username}'").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                return outputQueryUserBd;
            }

        }
        //Método que Altera (Update) a password de o utilizador
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
        //Método que Pesquisa prjetos ativos
        public List<Projeto> searchProjetosBd()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                var now = DateTime.Now.ToString("yyyy-MM-dd");
                var outputQueryBd = connection.Query<Projeto>($" select * from projeto where data_fim > '{now}'").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                return outputQueryBd;
            }
        }
        //Método que Pesquisa prjetos por estado
        public List<Projeto> searchProjetoIdBd(String id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                //var now = DateTime.Now.ToString("yyyy-MM-dd");
                var outputQueryBd = connection.Query<Projeto>($" select * from projeto where id_projeto = '{id}'").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                return outputQueryBd;
            }
        }
        //Método que Pesquisa prjetos ativos
        public List<Projeto> searchProjetoDatasBd(DateTime data_iniIn, DateTime data_fimIn)
        {
            string DataIni = data_iniIn.ToString("yyyy-MM-dd");

            //DialogResult dialogDataVerifica = MessageBox.Show(DataIni,
            //   "Erro - Datas erradas", MessageBoxButtons.OK, MessageBoxIcon.Error);

            var DataFim = data_fimIn.ToString("yyyy-MM-dd");

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                var outputQueryBd = connection.Query<Projeto>($" select * from projeto where data_ini BETWEEN '{DataIni}' and '{DataFim}' and data_fim BETWEEN '{DataIni}' and '{DataFim}'").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                return outputQueryBd;
            }
        }
        //Método que Pesquisa equipas por estado
        public List<Equipa> searchProjetosAtivos()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                var now = DateTime.Now.ToString("yyyy-MM-dd");
                var outputQueryBd = connection.Query<Equipa>($" select distinct * from colaborador, projeto, equipa where projeto.data_fim < '{now}' and projeto.id_projeto = equipa.id_projeto and equipa.estado = '1' and equipa.id_colab = colaborador.id_colab order by projeto.data_fim Desc").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();

                return outputQueryBd;
            }
        }
        //Método que Pesquisa equipas por estado
        public List<Equipa> searchEquipaProjetoBd(String  id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                var outputQueryBd = connection.Query<Equipa>($" select *, P.nome as nomeProj from equipa E, projeto P where E.id_colab = '{id}' and E.id_projeto = P.id_projeto").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                return outputQueryBd;
            }
        }
        //Método que Pesquisa equipas por projeto
        public List<Equipa> searchEquipaProjetoInfoBd(String id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                var outputQueryBd = connection.Query<Equipa>($" select *, P.nome as nomeProj, colaborador.nome as nomeColab from colaborador, equipa E, projeto P where E.id_projeto = '{id}' and E.id_colab = colaborador.id_colab and E.id_projeto = P.id_projeto").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                return outputQueryBd;
            }
        }
        //Método que Pesquisa se o colocaborador está numa equipa
        public List<Equipa> searchColabEquipaBd()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                var outputQueryBd = connection.Query<Equipa>($" Select * from colaborador, equipa where equipa.id_colab = colaborador.id_colab and equipa.estado='1'").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                return outputQueryBd;
            }
        }
        //Método que Pesquisa se o colocaborador está numa equipa
        public List<Colaborador> searchColabEstadoEquipaBd()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                var outputQueryBd = connection.Query<Colaborador>($" Select * from colaborador where estado_equipa='0' and estado='1'").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                return outputQueryBd;
            }
        }
        //Método que Pesquisa se o colocaborador está numa equipa
        public List<Colaborador> pontuacaoColab()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                var outputQueryBd = connection.Query<Colaborador>($" Select distinct *, colaborador.nome as colab_nome from colaborador, equipa, avaliacao where colaborador.id_colab = equipa.id_colab and equipa.id_avaliacao = avaliacao.id_avaliacao and colaborador.estado_equipa = 0").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                return outputQueryBd;
            }
        }
        //Método que insere um colaborador a uma equipa
        public void InsertEquipaBd(String nomeIn, String estadoIn, String colabId, String projetoId, String funcaoId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                List<Equipa> listaEquipa = new List<Equipa>();
                listaEquipa.Add(new Equipa { nome = nomeIn, estado = estadoIn, id_colab = colabId, id_funcao = funcaoId, id_projeto = projetoId , id_avaliacao = null});

                connection.Execute($"insert into equipa(nome,estado,id_colab,id_funcao,id_projeto,id_avaliacao ) values(@nome,@estado,@id_colab,@id_funcao,@id_projeto,@id_avaliacao)", listaEquipa);
            }

        }

        //Método que insere um historico de Projetos na BD
        public void insertHistoricoColabBd(String id_colabIn, DateTime data_ndisp_inicioIn, DateTime data_ndisp_fimIn, String motivoIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                List<Indisponibilidade> listaIndispColab = new List<Indisponibilidade>();
                listaIndispColab.Add(new Indisponibilidade { id_colab = id_colabIn, data_ndisp_inicio = data_ndisp_inicioIn, data_ndisp_fim = data_ndisp_fimIn, motivo = motivoIn });

                connection.Execute($"insert into indisponibilidade(id_colab,data_ndisp_inicio,data_ndisp_fim,motivo) values(@id_colab, @data_ndisp_inicio,@data_ndisp_fim,@motivo)", listaIndispColab);
            }

        }
        //Método que insere um historico de Projetos na BD
        public void insertHistoricoEquipaColabBd(String id_colabIn, DateTime data_inicioIn, DateTime data_fimIn, String id_projetoIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                List<Indisponibilidade> listaIndispColab = new List<Indisponibilidade>();
                listaIndispColab.Add(new Indisponibilidade { id_colab = id_colabIn, data_ini = data_inicioIn, data_fim = data_fimIn, id_projeto = id_projetoIn });

                connection.Execute($"insert into historico(id_colab,data_ini,data_fim,id_projeto) values(@id_colab, @data_ini, @data_fim, @id_projeto)", listaIndispColab);
            }

        }
        //Método que Pesquisa projetos de um colaborador
        public List<Projeto> searchHistoricoBd(String id_colabIn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper_db.conVal("tllagileDB")))
            {
                var outputQueryBd = connection.Query<Projeto>($" select * from historico, projeto where id_colab = '{id_colabIn}'").ToList();
                //var output = connection.Query<Colaborador>("dbo.Nome_Procedure @estado", new {estado = estado}).ToList();
                return outputQueryBd;
            }
        }

    }
}
