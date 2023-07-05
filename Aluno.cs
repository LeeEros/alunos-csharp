using System;

namespace Escola {
    public class Aluno: Pessoa {
        public int MatriculaAluno {
            get;
            private set;
        }
        public string EmailAluno {
            get;
            private set;
        }

        public Aluno(string nome, DateTime dataNascimento, int matriculaAluno, string emailAluno): base(nome, dataNascimento) {
            this.MatriculaAluno = matriculaAluno;
            this.EmailAluno = emailAluno;
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