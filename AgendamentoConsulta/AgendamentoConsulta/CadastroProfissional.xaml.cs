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
         if (VerificarPreenchimentoCampos())
                SalvarCadastro();

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
                                        return true;               
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
        
        private void ButtonSalvarProfissional_Click(object sender, RoutedEventArgs e)
        {

        }

      
    }
}
