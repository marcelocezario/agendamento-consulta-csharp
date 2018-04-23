using System.Collections.Generic;
using Model.DAL;
using Model;

namespace Controller
{
    public class ProfissionalController
    {
        public void SalvarProfissional(Profissional profissional)
        {
            ContextoSingleton.Instancia.Profissionais.Add(profissional);
            ContextoSingleton.Instancia.SaveChanges();
        }

        public void EditarProfissional(int idProfissional, Profissional profissionalEditado)
        {

        }

        public Profissional PesquisarPorID(int idProfissional)
        {
            return ContextoSingleton.Instancia.Profissionais.Find(idProfissional);
        }

        public void ExcluirProfissional(int idProfissional)
        {
            Profissional p = ContextoSingleton.Instancia.Profissionais.Find(idProfissional);

            ContextoSingleton.Instancia.Entry(p).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();
        }

        public List<Profissional> ListarProfissionais()
        {
            return null;
        }
    }
}
