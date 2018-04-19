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

            MessageBox.Show(BoxCpfPaciente.Text);
            if (!BoxNomePaciente.Text.Equals(""))
            {
                // Gabryel não esquecer de arrumar a máscara
                if (!BoxCpfPaciente.Text.Equals("___.___.___-__"))
                {
                    if (BoxDtNascimentoPaciente.Text != null)
                    {

                        if (Verificacoes.ValidarEmail(BoxEmailPaciente.Text))
                        {
                            if (BoxCepPaciente.Text != "" && BoxRuaPaciente.Text != "" && BoxNumeroPaciente.Text != "" &&
                                BoxCidadePaciente.Text != "" && ComboBoxEstado.Text != "")
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


                                //passar dados para controller

                                PacienteController pc = new PacienteController();
                                EnderecoController ec = new EnderecoController();
                                p.EnderecoID = ec.SalvarEndereco(end);
                                pc.SalvarPaciente(p);



                            }
                            else
                            {
                                MessageBox.Show("Dados obrigatórios do endereço do paciente não preenchidos");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Endereço de e-mail inválido");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Data de nascimento do paciente não preenchidos");
                    }
                }
                else
                {
                    MessageBox.Show("CPF inválido do paciente não preenchidos");
                }
            }
            else
            {
                MessageBox.Show("Nome inválido e/ou não preenchidos");
            }
        }
    }
}
