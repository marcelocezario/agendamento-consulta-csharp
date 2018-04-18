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
    public partial class CadastroCliente : MetroWindow
    {
        public CadastroCliente()
        {
            InitializeComponent();
        }

        public static Cada

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
                        Paciente paciente = new Paciente();

                        paciente.Nome = BoxNomePaciente.Text;
                        paciente.Cpf = BoxCpfPaciente.Text;
                        paciente.Rg = BoxRgPaciente.Text;

                        paciente.Email = BoxEmailPaciente.Text;
                        paciente.Celular = BoxContatoPaciente.Text;
                        paciente.DtNascimento = BoxDtNascimentoPaciente.SelectedDate.Value;


                        //criando novo objeto de Endereço
                        Endereco endereco = new Endereco();

                        endereco.Cep = BoxCepPaciente.Text;
                        endereco.Rua = BoxRuaPaciente.Text;
                        endereco.Complemento = BoxComplementoPaciente.Text;
                        endereco.Numero = int.Parse(BoxNumeroPaciente.Text);
                        endereco.Cidade = BoxCidadePaciente.Text;
                        endereco.Uf = ComboBoxEstado.Text;


                        //passar dados para controller

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
