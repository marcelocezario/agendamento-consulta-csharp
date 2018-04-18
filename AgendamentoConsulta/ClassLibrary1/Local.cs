using System;

namespace Model
{
    public class Local
    {
        public int LocalID { get; set; }
        //Dias da semana
        public bool Domingo { get; set; }
        public bool Segunda { get; set; }
        public bool Terca { get; set; }
        public bool Quarta { get; set; }
        public bool Quinta { get; set; }
        public bool Sexta { get; set; }
        public bool Sabado { get; set; }

        public DateTime HrInicio { get; set; }
        public DateTime HrFim { get; set; }


        public int EnderecoID { get; set; }
        public virtual Endereco _Endereco { get; set; }
    }
}
