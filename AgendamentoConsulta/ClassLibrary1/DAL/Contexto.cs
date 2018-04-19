using System.Data.Entity;

namespace Model.DAL
{


    //erro aqui para não gerar o banco de dados
    public class Contexto : DbContext
    {
        public Contexto() : base("strConn")
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
