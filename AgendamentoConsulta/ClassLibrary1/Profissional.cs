using AgendamentoConsulta;
using System;

namespace Model
{
    class Profissional : Pessoa 
    {
        public string ResgistroProfissional { get; set; }
        public int DiasConsulta { get; set; }
        public DateTime HorarioAtendimento { get; set; }
    }
}
