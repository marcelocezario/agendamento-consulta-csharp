using Model;
using Model.DAL;
using System.Collections.Generic;

namespace Controller
{
    public class EnderecoController
    {
        public int SalvarEndereco (Endereco endereco)
        {
            ContextoSingleton.Instancia.Enderecos.Add(endereco);
            ContextoSingleton.Instancia.SaveChanges();
            return endereco.EnderecoID;
        }

        public void EditarEndereco (int idEndereco, Endereco enderecoEditado)
        {
          
            
        }
        public Endereco PesquisarPorID(int idEndereco)
        {
            return ContextoSingleton.Instancia.Enderecos.Find(idEndereco);
        }

        public void ExluirEndereco (int idEndereco)
        {
            Endereco e = ContextoSingleton.Instancia.Enderecos.Find(idEndereco);

            ContextoSingleton.Instancia.Entry(e).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();
        }

    }
}
