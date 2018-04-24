using System.Data.Entity;

namespace Model.DAL
{


    //erro aqui para não gerar o banco de dados
    public class Contexto : DbContext
    {
        public Contexto() : base("strConn")
        {
            Database.SetInitializer(
               new DropCreateDatabaseIfModelChanges<Contexto>()
               );
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Pessoa>()
            //    .HasOptional<Endereco>(p => p._Endereco)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);
            //
            //modelBuilder.Entity<Local>()
            //    .HasOptional<Endereco>(l => l._Endereco)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);
            //
            //modelBuilder.Entity<Pessoa>()
            //    .HasOptional<Endereco>(p => p._Endereco)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);
            //base.OnModelCreating(modelBuilder);

        }
    }
}
