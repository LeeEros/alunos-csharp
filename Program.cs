using System;

namespace Escola {
    class Program {
        static void Main(string[] args) {
            Escola escola = new Escola();
            escola.CarregarDados();

            int opcao;

            do {
                Console.Clear();
                Console.WriteLine("Bem-vindo ao sistema");
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Cadastro");
                Console.WriteLine("2 - Consultas");
                Console.WriteLine("3 - Alterações");
                Console.WriteLine("0 - Sair");

                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao) {
                case 1:
                    Cadastros(escola);
                    break;
                case 2:
                    Consultas(escola);
                    break;
                case 3:
                    Alteracoes(escola);
                    break;
                case 0:
                    Console.WriteLine("Encerrando o sistema...");
                    break;
                default:
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                }
            } while (opcao != 0);
        }

        static void Cadastros(Escola escola) {
            Console.Clear();
            Console.WriteLine("Selecione uma opção de cadastro:");
            Console.WriteLine("1 - Cadastrar Aluno");
            Console.WriteLine("2 - Cadastrar Professor");
            Console.WriteLine("3 - Cadastrar Matéria");
            Console.WriteLine("4 - Cadastrar Turma");
            Console.WriteLine("0 - Voltar");

            int.TryParse(Console.ReadLine(), out int opcao);

            switch (opcao) {
            case 1:
                escola.CadastrarAluno(escola);
                break;

            case 2:
                escola.CadastrarProfessor(escola);
                break;

            case 3:
                escola.CadastrarMateria(escola);
                break;

            case 4:
                escola.CadastrarTurmas(escola);
                break;

            case 0:
                Console.WriteLine("Voltando...");
                break;

            default:
                Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }
        }

        static void Consultas(Escola escola) {
            Console.Clear();
            Console.WriteLine("Selecione uma opção de cadastro:");
            Console.WriteLine("1 - Consultar Aluno");
            Console.WriteLine("2 - Consultar Professor");
            Console.WriteLine("3 - Consultar Matéria");
            Console.WriteLine("4 - Consultar Turma");
            Console.WriteLine("0 - Voltar");

            int.TryParse(Console.ReadLine(), out int opcao);

            switch (opcao) {
            case 1:
                escola.ConsultarAluno(escola);
                break;

            case 2:
                escola.ConsultarProfessor(escola);
                break;

            case 3:
                escola.ConsultarMateria(escola);
                break;

            case 4:
                escola.ConsultarTurma(escola);
                break;

            case 0:
                Console.WriteLine("Voltando...");
                Console.ReadKey();
                break;

            default:
                Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }

        }

        static void Alteracoes(Escola escola) {
            Console.Clear();
            Console.WriteLine("Selecione uma opção de alteração:");
            Console.WriteLine("1 - Vincular Aluno a turma");
            Console.WriteLine("0 - Voltar");

            int.TryParse(Console.ReadLine(), out int opcao);

            switch (opcao) {
            case 1:
                escola.VincularAlunoATurma(escola);
                break;

            case 0:
                Console.WriteLine("Voltando...");
                Console.ReadKey();
                break;

            default:
                Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }
        }
    }
}