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
            SalvarCadastro();
        }

        private void SalvarCadastro()
        {
            //criando novo objeto de Endereço
            Endereco end = new Endereco
            {
                Cep = BoxCepLocal.Text,
                Rua = BoxRuaLocal.Text,
                Numero = int.Parse(BoxNumeroLocal.Text),
                Complemento = BoxComplementoLocal.Text,
                Cidade = BoxCidadeLocal.Text,
                Uf = ComboBoxEstado.SelectionBoxItem.ToString(),
            };
            EnderecoController ec = new EnderecoController();
            ec.SalvarEndereco(end);

            //criando novo objeto de Local
            Local p = new Local
            {
                NomeLocal = BoxNomeLocal.Text,

                Domingo = CheckBoxDomingo.IsChecked,
                Segunda = CheckBoxSegunda.IsChecked,
                Terca = CheckBoxTerca.IsChecked,
                Quarta = CheckBoxQuarta.IsChecked,
                Quinta = CheckBoxQuinta.IsChecked,
                Sexta = CheckBoxSexta.IsChecked,
                Sabado = CheckBoxSabado.IsChecked,

                HrInicio = TimePickerHInicioLocal.SelectedTime.Value,
                HrFim = TimePickerHFimLocal.SelectedTime.Value,

                EnderecoID = end.EnderecoID,
                _Endereco = end,
            };

            LocalController lc = new LocalController();

            lc.SalvarLocal(p);

            MessageBox.Show("Local cadastrado com sucesso!");
            this.Close();
        }
    }
}
