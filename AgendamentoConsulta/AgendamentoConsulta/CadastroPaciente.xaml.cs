using System.Windows;
using MahApps.Metro.Controls;
using Model;
using Controller;

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

        // Gabryel não esquecer de arrumar a máscara
        private bool VerificarPreenchimentoCampos()
        {

            if (BoxNomePaciente.Text.Equals(""))
                MessageBox.Show("O campo nome é obrigatório");
            else
            {
                if (Verificacoes.ValidaCpf(BoxCpfPaciente.Text))
                    MessageBox.Show("O campo CPF é obrigatório");
                else
                {
                    if (BoxDtNascimentoPaciente.Text.Equals(""))
                        MessageBox.Show("O campo data de nascimento é obrigatório");
                    else
                    {
                        if (!Verificacoes.ValidarEmail(BoxEmailPaciente.Text))
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
                                    string caracteresPermitidos = "1234567890";
                                    if (!(caracteresPermitidos.Contains(BoxNumeroPaciente.Text.ToString())))
                                        MessageBox.Show("O campo número de endereço esta preechido de forma incorreta");
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
            return false;
        }
    

            private void SalvarCadastro()
            {
                //criando novo objeto de Paciente
                Paciente p = new Paciente();

                p.Nome = BoxNomePaciente.Text;
                p.Cpf = BoxCpfPaciente.Text;
                p.Rg = BoxRgPaciente.Text;

                p.Email = BoxEmailPaciente.Text;
                p.Celular = BoxContatoPaciente.Text;
                p.DtNascimento = BoxDtNascimentoPaciente.SelectedDate.Value;

                //criando novo objeto de Endereço
                Endereco end = new Endereco();

                end.Cep = BoxCepPaciente.Text;
                end.Rua = BoxRuaPaciente.Text;
                end.Complemento = BoxComplementoPaciente.Text;
                end.Numero = int.Parse(BoxNumeroPaciente.Text);
                end.Cidade = BoxCidadePaciente.Text;
                end.Uf = ComboBoxEstado.Text;
                MessageBox.Show("ComboBoxEstado.Text");
                //passar dados para controller
                PacienteController pc = new PacienteController();
                EnderecoController ec = new EnderecoController();
                p.EnderecoID = ec.SalvarEndereco(end);
                p._Endereco = end;
                pc.SalvarPaciente(p);

                this.Close();

            }
        }
    }
