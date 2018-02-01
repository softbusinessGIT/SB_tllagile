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
    public partial class EquipaDeProjeto : Form
    {
        DataAccess db = new DataAccess(); //cria o objeto db
        List<Equipa> listaPesquisaColabHistorico = new List<Equipa>();
        public String publicId;

        public EquipaDeProjeto()
        {
            InitializeComponent();
        }
        public EquipaDeProjeto(String id)
        {
            InitializeComponent();
            publicId = id;

            carregarListViewEquipa();


        }
        //Método para carregar info na listview
        public void carregarListViewEquipa()
        {
            listaPesquisaColabHistorico = db.searchEquipaProjetoInfoBd(publicId);//Carregar a lista com o retorno da BD
            labelPerfilProjeto.Text = "Equipa do projeto: " + listaPesquisaColabHistorico[0].nomeProj;
            //Limpar a listView
            listViewEquipa.Items.Clear();

            //Popular a listView com o conteudo da lista
            foreach (Equipa colabProjeto in listaPesquisaColabHistorico)
            {

                //Converter para string as datas em DateTime
                //String dataIni = colabProjeto.data_ini.ToString("yyyy-MM-dd");
                //String dataFim = colabProjeto.data_fim.ToString("yyyy-MM-dd");

                //Indicar os subitems
                ListViewItem item1 = new ListViewItem(colabProjeto.id_colab);
                item1.SubItems.Add(colabProjeto.nomeColab);
                item1.SubItems.Add(colabProjeto.email);
                if (colabProjeto.id_funcao.Equals("1"))
                {
                    item1.SubItems.Add("Product Owner");
                }
                else if (colabProjeto.id_funcao.Equals("2"))
                {
                    item1.SubItems.Add("Scrum Master");
                }
                else
                {
                    item1.SubItems.Add("Scrum Team");
                }

                //Carregar valores na listView
                listViewEquipa.Items.Add(item1);

            }
        }
    }
}
