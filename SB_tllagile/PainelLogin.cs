using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security.Policy;
//using System.Security.Cryptography.SHA384;
//using HashLib;

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

            // Encriptação da string digitada pelo utilizador
            SHA384 sha384 = SHA384Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(PasswordText.Text);
            byte[] hash = sha384.ComputeHash(bytes);

            //Pesquisa na Base de dados o utilizador
            ListaUser = db.SearchUserBd(UserText.Text, GetStringFromHash(hash)); //GetStringFromHash é o metodo que retorna a string da chave encriptada

            if ((ListaUser.Count).Equals(1))
            {
                //Invoca uma nova janela
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

        // Metodo que retorna a string encriptada
        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
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
