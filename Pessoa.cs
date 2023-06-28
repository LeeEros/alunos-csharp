using System;

namespace Escola{
    public abstract class Pessoa : IPessoa{
        public string Nome{ get; set;}
        public DateTime DataNascimento{ get; set;}

        public virtual void ExibirInformacoes(){
            Console.WriteLine($"Nome: {Nome}\n Data de Nascimento: {DataNascimento.ToShortDateString()}");
        } 
   }
}