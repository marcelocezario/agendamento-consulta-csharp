using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Model.dao
{
    //erro aqui para não gerar o banco de dados
    public class Contexto : DbCont
    {
        public Contexto() : base("stringConn")
        {
        }

        public DbSet<Local>  { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Entregador> Entregadores { get; set; }

    
    }
}
