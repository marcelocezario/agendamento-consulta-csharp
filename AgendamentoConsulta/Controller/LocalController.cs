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

        public bool EditarLocal(int idLocal, Local localEditado)
        {
            Local localEditar = PesquisarPorID(idLocal);

            if (localEditar != null)
            {

                localEditar.NomeLocal = localEditado.NomeLocal;
                localEditar.Domingo = localEditado.Domingo;
                localEditar.Segunda = localEditado.Segunda;
                localEditar.Terca = localEditado.Terca;
                localEditar.Quarta = localEditado.Quarta;
                localEditar.Quinta = localEditado.Quinta;
                localEditar.Sexta = localEditado.Sexta;
                localEditar.Sabado = localEditado.Sabado;
                localEditar.HrInicio = localEditado.HrInicio;
                localEditar.HrFim = localEditado.HrFim;
                localEditar.EnderecoID = localEditado.EnderecoID;
                localEditar._Endereco = localEditado._Endereco;


                ContextoSingleton.Instancia.Entry(localEditar).State =
                    System.Data.Entity.EntityState.Modified;

                ContextoSingleton.Instancia.SaveChanges();
                return true;
            }
            return true;

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

        public bool ExcluirLocal(int idLocal)
        {
            Local l = ContextoSingleton.Instancia.Locais.Find(idLocal);

            ContextoSingleton.Instancia.Entry(l).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();
            return true;
        }

        public Local PesquisarPorID(int idLocal)
        {
            return ContextoSingleton.Instancia.Locais.Find(idLocal);
        }

        public List<Local> ListarLocais()
        {
            return ContextoSingleton.Instancia.Locais.ToList();
        }
    }
}
