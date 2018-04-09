using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public abstract class Endereco
    {
        public int IdEndereco { get; set; }

        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemeto { get; set; }
        
    }
}
