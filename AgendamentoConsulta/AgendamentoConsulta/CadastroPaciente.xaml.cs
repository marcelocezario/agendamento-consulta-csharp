using System.Windows;
using MahApps.Metro.Controls;
using Model;
using Controller;
using Veri
using System.Windows.Input;
using System;

namespace AgendamentoConsulta
{
    /// <summary>
    /// Lógica interna para CadastroCliente.xaml
    /// </summary>
    public partial class CadastroPaciente : MetroWindow
    {
        public CadastroPaciente()
        {
            InitializeComponent();
        }

        private void ButtonSalvarPaciente_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarPreenchimentoCampos())
                SalvarCadastro();
        }

        private bool VerificarPreenchimentoCampos()
        {
            if (BoxNomePaciente.Text.Equals(""))
                MessageBox.Show("O campo nome é obrigatório");
            else
            {
                if (BoxCpfPaciente.Text.Equals("___.___.___-__"))
                    /////////////////////////////////////////////////////////////////////////////if (Verificacao.Verificacao.ValidaCpf(BoxCpfPaciente.Text))
                    MessageBox.Show("O campo CPF é obrigatório");
                else
                {
                    if (DatePickerDtNascimentoPaciente.Text.Equals(""))
                        MessageBox.Show("O campo data de nascimento é obrigatório");
                    else
                    {
                        if (!Verificacao.Verificacao.ValidarEmail(BoxEmailPaciente.Text))
                            MessageBox.Show("E-mail inválido");
                        else
                        {                          
                               return true;        
                        }
                    }
                }
            }
            return false;
        }


        private void SalvarCadastro()
        {
            //criando novo objeto de Paciente

            Paciente p = new Paciente
            {
                Nome = BoxNomePaciente.Text,
                Cpf = BoxCpfPaciente.Text,
                
                Email = BoxEmailPaciente.Text,
                Celular = BoxContatoPaciente.Text,
                DtNascimento = DatePickerDtNascimentoPaciente.SelectedDate.Value
            };
            PacienteController pa = new PacienteController();

            pa.SalvarPaciente(p);

            MessageBox.Show("Paciente cadastrado com sucesso!");
            this.Close();
        }     
    }
}

