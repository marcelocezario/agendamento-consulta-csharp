using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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

            if (BoxNomePaciente.Text != null || BoxCpfPaciente != null || BoxDtNascimentoPaciente != null)
            {
                if (Verificacoes.ValidarEmail(BoxEmailPaciente.Text))
                {
                    if (BoxCepPaciente.Text != null || BoxRuaPaciente.Text != null || BoxNumeroPaciente.Text != null ||
                        BoxCidadePaciente.Text != null || ComboBoxEstado.Text != null)
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
                MessageBox.Show("Dados obrigatórios do paciente não preenchidos");
            }
        }
    }
}
}
