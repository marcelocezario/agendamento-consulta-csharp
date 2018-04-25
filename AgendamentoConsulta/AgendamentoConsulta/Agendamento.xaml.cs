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

            profissional = pc.PesquisarPorNome(BoxBuscaNomeProfissional.Text);

            if (MessageBox.Show(profissional.Nome, "Confirma o profissional?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                MessageBox.Show(profissional.Nome + " adicionado com sucesso!");
            else
                MessageBox.Show("Nenhum profissional selecionado");
        }
    }
}
