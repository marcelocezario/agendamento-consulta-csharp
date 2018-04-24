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
            CadastrarPaciente = 1,
            CadastrarProfissional = 2,
            CadastrarLocal = 3,

            ListarPacientes = 6,
            ListarProfissionais = 7,
            ListarLocais = 8,

            Sair = 10
        }

        private static OpcoesMenuPrincipal Menu()
        {
            Console.WriteLine("1 - Cadastrar Paciente");
            Console.WriteLine("2 - Cadastrar Profissional");
            Console.WriteLine("3 - Cadastrar Local");

            Console.WriteLine("6 - Listar Pacientes");
            Console.WriteLine("7 - Listar Profissionais");
            Console.WriteLine("8 - Listar Locais");

            Console.WriteLine("");
            Console.WriteLine("10 - Sair");
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
                    case OpcoesMenuPrincipal.CadastrarPaciente:
                        IncluirPaciente();
                        break;

                    case OpcoesMenuPrincipal.CadastrarProfissional:
                        IncluirProfissional();
                        break;

                    case OpcoesMenuPrincipal.CadastrarLocal:
                        IncluirLocal();
                        break;

                    case OpcoesMenuPrincipal.ListarPacientes:
                        ListarPacientes();
                        break;

                    case OpcoesMenuPrincipal.ListarProfissionais:
                        ListarProfissionais();
                        break;

                    case OpcoesMenuPrincipal.ListarLocais:

                        break;


                    default:
                        break;
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opcaoDigitada != OpcoesMenuPrincipal.Sair);













            Console.ReadKey();
        }

        private static void IncluirPaciente()
        {
            PacienteController pc = new PacienteController();

            Paciente paciente = new Paciente();

            paciente.Nome = "Teste";
            paciente.Celular = "4199-9999999";
            paciente.Email = "teste@testando.com.br";
            paciente.Rg = "123456789";
            paciente.Cpf = "123.456.789-09";
            paciente.DtNascimento = new DateTime(1991, 04, 12, 22, 00, 00);

            pc.SalvarPaciente(paciente);
        }

        private static void IncluirLocal()
        {
            LocalController lc = new LocalController();
            EnderecoController ec = new EnderecoController();

            Local local = new Local();
            local.NomeLocal = "Teste";
            local.Domingo = true;
            local.Segunda = true;
            local.Terca = true;
            local.Quarta = true;
            local.Quinta = true;
            local.Sexta = true;
            local.Sabado = true;
            local.HrInicio = new DateTime(2018, 04, 23, 16, 00, 00);
            local.HrFim = new DateTime(2018, 04, 23, 16, 30, 00);

            Endereco endereco = new Endereco();
            endereco.Cep = "81820000";
            endereco.Rua = "Cid Marcondes";
            endereco.Numero = 222;
            endereco.Complemento = "casa";
            endereco.Cidade = "Curitiba";
            endereco.Uf = "Pr";

            ec.SalvarEndereco(endereco);
            local._Endereco = endereco;
            local.EnderecoID = endereco.EnderecoID;
        }

        private static void IncluirProfissional()
        {
            ProfissionalController pc = new ProfissionalController();

            Profissional profissional = new Profissional();

            profissional.Nome = "Profissional";
            profissional.Celular = "4199-9999999";
            profissional.Email = "teste@testando.com.br";
            profissional.Rg = "123456789";
            profissional.Cpf = "123.456.789-09";
            profissional.DtNascimento = new DateTime(1991, 04, 12, 22, 00, 00);
            profissional.ResgistroProfissional = "123456789";
            profissional.Especialidade = "Psicologo";
            profissional.Domingo = true;
            profissional.Segunda = true;
            profissional.Terca = true;
            profissional.Quarta = true;
            profissional.Quinta = true;
            profissional.Sexta = true;
            profissional.Sabado = true;
            profissional.HrInicio = new DateTime(2018, 04, 23, 16, 00, 00);
            profissional.HrFim = new DateTime(2018, 04, 23, 16, 30, 00);

            pc.SalvarProfissional(profissional);
        }

        private static void ListarPacientes()
        {
            PacienteController pc = new PacienteController();

            foreach (Paciente paciente in pc.ListarPacientes())
            {
                Console.WriteLine("ID.............:" + paciente.ID);
                Console.WriteLine("Nome...........:" + paciente.Nome);
                Console.WriteLine("Email..........:" + paciente.Email);
                Console.WriteLine("CPF............:" + paciente.Cpf);
                Console.WriteLine("RG.............:" + paciente.Rg);
                Console.WriteLine("Data Nascimento:" + paciente.DtNascimento);
                Console.WriteLine("");
            }
        }

        private static void ListarProfissionais()
        {
            ProfissionalController pc = new ProfissionalController();

            foreach (Profissional profissional in pc.ListarProfissionais())
            {
                Console.WriteLine("ID.............:" + profissional.ID);
                Console.WriteLine("Nome...........:" + profissional.Nome);
                Console.WriteLine("Email..........:" + profissional.Email);
                Console.WriteLine("CPF............:" + profissional.Cpf);
                Console.WriteLine("RG.............:" + profissional.Rg);
                Console.WriteLine("Data Nascimento:" + profissional.DtNascimento);
                Console.WriteLine("CRM............:" + profissional.ResgistroProfissional);
                Console.WriteLine("Especialidade..:" + profissional.Especialidade);
                Console.WriteLine("Domingo........:" + profissional.Domingo);
                Console.WriteLine("Segunda........:" + profissional.Segunda);
                Console.WriteLine("Terça..........:" + profissional.Terca);
                Console.WriteLine("Quarta.........:" + profissional.Quarta);
                Console.WriteLine("Quinta.........:" + profissional.Quinta);
                Console.WriteLine("Sexta..........:" + profissional.Sexta);
                Console.WriteLine("Sábado.........:" + profissional.Sabado);
                Console.WriteLine("Horário inicio.:" + profissional.HrInicio.TimeOfDay);
                Console.WriteLine("Horário final..:" + profissional.HrFim.TimeOfDay);
                Console.WriteLine("");
            }
        }

        private static void ListarLocais()
        {
            LocalController lc = new LocalController();

            foreach (Local local in lc.ListarLocais())
            {
                Console.WriteLine("ID.............:" + local.LocalID);
                Console.WriteLine("Nome...........:" + local.NomeLocal);
                Console.WriteLine("Domingo........:" + local.Domingo);
                Console.WriteLine("Segunda........:" + local.Segunda);
                Console.WriteLine("Terça..........:" + local.Terca);
                Console.WriteLine("Quarta.........:" + local.Quarta);
                Console.WriteLine("Quinta.........:" + local.Quinta);
                Console.WriteLine("Sexta..........:" + local.Sexta);
                Console.WriteLine("Sábado.........:" + local.Sabado);
                Console.WriteLine("Horário inicio.:" + local.HrInicio.TimeOfDay);
                Console.WriteLine("Horário final..:" + local.HrFim.TimeOfDay);
            }
        }
    }
}
