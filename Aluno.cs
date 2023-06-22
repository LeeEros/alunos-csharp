using System;

namespace Escola{
	public class Aluno : Pessoa
	{
		public int MatriculaAluno{get; set;}
		public string EmailAluno{get; set;}

		public int Tumra{get; set;}

		 public override void ExibirInformacoes(){
            base.ExibirInformacoes();
        }
	}
}