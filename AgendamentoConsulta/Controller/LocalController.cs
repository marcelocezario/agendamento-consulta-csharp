using System.Collections.Generic;
using Model;
using Model.DAL;
using System.Linq;

namespace Controller

{
    public class LocalController
    {
        public void SalvarLocal(Local local)
        {
            ContextoSingleton.Instancia.Locais.Add(local);
            ContextoSingleton.Instancia.SaveChanges();
        }

        public void EditarLocal(int idLocal, Local localEditado)
        {

        }

        public Local PesquisarPorNome(string nome)
        {
            var l = from x in ContextoSingleton.Instancia.Locais
                    where x.NomeLocal.ToLower().Contains(nome.Trim().ToLower())
                    select x;

            if (l != null)
                return l.FirstOrDefault();
            else
                return null;
        }

        public void ExcluirLocal(int idLocal)
        {
            Local l = ContextoSingleton.Instancia.Locais.Find(idLocal);

            ContextoSingleton.Instancia.Entry(l).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();
        }

        public Local PesquisarPorID(int idLocal)
        {
            return ContextoSingleton.Instancia.Locais.Find(idLocal);
        }

        public List<Local> ListarClientes()
        {
            return ContextoSingleton.Instancia.Locais.ToList();
        }

        public List<Local> ListarLocais()
        {
            return null;
        }
    }
}
