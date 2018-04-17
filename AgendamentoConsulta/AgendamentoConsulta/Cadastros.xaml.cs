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

namespace AgendamentoConsulta
{
    /// <summary>
    /// Lógica interna para Casdastros.xaml
    /// </summary>
    public partial class Casdastros : MetroWindow
    {
        public Casdastros()
        {
            InitializeComponent();
        }

        private void BtnCadastrosCliente_Click(object sender, RoutedEventArgs e)
        {
            CadastroCliente cadCli = new CadastroCliente();
            cadCli.ShowDialog();
        }

        private void BtnCadastroProfissional_Click(object sender, RoutedEventArgs e)
        {
            CadastroProfissional cadPro = new CadastroProfissional();
            cadPro.ShowDialog();
        }

        private void BtnCadastroLocal_Click(object sender, RoutedEventArgs e)
        {
            CadastroLocal cadLocal = new CadastroLocal();
            cadLocal.ShowDialog();
        }
    }
}
