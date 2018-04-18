using Model;
using System.Collections.Generic;

namespace Controller
{
    public class EnderecoController
    {
        public int SalvarEndereco (Endereco endereco)
        {

            return endereco.EnderecoID;
        }

        public void EditarEndereco (int idEndereco, Endereco enderecoEditado)
        {

        }

        public void ExluirEndereco (int idEndereco)
        {

        }

        public List<Endereco> ListarEnderecos()
        {
            return null;
        }
    }
}
