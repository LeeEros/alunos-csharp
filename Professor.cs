using System;

namespace Escola{
    public class Professor : Pessoa{
        public int MatriculaProfessor{ get; set;}

        public string Formacao{ get; set;}

        public string EmailInstitucional{get; set;}

        public override void ExibirInformacoes()
        {
            int idade = calculaIdade();

            Console.WriteLine("Nome do Professor: " + Nome);
            Console.WriteLine("Data de Nascimento: " + DataNascimento + " - " + idade + " anos");
            Console.WriteLine("Email: " + EmailInstitucional);
            Console.WriteLine("Formacao: " + Formacao);
            Console.WriteLine("Matricula: " + MatriculaProfessor);
        }
    }
}