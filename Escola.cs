using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace Escola{
    public class Escola{
        public List<Aluno> Alunos = new List<Aluno>();
		
		public List<Professor> Professores = new List<Professor>();

		public List<Turma> Turmas = new List<Turma>();

		public List<Materia> Materias = new List<Materia>();
    }
}