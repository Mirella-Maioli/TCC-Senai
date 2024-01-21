using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AgenciaViagens
{
    public partial class Form3 : Form
    {

        MySqlConnection conexao;

        public Form3()
        {
            InitializeComponent();
            // Vincula os eventos à sua TextBox
            txtCPF.TextChanged += txtCPF_TextChanged;
            txtCPF.Leave += txtCPF_Leave;

            txtTelefone.TextChanged += txtTelefone_TextChanged;
            txtTelefone.Leave += txtTelefone_Leave;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && DataNasc.Text != "" && txtCPF.Text != "" && txtTelefone.Text != "" && txtEmail.Text != "" && txtSenha.Text != "")
            {
                try
                {
                    string data_source = "datasource=localhost;username=root;password=;database=cadastro";

                    // Cria conexão com MySql
                    conexao = new MySqlConnection(data_source); // Monta conexão com o BD


                    string sql = "INSERT INTO cadastrar (Nome_Completo, Data_Nascimento, CPF, Telefone, Email, Senha) VALUES ('" + txtNome.Text + "','" + DataNasc.Text + "','" + txtCPF.Text + "','" + txtTelefone.Text + "','" + txtEmail.Text + "','" + txtSenha.Text + "')";
                    MySqlCommand comando = new MySqlCommand(sql, conexao);// Abre o BD

                    conexao.Open();

                    comando.ExecuteReader();

                    MessageBox.Show(" Cadastro concluído! ");
                    this.Close();
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

        //CPF
        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            // Verifica se o tamanho atual do texto é maior que 11
            if (txtCPF.Text.Length > 11)
            {
                // Se for, corta o texto para 14 caracteres
                txtCPF.Text = txtCPF.Text.Substring(0, 11);
            }
        }

        private void txtCPF_Leave(object sender, EventArgs e)
        {
            // Verifica se o tamanho atual do texto é diferente de 11
            if (txtCPF.Text.Length != 11)
            {
                MessageBox.Show("O CPF deve ter 11 dígitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPF.Focus();  // Coloca o foco de volta no TextBox
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se a tecla pressionada é um número e se o tamanho atual do texto é menor que 11
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && txtCPF.Text.Length < 11)
            {
                e.Handled = true;  // Ignora a tecla pressionada
            }
        }

        //TELEFONE
        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            // Verifica se o tamanho atual do texto é maior que 11
            if (txtTelefone.Text.Length > 11)
            {
                // Se for, corta o texto para 14 caracteres
                txtTelefone.Text = txtTelefone.Text.Substring(0, 11);
            }
        }

        private void txtTelefone_Leave(object sender, EventArgs e)
        {
            // Verifica se o tamanho atual do texto é diferente de 11
            if (txtTelefone.Text.Length != 11)
            {
                MessageBox.Show("O Telefone deve ter 11 dígitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefone.Focus();  // Coloca o foco de volta no TextBox
            }
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se a tecla pressionada é um número e se o tamanho atual do texto é menor que 11
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && txtTelefone.Text.Length < 11)
            {
                e.Handled = true;  // Ignora a tecla pressionada
            }
        }
    }
}
