using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AgenciaViagens.Form1;

namespace AgenciaViagens
{
    public partial class Form4 : Form
    {
        bool Volta = InfoCompartilhada.Volta;

        MySqlConnection conexao;

        public Form4()
        {
            InitializeComponent();

            HoraIda.CheckOnClick = true;
            HoraIda.ItemCheck += checkedListBox2_ItemCheck;

            HoraVolta.CheckOnClick = true;

            Classes.CheckOnClick = true;
            Classes.ItemCheck += checkedListBox1_ItemCheck;

            // Inscreva-se para o evento ItemCheck
           // HoraVolta.ItemCheck += checkedListBox1_ItemCheck;
        }

        private Form1 form1;

        private void Form4_Load(object sender, EventArgs e)
        {
            if (Volta == false)
            {
                if (HoraVolta.CheckOnClick)
                {
                    HoraVolta.Visible = false;
                    label12.Text = "";
                }
            }
            try // ORIGEM
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
                            label8.Text = $"Origem: {origem}";
                        }
                        else
                        {
                            label8.Text = "Nenhum resultado encontrado.";
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

            try // DESTINO
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
                            label9.Text = $"Destino: {destino}";
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

            try // DATA IDA
            {
                string data_source = "datasource=localhost;username=root;password=;database=passagem";
                conexao = new MySqlConnection(data_source);

                conexao.Open();

                string consultaSQL = "SELECT DataIda FROM pesquisa WHERE id_pesquisa = (SELECT MAX(id_pesquisa) FROM pesquisa)";

                using (MySqlCommand command = new MySqlCommand(consultaSQL, conexao))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string dataIda = reader.GetString(0);
                            label10.Text = $"Ida: {dataIda}";
                        }
                        else
                        {
                            label10.Text = "Nenhum resultado encontrado.";
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

            if (Volta == true)
            {
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
                                label11.Text = $"Volta: {dataVolta}";
                            }
                            else
                            {
                                label11.Text = "Nenhum resultado encontrado.";
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
            }
            else
            {
                label11.Text = $"Volta:";
            }

            //-------------------------------------------------------------------------------------------------------

            if (numAdulto.Value > 0)
            {
                adulto = numAdulto.Value;

                adulto = adulto * 400;// Preço da passagem dos adultos

                precoAdulto.Text = $"R${adulto}";
            }

            if (numCrianca.Value > 0)
            {
                crianca = numCrianca.Value;

                crianca = crianca * 450;// Preço da passagem das crianças

                precoCrianca.Text = $"R${crianca}";
            }

        }

        private void button3_Click(object sender, EventArgs e) // Botão PROSSEGUIR
        {
            if (Volta == true)
            {
                if (numAdulto.Value > 0)
                {
                    if (HoraIda.CheckedItems.Count > 0)
                    {
                        if (HoraVolta.CheckedItems.Count > 0)
                        {
                            if (Classes.CheckedItems.Count > 0)
                            {


                                try// CLASSES
                                {
                                    string data_source = "datasource=localhost;username=root;password=;database=passagem";

                                    // Cria conexão com MySql
                                    conexao = new MySqlConnection(data_source); // Monta conexão com o BD


                                    string sql = "INSERT INTO classes  (Classe) VALUES ('" + Classes.Text + "')";
                                    MySqlCommand comando = new MySqlCommand(sql, conexao); // Abre o BD
                                    conexao.Open();

                                    comando.ExecuteReader();

                                }

                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                                finally
                                {
                                    conexao.Close();
                                }


                                try // PASSAGEIROS
                                {
                                    string data_source = "datasource=localhost;username=root;password=;database=passagem";

                                    // criar conexão com MySql
                                    conexao = new MySqlConnection(data_source); // Monta conexão com o BD


                                    string sql = "INSERT INTO passageiros (Adulto, Crianca) VALUES ('" + numAdulto.Text + "','" + numCrianca.Text + "')";


                                    MySqlCommand comando = new MySqlCommand(sql, conexao); // Abre o BD

                                    conexao.Open();

                                    comando.ExecuteReader();

                                }

                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                                finally
                                {
                                    conexao.Close();
                                }

                                try // HORARIOS
                                {
                                    string data_source = "datasource=localhost;username=root;password=;database=passagem";

                                    // Cria conexão com MySql
                                    conexao = new MySqlConnection(data_source); // Monta conexão com o BD


                                    string sql = "INSERT INTO horario (HorarioIda, HorarioVolta) VALUES ('" + HoraIda.Text + "','" + HoraVolta.Text + "')";


                                    MySqlCommand comando = new MySqlCommand(sql, conexao); // Abre o BD

                                    conexao.Open();

                                    comando.ExecuteReader();

                                }

                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                                finally
                                {
                                    conexao.Close();
                                }

                                try // PREÇO
                                {
                                    string data_source = "datasource=localhost;username=root;password=;database=passagem";

                                    // Cria conexão com MySql
                                    conexao = new MySqlConnection(data_source); // Monta conexão com o BD

                                    pessoas = crianca + adulto;

                                    preco = pessoas;
                                    string sql = "INSERT INTO preco (Precos) VALUES ('" + preco + "')";


                                    MySqlCommand comando = new MySqlCommand(sql, conexao); // Abre o BD

                                    conexao.Open();

                                    comando.ExecuteReader();

                                }

                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                                finally
                                {
                                    conexao.Close();
                                }

                                Form5 pagamento = new Form5();
                                pagamento.Show();

                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show("Selecione uma classe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return; // Impede a transição se a validação falhar
                            }
                        }
                        else
                        {

                            MessageBox.Show("Selecione uma hora para volta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Impede a transição se a validação falhar
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selecione uma hora para ida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Impede a transição se a validação falhar
                    }

                }
                else
                {
                    MessageBox.Show("Selecione um adulto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Impede a transição se a validação falhar
                }
            }
            
            else
            {
                if (numAdulto.Value > 0)
                {
                    if (HoraIda.CheckedItems.Count > 0)
                    {

                        if (Classes.CheckedItems.Count > 0)
                        {


                            try// CLASSES
                            {
                                string data_source = "datasource=localhost;username=root;password=;database=passagem";

                                // Cria conexão com MySql
                                conexao = new MySqlConnection(data_source); // Monta conexão com o BD


                                string sql = "INSERT INTO classes  (Classe) VALUES ('" + Classes.Text + "')";
                                MySqlCommand comando = new MySqlCommand(sql, conexao); // Abre o BD
                                conexao.Open();

                                comando.ExecuteReader();

                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                            finally
                            {
                                conexao.Close();
                            }


                            try // PASSAGEIROS
                            {
                                string data_source = "datasource=localhost;username=root;password=;database=passagem";

                                // criar conexão com MySql
                                conexao = new MySqlConnection(data_source); // Monta conexão com o BD


                                string sql = "INSERT INTO passageiros (Adulto, Crianca) VALUES ('" + numAdulto.Text + "','" + numCrianca.Text + "')";


                                MySqlCommand comando = new MySqlCommand(sql, conexao); // Abre o BD

                                conexao.Open();

                                comando.ExecuteReader();

                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                            finally
                            {
                                conexao.Close();
                            }

                            try // HORARIOS
                            {
                                string data_source = "datasource=localhost;username=root;password=;database=passagem";

                                // Cria conexão com MySql
                                conexao = new MySqlConnection(data_source); // Monta conexão com o BD


                                string sql = "INSERT INTO horario (HorarioIda) VALUES ('" + HoraIda.Text + "')";


                                MySqlCommand comando = new MySqlCommand(sql, conexao); // Abre o BD

                                conexao.Open();

                                comando.ExecuteReader();

                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                            finally
                            {
                                conexao.Close();
                            }

                            try // PREÇO
                            {
                                string data_source = "datasource=localhost;username=root;password=;database=passagem";

                                // Cria conexão com MySql
                                conexao = new MySqlConnection(data_source); // Monta conexão com o BD

                                pessoas = crianca + adulto;

                                preco = pessoas;
                                string sql = "INSERT INTO preco (Precos) VALUES ('" + preco + "')";


                                MySqlCommand comando = new MySqlCommand(sql, conexao); // Abre o BD

                                conexao.Open();

                                comando.ExecuteReader();

                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                            finally
                            {
                                conexao.Close();
                            }

                            Form5 pagamento = new Form5();
                            pagamento.Show();

                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("Selecione uma classe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Impede a transição se a validação falhar
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Selecione uma hora para ida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Impede a transição se a validação falhar
                    }

                }
                else
                {
                    MessageBox.Show("Selecione um adulto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Impede a transição se a validação falhar
                }
            }
        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Desmarca todos os itens, exceto o que está sendo verificado
           for (int i = 0; i < HoraIda.Items.Count; i++)
           {
                if (i != e.Index && HoraIda.GetItemChecked(i))
                {
                    HoraIda.SetItemChecked(i, false);
                }
           }
        }

        decimal preco;
        decimal pessoas;
        decimal crianca;
        decimal adulto;

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Desmarca todos os itens, exceto o que está sendo verificado
            for (int i = 0; i < Classes.Items.Count; i++)
            {
                if (i != e.Index)
                {
                    Classes.SetItemChecked(i, false);
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numAdulto.Value > 0)
            {
                adulto = numAdulto.Value;

                adulto = adulto * 400; // Preço da passagem dos adultos
                precoAdulto.Text = $"R$ {adulto},00";
            }
            else
            {
                precoAdulto.Text = "R$ ";
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numCrianca.Value < 1)
            { 
                crianca = crianca - 450; 

                if (crianca <= 0)
                {
                    crianca = 0;
                }
            }
                
                if (numCrianca.Value > 0)
                {
                    crianca = numCrianca.Value;

                    crianca = crianca * 450; // Preço da passagem das crianças
                    precoCrianca.Text = $"R$ {crianca},00";
                }
                else
                {
                    precoCrianca.Text = "R$ ";
                }
           
        }
    }
}

