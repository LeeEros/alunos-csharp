using System;

namespace Escola {
    public class Materia {
        public int IdMateria {
            get;
            set;
        }

        public string NomeMateria {
            get;
            set;
        }

        public Professor ProfessorResposavel {
            get;
            set;
        }

        public List < Turma > obterTurmas(Escola escola) {

            List < Turma > turmas = new List < Turma > ();

            foreach(var turma in escola.Turmas) {
                Materia materiaExisteNaturma = turma.GradeTurma.Find(materia => materia.IdMateria == this.IdMateria);

                if (materiaExisteNaturma != null) {
                    turmas.Add(turma);
                }
            }
            return turmas;
        }

    }
}