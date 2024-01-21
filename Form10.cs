using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AgenciaViagens.Form2;

namespace AgenciaViagens
{
    public partial class Form10 : Form
    {
        string emailDoUsuario = InformacaoCompartilhada.EmailDoUsuario;

        MySqlConnection conexao;

        private List<string> mensagens = new List<string> // Adiciona mensagens para sortear aleatoriamente 
        {
            "AR 198",
            "AV 156",
            "AR 902",
            "AR 008",
            "AV 171",
            "AR 098",
            "AR 144",
            "AV 783",
            "AR 418",
            "AR 890",
            "AV 603",
            "AR 533",
            "AR 338",
            "AV 199",
            "AR 969",
            "AR 118",
            "AV 396",
            "AR 221",
        };

        private List<char> letras = new List<char> { 'P', 'L', 'C', 'F', 'B', 'K', 'R', 'A', 'S', 'M' }; // Adiciona letras para sortear aleatoriamente

        public Form10()
        {
            InitializeComponent();
            SortAssento();
            SortAviao();
            SortPortao();
        }

        private void SortAssento()
        {
            Random random = new Random();
            int numeroAleatorio = random.Next(1, 201); // Gera um número aleatório entre 1 e 200
            label8.Text = numeroAleatorio.ToString();
        }

        private void SortAviao() // Sorteia o nome do avião para o bilhete
        {
            Random random = new Random();
            int indice = random.Next(0, mensagens.Count); // Escolhe uma mensagem aleatória na lista
            label26.Text = mensagens[indice];
        }

        private void SortPortao() // Sorteia o portão de embarque para o bilhete
        {
            Random random = new Random();
            int Sorteio = random.Next(0, letras.Count);
            char letraAleatoria = letras[Sorteio];
            label30.Text = letraAleatoria.ToString();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            try // ORIGEM (destino)
            {
                string data_source = "datasource=localhost;username=root;password=;database=passagem";
                conexao = new MySqlConnection(data_source);

                conexao.Open();

                string consultaSQL = "SELECT Destino FROM pesquisa WHERE id_pesquisa = (SELECT MAX(id_pesquisa) FROM pesquisa)";

                using (MySqlCommand command = new MySqlCommand(consultaSQL, conexao))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string destino = reader.GetString(0);
                            Origem.Text = destino;
                            OrigemViagem.Text = destino;
                        }
                        else
                        {
                            Origem.Text = "Nenhum resultado encontrado.";
                            OrigemViagem.Text = "Nenhum resultado encontrado.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }

            try // DESTINO (origem)
            {
                string data_source = "datasource=localhost;username=root;password=;database=passagem";
                conexao = new MySqlConnection(data_source);

                conexao.Open();

                string consultaSQL = "SELECT Origem FROM pesquisa WHERE id_pesquisa = (SELECT MAX(id_pesquisa) FROM pesquisa)";

                using (MySqlCommand command = new MySqlCommand(consultaSQL, conexao))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string origem = reader.GetString(0);
                            Destino.Text = origem;
                            DestinoViagem.Text = origem;
                        }
                        else
                        {
                            Destino.Text = "Nenhum resultado encontrado.";
                            DestinoViagem.Text = "Nenhum resultado encontrado.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }

            try // DATA VOLTA
            {
                string data_source = "datasource=localhost;username=root;password=;database=passagem";
                conexao = new MySqlConnection(data_source);

                conexao.Open();

                string consultaSQL = "SELECT DataVolta FROM pesquisa WHERE id_pesquisa = (SELECT MAX(id_pesquisa) FROM pesquisa)";

                using (MySqlCommand command = new MySqlCommand(consultaSQL, conexao))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string dataVolta = reader.GetString(0);
                            DataViagem.Text = dataVolta;
                            DataViagem2.Text = dataVolta;

                        }
                        else
                        {
                            DataViagem.Text = "Nenhum resultado encontrado.";
                            DataViagem2.Text = "Nenhum resultado encontrado.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }

            try // NOME PASSAGEIRO
            {
                string data_source = "datasource=localhost;username=root;password=;database=cadastro";
                conexao = new MySqlConnection(data_source);

                conexao.Open();

                string consultaSQL = "SELECT Nome_Completo FROM cadastrar WHERE Email = @Email";

                using (MySqlCommand command = new MySqlCommand(consultaSQL, conexao))
                {
                    // Certifique-se de que emailDoUsuario está definido corretamente antes de usar
                    if (!string.IsNullOrEmpty(emailDoUsuario))
                    {
                        command.Parameters.AddWithValue("@Email", emailDoUsuario);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nome = reader.GetString(0);
                                PassageiroNome.Text = $"{nome}";
                                PassageiroNome2.Text = $"{nome}";
                            }
                            else
                            {
                                PassageiroNome.Text = "Nenhum resultado encontrado.";
                                PassageiroNome2.Text = "Nenhum resultado encontrado.";
                            }
                        }
                    }
                    else
                    {
                        // Trate o caso em que emailDoUsuario não está definido
                        PassageiroNome.Text = "Email do usuário não definido.";
                        PassageiroNome2.Text = "Email do usuário não definido.";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }

            try // CLASSE
            {
                string data_source = "datasource=localhost;username=root;password=;database=passagem";
                conexao = new MySqlConnection(data_source);

                conexao.Open();

                string consultaSQL = "SELECT Classe FROM classes WHERE id_classes = (SELECT MAX(id_classes) FROM classes)";

                using (MySqlCommand command = new MySqlCommand(consultaSQL, conexao))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string classe = reader.GetString(0);
                            ClasseViagem.Text = classe;

                        }
                        else
                        {
                            ClasseViagem.Text = "Nenhum resultado encontrado.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }

            try // HORA VOLTA
            {
                string data_source = "datasource=localhost;username=root;password=;database=passagem";
                conexao = new MySqlConnection(data_source);

                conexao.Open();

                string consultaSQL = "SELECT HorarioVolta FROM horario WHERE id_horario = (SELECT MAX(id_horario) FROM horario)";

                using (MySqlCommand command = new MySqlCommand(consultaSQL, conexao))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string horaVolta = reader.GetString(0);
                            HoraViagem.Text = horaVolta;
                            HoraViagem2.Text = horaVolta;

                        }
                        else
                        {
                            HoraViagem.Text = "Nenhum resultado encontrado.";
                            HoraViagem2.Text = "Nenhum resultado encontrado.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }


            label28.Text = label8.Text; // Mostra o assento sorteado no bilhete (a parte que fica com o passageiro)
            label33.Text = label26.Text; // Mostra o avião sorteado no bilhete (a parte que fica com o passageiro)
            label18.Text = label30.Text; // Mostra o portão sorteado no bilhete (a parte que fica com o passageiro)
        }

        private void PassageiroNome_Click(object sender, EventArgs e)
        {

        }
    }
}


