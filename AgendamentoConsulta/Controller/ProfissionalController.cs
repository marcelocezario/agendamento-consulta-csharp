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

        public bool EditarProfissional(int idProfissional, Profissional profissionalEditado)
        {
            Profissional profissionalEditar = PesquisarPorID(idProfissional);

            if (profissionalEditar != null)
            {
                profissionalEditar.Nome = profissionalEditado.Nome;
                profissionalEditar.Celular = profissionalEditado.Celular;
                profissionalEditar.Email = profissionalEditado.Email;
                profissionalEditar.Cpf = profissionalEditado.Cpf;
                profissionalEditar.DtNascimento = profissionalEditado.DtNascimento;
                profissionalEditar.ResgistroProfissional = profissionalEditado.ResgistroProfissional;
                profissionalEditar.Domingo = profissionalEditado.Domingo;
                profissionalEditar.Segunda = profissionalEditado.Segunda;
                profissionalEditar.Terca = profissionalEditado.Terca;
                profissionalEditar.Quarta = profissionalEditado.Quarta;
                profissionalEditar.Quinta = profissionalEditado.Quinta;
                profissionalEditar.Sexta = profissionalEditado.Sexta;
                profissionalEditar.Sabado = profissionalEditado.Sabado;
                profissionalEditar.HrInicio = profissionalEditado.HrInicio;
                profissionalEditar.HrFim = profissionalEditado.HrFim;

                ContextoSingleton.Instancia.Entry(profissionalEditar).State =
                    System.Data.Entity.EntityState.Modified;

                ContextoSingleton.Instancia.SaveChanges();
            }
            return true;
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

        public bool ExcluirProfissional(int idProfissional)
        {
            Profissional p = ContextoSingleton.Instancia.Profissionais.Find(idProfissional);

            ContextoSingleton.Instancia.Entry(p).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        public List<Profissional> ListarProfissionais()
        {
            return ContextoSingleton.Instancia.Profissionais.ToList();
        }
    }
}
