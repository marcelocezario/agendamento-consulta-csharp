using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Endereco
    {
        public int IdEndereco { get; set; }

        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

    }
}
