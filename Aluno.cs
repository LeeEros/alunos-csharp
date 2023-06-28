using System;

namespace Escola
{
    public class Aluno : Pessoa
    {
        public int MatriculaAluno { get; set; }
        public string EmailAluno { get; set; }

        public int Turma { get; set; }
    }
}