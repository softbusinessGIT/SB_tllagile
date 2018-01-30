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
        DataAccess db = new DataAccess();

        public PainelLogin()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            

            // Encriptação da string digitada pelo utilizador
            SHA384 sha384 = SHA384Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(PasswordText.Text);
            byte[] hash = sha384.ComputeHash(bytes);

            //Pesquisa na Base de dados o utilizador
            ListaUser = db.SearchUserBd(UserText.Text, getStringFromHash(hash)); //GetStringFromHash é o metodo que retorna a string da chave encriptada

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
        private static string getStringFromHash(byte[] hash)
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

        private void label1_Click(object sender, EventArgs e)
        {
            RecupPanel.Visible = true;
            LoginPanel.Visible = false;
        }

        private void UserRecupText_Click(object sender, EventArgs e)
        {
            UserRecupText.Text = "";
        }

        private void PassRecupText_Click(object sender, EventArgs e)
        {
            PassRecupText.Text = "";
            PassRecupText.UseSystemPasswordChar = true;
        }

        private void PassConfRecupText_Click(object sender, EventArgs e)
        {
            PassConfRecupText.Text = "";
            PassConfRecupText.UseSystemPasswordChar = true;
        }

        private void AplicarRecupButton_Click(object sender, EventArgs e)
        {
            if (PassConfRecupText.Text.Equals(PassRecupText.Text))
            {
                ListaUser = db.SearchUser(UserRecupText.Text); //GetStringFromHash é o metodo que retorna a string da chave encriptada

                if ((ListaUser.Count).Equals(1))
                {
                    // Encriptação da string digitada pelo utilizador
                    SHA384 sha384 = SHA384Managed.Create();
                    byte[] bytes = Encoding.UTF8.GetBytes(PassConfRecupText.Text);
                    byte[] hash = sha384.ComputeHash(bytes);

                    //Pesquisa na Base de dados o utilizador
                    db.alterUserPasswordBd(UserRecupText.Text, getStringFromHash(hash)); //GetStringFromHash é o metodo que retorna a string da chave encriptada

                    //Alterar para o painel do login
                    RecupPanel.Visible = false;
                    LoginPanel.Visible = true;

                    DialogResult dialogCredenciais = MessageBox.Show("Credênciais alteradas com sucesso!",
                    "Credênciais Alteradas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PasswordText.Text = "";
                }
                else
                {
                    DialogResult dialogCredenciais = MessageBox.Show("Utilizador inválido, Tente Novamente.",
                "Erro - Credênciais", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                DialogResult dialogCredenciais = MessageBox.Show("Credênciais erradas, Tente Novamente.",
                "Erro - Credênciais", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        private void exitAppButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
