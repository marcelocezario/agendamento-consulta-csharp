using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Agendamento
    {
        public int AgendamentoID { get; set; }
        public int LocalID { get; set; }
        public int PacienteID { get; set; }
        public int ProfissionalID { get; set; }
        //tempo de cada consulta realizada
        public DateTime TempoConsunta = DateTime.Now.AddMinutes(30);
        public DateTime DiaMarcado { get; set; }
        public DateTime HoraMarcada { get; set; }
}
}
