using System.Collections.Generic;
using Model;

namespace Controller
{
    public class PacienteController
    {
        public void SalvarPaciente(Paciente paciente)
        {
            ContextoSingleton.Instancia.Pacientes.Add(paciente);
            ContextoSingleton.Instancia.SaveChanges();
        }

        public void EditarPaciente(int idPaciente, Paciente pacienteEditado)
        {

        }

        public void ExcluirPaciente(int idPaciente)
        {
            Paciente p = ContextoSingleton.Instancia.Pacientes.Find(idPaciente);

            ContextoSingleton.Instancia.Entry(p).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();
        }

        public Paciente PesquisarPorID(int idPaciente)
        {
            return ContextoSingleton.Instancia.Pacientes.Find(idPaciente);
        }

        public List<Paciente> ListarPacientes()
        {
            return null;
        }
    }
}
