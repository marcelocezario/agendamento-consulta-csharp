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
        private bool VerificarPreenchimentoCampos()
        {
            if (TimePickerHInicioLocal.Text.Equals(""))
                MessageBox.Show("Horario de inicio para o uso obrigadorio");
            else
            {
                if (TimePickerHFimLocal.Text.Equals(""))
                    MessageBox.Show("Horario de Fim do para o uso obrigadorio");
                else
                {
                    if (BoxNomeLocal.Text.Equals(""))
                        MessageBox.Show("O campo nome é obrigatório");
                    else
                    {
                        if (BoxCepLocal.Text.Equals("__.___-___"))
                            MessageBox.Show("O campo CEP é obrigatório");
                        else
                        {
                            if (BoxRuaLocal.Text.Equals(""))
                                MessageBox.Show("O campo rua é obrigatório");
                            else
                            {
                                if (BoxNumeroLocal.Text.Equals(""))
                                    MessageBox.Show("O campo número em endereço é obrigatório");
                                else
                                {
                                    if (BoxCidadeLocal.Text.Equals(""))
                                        MessageBox.Show("O campo Cidade é obrigatório");
                                    else
                                    {
                                        if (ComboBoxEstado.Text.Equals(""))
                                            MessageBox.Show("O campo UF é obrigatório");
                                        else
                                        {
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }


        //salvar nova sala 
        private void ButtonSalvarLocal_Click(object sender, RoutedEventArgs e)
        {

        

       
        }
    }
}
