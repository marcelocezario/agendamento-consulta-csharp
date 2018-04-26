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
using Model;
using Controller;

namespace AgendamentoConsulta
{
    /// <summary>
    /// Lógica interna para AlterarLocal.xaml
    /// </summary>
    public partial class AlterarLocal : MetroWindow
    {
        public AlterarLocal()
        {
            InitializeComponent();
            LocalController proControl = new LocalController();
            // Inicializa a listagem de Local
            DgDados.ItemsSource = proControl.ListarLocais();
        }

        //
        private void EditarLocal()
        {
            LocalController lcControl = new LocalController();
            EnderecoController endControl = new EnderecoController();            
           

            
                Endereco end = new Endereco
                {
                    Cep = BoxCepLocal.Text,
                    Rua = BoxRuaLocal.Text,
                    Numero = int.Parse(BoxNumeroLocal.Text),
                    Complemento = BoxComplementoLocal.Text,
                    Cidade = BoxCidadeLocal.Text,
                    Uf = ComboBoxEstado.Text,
                };
                EnderecoController ec = new EnderecoController();
                ec.SalvarEndereco(end);

                //criando novo objeto de Local
                Local lc = new Local
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

                if (lc != null)
                {
                    if (lcControl.EditarLocal(int.Parse(TxtLocalID.Text), lc))
                    {
                        endControl.EditarEndereco(int.Parse(TxtEnderecoID.Text), end);
                        ListagemLocal();
                    }

                }
                else
                {
                    MessageBox.Show("Local vazio");

                }
            }

        private void ListagemLocal()
        {
            //Metodo para listar os Paciente no DataGrid
            LocalController lcControl = new LocalController();

            DgDados.ItemsSource = lcControl.ListarLocais();

        }


        private void ExcluirLocal()
        {
            // Metódo para excluir o insumo no banco
            
            LocalController lcControl = new LocalController();
            Local lc = lcControl.PesquisarPorID(Convert.ToInt32(TxtLocalID.Text));
            EnderecoController endControl = new EnderecoController();
            Endereco end = endControl.PesquisarPorID(lc.EnderecoID);

            int idlocal = Convert.ToInt32(TxtLocalID.Text);            

            if (lc != null)
            {
                if (lcControl.ExcluirLocal(idlocal))
                {
                    endControl.ExcluirEndereco(end.EnderecoID);
                    ListagemLocal(); // Lista os Local atualizados
                    LimpaCampos(); //  Limpa campos antigos
                }
            }
            else
            {
                MessageBox.Show("Local não selecionado");
            }
        }

        private void PesquisarLocalPorNome()
        {
            // Metódo que pesquisa por nome e exibe o campo  buscado
            LocalController lcControl = new LocalController();

            try
            {
                var consulta = from c in ContextoSingleton.Instancia.Locais
                               where c.NomeLocal.Equals(BoxNomeLocal.Text)
                               select c;

                DgDados.ItemsSource = consulta.ToList();
            }
            catch
            {
                MessageBox.Show("Local não encontrado");
            }


        }

       
        //limpar campos 
        private void LimpaCampos()
        {
            BoxNomeLocal.Clear();
            
        }

        /// <summary>
        /// botoes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Editar_Local_Click(object sender, RoutedEventArgs e)
        {
            EditarLocal();
        }

        private void Excluir_Local_Click(object sender, RoutedEventArgs e)
        {
            EditarLocal();
        }

        private void Pesquisar_Local_Click(object sender, RoutedEventArgs e)
        {
            PesquisarLocalPorNome();
        }
        //carega a lista
        private void DgDados_Loaded(object sended, RoutedEventArgs e)
        {
            this.ListagemLocal();
        }

        //carrega objeto selecionado para os textbox
        private void DgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EnderecoController endControl = new EnderecoController();
            if (DgDados.SelectedIndex >= 0)
            {
                Local lc = (Local)DgDados.SelectedItem;
                Endereco end = endControl.PesquisarPorID(lc.EnderecoID);

                TxtLocalID.Text = lc.LocalID.ToString();
                BoxNomeLocal.Text = lc.NomeLocal;               
                CheckBoxDomingo.IsChecked = lc.Domingo;
                CheckBoxSegunda.IsChecked = lc.Segunda;
                CheckBoxTerca.IsChecked = lc.Terca;
                CheckBoxQuarta.IsChecked = lc.Quarta;
                CheckBoxQuinta.IsChecked = lc.Quinta;
                CheckBoxSexta.IsChecked = lc.Sexta;
                CheckBoxSabado.IsChecked = lc.Sabado;

                TxtEnderecoID.Text = end.EnderecoID.ToString();
                BoxCepLocal.Text = end.Cep;
                BoxRuaLocal.Text = end.Rua;
                BoxNumeroLocal.Text = end.Numero.ToString();
                BoxComplementoLocal.Text = end.Complemento;
                BoxCidadeLocal.Text = end.Cidade;
                ComboBoxEstado.Text = end.Uf;
            

            TimePickerHInicioLocal.SelectedTime = lc.HrInicio;
                TimePickerHFimLocal.SelectedTime = lc.HrFim;
            }
            else
            {
                MessageBox.Show("Local vazio");
            }
        }
    }
}

