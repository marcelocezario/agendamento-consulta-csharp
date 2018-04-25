using System.Windows;
using MahApps.Metro.Controls;
using Model;
using Controller;
using System.Windows.Input;
using System;

namespace AgendamentoConsulta
{
    /// <summary>
    /// Lógica interna para TelaAgendamento.xaml
    /// </summary>
    public partial class TelaAgendamento : MetroWindow
    {
        public TelaAgendamento()
        {
            InitializeComponent();
        }

        private void ButtonSalvarAgendamento_Click(object sender, RoutedEventArgs e)
        {
            SalvarAgendamento();
        }

        private void ButtonBuscarProfissional_Click(object sender, RoutedEventArgs e)
        {
            ProfissionalController pc = new ProfissionalController();
            Profissional profissional;

            profissional = pc.PesquisarPorNome(BoxBuscarProfissional.Text);

            if (profissional != null)
            {
                string diasAtendimento = "";

                if (profissional.Domingo == true)
                    diasAtendimento = diasAtendimento + "Domingo / ";
                if (profissional.Segunda == true)
                    diasAtendimento = diasAtendimento + "Segunda-Feira / ";
                if (profissional.Terca == true)
                    diasAtendimento = diasAtendimento + "Terça-Feira / ";
                if (profissional.Quarta == true)
                    diasAtendimento = diasAtendimento + "Quarta-Feira / ";
                if (profissional.Quinta == true)
                    diasAtendimento = diasAtendimento + "Quinta-Feira / ";
                if (profissional.Sexta == true)
                    diasAtendimento = diasAtendimento + "Sexta-Feira / ";
                if (profissional.Sabado == true)
                    diasAtendimento = diasAtendimento + "Sábado";

                string profissionalBusca = "Id: " + profissional.ID +
                    "\nNome: " + profissional.Nome +
                    "\nEspecialidade: " + profissional.Especialidade +
                    "\nRegistro Profissional: " + profissional.ResgistroProfissional +
                    "\n\nDias atendimento: " + diasAtendimento +
                    "\nHorário atendimento: " + profissional.HrInicio.ToString("HH:mm") + " até " + profissional.HrFim.ToString("HH:mm");


                if (MessageBox.Show(profissionalBusca, "Confirma o profissional?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    BoxBuscarProfissional.Text = profissional.Nome;
                    BoxBuscarProfissional.IsEnabled = false;
                    ButtonBuscarProfissional.IsEnabled = false;
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

            paciente = pc.PesquisarPorNome(BoxBuscarPaciente.Text);

            if (paciente != null)
            {
                string pacienteBusca = "Id: " + paciente.ID +
                    "\nNome: " + paciente.Nome +
                    "\nCPF: " + paciente.Cpf +
                    "\nData de nascimento: " + paciente.DtNascimento.ToString("dd/MM/yyyy");

                if (MessageBox.Show(pacienteBusca, "Confirma o paciente?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    BoxBuscarPaciente.Text = paciente.Nome;
                    BoxBuscarPaciente.IsEnabled = false;
                    ButtonBuscarPaciente.IsEnabled = false;
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
                string diasAtendimento = "";

                if (local.Domingo == true)
                    diasAtendimento = diasAtendimento + "Domingo / ";
                if (local.Segunda == true)
                    diasAtendimento = diasAtendimento + "Segunda-Feira / ";
                if (local.Terca == true)
                    diasAtendimento = diasAtendimento + "Terça-Feira / ";
                if (local.Quarta == true)
                    diasAtendimento = diasAtendimento + "Quarta-Feira / ";
                if (local.Quinta == true)
                    diasAtendimento = diasAtendimento + "Quinta-Feira / ";
                if (local.Sexta == true)
                    diasAtendimento = diasAtendimento + "Sexta-Feira / ";
                if (local.Sabado == true)
                    diasAtendimento = diasAtendimento + "Sábado";

                string localBusca = "Id: " + local.LocalID +
                    "\nNome: " + local.NomeLocal +
                    "\nEndereço: " + local._Endereco.Rua + local._Endereco.Numero + local._Endereco.Complemento +
                    "\nCidade: " + local._Endereco.Cidade + local._Endereco.Uf +
                    "\n\nDias atendimento: " + diasAtendimento +
                    "\nHorário atendimento: " + local.HrInicio.ToString("HH:mm") + " até " + local.HrFim.ToString("HH:mm");

                if (MessageBox.Show(localBusca, "Confirma o local?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    BoxBuscarLocal.Text = local.NomeLocal;
                    BoxBuscarLocal.IsEnabled = false;
                    ButtonBuscarLocal.IsEnabled = false;
                    MessageBox.Show(local.NomeLocal + " adicionado com sucesso!");
                }
                else
                    MessageBox.Show("Nenhum local selecionado");
            }
            else
                MessageBox.Show("Nenhum local encontrado");
        }

        private void SalvarAgendamento()
        {
            ProfissionalController prc = new ProfissionalController();
            PacienteController pac = new PacienteController();
            LocalController lc = new LocalController();
            AgendamentoController ac = new AgendamentoController();

            Local local = lc.PesquisarPorNome(BoxBuscarLocal.Text);
            Paciente paciente = pac.PesquisarPorNome(BoxBuscarPaciente.Text);
            Profissional profissional = prc.PesquisarPorNome(BoxBuscarProfissional.Text);

            Agendamento a = new Agendamento()
            {
                LocalID = local.LocalID,
                _Local = local,
                PacienteID = paciente.ID,
                _Paciente = paciente,
                ProfissionalID = profissional.ID,
                _Profissional = profissional,
                DataHoraConsulta = TimePickerHorarioAgendamento.SelectedTime.Value,
            };

            if (ac.IncluirAgendamento(a))
            {
                MessageBox.Show("Agendamento efetuado com sucesso");
                this.Close();
            }
            else
                MessageBox.Show("Agendamento não efetuado por indiponibilidade de horários");
        }
    }
}
