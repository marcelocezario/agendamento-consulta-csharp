using System;
using Controller;
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
using Model;
using Model.DAL;
using MahApps.Metro.Controls;


namespace AgendamentoConsulta
{

    /// <summary>
    /// Interaction logic for Produto.xaml
    /// </summary>
    public partial class AlterarProfissional : Window
    {
        public AlterarProfissional()
        {
            InitializeComponent();
            ProfissionalController proControl = new ProfissionalController();
            // Inicializa a listagem de Profissional
            DgDados.ItemsSource = proControl.ListarProfissionais();
        }

        //
        private void EditarProfissional()
        {
            ProfissionalController prControl = new ProfissionalController();
            Profissional pr = ContextoSingleton.Instancia.Profissionais.Find(Convert.ToInt32(TxtProfissionalID.Text));

            if (pr != null)
            {
                if (prControl.EditarProfissional(Convert.ToInt32(TxtProfissionalID.Text), pr))
                {
                    ContextoSingleton.Instancia.SaveChanges();
                    this.ListagemProfissional();
                }

            }
            else {
                MessageBox.Show("Profissional vazio");

            }
        }

        private void ExcluirProfissional()
        {
            // Metódo para excluir o insumo no banco
            ProfissionalController  prControl = new ProfissionalController();
           
            Profissional pr = ContextoSingleton.Instancia.Profissionais.Find(Convert.ToInt32(TxtProfissionalID.Text));

            if (pr != null)
            {
                if (prControl.ExcluirProfissional(pr.ID))
                {
                    this.ListagemProfissional(); // Lista os Profissional atualizados
                    this.LimpaCampos(); //  Limpa campos antigos
                }
            }
            else
            {
                MessageBox.Show("Profissional vazio");
            }
        }

        private void PesquisarProfissionalPorNome()
        {
            // Metódo que pesquisa por nome e exibe o campo  buscado
            ProfissionalController prControl = new ProfissionalController();

            try
            {
                var consulta = from c in ContextoSingleton.Instancia.Profissionais
                               where c.Nome.Equals(BoxNomeProfissional.Text)
                               select c;

                DgDados.ItemsSource = consulta.ToList();
            }
            catch { }


        }

        private void ListagemProfissional()
        {
            //Metodo para listar os Profissional no DataGrid
            ProfissionalController prControl = new ProfissionalController();

           DgDados.ItemsSource = prControl.ListarProfissionais();

        }
        private void LimpaCampos()
        {
            txtNome.Clear();
            txtCategoria.Clear();
            txtPrecoCusto.Clear();
            txtMedida.Clear();
            txtEstoque.Clear();

        }

        private void Editar_Profissional_Click(object sender, RoutedEventArgs e)
        {
            EditarProfissional();
        }

        private void Excluir_Profissional_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Pesquisar_Profissional_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DgDados_Loaded(object sended, RoutedEventArgs e)
        {

        }
    }
          
        
        
      
        

        

       

        private void ListagemProfissional_Loaded(object sender; RoutedEventArgs e)
        {
            // Faz o refresh da listagem do Datagrid
            this.ListagemProfissional();
        }

        p

        //--------
        // FUNCÕES
        //--------


        //---------------------------
        // BOTOES CHAMANDO AS FUNÇÕES
        //---------------------------

        private void btnCadastrarInsumo(object sender; RoutedEventArgs e)
        {
            // Recebe os dados do insumo e grava definito no banco
            SalvarInsumo();
            this.ListagemProfissional();
            this.LimpaCampos(); // Limpa os campos das textbox
            MessageBox.Show("Insumo cadastrado !");

        }

        public void btnEditarInsumo(object sender; RoutedEventArgs e)
        {
            EditarInsumo();
        }

        private void btnExcluirInsumo(object sender; RoutedEventArgs e)
        {
            ExcluirProfissional();
        }

        private void btnPesquisarInsumo(object sender; RoutedEventArgs e)
        {
            PesquisarInsumoPorNome();
        }

        //Atualiza a textbox com a linha clicada na listagem
        private void dgDados_MouseDoubleClick(object sender; MouseButtonEventArgs e)
        {
            if (dgDados.SelectedIndex >= 0)
            {
                insumo pr = (insumo)dgDados.SelectedItem;

                txtInsumoID.Text = pr.InsumoID.ToString();
                txtNome.Text = pr.Nome;
                txtCategoria.Text = pr.Categoria;
                txtPrecoCusto.Text = pr.PrecoCusto.ToString();
                txtMedida.Text = pr.Medida;
                txtEstoque.Text = pr.Estoque.ToString();
            }
        }

        //---------------------------
        // BOTOES CHAMANDO AS FUNÇÕES
        //---------------------------
    }
}

}
