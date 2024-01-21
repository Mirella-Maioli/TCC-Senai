using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AgenciaViagens.Form1;
using static AgenciaViagens.Form2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AgenciaViagens
{
    public partial class Form6 : Form
    {
        bool Volta = InfoCompartilhada.Volta;

        MySqlConnection conexao;

        public Form6()
        {
            InitializeComponent();

            // Vincula os eventos à sua TextBox
            txtCPFCNPJ.KeyPress += txtCPFCNPJ_KeyPress;
            txtCPFCNPJ.TextChanged += txtCPFCNPJ_TextChanged;
            txtCPFCNPJ.Leave += txtCPFCNPJ_Leave;

            txtNumCartao.KeyPress += txtNumCartao_KeyPress;
            txtNumCartao.TextChanged += txtNumCartao_TextChanged;
            txtNumCartao.Leave += txtNumCartao_Leave;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (txtNome.Text != "" && txtCPFCNPJ.Text != "" && txtNumCartao.Text != "" && txtValidade.Text != "" && txtCVC.Text != "" && cbParcela.Text != "")
            {
                try
                {
                    string data_source = "datasource=localhost;username=root;password=;database=pagamento";

                    // Cria conexão com MySql
                    conexao = new MySqlConnection(data_source); // Monta conexão com o BD
                    string sql = "INSERT INTO credito (NomeTitular, CPFCNPJ, NumeroCartao, Validade, Codigo, Parcela) VALUES ('" + txtNome.Text + "','" + txtCPFCNPJ.Text + "','" + txtNumCartao.Text + "','" + txtValidade.Text + "','" + txtCVC.Text + "','" + cbParcela.Text + "')";
                    MySqlCommand comando = new MySqlCommand(sql, conexao);// Abre o BD

                    conexao.Open();

                    comando.ExecuteReader();

                    MessageBox.Show(" Pagamento Efetuado ");
                    this.Close();

                    Form9 bilheteIda = new Form9();
                    bilheteIda.Show();

                    if (Volta == true)
                    {
                        Form10 bilheteVolta = new Form10();
                        bilheteVolta.Show();
                    }
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
            else
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Form6_Load(object sender, EventArgs e)
        {

            try // PREÇO
            {
                string data_source = "datasource=localhost;username=root;password=;database=passagem";
                conexao = new MySqlConnection(data_source);

                conexao.Open();

                string consultaSQL = "SELECT PrecoCTaxa FROM preco WHERE id_preco = (SELECT MAX(id_preco) FROM preco)";

                using (MySqlCommand command = new MySqlCommand(consultaSQL, conexao))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            float precoCTaxa = reader.GetFloat(0);


                            cbParcela.Items.Add($"1x = {precoCTaxa:F2}");
                            cbParcela.Items.Add($"2x = {precoCTaxa / 2:F2}");
                            cbParcela.Items.Add($"3x = {precoCTaxa / 3:F2}");
                            cbParcela.Items.Add($"4x = {precoCTaxa / 4:F2}");
                            cbParcela.Items.Add($"5x = {precoCTaxa / 5:F2}");
                            cbParcela.Items.Add($"6x = {precoCTaxa / 6:F2}");
                            cbParcela.Items.Add($"7x = {precoCTaxa / 7:F2}");
                            cbParcela.Items.Add($"8x = {precoCTaxa / 8:F2}");
                            cbParcela.Items.Add($"9x = {precoCTaxa / 9:F2}");
                            cbParcela.Items.Add($"10x = {precoCTaxa / 10:F2}");

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
        }

        private void Origem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (txtCVC.Text.Length > 3)
            {
                MessageBox.Show("O CVC deve conter apenas 3 dígitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCVC.Text = txtCVC.Text.Substring(0, 3);
                txtCVC.SelectionStart = txtCVC.Text.Length;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (txtValidade.Text.Length == 2 && !txtValidade.Text.Contains("/"))
            {
                txtValidade.Text += "/";
                txtValidade.SelectionStart = txtValidade.Text.Length;
            }
            else if (txtValidade.Text.Length > 7)
            {
                txtValidade.Text = txtValidade.Text.Substring(0, 7);
                txtValidade.SelectionStart = txtValidade.Text.Length;
            }
        }

        private void txtCPFCNPJ_TextChanged(object sender, EventArgs e)
        {

        }

        //CPFCNPJ
        private void txtCPFCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se a tecla pressionada é um número
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  // Ignora a tecla pressionada
            }
        }

        private void txtCPFCNPJ_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidarCPF();
            }
        }

        private void ValidarCPF()
        {
            string texto = txtCPFCNPJ.Text;

            // Remove caracteres não numéricos
            string numeros = new string(texto.Where(char.IsDigit).ToArray());

            // Verifica se é um CPF (11 dígitos) ou um CNPJ (14 dígitos)
            if (numeros.Length == 11 || numeros.Length == 14)
            {
                txtCPFCNPJ.Text = numeros;  // Atualiza o texto
                if (numeros.Length == 11)
                {
                    // Aqui você pode chamar uma função ou método para validar o CPF
                    if (ValidarCPF(numeros))
                    {
                        MessageBox.Show("CPF/CNPJ válido!");
                    }
                    else
                    {
                        MessageBox.Show("CPF/CNPJ inválido!");
                    }
                }
            }
            else if (numeros.Length > 14)
            {
                txtCPFCNPJ.Text = numeros.Substring(0, 14);  // Corta para 14 caracteres se ultrapassar
            }
        }

        private bool ValidarCPF(string cpf)
        {
            // Aqui implementamos a lógica de validação do CPF
            // Pode ser utilizado um algoritmo específico ou uma biblioteca de validação de CPF
            // Retorne true se o CPF for válido, e false caso contrário
            // Exemplo simplificado:
            return cpf.Length == 11 && cpf.All(char.IsDigit);
        }

        private void txtCPFCNPJ_Leave(object sender, EventArgs e)
        {
            string numeros = new string(txtCPFCNPJ.Text.Where(char.IsDigit).ToArray());

            // Verifica se o tamanho é exatamente 11 (CPF) ou 14 (CNPJ)
            if (numeros.Length != 11 && numeros.Length != 14)
            {
                MessageBox.Show("O campo deve ter 11 (CPF) ou 14 (CNPJ) dígitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPFCNPJ.Focus();  // Coloca o foco de volta no TextBox
            }
        }

        //NÚMERO DO CARTÃO
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtNumCartao_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtNumCartao_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se a tecla pressionada é um número
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  // Ignora a tecla pressionada
            }
        }

        private void txtNumCartao_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidarNumCartao();
            }
        }

        private void ValidarNumCartao()
        {
            string texto = txtNumCartao.Text;

            // Remove caracteres não numéricos
            string numero = new string(texto.Where(char.IsDigit).ToArray());

            // Verifica se tem 16 digitos
            if (numero.Length == 16)
            {
                txtNumCartao.Text = numero;  // Atualiza o texto
                if (numero.Length == 16)
                {
                    // Aqui você pode chamar uma função ou método para validar o NÚMERO DO CARTÃO
                    if (ValidarNumCartao(numero))
                    {
                        MessageBox.Show("Número do cartão válido!");
                    }
                    else
                    {
                        MessageBox.Show("Número do cartão inválido!");
                    }
                }
            }
            else if (numero.Length > 16)
            {
                txtNumCartao.Text = numero.Substring(0, 16);  // Corta para 16 caracteres se ultrapassar
            }
        }

        private bool ValidarNumCartao(string NumCartao)
        {
            // Aqui implementamos a lógica de validação do NÚMERO DO CARTÃO
            // Pode ser utilizado um algoritmo específico ou uma biblioteca de validação do NÚMERO DO CARTÃO
            // Retorne true se o NÚMERO DO CARTÃO for válido, e false caso contrário
            // Exemplo simplificado:
            return NumCartao.Length == 16 && NumCartao.All(char.IsDigit);
        }

        private void txtNumCartao_Leave(object sender, EventArgs e)
        {
            string numero = new string(txtNumCartao.Text.Where(char.IsDigit).ToArray());

            // Verifica se o tamanho é de exatamente 16 digitos
            if (numero.Length != 16)
            {
                MessageBox.Show("O número do cartão deve ter 16 dígitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumCartao.Focus();  // Coloca o foco de volta no TextBox
            }
        }

        private void txtValidade_Leave(object sender, EventArgs e)
        {
            if (txtValidade.Text.Length == 2 && !txtValidade.Text.Contains("/"))
            {
                txtValidade.Text = txtValidade.Text.Insert(2, "/");
            }

            if (txtValidade.Text.Length < 7)
            {
                MessageBox.Show("A data deve ter 6 dígitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtValidade.Text.Length > 7)
            {
                MessageBox.Show("A data deve ter 6 dígitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValidade.Text = txtValidade.Text.Substring(0, 7);
            }
        }
    }
}
