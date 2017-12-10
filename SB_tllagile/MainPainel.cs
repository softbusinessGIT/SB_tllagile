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

            atualizarListBox();

            HomeWebsiteButton.FlatAppearance.BorderSize = 0;
            HomeWebsiteButton.FlatAppearance.BorderColor = Color.White;

            //Elemento pre-definido da combobox
            comboBoxBasica.SelectedIndex = 0;
            InsComboBox.SelectedIndex = 0;
            SearchPesquisaEstadoComboBox.SelectedIndex = 0;

        }
        //Métodos 

        //Atualiza a listBox com a informação returnada da query a BD
        public void atualizarListBox()
        {
            AlterColabListBox.DataSource = listaAlterColab; // Indicação que a fonte de informação é a lista
            AlterColabListBox.DisplayMember = "dadosPesquisaBasica"; // Mostrar o conteudo da função Colaborador.dadosPesquisaBasica();

            listBoxColab.DataSource = listaPesquisaBasicaColab; // Indicação que a fonte de informação é a lista
            listBoxColab.DisplayMember = "dadosPesquisaBasica"; // Mostrar o conteudo da função Colaborador.dadosPesquisaBasica();

            SearchEquipaEstadolistBox.DataSource = listaPesquisaEquipaEstado; // Indicação que a fonte de informação é a lista
            SearchEquipaEstadolistBox.DisplayMember = "dadosEquipa"; // Mostrar o conteudo da função Colaborador.dadosPesquisaBasica();

        }
        private void PesquisarBasicaButton_Click(object sender, EventArgs e)
        {
            //DataAccess db = new DataAccess();
            if ((comboBoxBasica.Text).Equals("Indisponivel"))
            {
                // A lista "listaPesquisaBasicaColab" vai conter o retorno da pesquisa á BD
                listaPesquisaBasicaColab = db.getPessoa(0);

            }
            else
            {
                listaPesquisaBasicaColab = db.getPessoa(1);

            }
            atualizarListBox();
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
            //Data de nascimento do colaborador
            String dataNascimento = InsDataNascPicker.Value.ToString("yyyy-MM-dd");

            //DataAccess db = new DataAccess(); //cria o objeto db
            if (InsNomeTextBox.Text.Equals("") || InsEmailTextBox.Equals(""))  //se os campos forem vazios apresenta uma janela de erro
            {
                DialogResult dialogCamposIns = MessageBox.Show("Campos vazios, Preencha todos campos e tente novamente",
               "Erro - Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // se não, faz a query a BD
            {
                if (InsComboBox.Text.Equals("Disponivel"))
                {
                    db.insertColabBd(InsNomeTextBox.Text, "1", DateTime.Now.ToString("yyyy-MM-dd"), dataNascimento, InsEmailTextBox.Text);
                }
                else
                {
                    db.insertColabBd(InsNomeTextBox.Text, "0", DateTime.Now.ToString("yyyy-MM-dd"), dataNascimento, InsEmailTextBox.Text);
                }
                DialogResult dialogConfirmar = MessageBox.Show("Inserção realizada com sucesso",
               "Inserir - Colaboradores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Coloca os campos vazios para uma possivel nova inserção
                InsNomeTextBox.Text = "";
                InsEmailTextBox.Text = "";
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

            if (ProjetoNomeTextBox.Text.Equals(""))
            {
                DialogResult dialogCamposIns = MessageBox.Show("Campos vazios, Preencha todos campos e tente novamente",
               "Erro - Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {     

                //String dataIniProj = InsProjDataIniPicker.Value.ToString("yyyy-MM-dd");
                //String dataFimProj = InsProjDataFimPicker.Value.ToString("yyyy-MM-dd");


                if (InsProjDataIniPicker.Value.CompareTo(InsProjDataFimPicker.Value) <= 0)
                {
                    db.InsertProjetoBd(ProjetoNomeTextBox.Text, InsProjDataIniPicker.Value, InsProjDataFimPicker.Value);

                    DialogResult dialogConfirmar = MessageBox.Show("Inserção realizada com sucesso",
                   "Inserir - Projetos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Coloca o campo vazio para uma possivel nova inserção
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
            pesquisarTodosUsers(); // invoca o método que pesquisa por todos os user na BD
        }
        public void pesquisarTodosUsers()
        {
            //DataAccess db = new DataAccess(); //cria o objeto db
            listaAlterColab = db.getTodosColab();

            atualizarListBox();
        }

        private void AlterColabAplicarButton_Click(object sender, EventArgs e)
        {
            AlterColabAplicarButton.Enabled = true;// Habilitar o botão


            String dadosUser = AlterColabListBox.Text;
            String[] dadosArray = dadosUser.Split('|');


            String idColab = dadosArray[0].Replace(" ", "").Replace("\t\t", "");
            String DisponibilidadeColab = dadosArray[2];
            //DisponibilidadeColab.Replace(" ", "");
            // Console.WriteLine("ID:" + dadosArray[0]+ "Estado:"+dadosArray[2]);
            if (DisponibilidadeColab.Contains("Disponivel"))
            {
                db.alterColabBd(idColab, "0");
                DialogResult dialogConfirmar = MessageBox.Show("Alteração realizada com sucesso",
               "Alterar - Colaboradores", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                db.alterColabBd(idColab, "1");
                DialogResult dialogConfirmar = MessageBox.Show("Alteração realizada com sucesso",
               "Alterar - Colaboradores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            pesquisarTodosUsers();

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
                listaPesquisaEquipaEstado = db.searchEquipaBd(0); //Equipas disponivel
            }
            else
            {
                listaPesquisaEquipaEstado = db.searchEquipaBd(1); //Equipas com projetos atribuidos (indisponivel)
            }
            atualizarListBox(); // Atualizar a comboBox com a informação
        }

        //Atualiza a listBox com a informação returnada da query a BD
        /*public void AtualizarAlterListBox()
        {
            AlterCheckedListBox.DataSource = listaAlterColab; // Indicação que a fonte de informação é a lista
            AlterCheckedListBox.DisplayMember = "dadosPesquisaBasica"; // Mostrar o conteudo da função Colaborador.dadosPesquisaBasica();
        }*/
    }
}
