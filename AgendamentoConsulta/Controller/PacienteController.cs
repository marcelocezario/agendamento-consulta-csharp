using System.Collections.Generic;
using Model;
using System.Linq;

namespace Controller
{
    public class PacienteController
    {
        public void SalvarPaciente(Paciente paciente)
        {
            ContextoSingleton.Instancia.Pacientes.Add(paciente);
            ContextoSingleton.Instancia.SaveChanges();
            
        }

        public bool EditarPaciente(int idPaciente, Paciente pacienteEditado)
        {
            Paciente pacienteEditar = PesquisarPorID(idPaciente);

            if (pacienteEditar != null)
            {
                pacienteEditar.Nome = pacienteEditado.Nome;
                pacienteEditar.Celular = pacienteEditado.Celular;
                pacienteEditar.Email = pacienteEditado.Email;
                pacienteEditar.Cpf = pacienteEditado.Cpf;
                pacienteEditar.DtNascimento = pacienteEditado.DtNascimento;

                ContextoSingleton.Instancia.Entry(pacienteEditar).State =
                    System.Data.Entity.EntityState.Modified;

                ContextoSingleton.Instancia.SaveChanges();
                return true;
            }
            return true;
        }

        public Paciente PesquisarPorNome(string nome)
        {
            var c = from x in ContextoSingleton.Instancia.Pacientes
                    where x.Nome.ToLower().Contains(nome.Trim().ToLower())
                    select x;

            if (c != null)
                return c.FirstOrDefault();
            else
                return null;
        }

        public Paciente PesquisarPorID(int idPaciente)
        {
            return ContextoSingleton.Instancia.Pacientes.Find(idPaciente);
        }

        public bool ExcluirPaciente(int idPaciente)
        {
            Paciente p = ContextoSingleton.Instancia.Pacientes.Find(idPaciente);

            ContextoSingleton.Instancia.Entry(p).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }



        public List<Paciente> ListarPacientes()
        {
            return ContextoSingleton.Instancia.Pacientes.ToList();
        }
    }
}
