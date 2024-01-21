using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace AgenciaViagens
{
     // Substitua 'NamespaceDoInfoType' pelo namespace onde InfoType está definido
    public partial class Form2 : Form
    {
        private bool info;

        public Form2(bool info)
        {
            InitializeComponent();
            this.info = info;
        }

        public static class InformacaoCompartilhada
        {
            public static bool info { get; set; }
            public static string EmailDoUsuario { get; set; }
            public static string SenhaDoUsuario { get; set; }
        }
        public Form2()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 cadastro = new Form3();
            cadastro.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string data_source = "server=localhost;database=cadastro; user id='root';password=''"; // String de conexão
            string usuario = txtEmail.Text; // Obtem o valor da TextBox do usuário
            string senha = txtSenha.Text; // Obtem o valor da TextBox da senha

            try
            {
                using (MySqlConnection connection = new MySqlConnection(data_source)) // Adapta connection para variável de conexão que recebe a conexão do data_source (BD)
                {
                    connection.Open();// Conexão aberta

                    string consultaSQL = "SELECT * FROM cadastrar WHERE Email = @Email AND Senha = @Senha"; // Puxa os dados do BD de email e senha

                    using (MySqlCommand command = new MySqlCommand(consultaSQL, connection)) // Cria uma variável de comando que recebe a consulta dos valores com a conxão do BD
                    {
                        command.Parameters.AddWithValue("@Email", usuario); // Verifica os valores do email no BD com o que foi inserido na text box
                        command.Parameters.AddWithValue("@Senha", senha); // Verifica os valores da senha no BD com o que foi inserido na text box

                        using (MySqlDataReader reader = command.ExecuteReader()) // Lê tudo do SQL e executa
                        {
                            if (reader.Read())
                            {
                                InformacaoCompartilhada.info = true;
                                string emailDoUsuario = reader["Email"].ToString();
                                string senhaDoUsuario = reader["Senha"].ToString();
                                // Usuário e senha correspondem aos registros no BD
                                MessageBox.Show("Login bem-sucedido!");

                                InformacaoCompartilhada.EmailDoUsuario = emailDoUsuario;
                                InformacaoCompartilhada.SenhaDoUsuario = senhaDoUsuario;

                                Form1 form1 = Application.OpenForms["Form1"] as Form1;
                                if (form1 != null)
                                {
                                    form1.AlterarVisibilidadeBotao3(false); // Define a visibilidade do botão 3 como falso
                                }

                                connection.Close();

                                this.Close(); // Fecha o Form2
                            }
                            else
                            {
                                // Não há correspondência no BD
                                MessageBox.Show("Usuário ou senha incorretos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtSenha.Text = "";
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro", ex.Message);
            }

        }
    }
}


