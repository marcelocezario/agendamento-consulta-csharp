using AgendamentoConsulta;
using System;

namespace Model
{
    class Profissional : Pessoa 
    {
        public string ResgistroProfissional { get; set; }
        public int DiasSemana { get; set; }
        public DateTime Periodo { get; set; }
    }
}
