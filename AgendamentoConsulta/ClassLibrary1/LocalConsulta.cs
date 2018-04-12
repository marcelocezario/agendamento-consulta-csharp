using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class LocalConsulta
    {
        public int IdLocal { get; set; }
        public int DiasConsulta { get; set; }
        public string Periodo { get; set; }
        public DateTime tmpConsulta { get; set; }


        public int EnderecoID { get; set; }
    }
}
