using System;

namespace Escola {
    public class Professor: Pessoa {
        public int MatriculaProfessor {
            get;
            private set;
        }

        public string Formacao {
            get;
            private set;
        }

        public string EmailInstitucional {
            get;
            private set;
        }

        public Professor(string nome, DateTime dataNascimento, int matriculaProfessor, string formacao, string emailInstitucional) : base(nome, dataNascimento) {
            this.MatriculaProfessor = matriculaProfessor;
            this.Formacao = formacao;
            this.EmailInstitucional = emailInstitucional;
        }

        public override void ExibirInformacoes() {
            int idade = calculaIdade();

            Console.WriteLine("Nome do Professor: " + Nome);
            Console.WriteLine("Data de Nascimento: " + DataNascimento + " - " + idade + " anos");
            Console.WriteLine("Email: " + EmailInstitucional);
            Console.WriteLine("Formacao: " + Formacao);
            Console.WriteLine("Matricula: " + MatriculaProfessor);
        }
    }
}