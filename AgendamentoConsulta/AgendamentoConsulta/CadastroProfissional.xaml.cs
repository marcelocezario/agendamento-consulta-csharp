using System.Windows;
using MahApps.Metro.Controls;
using Model;
using Controller;
using System.Windows.Input;
using System;

namespace AgendamentoConsulta
{
    /// <summary>
    /// Lógica interna para CadastroProfissional.xaml
    /// </summary>
    public partial class CadastroProfissional : MetroWindow
    {
        public CadastroProfissional()
        {
            InitializeComponent();
        }
        //Verificacao
        private bool VerificarPreenchimentoCampos()
        {
            if (BoxResgistroProfissional.Text.Equals(""))
                MessageBox.Show("Registro profissional em branco");
            else
            {
                if (TimePickerHInicioProfissional.Text.Equals(""))
                    MessageBox.Show("Horario de inicio do atendimento obrigadorio");
                else
                {
                    if (TimePickerHFimProfissional.Text.Equals(""))
                        MessageBox.Show("Horario de Fim do atendimento obrigadorio");
                    else
                    {
                        if (BoxNomeProfissional.Text.Equals(""))
                            MessageBox.Show("O campo nome é obrigatório");
                        else
                        {
                            if (Verificacao.Verificacao.ValidaCpf(BoxCpfProfissional.Text))
                                MessageBox.Show("O campo CPF é obrigatório");
                            else
                            {
                                if (DatePickerDtNascimentoProfissional.Text.Equals(""))
                                    MessageBox.Show("O campo data de nascimento é obrigatório");
                                else
                                {
                                    if (!Verificacao.Verificacao.ValidarEmail(BoxEmailProfissional.Text))
                                        MessageBox.Show("E-mail inválido");
                                    else
                                    {
                                        if (BoxCepProfissional.Text.Equals("__.___-___"))
                                            MessageBox.Show("O campo CEP é obrigatório");
                                        else
                                        {
                                            if (BoxRuaProfissional.Text.Equals(""))
                                                MessageBox.Show("O campo rua é obrigatório");
                                            else
                                            {
                                                if (BoxNumeroProfissional.Text.Equals(""))
                                                    MessageBox.Show("O campo número em endereço é obrigatório");
                                                else
                                                {
                                                    if (BoxCidadeProfissional.Text.Equals(""))
                                                        MessageBox.Show("O campo Cidade é obrigatório");
                                                    else
                                                    {
                                                        if (ComboBoxEstado.Text.Equals(""))
                                                            MessageBox.Show("O campo UF é obrigatório");
                                                        else
                                                        {
                                                            return true;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Validações não podem ir para a lib de validações pois são excutadas em execução
        /// </summary>
        private void BoxRgProfissional_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {         
            try
            {
                KeyConverter key = new KeyConverter();
                if ((char.IsNumber((string)key.ConvertTo(e.Key, typeof(string)), 0) == false))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }
        private void ButtonSalvarProfissional_Click(object sender, RoutedEventArgs e)
        {

        }

        //valida para o textbox aceitar somente numeros
        private void BoxNumeroProfissional_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                KeyConverter key = new KeyConverter();
                if ((char.IsNumber((string)key.ConvertTo(e.Key, typeof(string)), 0) == false))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

      
    }
}
