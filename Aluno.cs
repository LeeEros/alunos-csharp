using System;

namespace Escola {
    public class Aluno: Pessoa {
        public int MatriculaAluno {
            get;
            set;
        }
        public string EmailAluno {
            get;
            set;
        }

        public override void ExibirInformacoes() {
            int idade = calculaIdade();

            Console.WriteLine("Nome do Aluno: " + Nome);
            Console.WriteLine("Data de Nascimento: " + DataNascimento + " - " + idade + " anos");
            Console.WriteLine("Email: " + EmailAluno);
            Console.WriteLine("Matricula: " + MatriculaAluno);

        }
    }
}