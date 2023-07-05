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

        public void SalvarDadosTurma() {
            File.WriteAllText(".\\dados\\GradeTurma.json", JsonConvert.SerializeObject(GradeTurma));
        }

        public void CarregarDadosTurma() {
            if (File.Exists(".\\dados\\GradeTurma.json")) {
                GradeTurma = JsonConvert.DeserializeObject < List < Materia >> (File.ReadAllText("\\dados\\GradeTurma.json"));
            }
        }
    }

}