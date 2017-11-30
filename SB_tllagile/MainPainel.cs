using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SB_tllagile
{
    public partial class MainPainel : Form
    {
        //Variaveis 
        List<Colaborador> listaPesquisaBasicaColab = new List<Colaborador>();
        List<Colaborador> listaAlterColab = new List<Colaborador>();
        DataAccess db = new DataAccess(); //cria o objeto db

        public MainPainel()
        {
            InitializeComponent();
            //SearchColabBasicaPainel.BackColor = Color.LightGray;
            //menuStrip1.ForeColor = Color.White; //coloca a letra do menu a branco
            AtualizarListBox();
            comboBoxBasica.SelectedIndex = 0;
            DataIniTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DataFimTextBox.Text = DateTime.Now.AddMonths(3).ToString("yyyy-MM-dd");
        }
        //Métodos 

        //Atualiza a listBox com a informação returnada da query a BD
        public void AtualizarListBox()
        {
            AlterColabListBox.DataSource = listaAlterColab; // Indicação que a fonte de informação é a lista
            AlterColabListBox.DisplayMember = "DadosPesquisaBasica"; // Mostrar o conteudo da função Colaborador.DadosPesquisaBasica();

            listBoxColab.DataSource = listaPesquisaBasicaColab; // Indicação que a fonte de informação é a lista
            listBoxColab.DisplayMember = "DadosPesquisaBasica"; // Mostrar o conteudo da função Colaborador.DadosPesquisaBasica();
        }
        private void PesquisarBasicaButton_Click(object sender, EventArgs e)
        {
            //DataAccess db = new DataAccess();
            if ((comboBoxBasica.Text).Equals("Indisponivel"))
            {
                // A lista "listaPesquisaBasicaColab" vai conter o retorno da pesquisa á BD
                listaPesquisaBasicaColab = db.GetPessoa(0);

            }
            else
            {
                listaPesquisaBasicaColab = db.GetPessoa(1);

            }
            AtualizarListBox();
        }

        private void básicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchColabBasicaPainel.Visible = true;
            InsertProjetoPainel.Visible = false;
            InsertColabPainel.Visible = false;
            AlterColabPainel.Visible = false;
        }

        private void InsButton_Click(object sender, EventArgs e)
        {
            //DataAccess db = new DataAccess(); //cria o objeto db
            if (InsNomeTextBox.Text.Equals("") && InsCodigoTextBox.Text.Equals("")) //se os campos forem vazios apresenta uma janela de erro
            {
                DialogResult dialogCamposIns = MessageBox.Show("Campos vazios, Preencha todos campos e tente novamente",
               "Erro - Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // se não faz a query a BD
            {
                db.InsertColabBd(InsNomeTextBox.Text, InsCodigoTextBox.Text);

                DialogResult dialogConfirmar = MessageBox.Show("Inserção realizada com sucesso",
               "Inserir - Colaboradores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                InsNomeTextBox.Text = "";
                InsCodigoTextBox.Text = "";
            }
        }

        private void colaboradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchColabBasicaPainel.Visible = false;
            InsertProjetoPainel.Visible = false;
            InsertColabPainel.Visible = true;
            AlterColabPainel.Visible = false;
        }

        //Método que trata da inserção de um Projeto
        private void InsProjetoButton_Click(object sender, EventArgs e)
        {
            //DataAccess db = new DataAccess(); //cria o objeto db

            if (ProjetoNomeTextBox.Text.Equals("") || DataIniTextBox.Text.Equals("") || DataFimTextBox.Text.Equals(""))
            {
                DialogResult dialogCamposIns = MessageBox.Show("Campos vazios, Preencha todos campos e tente novamente",
               "Erro - Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //converte a Strings das TextBox em DateTime
                DateTime DataInicio = Convert.ToDateTime(DataIniTextBox.Text);
                DateTime DataFim = Convert.ToDateTime(DataFimTextBox.Text);

                if (DataInicio.CompareTo(DataFim) <= 0)
                {
                    db.InsertProjetoBd(ProjetoNomeTextBox.Text, DataInicio, DataFim);

                    DialogResult dialogConfirmar = MessageBox.Show("Inserção realizada com sucesso",
                   "Inserir - Projetos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DataIniTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd"); //coloca na textBox a data de hoje
                    DataFimTextBox.Text = DateTime.Now.AddMonths(3).ToString("yyyy-MM-dd");
                    ProjetoNomeTextBox.Text = "";
                }
                else
                {
                    DialogResult dialogDataVerifica = MessageBox.Show("Data final é inferior á data incial do Projeto",
                   "Erro - Datas erradas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void projetoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchColabBasicaPainel.Visible = false;
            InsertProjetoPainel.Visible = true;
            InsertColabPainel.Visible = false;
            AlterColabPainel.Visible = false;
        }

        private void colaboradorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SearchColabBasicaPainel.Visible = false;
            InsertProjetoPainel.Visible = false;
            InsertColabPainel.Visible = false;
            AlterColabPainel.Visible = true;

            // AlterColabAplicarButton.Enabled = false;// Desabilita o botão
            PesquisarTodosUsers(); // invoca o método que pesquisa por todos os user na BD
        }
        public void PesquisarTodosUsers()
        {
            //DataAccess db = new DataAccess(); //cria o objeto db
            listaAlterColab = db.GetTodosColab();

            AtualizarListBox();


            //AtualizarAlterListBox();

        }

        private void AlterColabAplicarButton_Click(object sender, EventArgs e)
        {
            AlterColabAplicarButton.Enabled = true;// Habilitar o botão


            String DadosUser = AlterColabListBox.Text;
            String[] DadosArray = DadosUser.Split('|');
            

            String IdColab = DadosArray[0];
            String DisponibilidadeColab = DadosArray[2];
           // Console.WriteLine("ID:" + DadosArray[0]+ "Estado:"+DadosArray[2]);
            if (DisponibilidadeColab.Contains("Disponivel"))
            {
                db.AlterColabBd(IdColab,"0");
                DialogResult dialogConfirmar = MessageBox.Show("Alteração realizada com sucesso",
               "Alterar - Colaboradores", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                db.AlterColabBd(IdColab,"1");
                DialogResult dialogConfirmar = MessageBox.Show("Alteração realizada com sucesso",
               "Alterar - Colaboradores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            PesquisarTodosUsers();

        }

        private void AlterColabPainel_Paint(object sender, PaintEventArgs e)
        {

        }
        //Atualiza a listBox com a informação returnada da query a BD
        /*public void AtualizarAlterListBox()
        {
            AlterCheckedListBox.DataSource = listaAlterColab; // Indicação que a fonte de informação é a lista
            AlterCheckedListBox.DisplayMember = "DadosPesquisaBasica"; // Mostrar o conteudo da função Colaborador.DadosPesquisaBasica();
        }*/
    }
}
