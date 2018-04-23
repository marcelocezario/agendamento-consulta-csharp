using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Controller;

namespace AgendamentoConsulta_Console
{
    class Program
    {
        enum OpcoesMenuPrincipal
        {
            ListarPacientes = 1,
            ListarProfissionais = 2,
            Sair = 0
        }

        private static OpcoesMenuPrincipal Menu()
        {
            Console.WriteLine("1 - Listar Pacientes");
            Console.WriteLine("2 - Listar Profissionais");
            Console.WriteLine("");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("");
            Console.WriteLine("Escolha sua opcao e tecle enter: ");
            string opcao = Console.ReadLine();
            return (OpcoesMenuPrincipal)int.Parse(opcao);
        }

        static void Main(string[] args)
        {
            OpcoesMenuPrincipal opcaoDigitada = OpcoesMenuPrincipal.Sair;
            do
            {
                opcaoDigitada = Menu();

                switch (opcaoDigitada)
                {
                    case OpcoesMenuPrincipal.ListarPacientes:
                        PacienteController pc = new PacienteController();
                        foreach (Paciente x in pc.ListarPacientes())
                        {
                            Console.WriteLine(x.Nome);
                            Console.WriteLine("");
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opcaoDigitada != OpcoesMenuPrincipal.Sair);













            Console.ReadKey();
        }
    }
}
