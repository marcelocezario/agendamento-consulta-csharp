using System.Windows;
using MahApps.Metro.Controls;
using Model;
using Controller;
using Verificacao;
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
                            if (BoxCepPaciente.Text.Equals("__.___-___"))
                                MessageBox.Show("O campo CEP é obrigatório");
                            else
                            {
                                if (BoxRuaPaciente.Text.Equals(""))
                                    MessageBox.Show("O campo rua é obrigatório");
                                else
                                {
                                    if (BoxNumeroPaciente.Text.Equals(""))
                                        MessageBox.Show("O campo número em endereço é obrigatório");
                                    else
                                    {
                                        if (BoxCidadePaciente.Text.Equals(""))
                                            MessageBox.Show("O campo Cidade é obrigatório");
                                        else
                                        {
                                            if (BoxUFPaciente.Text.Equals(""))
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
            return false;
        }


        private void SalvarCadastro()
        {
            //criando novo objeto de Paciente

            Paciente p = new Paciente
            {
                Nome = BoxNomePaciente.Text,
                Cpf = BoxCpfPaciente.Text,
                Rg = BoxRgPaciente.Text,

                Email = BoxEmailPaciente.Text,
                Celular = BoxContatoPaciente.Text,
                DtNascimento = DatePickerDtNascimentoPaciente.SelectedDate.Value
            };

            //criando novo objeto de Endereço
            Endereco end = new Endereco
            {
                Cep = BoxCepPaciente.Text,
                Rua = BoxRuaPaciente.Text,
                Complemento = BoxComplementoPaciente.Text,
                Numero = int.Parse(BoxNumeroPaciente.Text),
                Cidade = BoxCidadePaciente.Text,
                Uf = BoxUFPaciente.Text
            };

            //passar dados para controller
            PacienteController pc = new PacienteController();
            EnderecoController ec = new EnderecoController();
            ec.SalvarEndereco(end);
            p.EnderecoID = end.EnderecoID;
            p._Endereco = end;
            pc.SalvarPaciente(p);

            this.Close();

        }

        //valida para o textbox aceitar somente numeros
        private void BoxRgPaciente_KeyDown(object sender, KeyEventArgs e)
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

        //valida para o textbox aceitar somente numeros
        private void BoxNumeroPaciente_KeyDown(object sender, KeyEventArgs e)
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

