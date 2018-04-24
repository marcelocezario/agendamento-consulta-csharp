﻿using System;

namespace Model
{
    //cria a classe que corresponde as caracteristicas que seram usados como base 
    public abstract class Pessoa
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime DtNascimento { get; set; } 

        public int? EnderecoID { get; set; }
        public virtual Endereco  _Endereco { get; set; }
    }
}
