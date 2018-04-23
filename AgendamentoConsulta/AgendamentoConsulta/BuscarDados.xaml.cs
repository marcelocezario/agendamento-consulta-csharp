using System.Windows;
using MahApps.Metro.Controls;
using Model;
using Controller;
using Verificacao;
using System.Windows.Input;
using System;
using System.Windows.Controls;

namespace AgendamentoConsulta
{
    /// <summary>
    /// Lógica interna para BuscarDados.xaml
    /// </summary>
    public partial class BuscarDados : MetroWindow
    {
        public BuscarDados()
        {
            InitializeComponent();
        }

        private void ListBoxItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                ListBoxItem lbi = sender as ListBoxItem;
                lbi.IsSelected = true;
                lbi.Focus();
                lb2.SelectedItems.Add(lbi);
            }
        }

        private void ListBoxItem_SelectedPaciente(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Paciente");
        }
        
        private void ListBoxItem_SelectedProfissional(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Profissional");
        }

        private void ListBoxItem_SelectedLocal(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("local");
        }
    }
}
