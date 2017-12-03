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
        List<Equipa> listaPesquisaEquipaEstado = new List<Equipa>();
        DataAccess db = new DataAccess(); //cria o objeto db

        public MainPainel()
        {
            InitializeComponent();
            //SearchColabBasicaPainel.BackColor = Color.LightGray;
            //menuStrip1.ForeColor = Color.White; //coloca a letra do menu a branco
            AtualizarListBox();

            HomeWebsiteButton.FlatAppearance.BorderSize = 0;
            HomeWebsiteButton.FlatAppearance.BorderColor = Color.White;


            comboBoxBasica.SelectedIndex = 0;
            InsComboBox.SelectedIndex = 0;
            SearchPesquisaEstadoComboBox.SelectedIndex = 0;

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

            SearchEquipaEstadolistBox.DataSource = listaPesquisaEquipaEstado; // Indicação que a fonte de informação é a lista
            SearchEquipaEstadolistBox.DisplayMember = "DadosEquipa"; // Mostrar o conteudo da função Colaborador.DadosPesquisaBasica();

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
            HomePainel.Visible = false;
            SearchEquipaEstadoPanel.Visible = false;
        }

        private void InsButton_Click(object sender, EventArgs e)
        {

            //DataAccess db = new DataAccess(); //cria o objeto db
            if (InsNomeTextBox.Text.Equals("")) //se os campos forem vazios apresenta uma janela de erro
            {
                DialogResult dialogCamposIns = MessageBox.Show("Campos vazios, Preencha todos campos e tente novamente",
               "Erro - Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // se não faz a query a BD
            {
                if (InsComboBox.Text.Equals("Disponivel"))
                {
                    db.InsertColabBd(InsNomeTextBox.Text, "1");
                }
                else
                {
                    db.InsertColabBd(InsNomeTextBox.Text, "0");
                }
                DialogResult dialogConfirmar = MessageBox.Show("Inserção realizada com sucesso",
               "Inserir - Colaboradores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InsNomeTextBox.Text = "";
            }
        }

        private void colaboradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchColabBasicaPainel.Visible = false;
            InsertProjetoPainel.Visible = false;
            InsertColabPainel.Visible = true;
            AlterColabPainel.Visible = false;
            HomePainel.Visible = false;
            SearchEquipaEstadoPanel.Visible = false;
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
            HomePainel.Visible = false;
            SearchEquipaEstadoPanel.Visible = false;
        }

        private void colaboradorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SearchColabBasicaPainel.Visible = false;
            InsertProjetoPainel.Visible = false;
            InsertColabPainel.Visible = false;
            AlterColabPainel.Visible = true;
            HomePainel.Visible = false;
            SearchEquipaEstadoPanel.Visible = false;

            // AlterColabAplicarButton.Enabled = false;// Desabilita o botão
            PesquisarTodosUsers(); // invoca o método que pesquisa por todos os user na BD
        }
        public void PesquisarTodosUsers()
        {
            //DataAccess db = new DataAccess(); //cria o objeto db
            listaAlterColab = db.GetTodosColab();

            AtualizarListBox();
        }

        private void AlterColabAplicarButton_Click(object sender, EventArgs e)
        {
            AlterColabAplicarButton.Enabled = true;// Habilitar o botão


            String DadosUser = AlterColabListBox.Text;
            String[] DadosArray = DadosUser.Split('|');


            String IdColab = DadosArray[0].Replace(" ", "").Replace("\t\t", "");
            String DisponibilidadeColab = DadosArray[2];
            //DisponibilidadeColab.Replace(" ", "");
            // Console.WriteLine("ID:" + DadosArray[0]+ "Estado:"+DadosArray[2]);
            if (DisponibilidadeColab.Contains("Disponivel"))
            {
                db.AlterColabBd(IdColab, "0");
                DialogResult dialogConfirmar = MessageBox.Show("Alteração realizada com sucesso",
               "Alterar - Colaboradores", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                db.AlterColabBd(IdColab, "1");
                DialogResult dialogConfirmar = MessageBox.Show("Alteração realizada com sucesso",
               "Alterar - Colaboradores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            PesquisarTodosUsers();

        }

        private void AlterColabPainel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HomeWebsiteButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://softbusiness.mypressonline.com/");
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchColabBasicaPainel.Visible = false;
            InsertProjetoPainel.Visible = false;
            InsertColabPainel.Visible = false;
            AlterColabPainel.Visible = false;
            HomePainel.Visible = true;
            SearchEquipaEstadoPanel.Visible = false;
        }

        private void porEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchColabBasicaPainel.Visible = false;
            InsertProjetoPainel.Visible = false;
            InsertColabPainel.Visible = false;
            AlterColabPainel.Visible = false;
            HomePainel.Visible = false;
            SearchEquipaEstadoPanel.Visible = true;
        }

        private void SearchEquipaButton_Click(object sender, EventArgs e)
        {
            if (SearchPesquisaEstadoComboBox.Text.Equals("Disponivel"))
            {
                listaPesquisaEquipaEstado = db.SearchEquipaBd(0); //Equipas disponivel
            }
            else
            {
                listaPesquisaEquipaEstado = db.SearchEquipaBd(1); //Equipas com projetos atribuidos (indisponivel)
            }
            AtualizarListBox(); // Atualizar a comboBox com a informação
        }

        //Atualiza a listBox com a informação returnada da query a BD
        /*public void AtualizarAlterListBox()
        {
            AlterCheckedListBox.DataSource = listaAlterColab; // Indicação que a fonte de informação é a lista
            AlterCheckedListBox.DisplayMember = "DadosPesquisaBasica"; // Mostrar o conteudo da função Colaborador.DadosPesquisaBasica();
        }*/
    }
}
