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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;

namespace AgenciaViagens
{
    public partial class Form5 : Form
    {
        bool info = InformacaoCompartilhada.info;

        MySqlConnection conexao;
        // Inicializa a lista de CheckBoxes
        private List<CheckBox> checkBoxes = new List<CheckBox>();

        public EventHandler CheckBox_CheckedChanged { get; }

        public Form5()

        {
            InitializeComponent();


            // Adiciona as CheckBoxes à lista
            checkBoxes.Add(checkBox1);
            checkBoxes.Add(checkBox2);
            checkBoxes.Add(checkBox3);

            // Adiciona o evento CheckedChanged a todas as CheckBoxes
            foreach (var checkBox in checkBoxes)
            {
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
            }

        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        double valorTaxa;
        int numPassageiros;
        double precoCTaxa;
        double id;
        double preco;

        private void Form5_Load(object sender, EventArgs e)
        {
            try // TAXA DE EMBARQUE
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

                            if (classe == "Econômica")
                            {
                                label8.Text = $"Taxa de Embarque: R$ 38,66 ";
                                valorTaxa = +38.66;

                            }
                            else if (classe == "Primeira Classe")
                            {
                                label8.Text = $"Taxa de Embarque: R$ 96,50 ";
                                valorTaxa = +96.50;

                            }
                            else if (classe == "Executiva")
                            {
                                label8.Text = $"Taxa de Embarque: R$ 115,82 ";
                                valorTaxa = +115.82;

                            }
                        }
                        else
                        {
                            label7.Text = "Nenhum resultado encontrado.";
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



            try // PASSAGEIROS
            {
                string data_source = "datasource=localhost;username=root;password=;database=passagem";
                conexao = new MySqlConnection(data_source);

                conexao.Open();

                string consultaSQL = "SELECT Adulto, Crianca FROM passageiros WHERE id_passageiros = (SELECT MAX(id_passageiros) FROM passageiros)";

                using (MySqlCommand command = new MySqlCommand(consultaSQL, conexao))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int adulto = reader.GetInt32(0);
                            int crianca = reader.GetInt32(1);

                            numPassageiros = adulto + crianca;
                            label9.Text = $"Número de Passageiros: {numPassageiros}";

                        }
                        else
                        {
                            label9.Text = "Nenhum resultado encontrado.";
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


            try // Preço calculado com o valor da taxa
            {
                string data_source = "datasource=localhost;username=root;password=;database=passagem";
                conexao = new MySqlConnection(data_source);

                conexao.Open();

                string consultaSQL = "SELECT id_preco, Precos FROM preco WHERE id_preco = (SELECT MAX(id_preco) FROM preco)";

                using (MySqlCommand command = new MySqlCommand(consultaSQL, conexao))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = reader.GetInt32(0);
                            preco = reader.GetInt32(1);
                            valorTaxa = valorTaxa * numPassageiros;

                            preco += valorTaxa;

                            label7.Text = $"Preço: R$ {preco}";
                            precoCTaxa = preco;

                        }
                        else
                        {
                            label7.Text = "Nenhum resultado encontrado.";
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


            try // Preço com taxa, indo alterar na tabela do BD
            {
                string data_source = "datasource=localhost;username=root;password=;database=passagem";
                conexao = new MySqlConnection(data_source);

                // Cria conexão com MySql
                conexao.Open();

                // Seleciona o último registro
                string selectLastRecordSql = "SELECT * FROM preco ORDER BY id_preco DESC LIMIT 1";

                MySqlCommand selectLastRecordCmd = new MySqlCommand(selectLastRecordSql, conexao);

                // Executa a consulta para obter o último registro
                MySqlDataReader reader = selectLastRecordCmd.ExecuteReader();


                if (reader.Read())
                {
                    // Obtém o ID do último registro
                    int id = reader.GetInt32("id_preco");

                    // Fecha o leitor antes de executar a atualização
                    reader.Close();

                    // Atualiza o último registro
                    string updateSql = "UPDATE preco SET PrecoCTaxa = @precoCTaxa WHERE id_preco = @id";
                    MySqlCommand updateCmd = new MySqlCommand(updateSql, conexao);
                    updateCmd.Parameters.AddWithValue("@precoCTaxa", precoCTaxa);
                    updateCmd.Parameters.AddWithValue("@id", id);

                    // Executa a atualização
                    updateCmd.ExecuteNonQuery();
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
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clickedCheckBox1 = sender as CheckBox;

            // Conta quantas CheckBoxes estão marcadas
            int checkBoxesMarcadas = checkBoxes.Count(cb => cb.Checked);

            // Limite de 1 CheckBoxes marcadas
            if (checkBoxesMarcadas > 1)
            {
                clickedCheckBox1.Checked = false;
            }

            CheckBox clickedCheckBox = sender as CheckBox;

            // Desmarca todas as outras CheckBoxes quando uma é marcada
            foreach (var checkBox1 in checkBoxes)
            {
                if (checkBox1 != clickedCheckBox1)
                {
                    checkBox1.Checked = false;
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox clickedCheckBox2 = sender as CheckBox;

            // Conta quantas CheckBoxes estão marcadas
            int checkBoxesMarcadas = checkBoxes.Count(cb => cb.Checked);

            // Limite de 1 CheckBoxes marcadas
            if (checkBoxesMarcadas > 1)
            {
                clickedCheckBox2.Checked = false;
            }

            CheckBox clickedCheckBox = sender as CheckBox;

            // Desmarca todas as outras CheckBoxes quando uma é marcada
            foreach (var checkBox2 in checkBoxes)
            {
                if (checkBox2 != clickedCheckBox2)
                {
                    checkBox2.Checked = false;
                }

        }   }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            

            CheckBox clickedCheckBox3 = sender as CheckBox;

            // Conta quantas CheckBoxes estão marcadas
            int checkBoxesMarcadas = checkBoxes.Count(cb => cb.Checked);

            // Limite de 1 CheckBoxes marcadas
            if (checkBoxesMarcadas > 1)
            {
                clickedCheckBox3.Checked = false;
            }

            CheckBox clickedCheckBox = sender as CheckBox;

            // Desmarca todas as outras CheckBoxes quando uma é marcada
            foreach (var checkBox3 in checkBoxes)
            {
                if (checkBox3 != clickedCheckBox3)
                {
                    checkBox3.Checked = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (info == true)
            {
                if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked)
                {
                    if (checkBox1.Checked)
                    {
                        Form8 pix = new Form8();
                        pix.Show();
                    }
                    else if (checkBox2.Checked)
                    {
                        Form7 debito = new Form7();
                        debito.Show();
                    }
                    else if (checkBox3.Checked)
                    {
                        Form6 credito = new Form6();
                        credito.Show();
                    }

                    this.Close();
                }
                else 
                {
                    MessageBox.Show("Selecione uma opção de pagamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Login não realizado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                Form2 login = new Form2();
                login.Show();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
