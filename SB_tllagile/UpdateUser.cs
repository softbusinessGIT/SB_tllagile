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
    public partial class UpdateUser : Form
    {
        //Variaveis 
        List<Colaborador> listaPesquisaColab = new List<Colaborador>();
        List<Indisponibilidade> listaPesquisaColabIndisp = new List<Indisponibilidade>();
        DataAccess db = new DataAccess(); //cria o objeto db
        public String publicId;

        public UpdateUser()
        {
            InitializeComponent();
        }
        public UpdateUser(string id)
        {
            InitializeComponent();
            publicId = id;//id do colaborador
            updateComboBox.SelectedIndex = 0;
            autoFill();
        }
        //Método que carrega as informações atuais do colaborador
        public void autoFill()
        {
            listaPesquisaColab = db.getColaborador(publicId);//Carregar a lista com o retorno da BD

            //carregar dados
            updateNomeTextBox.Text = listaPesquisaColab[0].nome;
            updateEmailTextBox.Text = listaPesquisaColab[0].email;
            updateDataNascPicker.Value = listaPesquisaColab[0].data_nascimento;


        }

        private void InsButton_Click(object sender, EventArgs e)
        {
            if (updateNomeTextBox.Text.Equals("") || updateEmailTextBox.Equals(""))  //se os campos forem vazios apresenta uma janela de erro
            {
                DialogResult dialogCamposIns = MessageBox.Show("Campos vazios, Preencha todos campos e tente novamente",
               "Erro - Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // se não, faz a query a BD
            {
                if (updateComboBox.Text.Equals("Ativo"))
                {
                    db.alterInfoColabBd(publicId, updateEmailTextBox.Text, updateNomeTextBox.Text, "1", updateDataNascPicker.Value );
                }
                else
                {
                    db.alterInfoColabBd(publicId, updateEmailTextBox.Text, updateNomeTextBox.Text, "0", updateDataNascPicker.Value);
                }
                DialogResult dialogConfirmar = MessageBox.Show("Inserção realizada com sucesso",
               "Inserir - Colaboradores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
