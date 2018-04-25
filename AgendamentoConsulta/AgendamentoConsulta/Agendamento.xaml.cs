using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;

namespace AgendamentoConsulta
{
    /// <summary>
    /// Interação lógica para CadastroAgendamento.xam
    /// </summary>
    public partial class Agendamento : MetroWindow

    {
        public Agendamento()
        {
            InitializeComponent();
        }

        private void ComboBoxNomeProfissional_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSalvarAgendamento_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonBuscarProfissional_Click(object sender, RoutedEventArgs e)
        {
            ProfissionalController pc = new ProfissionalController();
            Profissional profissional;

            profissional = pc.PesquisarPorNome(BoxBuscarProfissional.Text);

            if (profissional != null)
            {
                string profissionalBusca = "Id: " + profissional.ID +
                    "\nNome: " + profissional.Nome +
                    "\nEspecialidade: " + profissional.Especialidade +
                    "\nRegistro Profissional: " + profissional.ResgistroProfissional;

                if (MessageBox.Show(profissionalBusca, "Confirma o profissional?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    BoxBuscarProfissional.Text = profissional.Nome;
                    MessageBox.Show(profissional.Nome + " adicionado com sucesso!");
                }
                else
                    MessageBox.Show("Nenhum profissional selecionado");
            }
            else
                MessageBox.Show("Nenhum profissional encontrado");

        }

        private void ButtonBuscarPaciente_Click(object sender, RoutedEventArgs e)
        {
            PacienteController pc = new PacienteController();
            Paciente paciente;

            paciente = pc.PesquisarPorNome(BoxBuscasrPaciente.Text);

            if (paciente != null)
            {
                string pacienteBusca = "Id: " + paciente.ID +
                    "\nNome: " + paciente.Nome +
                    "\nCPF: " + paciente.Cpf +
                    "\nData de nascimento: " + paciente.DtNascimento.ToString("dd/MM/yyyy");

                if (MessageBox.Show(pacienteBusca, "Confirma o paciente?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    BoxBuscasrPaciente.Text = paciente.Nome;
                    MessageBox.Show(paciente.Nome + " adicionado com sucesso!");
                }
                else
                    MessageBox.Show("Nenhum paciente selecionado");
            }
            else
                MessageBox.Show("Nenhum paciente encontrado");
        }

        private void ButtonBuscarLocal_Click(object sender, RoutedEventArgs e)
        {
            LocalController lc = new LocalController();
            Local local;

            local = lc.PesquisarPorNome(BoxBuscarLocal.Text);

            if (local != null)
            {
                string localBusca = "Id: " + local.LocalID +
                    "\nNome: " + local.NomeLocal +
                    "\nEndereço: " + local._Endereco.Rua + local._Endereco.Numero + local._Endereco.Complemento +
                    "\nCidade: " + local._Endereco.Cidade + local._Endereco.Uf;

                if (MessageBox.Show(localBusca, "Confirma o local?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    BoxBuscarLocal.Text = local.NomeLocal;
                    MessageBox.Show(local.NomeLocal + " adicionado com sucesso!");
                }
                else
                    MessageBox.Show("Nenhum local selecionado");
            }
            else
                MessageBox.Show("Nenhum local encontrado");
        }
    }
}
