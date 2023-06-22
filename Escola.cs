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

		public void SalvarDados(){
			File.WriteAllText("Alunos.json", JsonConvert.SerializeObject(Alunos));
			File.WriteAllText("Professores.json", JsonConvert.SerializeObject(Professores));
			File.WriteAllText("Turmas.json", JsonConvert.SerializeObject(Turmas));
			File.WriteAllText("Materias.json", JsonConvert.SerializeObject(Materias));
	   }
	   
	   public void CarregarDados()
	   {
			if(File.Exists("Alunos.json"))
			{
				Alunos = JsonConvert.DeserializeObject<List<Aluno>>(File.ReadAllText("Alunos.json"));
			}
			
			if(File.Exists("Professores.json"))
			{
				Professores = JsonConvert.DeserializeObject<List<Professor>>(File.ReadAllText("Professores.json"));
			}
			
			if(File.Exists("Turmas.json"))
			{
				Turmas = JsonConvert.DeserializeObject<List<Turma>>(File.ReadAllText("Turmas.json"));
			}
			
			if(File.Exists("Materias.json"))
			{
				Materias = JsonConvert.DeserializeObject<List<Materia>>(File.ReadAllText("Materias.json"));
			}
			
	   }
	}
}