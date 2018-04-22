using System.Windows;
using MahApps.Metro.Controls;
using Model;
using Controller;
using System.Windows.Input;
using System;

namespace AgendamentoConsulta
{
    /// <summary>
    /// Interaction logic for CadastroLocal.xaml
    /// </summary>
    public partial class CadastroLocal : MetroWindow
    {
        public CadastroLocal()
        {
            InitializeComponent();
        }

        //salvar nova sala 
        private void ButtonSalvarLocal_Click(object sender, RoutedEventArgs e)
        {

        }


        //valida para o textbox aceitar somente numeros
        private void BoxNumeroLocal_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                KeyConverter key = new KeyConverter();
                if ((char.IsNumber((string)key.ConvertTo(e.Key, typeof(string)), 0) == false))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }
    }
}
