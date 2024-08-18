using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculadora
{
    public partial class calculadora : Form
    {
        public calculadora()
        {
            InitializeComponent();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (txtConta.Text.Length > 0) {
                txtConta.Text = txtConta.Text.Substring(0, txtConta.Text.Length - 1);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtConta.Text = "";
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtConta.Text += "0";
        }

        private void btnUm_Click(object sender, EventArgs e)
        {
            txtConta.Text += "1";
        }

        private void btnDois_Click(object sender, EventArgs e)
        {
            txtConta.Text += "2";
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            txtConta.Text += "3";
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            txtConta.Text += "6";
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            txtConta.Text += "5";
        }

        private void btnQuatro_Click(object sender, EventArgs e)
        {
            txtConta.Text += "4";
        }

        private void btnSete_Click(object sender, EventArgs e)
        {
            txtConta.Text += "7";
        }

        private void btnOito_Click(object sender, EventArgs e)
        {
            txtConta.Text += "8";
        }

        private void btnNove_Click(object sender, EventArgs e)
        {
            txtConta.Text += "9";
        }

        private void btnSoma_Click(object sender, EventArgs e)
        {
            txtConta.Text += "+";
        }

        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            txtConta.Text += "-";
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            txtConta.Text += "*";
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            txtConta.Text += "/";
        }

        private void btnPorcentagem_Click(object sender, EventArgs e)
        {
            txtConta.Text += "%";
        }

        private void btnParenteses_Click(object sender, EventArgs e)
        {
            int tamanho = txtConta.Text.Length;

            String ultimo_digito = txtConta.Text[tamanho-1].ToString();
            MessageBox.Show(ultimo_digito);

            if (txtConta.Text.Contains("(") && txtConta.Text.Contains(")"))
            {
                int numAbre = 0;
                int numFecha = 0;

                for (int i = 0; i < txtConta.Text.Length; i++)
                {
                    if(txtConta.Text[i] == '(')
                    {
                            numAbre++;
                    }
                    else if (txtConta.Text[i] == ')')
                    {
                        numFecha++;
                    }
                }

                if(numAbre > numFecha)
                {
                    txtConta.Text += ")";
                }
                else if(numAbre == numFecha)
                {
                    txtConta.Text += "(";
                }
            }
            else if(txtConta.Text.Contains("(") && !txtConta.Text.Contains(")"))
            {
                txtConta.Text += ")";
            }
            else
            {
                txtConta.Text += "(";
            }
        }

        private void btnVirgula_Click(object sender, EventArgs e)
        {

        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            calcula();
        }

        private void calcula()
        {
            string conta = txtConta.Text;

            // Verifica se há pelo menos uma das operações básicas na conta
            if (conta.Contains('+') || conta.Contains('-') || conta.Contains('/') || conta.Contains('*'))
            {
                // Verifica se a conta não contém parênteses
                if (!conta.Contains('(') && !conta.Contains(')'))
                {
                    double primeiro = 0;
                    double segundo = 0;
                    double resultado = 0;

                    // Verifica qual operador está presente e realiza a operação correspondente
                    if (conta.Contains('+'))
                    {
                        primeiro = Convert.ToDouble(conta.Split('+')[0]);
                        segundo = Convert.ToDouble(conta.Split('+')[1]);
                        resultado = primeiro + segundo;
                    }
                    else if (conta.Contains('-'))
                    {
                        primeiro = Convert.ToDouble(conta.Split('-')[0]);
                        segundo = Convert.ToDouble(conta.Split('-')[1]);
                        resultado = primeiro - segundo;
                    }
                    else if (conta.Contains('*'))
                    {
                        primeiro = Convert.ToDouble(conta.Split('*')[0]);
                        segundo = Convert.ToDouble(conta.Split('*')[1]);
                        resultado = primeiro * segundo;
                    }
                    else if (conta.Contains('/'))
                    {
                        primeiro = Convert.ToDouble(conta.Split('/')[0]);
                        segundo = Convert.ToDouble(conta.Split('/')[1]);

                        // Verifica se o divisor não é zero
                        if (segundo != 0)
                        {
                            resultado = primeiro / segundo;
                        }
                        else
                        {
                            MessageBox.Show("Divisão por zero não é permitida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Exibe o resultado no TextBox (ou onde desejar)
                    txtConta.Text = resultado.ToString();
                }
            }
            else
            {
                MessageBox.Show("Nenhuma operação foi detectada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
