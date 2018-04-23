using Model;
using System.Linq;
using System.Data;

namespace Controller
{
    public class AgendamentoController
    {
        public void IncluirAgendamento (Agendamento agendamento)
        {
            ContextoSingleton.Instancia.Agendamentos.Add(agendamento);
            ContextoSingleton.Instancia.SaveChanges();
        }

        public void ExcluirAgendamento (int idAgendamento)
        {
            Agendamento a = ContextoSingleton.Instancia.Agendamentos.Find(idAgendamento);

            ContextoSingleton.Instancia.Entry(a).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();

        }

        public Agendamento ListarAgendamento(DataSetDateTime dia)
        {
            var pr = from x in ContextoSingleton.Instancia.Agendamentos
                     where x.DiaMarcado.Equals(dia)
                     select x;

            if (pr != null)
                return pr.FirstOrDefault();
            else
                return null;
        }

        public void EditarAgendamento (int idAgendamento, Agendamento novoAgendamento)
        {

        }

    }
}
