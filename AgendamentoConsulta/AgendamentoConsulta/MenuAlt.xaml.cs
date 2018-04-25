﻿using System;
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
using System.Windows;
using MahApps.Metro.Controls;

namespace AgendamentoConsulta
{
    /// <summary>
    /// Interaction logic for MenuAlt.xaml
    /// </summary>
    public partial class MenuAlt : MetroWindow
    {
        public MenuAlt()
        {
            InitializeComponent();

        }
        private void BtnAlterarsCliente_Click(object sender, RoutedEventArgs e)
        {
            AlterarPaciente cadCli = new AlterarPaciente();
            cadCli.ShowDialog();
        }

        private void BtnAlterarProfissional_Click(object sender, RoutedEventArgs e)
        {
            AlterarProfissional cadPro = new AlterarProfissional();
            cadPro.ShowDialog();
        }

        private void BtnAlterarLocal_Click(object sender, RoutedEventArgs e)
        {
            AlterarLocal cadLocal = new AlterarLocal();
            cadLocal.ShowDialog();
        }
    }
}

