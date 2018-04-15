namespace AgendamentoConsulta
{
    //cria a classe que corresponde as caracteristicas que seram usados como base 
    public abstract class Pessoa
    {
        public int PessoaID { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string Email { get; set; }

        public int EnderecoID { get; set; } 
    }
}
