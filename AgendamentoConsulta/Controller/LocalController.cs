using System.Collections.Generic;
using Model;
using Model.DAL;
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

        public void ExcluirLocal(int idLocal)
        {
            Local p = ContextoSingleton.Instancia.Locais.Find(idLocal);

            ContextoSingleton.Instancia.Entry(p).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();
        }

        public Local PesquisarPorID(int idLocal)
        {
            return ContextoSingleton.Instancia.Locais.Find(idLocal);
        }

        public List<Local> ListarLocais()
        {
            return null;
        }
    }
}
