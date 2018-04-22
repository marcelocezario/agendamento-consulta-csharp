using System.Windows;
using MahApps.Metro.Controls;
using Model;
using Controller;
using System.Windows.Input;
using System;

namespace AgendamentoConsulta
{
    /// <summary>
    /// Lógica interna para CadastroProfissional.xaml
    /// </summary>
    public partial class CadastroProfissional : MetroWindow
    {
        public CadastroProfissional()
        {
            InitializeComponent();
        }

        //valida para o textbox aceitar somente numeros
        private void BoxRgProfissional_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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
        
        //valida para o textbox aceitar somente numeros
        private void BoxNumeroProfissional_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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
