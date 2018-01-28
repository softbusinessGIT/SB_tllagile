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
        List<Equipa> listaEquipa = new List<Equipa>();
        DataAccess db = new DataAccess(); //cria o objeto db

        public MainPainel()
        {
            InitializeComponent();
            //SearchColabBasicaPainel.BackColor = Color.LightGray;
            //menuStrip1.ForeColor = Color.White; //coloca a letra do menu a branco

            HomeWebsiteButton.FlatAppearance.BorderSize = 0;
            HomeWebsiteButton.FlatAppearance.BorderColor = Color.White;

            //Elemento pre-definido da combobox
            comboBoxBasica.SelectedIndex = 0;
            InsComboBox.SelectedIndex = 0;
            SearchPesquisaEstadoComboBox.SelectedIndex = 0;

        }

        //Métodos 

        //-----------------------------Pesquisar Colaborador por estado (Pesquisa Basica)-------------------------------

        //Atualiza a listBox com a informação returnada da query a BD
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
            //Limpar a listView
            listViewSearchColab.Items.Clear();

            //Popular a listView com o conteudo da lista
            foreach (Colaborador colab in listaPesquisaBasicaColab)
            {
                ListViewItem item1 = new ListViewItem(colab.id_colab);
                item1.SubItems.Add(colab.nome);
                item1.SubItems.Add(colab.estado);
                item1.SubItems.Add(colab.email);

                listViewSearchColab.Items.Add(item1);
            }
        }

        private void básicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchColabBasicaPainel.Visible = true;
            InsertProjetoPainel.Visible = false;
            InsertColabPainel.Visible = false;
            AlterColabPainel.Visible = false;
            HomePainel.Visible = false;
            SearchEquipaEstadoPanel.Visible = false;
            AlterDispColabPainel.Visible = false;
            SearchColabPerfilPainel.Visible = false;
        }

        //--------------------------------------------------------------------------------------------------------------

        // -------------------------------------------Criar colaborador-------------------------------------------------
        private void InsButton_Click(object sender, EventArgs e)
        {
            //Data de nascimento do colaborador
            //String dataNascimento = InsDataNascPicker.Value.ToString("yyyy-MM-dd");

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
                    db.insertColabBd(InsNomeTextBox.Text, "1", DateTime.Now, InsDataNascPicker.Value, InsEmailTextBox.Text);
                }
                else
                {
                    db.insertColabBd(InsNomeTextBox.Text, "0", DateTime.Now, InsDataNascPicker.Value, InsEmailTextBox.Text);
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
            AlterDispColabPainel.Visible = false;
            SearchColabPerfilPainel.Visible = false;
        }
        //-----------------------------------------------------------------------------------------------------------

        //-------------------------------------------Criar Projeto---------------------------------------------------

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
            AlterDispColabPainel.Visible = false;
            SearchColabPerfilPainel.Visible = false;
        }
        //------------------------------------------------------------------------------------------------------------
        private void colaboradorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        //----------------------------------Alterar estado do colaborador-----------------------------
        private void estadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchColabBasicaPainel.Visible = false;
            InsertProjetoPainel.Visible = false;
            InsertColabPainel.Visible = false;
            AlterColabPainel.Visible = true;
            HomePainel.Visible = false;
            SearchEquipaEstadoPanel.Visible = false;
            AlterDispColabPainel.Visible = false;
            SearchColabPerfilPainel.Visible = false;

            pesquisarTodosUsers(); // invoca o método que pesquisa por todos os user na BD
        }
        public void pesquisarTodosUsers()
        {
            listaAlterColab = db.getTodosColab();

            //Limpar listView
            listViewAlterColab.Items.Clear();

            //Popular a listView com o conteudo da lista
            foreach (Colaborador colab in listaAlterColab)
            {
                ListViewItem item1 = new ListViewItem(colab.id_colab);
                item1.SubItems.Add(colab.nome);
                //Converter o valor True para Ativo ou Inativo
                if (colab.estado.Equals("True"))
                {
                    item1.SubItems.Add("Ativo");
                }
                else
                {
                    item1.SubItems.Add("Inativo");
                }

                listViewAlterColab.Items.Add(item1);
            }
        }

        private void AlterColabAplicarButton_Click(object sender, EventArgs e)
        {
            AlterColabAplicarButton.Enabled = true;// Habilitar o botão

            try
            {
                //Valores dos subitems da lista
                String id = listViewAlterColab.SelectedItems[0].SubItems[0].Text;
                String DisponibilidadeColab = listViewAlterColab.SelectedItems[0].SubItems[2].Text;

                if (DisponibilidadeColab.Contains("Ativo"))
                {
                    db.alterColabBd(id, "0");
                    DialogResult dialogConfirmar = MessageBox.Show("Alteração realizada com sucesso",
                   "Alterar - Colaboradores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    db.alterColabBd(id, "1");
                    DialogResult dialogConfirmar = MessageBox.Show("Alteração realizada com sucesso",
                   "Alterar - Colaboradores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                pesquisarTodosUsers();

            }
            catch (Exception)
            {

                DialogResult dialogCamposIns = MessageBox.Show("Colaborador não selecionado, faça uma seleção e tente novamente!",
                   "Erro - seleção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void AlterColabPainel_Paint(object sender, PaintEventArgs e)
        {

        }
        //------------------------------------------------------------------------------------------


        //-------------------------------------Homepage---------------------------------------------
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
            AlterDispColabPainel.Visible = false;
            SearchColabPerfilPainel.Visible = false;
        }
        //---------------------------------------------------------------------------------------

        // ----------------------------Visualizar equipa por estado------------------------------
        private void porEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchColabBasicaPainel.Visible = false;
            InsertProjetoPainel.Visible = false;
            InsertColabPainel.Visible = false;
            AlterColabPainel.Visible = false;
            HomePainel.Visible = false;
            SearchEquipaEstadoPanel.Visible = true;
            AlterDispColabPainel.Visible = false;
            SearchColabPerfilPainel.Visible = false;
        }

        private void SearchEquipaButton_Click(object sender, EventArgs e)
        {
            if (SearchPesquisaEstadoComboBox.Text.Equals("Disponivel"))
            {
                listaEquipa = db.searchEquipaBd(0); //Equipas disponiveis
            }
            else
            {
                listaEquipa = db.searchEquipaBd(1); //Equipas com projetos atribuidos (indisponivel)
            }

            //Limpar listView
            listViewSearchEquipaEstado.Items.Clear();

            //Popular a listView com o conteudo da lista
            foreach (Equipa equipa in listaEquipa)
            {
                //Dar valores aos subItems
                ListViewItem item1 = new ListViewItem(equipa.nome);
                item1.SubItems.Add(equipa.nomeProj);

                //Carregar os valores na listView
                listViewSearchEquipaEstado.Items.Add(item1);
            }
        }
        //--------------------------------------------------------------------------------------


        // -----------------------------------Alterar Disponibilidade---------------------------------------
        private void disponibilidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchColabBasicaPainel.Visible = false;
            InsertProjetoPainel.Visible = false;
            InsertColabPainel.Visible = false;
            AlterColabPainel.Visible = false;
            HomePainel.Visible = false;
            SearchEquipaEstadoPanel.Visible = false;
            AlterDispColabPainel.Visible = true;
            SearchColabPerfilPainel.Visible = false;

            //lista que vai conter todos os utilizadores
            listaAlterColab = db.getPessoa(1);

            //Limpar listView
            AlterDispColabListView.Items.Clear();

            //Popular a listView com o conteudo da lista
            foreach (Colaborador colab in listaAlterColab)
            {
                ListViewItem item1 = new ListViewItem(colab.id_colab);     
                item1.SubItems.Add(colab.nome);
                item1.SubItems.Add(colab.email);

                AlterDispColabListView.Items.Add(item1);
            }
            
        }

        private void AlterDispColabButton_Click(object sender, EventArgs e)
        {
            try
            {
                String id = AlterDispColabListView.SelectedItems[0].SubItems[0].Text;
                if (AlterDispColabMotivoTextBox.Text.Equals(""))
                {
                    DialogResult dialogCamposIns = MessageBox.Show("Campos vazios, Preencha todos campos e tente novamente",
                   "Erro - Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (AlterColabIniDateTimePicker.Value.CompareTo(AlterColabFimDateTimePicker.Value) <= 0)
                    {
                        db.insertIndispColabBd(id, AlterColabIniDateTimePicker.Value, AlterColabFimDateTimePicker.Value, AlterDispColabMotivoTextBox.Text);
                        DialogResult dialogConfirmar = MessageBox.Show("Indisponibilidade registada com sucesso!",
                       "Inserir - Indisponibilidade", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Coloca o campo vazio para nova inserção
                        AlterDispColabMotivoTextBox.Text = "";
                    }
                    else
                    {
                        DialogResult dialogDataVerifica = MessageBox.Show("Data final é inferior á data incial da indisponibilidade",
                       "Erro - Datas erradas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                DialogResult dialogCamposIns = MessageBox.Show("Colaborador não selecionado, faça uma seleção e tente novamente!",
                   "Erro - seleção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AlterDispColabPainel_Paint(object sender, PaintEventArgs e)
        {

        }

        //-------------------------------------Visualizar Perfil do colaborador----------------------------------
        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchColabBasicaPainel.Visible = false;
            InsertProjetoPainel.Visible = false;
            InsertColabPainel.Visible = false;
            AlterColabPainel.Visible = false;
            HomePainel.Visible = false;
            SearchEquipaEstadoPanel.Visible = false;
            AlterDispColabPainel.Visible = false;
            SearchColabPerfilPainel.Visible = true;

            //lista que vai conter todos os utilizadores
            listaPesquisaBasicaColab = db.getPessoa(1);

            //Limpar listView
            listViewPerfilColab.Items.Clear();

            //Popular a listView com o conteudo da lista
            foreach (Colaborador colab in listaPesquisaBasicaColab)
            {
                ListViewItem item1 = new ListViewItem(colab.id_colab);
                item1.SubItems.Add(colab.nome);
                item1.SubItems.Add(colab.email);

                listViewPerfilColab.Items.Add(item1);
            }
        }

        private void VisualizarPerfilButton_Click(object sender, EventArgs e)
        {
            try
            {
                //A variavel id vai ter o valor do subitem[0] da row selecionada
                String id = listViewPerfilColab.SelectedItems[0].SubItems[0].Text;

                //Instanciar e Atribuir o objeto PerfilColaborador
                PerfilColaborador janela = new PerfilColaborador(id);
                janela.Show();
            }
            catch (Exception)
            {
                DialogResult dialogCamposIns = MessageBox.Show("Colaborador não selecionado, faça uma seleção e tente novamente!",
                   "Erro - seleção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //----------------------------------------------Criar Equipa-----------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {

            st.Visible = false;
            sm.Visible = false;
            po.Visible = true;

            dataGridViewPo.Rows.Add("Communication Skill",1);
            dataGridViewPo.Rows.Add("Knowledge of business models", 0, 1);
            dataGridViewPo.Rows.Add("Knowledge of industry field",0,0,1);
            dataGridViewPo.Rows.Add("Entrepeneur ability",0,0,0,1);
            dataGridViewPo.Rows.Add("Financial knowledge", 0, 0, 0,0, 1);

            foreach (DataGridViewColumn column in dataGridViewPo.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            

            //DataGridViewRow row = (DataGridViewRow)dataGridViewPo.Rows[0].Clone();
            //row.Cells[0].Value = "Communication Skill";
            //row.Cells[1].Value = 50.2;
            //dataGridViewPo.Rows.Add(row);

            //DataGridViewRow row2 = (DataGridViewRow)dataGridViewPo.Rows[1];
            //row.Cells[0].Value = "Knowledge of business models";
            //dataGridViewPo.Rows.Add(row2);

            //DataGridViewRow row3 = (DataGridViewRow)dataGridViewPo.Rows[2].Clone();
            //row.Cells[0].Value = "Knowledge of industry field";
            //dataGridViewPo.Rows.Add(row3);

            //DataGridViewRow row4 = (DataGridViewRow)dataGridViewPo.Rows[3].Clone();
            //row.Cells[0].Value = "Entrepeneur ability";
            //dataGridViewPo.Rows.Add(row4);

            //DataGridViewRow row5 = (DataGridViewRow)dataGridViewPo.Rows[4].Clone();
            //row.Cells[0].Value = "Financial knowledge";
            //dataGridViewPo.Rows.Add(row5);
        }

        //Método que converte frações de string para double ex: string "1/2" returns 0,5
        double fractionToDouble(string fraction)
        {
            double result;

            if (double.TryParse(fraction, out result))
            {
                return result;
            }

            string[] split = fraction.Split(new char[] { ' ', '/' });

            if (split.Length == 2 || split.Length == 3)
            {
                int a, b;

                if (int.TryParse(split[0], out a) && int.TryParse(split[1], out b))
                {
                    if (b != 0)
                    { 
                        if (split.Length == 2)
                        {
                            return (double)a / b;
                        }

                        int c;

                        if (int.TryParse(split[2], out c))
                        {
                            return a + (double)b / c;
                        }
                    }
                    
                }
            }
            return 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            //for (int row = 0; row<=3; row++)
            //{
            //    for (int cell=2; cell<=5; cell++)
            //    {
            //        fractionToDouble(dataGridViewPo.Rows[row].Cells[cell].Value.ToString());
            //    }
            //}


            //Communication skill compares to others
            var kbnCm = fractionToDouble(dataGridViewPo.Rows[0].Cells[2].Value.ToString());
            var kifCm = fractionToDouble(dataGridViewPo.Rows[0].Cells[3].Value.ToString());
            var eaCm = fractionToDouble(dataGridViewPo.Rows[0].Cells[4].Value.ToString());
            var fkCm = fractionToDouble(dataGridViewPo.Rows[0].Cells[5].Value.ToString());

            //Knowledge of business models compares to others
            var kifKbm = fractionToDouble(dataGridViewPo.Rows[1].Cells[3].Value.ToString());
            var eaKbm = fractionToDouble(dataGridViewPo.Rows[1].Cells[4].Value.ToString());
            var fkKbm = fractionToDouble(dataGridViewPo.Rows[1].Cells[5].Value.ToString());

            //Knowledge of industry field
            var eaKif = fractionToDouble(dataGridViewPo.Rows[2].Cells[4].Value.ToString());
            var fkKif = fractionToDouble(dataGridViewPo.Rows[2].Cells[5].Value.ToString());

            //Entrepeneur ability compares to others
            var fkea = fractionToDouble(dataGridViewPo.Rows[3].Cells[5].Value.ToString());


            //var teste = double.Parse(myvalue);
            DialogResult dialogCamposIns = MessageBox.Show(kbnCm.ToString(),
                  "Erro - seleção", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            st.Visible = false;
            sm.Visible = true;
            po.Visible = false;

            dataGridViewSm.Rows.Add("Communication Skill", 1);
            dataGridViewSm.Rows.Add("Project Managment tools", 0, 1);
            dataGridViewSm.Rows.Add("Continuos integration tools", 0, 0, 1);
            dataGridViewSm.Rows.Add("Development enviroment setup", 0, 0, 0, 1);
            dataGridViewSm.Rows.Add("Motivation ability", 0, 0, 0, 0, 1);
            dataGridViewSm.Rows.Add("Coordenation skill", 0, 0, 0, 0, 0, 1);

            foreach (DataGridViewColumn column in dataGridViewSm.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Communication skill compares to others
            var pmtCs = fractionToDouble(dataGridViewSm.Rows[0].Cells[2].Value.ToString());
            var citCs = fractionToDouble(dataGridViewSm.Rows[0].Cells[3].Value.ToString());
            var desCs = fractionToDouble(dataGridViewSm.Rows[0].Cells[4].Value.ToString());
            var maCs = fractionToDouble(dataGridViewSm.Rows[0].Cells[5].Value.ToString());
            var csCs = fractionToDouble(dataGridViewSm.Rows[0].Cells[6].Value.ToString());


            //Project Managment tools
            var citPmt = fractionToDouble(dataGridViewSm.Rows[1].Cells[3].Value.ToString());
            var desPmt = fractionToDouble(dataGridViewSm.Rows[1].Cells[4].Value.ToString());
            var maPmt = fractionToDouble(dataGridViewSm.Rows[1].Cells[5].Value.ToString());
            var csPmt = fractionToDouble(dataGridViewSm.Rows[1].Cells[6].Value.ToString());

            //Continuos integration tools
            var desCit = fractionToDouble(dataGridViewSm.Rows[2].Cells[4].Value.ToString());
            var maCit = fractionToDouble(dataGridViewSm.Rows[2].Cells[5].Value.ToString());
            var csCit = fractionToDouble(dataGridViewSm.Rows[2].Cells[6].Value.ToString());

            //Development enviroment setup
            var maDes = fractionToDouble(dataGridViewSm.Rows[3].Cells[5].Value.ToString());
            var csDes = fractionToDouble(dataGridViewSm.Rows[3].Cells[6].Value.ToString());

            //Motivation ability
            var csMa = fractionToDouble(dataGridViewSm.Rows[4].Cells[6].Value.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            st.Visible = true;
            sm.Visible = false;
            po.Visible = false;

            dataGridViewSt.Rows.Add("Programming language skills", 1);
            dataGridViewSt.Rows.Add("Problem solving abilities", 0, 1);
            dataGridViewSt.Rows.Add("Testing skillls", 0, 0, 1);
            dataGridViewSt.Rows.Add("Continuos integration tools", 0, 0, 0, 1);
            dataGridViewSt.Rows.Add("Refactoring concepts", 0, 0, 0, 0, 1);
            dataGridViewSt.Rows.Add("Database knowledge", 0, 0, 0, 0, 0, 1);
            dataGridViewSt.Rows.Add("Big data knowledge", 0, 0, 0, 0, 0, 0, 1);

            foreach (DataGridViewColumn column in dataGridViewSt.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Programming language skills 
            var psaPls = fractionToDouble(dataGridViewSt.Rows[0].Cells[2].Value.ToString());
            var tsPls = fractionToDouble(dataGridViewSt.Rows[0].Cells[3].Value.ToString());
            var citPls = fractionToDouble(dataGridViewSt.Rows[0].Cells[4].Value.ToString());
            var rcPls = fractionToDouble(dataGridViewSt.Rows[0].Cells[5].Value.ToString());
            var dkPls = fractionToDouble(dataGridViewSt.Rows[0].Cells[6].Value.ToString());
            var bdkPls = fractionToDouble(dataGridViewSt.Rows[0].Cells[7].Value.ToString());

            //Problem solving abilities
            var tsPsa = fractionToDouble(dataGridViewSt.Rows[1].Cells[3].Value.ToString());
            var citPsa = fractionToDouble(dataGridViewSt.Rows[1].Cells[4].Value.ToString());
            var rcPsa = fractionToDouble(dataGridViewSt.Rows[1].Cells[5].Value.ToString());
            var dkPsa = fractionToDouble(dataGridViewSt.Rows[1].Cells[6].Value.ToString());
            var bdkPsa = fractionToDouble(dataGridViewSt.Rows[1].Cells[7].Value.ToString());

            //Testing skillls
            var citTs = fractionToDouble(dataGridViewSt.Rows[2].Cells[4].Value.ToString());
            var rcTs = fractionToDouble(dataGridViewSt.Rows[2].Cells[5].Value.ToString());
            var dkTs = fractionToDouble(dataGridViewSt.Rows[2].Cells[6].Value.ToString());
            var bdkTs = fractionToDouble(dataGridViewSt.Rows[2].Cells[7].Value.ToString());

            //Continuos integration tools
            var rcCit = fractionToDouble(dataGridViewSt.Rows[3].Cells[5].Value.ToString());
            var dkCit = fractionToDouble(dataGridViewSt.Rows[3].Cells[6].Value.ToString());
            var bdkCit = fractionToDouble(dataGridViewSt.Rows[3].Cells[7].Value.ToString());

            //Refactoring concepts
            var dkRc = fractionToDouble(dataGridViewSt.Rows[4].Cells[6].Value.ToString());
            var bdkRc = fractionToDouble(dataGridViewSt.Rows[4].Cells[7].Value.ToString());

            //data knowledge
            var bdkDk = fractionToDouble(dataGridViewSt.Rows[5].Cells[7].Value.ToString());
        }
    }
}
