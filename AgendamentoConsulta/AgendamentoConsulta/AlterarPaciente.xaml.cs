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
    /// Lógica interna para AlterarPaciente.xaml
    /// </summary>
    public partial class AlterarPaciente : Window
    {
        public AlterarPaciente()
        {
            InitializeComponent();
            PacienteController proControl = new PacienteController();
            // Inicializa a listagem de Paciente
            DgDados.ItemsSource = proControl.ListarPacientes();
        }

        //
        private void  EditarPaciente()
        {
            PacienteController prControl = new PacienteController();
            Paciente pc = ContextoSingleton.Instancia.Pacientes.Find(Convert.ToInt32(TxtPacienteID.Text));

            if (pc != null)
            {
                if (prControl.EditarPaciente(Convert.ToInt32(TxtPacienteID.Text), pc))
                {
                    ContextoSingleton.Instancia.SaveChanges();
                    this.ListagemPaciente();
                }

            }
            else
            {
                MessageBox.Show("Paciente vazio");

            }
        }

        private void ExcluirPaciente()
        {
            // Metódo para excluir o insumo no banco
            PacienteController prControl = new PacienteController();

            Paciente pc = ContextoSingleton.Instancia.Pacientes.Find(Convert.ToInt32(TxtPacienteID.Text));

            if (pc != null)
            {
                if (prControl.ExcluirPaciente(pc.ID))
                {
                    this.ListagemPaciente(); // Lista os Paciente atualizados
                    this.LimpaCampos(); //  Limpa campos antigos
                }
            }
            else
            {
                MessageBox.Show("Paciente não selecionado");
            }
        }

        private void PesquisarPacientePorNome()
        {
            // Metódo que pesquisa por nome e exibe o campo  buscado
            PacienteController prControl = new PacienteController();

            try
            {
                var consulta = from c in ContextoSingleton.Instancia.Profissionais
                               where c.Nome.Equals(BoxNomePaciente.Text)
                               select c;

                DgDados.ItemsSource = consulta.ToList();
            }
            catch
            {
                MessageBox.Show("Paciente não encontrado");
            }


        }

        private void ListagemPaciente()
        {
            //Metodo para listar os Paciente no DataGrid
            PacienteController prControl = new PacienteController();

            DgDados.ItemsSource = prControl.ListarPacientes();

        }
        private void LimpaCampos()
        {
            BoxNomePaciente.Clear();
            BoxCpfPaciente.Clear();
            BoxContatoPaciente.Clear();
            BoxEmailPaciente.Clear();
        }

        private void Editar_Paciente_Click(object sender, RoutedEventArgs e)
        {
            EditarPaciente();
        }

        private void Excluir_Paciente_Click(object sender, RoutedEventArgs e)
        {
            EditarPaciente();
        }

        private void Pesquisar_Paciente_Click(object sender, RoutedEventArgs e)
        {
            PesquisarPacientePorNome();
        }

        private void DgDados_Loaded(object sended, RoutedEventArgs e)
        {
            this.ListagemPaciente();
        }

        private void DgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DgDados.SelectedIndex >= 0)
            {
                Paciente pc = (Paciente)DgDados.SelectedItem;

                BoxNomePaciente.Text = pc.Nome;
                BoxCpfPaciente.Text = pc.Cpf;
                BoxContatoPaciente.Text = pc.Celular;
                DatePickerDtNascimentoPaciente.SelectedDate = pc.DtNascimento;
                BoxEmailPaciente.Text = pc.Email;
            }
            else
            {
                MessageBox.Show("Paciente vazio");
            }
        }
    }
}
