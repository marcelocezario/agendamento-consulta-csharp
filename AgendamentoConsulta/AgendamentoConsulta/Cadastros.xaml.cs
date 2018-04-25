using System.Windows;
using MahApps.Metro.Controls;


namespace AgendamentoConsulta
{
    /// <summary>
    /// Lógica interna para Casdastros.xaml
    /// </summary>
    public partial class Cadastros : MetroWindow
    {
        public Cadastros()
        {
            InitializeComponent();
        }

        private void BtnCadastrosCliente_Click(object sender, RoutedEventArgs e)
        {
            CadastroPaciente cadCli = new CadastroPaciente();
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
