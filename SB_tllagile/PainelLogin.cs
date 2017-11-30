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
    public partial class PainelLogin : Form
    {
        //static MainPainel janela;
        List<Utilizador> ListaUser = new List<Utilizador>(); //lista de Utilizador (tipo Utilizador)

        public PainelLogin()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            ListaUser = db.SearchUserBd(UserText.Text, PasswordText.Text);
            if((ListaUser.Count).Equals(1))
            {
                this.Hide();
                MainPainel janela = new MainPainel();
                janela.Closed += (s, args) => this.Close();
                janela.Show();
                
            }
            else
            {
                DialogResult dialogCredenciais = MessageBox.Show("Credênciais erradas, Tente Novamente",
                "Erro - Credênciais",MessageBoxButtons.OK,MessageBoxIcon.Error);
                PasswordText.Text = "";
            }

        }

        private void RecupButton_Click(object sender, EventArgs e)
        {
            RecupPanel.Visible = true;
            LoginPanel.Visible = false;
        }

        private void CancelRecupButton_Click(object sender, EventArgs e)
        {
            RecupPanel.Visible = false;
            LoginPanel.Visible = true;
        }
        public void LimparTextBox()
        {
            UserRecupText.Text = "";
            PassRecupText.Text = "";
            PassConfRecupText.Text = "";
        }
    }
}
