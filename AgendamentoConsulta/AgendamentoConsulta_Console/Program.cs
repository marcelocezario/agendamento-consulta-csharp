using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace AgendamentoConsulta_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("teste");

            DateTime dia = DateTime.Now;

            DateTime dia2 = new DateTime (2018, 04, 30, 10, 30, 00);

            DateTime dia3 = dia;

            Console.WriteLine(DateTime.Compare(dia, dia2));

            Console.WriteLine(DateTime.Compare(dia, dia3));

            DateTime TempoConsulta = DateTime.Now.AddMinutes(30);


            if (dia.TimeOfDay > dia2.TimeOfDay)
                Console.WriteLine("horário de agora é maior");
            else
            {
                if (dia.TimeOfDay == dia2.TimeOfDay)
                    Console.WriteLine("horário de agora é igual");
                else
                    Console.WriteLine("horário de agora é menor");
            }



            Console.WriteLine(dia.TimeOfDay);











            Console.ReadKey();
    }
}
}
