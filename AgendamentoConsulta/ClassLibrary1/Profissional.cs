using AgendamentoConsulta;
using System;

namespace Model
{
    class Profissional : Pessoa 
    {
        public string ResgistroProfissional { get; set; }
        //Dias da semana
        public bool Domingo { get; set; }
        public bool Segunda { get; set; }
        public bool Terca { get; set; }
        public bool Quarta { get; set; }
        public bool Quinta { get; set; }
        public bool Sexta { get; set; }
        public bool Sabado { get; set; }
        public DateTime Periodo { get; set; }
    }
}
