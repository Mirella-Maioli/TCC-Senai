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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;

namespace AgenciaViagens
{
    public partial class Form1 : Form
    {
        public static class InfoCompartilhada
        {
            public static bool Volta { get; set; }
        }

        MySqlConnection conexao;
        public EventHandler Origem_SelectedIndexChanged { get; }
        public EventHandler Destino_SelectedIndexChanged { get; private set; }

        public Form1()
        {
            InitializeComponent();

           // Define a data mínima como a data atual
            DataIda.MinDate = DateTime.Today;
            DataVolta.MinDate = DataIda.MinDate.AddDays(1);

            // Adiciona itens de exemplo às ComboBoxes
            Origem.Items.Add("SÃO PAULO - SP");
            Origem.Items.Add("CURITIBA - PR");
            Origem.Items.Add("RIO DE JANEIRO - RJ");
            Origem.Items.Add("MANAUS - AM");
            Origem.Items.Add("BRASÍLIA - DF");
            Origem.Items.Add("FORTALEZA - CE");


            Destino.Items.Add("SÃO PAULO - SP");
            Destino.Items.Add("CURITIBA - PR");
            Destino.Items.Add("RIO DE JANEIRO - RJ");
            Destino.Items.Add("MANAUS - AM");
            Destino.Items.Add("BRASÍLIA - DF");
            Destino.Items.Add("FORTALEZA - CE");


            // Adiciona o evento SelectedIndexChanged para ambas as ComboBoxes
            Origem.SelectedIndexChanged += Origem_SelectedIndexChanged;
            Destino.SelectedIndexChanged += Destino_SelectedIndexChanged;

        }

        public void AlterarVisibilidadeBotao3(bool visivel)
        {
            button3.Visible = visivel;
        }

        public void button3_Click(object sender, EventArgs e) // BOTÃO DE LOGIN
        {
            Form2 login = new Form2();
            login.Show();

        }

        private void button4_Click(object sender, EventArgs e)// BOTÃO DE PESQUISA
        {
            if (Origem.SelectedItem == null || Destino.SelectedItem == null)
            {
                MessageBox.Show("Preencha origem e destino.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (checkBox1.Checked == true)
            {
                if (DataIda.Value < DataVolta.Value)
                {
                    if (DataIda.Value != DataVolta.Value)
                    {
                        if (Origem.SelectedItem == null && Destino.SelectedItem == null)
                        {
                            MessageBox.Show("Selecione origem e destino.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {

                            string LocalOrigem = Origem.SelectedItem as string;
                            string LocalDestino = Destino.SelectedItem as string;

                            try
                            {
                                string data_source = "datasource=localhost;username=root;password=;database=passagem";

                                // Cria conexão com MySql
                                conexao = new MySqlConnection(data_source); // Monta a conexão com o BD


                                string sql = "INSERT INTO pesquisa (Origem, Destino, DataIda, DataVolta) VALUES ('" + Origem.Text + "','" + Destino.Text + "','" + DataIda.Text + "','" + DataVolta.Text + "')";
                                MySqlCommand comando = new MySqlCommand(sql, conexao);// Abre o BD

                                conexao.Open();

                                comando.ExecuteReader();

                                InfoCompartilhada.Volta = true;

                                Form4 Form4 = new Form4();
                                Form4.Show();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                            finally
                            {
                                conexao.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Data invalida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Data invalida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                
                        if (Origem.SelectedItem == null && Destino.SelectedItem == null)
                        {
                            MessageBox.Show("Selecione origem e destino.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {

                            string LocalOrigem = Origem.SelectedItem as string;
                            string LocalDestino = Destino.SelectedItem as string;

                            try
                            {
                                string data_source = "datasource=localhost;username=root;password=;database=passagem";

                                // Cria conexão com MySql
                                conexao = new MySqlConnection(data_source); // Monta a conexão com o BD


                                string sql = "INSERT INTO pesquisa (Origem, Destino, DataIda) VALUES ('" + Origem.Text + "','" + Destino.Text + "','" + DataIda.Text + "')";
                                MySqlCommand comando = new MySqlCommand(sql, conexao);// Abre o BD

                                conexao.Open();

                                comando.ExecuteReader();

                                InfoCompartilhada.Volta = false;

                                Form4 Form4 = new Form4();
                                Form4.Show();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                            finally
                            {
                                conexao.Close();
                            }
                        }
                    
            }
        }

        public string[] GetComboBox1Items()
        {
            string[] items = new string[Origem.Items.Count];
            Origem.Items.CopyTo(items, 0);
            return items;
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)// COMBO BOX ORIGEM
        {
            VerificarSelecoes();
        }

        private void VerificarSelecoes()
        {
            if (Origem.SelectedItem != null && Destino.SelectedItem != null)
            {

                if (Origem.SelectedItem.Equals(Destino.SelectedItem)) // Condição caso origem e destino sejam iguais
                {
                    MessageBox.Show("A origem não deve ser igual ao destino.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Desfaz a seleção em uma das ComboBoxes, se necessário
                    Origem.SelectedIndex = -1;
                    Destino.SelectedIndex = -1;

                }
            }
            

        }
        public void comboBox2_SelectedIndexChanged(object sender, EventArgs e)// COMBO BOX DESTINO
        {
            VerificarSelecoes();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) // DATA IDA
        {
            if (checkBox1.Checked == true)
            {
                // Restringe a seleção na data de volta para ser depois da data de ida
                if (DataIda.Value == DataVolta.Value)
                {
                    DataVolta.Value = DataVolta.Value.AddDays(1); // Adiciona um dia à data de volta
                }
            }
            
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) // DATA VOLTA
        {
            if (checkBox1.Checked == true)
            {
                // Restringe a seleção na data de volta para ser depois da data de ida
                if (DataVolta.Value <= DataIda.Value)
                {
                    DataVolta.Value = DataIda.Value.AddDays(1); // Adiciona um dia à data de volta
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}