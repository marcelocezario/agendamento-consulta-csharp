using Model;
using Model.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class EnderecoController
    {
        public void SalvarEndereco (Endereco endereco)
        {
            ContextoSingleton.Instancia.Enderecos.Add(endereco);
            ContextoSingleton.Instancia.SaveChanges();
        }

        public Endereco PesquisarPorCep(string cep)
        {
            var e = from x in ContextoSingleton.Instancia.Enderecos
                    where x.Cep.ToLower().Contains(cep.Trim().ToLower())
                    select x;

            if (e != null)
                return e.FirstOrDefault();
            else
                return null;
        }

        public void EditarEndereco (int idEndereco, Endereco enderecoEditado)
        {

          
            
        }
        public Endereco PesquisarPorID(int idEndereco)
        {
            return ContextoSingleton.Instancia.Enderecos.Find(idEndereco);
        }

        public void ExcluirEndereco (int idEndereco)
        {
            Endereco e = ContextoSingleton.Instancia.Enderecos.Find(idEndereco);

            ContextoSingleton.Instancia.Entry(e).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();
        }

        public List<Endereco> ListarEnderecos()
        {
            return ContextoSingleton.Instancia.Enderecos.ToList();
        }
    }
}
