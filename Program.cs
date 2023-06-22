using System;

namespace Escola{
	class Program{
		static void Main(string[] args){
			Escola escola = new Escola();
			escola.CarregarDados();
			
			int opcao;
			
			do
			{
				Console.Clear();
				Console.WriteLine("Bem-vindo ao sistema");
				Console.WriteLine("Selecione uma opção:");
				Console.WriteLine("1 - Cadastro");
				Console.WriteLine("2 - Consultas");
				Console.WriteLine("3 - Empréstimos");
				Console.WriteLine("4 - Devoluções");
				Console.WriteLine("0 - Sair");

				int.TryParse(Console.ReadLine(), out opcao);

				switch (opcao)
				{
					case 1:
						Cadastro(biblioteca);
						break;
					case 2:
						Consultas(biblioteca);
						break;
					case 3:
						Emprestimos(biblioteca);
						break;
					case 4:
						Devolucoes(biblioteca);
						break;
					case 0:
						Console.WriteLine("Encerrando o sistema...");
						biblioteca.SalvarDados();
						break;
					default:
						Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
						Console.ReadKey();
						break;
				}
			} while (opcao != 0);
			
		}
	}
}