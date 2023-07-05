using System;

namespace Escola{
    public class Professor : Pessoa{
        public int MatriculaProfessor{ get; set;}

        public string Formacao{ get; set;}

        public string EmailInstitucional{get; set;}

        public override void ExibirInformacoes()
        {
            
        }
    }
}