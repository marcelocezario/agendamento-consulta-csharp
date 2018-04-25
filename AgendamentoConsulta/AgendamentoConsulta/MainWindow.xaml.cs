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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace AgendamentoConsulta
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void BtnCadastros_Click(object sender, RoutedEventArgs e)
        {
            Cadastros cad = new Cadastros();

            cad.ShowDialog();
        }

        private void BtnAlteracoes_Click(object sender, RoutedEventArgs e)
        {
            AlterarPaciente nAlt = new AlterarPaciente();
            nAlt.ShowDialog();
        }

        private void BtnPesquisa_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BtnAgendamento_Click(object sender, RoutedEventArgs e)
        {
            TelaAgendamento ag = new TelaAgendamento();
            ag.ShowDialog();
        }
    }
}

