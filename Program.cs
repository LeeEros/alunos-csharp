using System;

namespace Escola{
	class Program{
		static void Main(string[] args){
			Escola escola = new Escola();
			escola.CarregarDados();
			
			int opcao;
			
			do{
				Console.Clear();
				Console.WriteLine("Bem-vindo ao sistema");
				Console.WriteLine("Selecione uma opção:");
				Console.WriteLine("1 - Cadastro");
				Console.WriteLine("2 - Consultas");
				Console.WriteLine("3-Alterações");
				Console.WriteLine("0 - Sair");

				int.TryParse(Console.ReadLine(), out opcao);

				switch (opcao){
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
						escola.SalvarDados();
						break;
					default:
						Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
						Console.ReadKey();
					break;
				}
			} while (opcao != 0);
		}

		static void Cadastros(Escola escola){
			Console.Clear();
			Console.WriteLine("Selecione uma opção de cadastro:");
            Console.WriteLine("1 - Cadastrar Aluno");  
            Console.WriteLine("2 - Cadastrar Professor");
			Console.WriteLine("2 - Cadastrar Matéria");  
			Console.WriteLine("2 - Cadastrar Turma");        
            Console.WriteLine("0 - Voltar"); 

			int.TryParse(Console.ReadLine(), out int opcao);

			switch (opcao){
				case 1:
				  Console.Clear();
				  Console.WriteLine("Cadastro de aluno(a):");
				  Console.WriteLine("Nome Completo: ");
				  string nomeAluno = Console.ReadLine();
				  Console.WriteLine("Data de Nascimento(AAAA-MM-DD): ");
				  DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento);
				  Console.WriteLine("Email Aluno: ");
				  string emailAluno = Console.ReadLine();
				  
				  Aluno novoAluno = new Aluno{MatriculaAluno = escola.Alunos.Count + 1, Nome = nomeAluno, DataNascimento = dataNascimento, EmailAluno = emailAluno};
				  escola.Alunos.Add(novoAluno);
				  escola.SalvarDados();
				  Console.WriteLine("Aluno Cadastrado com Sucesso!");
				  Console.ReadKey();
			    break;

				case 2:
				  Console.Clear();
				  Console.WriteLine("Cadastro de Professor:");
				  Console.WriteLine("Nome Completo: ");
				  string nomeProf = Console.ReadLine();
				  Console.WriteLine("Data de Nascimento(AAAA-MM-DD): ");
				  DateTime.TryParse(Console.ReadLine(), out DateTime dataNasc);
				  Console.WriteLine("Fromação: ");
				  string formacao = Console.ReadLine();
				  Console.WriteLine("Email Institucional: ");
				  string emailProf = Console.ReadLine();
				  
				  Professor novoProf = new Professor{MatriculaProfessor = escola.Professores.Count + 1, Nome = nomeProf, DataNascimento = dataNasc, Formacao = formacao ,EmailInstitucional = emailProf};
				  escola.Professores.Add(novoProf);
				  escola.SalvarDados();
				  Console.WriteLine("Professor Cadastrado com Sucesso!");
				  Console.ReadKey();
			    break;

				case 3:
				  Console.Clear();
				  Console.WriteLine("Cadastro de Matéria:");
				  Console.WriteLine("Nome Matéria: ");
				  string nomeMateria = Console.ReadLine();
				  Console.WriteLine("Matricula Professor Responsavel: ");
				  int matProf = Convert.ToInt32(Console.ReadLine());
							  
				  Materia novaMat = new Materia{IdMateira = escola.Materias.Count + 1, NomeMateria = nomeMateria, ProfessorResposavel = matProf};
				  escola.Materias.Add(novaMat);
				  escola.SalvarDados();
				  Console.WriteLine("Matéria cadastrada com Sucesso!");
				  Console.ReadKey();
			    break;

				case 4:
				  Console.Clear();
				  Console.WriteLine("Cadastro de Turma:");
				  Console.WriteLine("Nome Turma: ");
				  string nomeTurma = Console.ReadLine();
				  Console.WriteLine("Número da Sala: ");
				  int numSala = Convert.ToInt32(Console.ReadLine());		  
				
							  
				  Turma novaTuma = new Turma{IDturma = escola.Turmas.Count + 1, NomeTurma = nomeTurma, NumeroSala = numSala};
				  escola.Turmas.Add(novaTuma);
				  escola.SalvarDados();
				  Console.WriteLine("Turma cadastrada com Sucesso!");
				  Console.ReadKey();
			    break;

				case 0:
                 Console.WriteLine("Voltando...");   
                 Console.ReadKey();
                 break;
			}
		}

		static void Consultas(Escola escola){
		}

		static void Alteracoes(Escola escola){

		}
	}
}