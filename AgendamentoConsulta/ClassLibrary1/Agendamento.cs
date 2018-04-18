using System;

namespace Model
{
    public class Agendamento
    {
        //virtual serve para facilitar a visualização do objeto que retorna do banco de dados

        public int AgendamentoID { get; set; }

        public int LocalID { get; set; }
        public virtual Local _Local { get; set; }

        public int PacienteID { get; set; }
        public virtual Paciente _Paciente { get; set; }

        public int ProfissionalID { get; set; }
        public virtual Profissional _Profissional { get; set; }

        //tempo de cada consulta realizada
        public DateTime TempoConsunta = DateTime.Now.AddMinutes(30);
        public DateTime DiaMarcado { get; set; }
        public DateTime HoraMarcada { get; set; }
}
}
