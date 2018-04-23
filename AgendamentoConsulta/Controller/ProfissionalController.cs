using System.Collections.Generic;
using Model.DAL;
using Model;
using System.Linq;

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

        public Profissional PesquisarPorNome(string nome)
        {
            var pr = from x in ContextoSingleton.Instancia.Profissionais
                    where x.Nome.ToLower().Contains(nome.Trim().ToLower())
                    select x;

            if (pr != null)
                return pr.FirstOrDefault();
            else
                return null;
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
            return ContextoSingleton.Instancia.Profissionais.ToList();
        }
    }
}
