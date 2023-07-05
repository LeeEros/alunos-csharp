using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Escola {
    public class Turma {
        public int Idturma {
            get;
            set;
        }
        public string NomeTurma {
            get;
            set;
        }

        public int NumeroSala {
            get;
            set;
        }

        public List < Materia > GradeTurma = new List < Materia > ();
        public List < Aluno > AlunosTurma = new List < Aluno > ();

        public void MostrarAlunos() {
            if (AlunosTurma == null || AlunosTurma.Count < 1) {
                Console.WriteLine("A turma não possuí alunos!");
                return;
            } else {
                Console.WriteLine("Alunos da Turma:");
                Console.WriteLine("{0,-10} {1,-30}", "Id Aluno", "Nome Aluno");
                foreach(var aluno in AlunosTurma) {
                    Console.WriteLine("{0,-10} {1,-30}", aluno.MatriculaAluno, aluno.Nome);
                }
            }
        }

        public void MostrarGrade() {
            if (GradeTurma == null || GradeTurma.Count < 1) {
                Console.WriteLine("A turma não possuí grade!");
                return;
            } else {
                Console.WriteLine("Grade da Turma:");
                Console.WriteLine("{0,-10} {1,-30} {2,-30}", "Id Materia", "Nome Materia", "Nome Professor");
                foreach(var materia in GradeTurma) {
                    Console.WriteLine("{0,-10} {1,-30} {2,-30}", materia.IdMateria, materia.NomeMateria, materia.ProfessorResposavel.Nome);
                }
            }
        }
    }

}