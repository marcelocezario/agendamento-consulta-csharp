using Model;

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

        public void EditarAgendamento (int idAgendamento, Agendamento novoAgendamento)
        {

        }

    }
}
