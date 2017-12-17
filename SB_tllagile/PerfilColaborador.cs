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
    public partial class PerfilColaborador : Form
    {
        //Variaveis 
        List<Colaborador> listaPesquisaColab = new List<Colaborador>();
        List<Indisponibilidade> listaPesquisaColabIndisp = new List<Indisponibilidade>();
        DataAccess db = new DataAccess(); //cria o objeto db
        public String publicId;

        public PerfilColaborador()
        {
            InitializeComponent();
        }
        public PerfilColaborador(String id)
        {
            InitializeComponent();
            publicId = id;

            carregarListViewInfo();
            carregarListViewIndisp();

        }
        //Método para popular a listView
        public void carregarListViewInfo()
        {
            listaPesquisaColab = db.getColaborador(publicId);//Carregar a lista com o retorno da BD

            //Limpar a listView
            listViewInfo.Items.Clear();

            //Popular a listView com o conteudo da lista
            foreach (Colaborador colab in listaPesquisaColab)
            {
                //Converter para string as datas em DateTime
                String dataNasc = colab.data_nascimento.ToString("yyyy-MM-dd");
                String dataIns = colab.data_inscricao.ToString("yyyy-MM-dd");

                //Indicar os subitems
                ListViewItem item1 = new ListViewItem(colab.id_colab);
                item1.SubItems.Add(colab.nome);
                item1.SubItems.Add(colab.estado);
                item1.SubItems.Add(colab.email);
                item1.SubItems.Add(dataNasc);
                item1.SubItems.Add(dataIns);

                //Carregar valores na listView
                listViewInfo.Items.Add(item1);
            }
        }
        //Método para popular a listView
        public void carregarListViewIndisp()
        {
            listaPesquisaColabIndisp = db.getIndispColaborador(publicId);//Carregar a lista com o retorno da BD

            //Limpar a listView
            listViewIndisp.Items.Clear();

            //Popular a listView com o conteudo da lista
            foreach (Indisponibilidade colab in listaPesquisaColabIndisp)
            {
                //Converter para string as datas em DateTime
                String dataIni = colab.data_ndisp_inicio.ToString("yyyy-MM-dd");
                String dataFim = colab.data_ndisp_fim.ToString("yyyy-MM-dd");
                
                //Indicar os subitems
                ListViewItem item1 = new ListViewItem(dataIni);                
                item1.SubItems.Add(dataFim);
                item1.SubItems.Add(colab.motivo);

                //Carregar valores na listView
                listViewIndisp.Items.Add(item1);
            }
        }

    }
}
