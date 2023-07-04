using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace Escola
{
    public class Escola
    {
        public List<Aluno> Alunos = new List<Aluno>();

        public List<Professor> Professores = new List<Professor>();

        public List<Turma> Turmas = new List<Turma>();

        public List<Materia> Materias = new List<Materia>();

        public void SalvarDados()
        {
            File.WriteAllText("Alunos.json", JsonConvert.SerializeObject(Alunos));
            File.WriteAllText("Professores.json", JsonConvert.SerializeObject(Professores));
            File.WriteAllText("Turmas.json", JsonConvert.SerializeObject(Turmas));
            File.WriteAllText("Materias.json", JsonConvert.SerializeObject(Materias));
        }

        public void CarregarDados()
        {
            if (File.Exists("Alunos.json"))
            {
                Alunos = JsonConvert.DeserializeObject<List<Aluno>>(File.ReadAllText("Alunos.json"));
            }

            if (File.Exists("Professores.json"))
            {
                Professores = JsonConvert.DeserializeObject<List<Professor>>(File.ReadAllText("Professores.json"));
            }

            if (File.Exists("Turmas.json"))
            {
                Turmas = JsonConvert.DeserializeObject<List<Turma>>(File.ReadAllText("Turmas.json"));
            }

            if (File.Exists("Materias.json"))
            {
                Materias = JsonConvert.DeserializeObject<List<Materia>>(File.ReadAllText("Materias.json"));
            }
        }


        public void CadastrarAluno(Escola escola)
        {

            string emailAluno;
            DateTime dataNascimento;
            string nomeAluno;
            Console.Clear();
            Console.WriteLine("Cadastro de aluno(a):");

            do {
            Console.WriteLine("Nome Completo: ");
            nomeAluno = Console.ReadLine();
            nomeAluno = nomeAluno.Trim();
            }while (nomeAluno == null || nomeAluno == "");

            do {
            Console.WriteLine("Data de Nascimento(AAAA-MM-DD): ");
            DateTime.TryParse(Console.ReadLine(), out dataNascimento);
            }while (dataNascimento == new DateTime());

            do {

            Console.WriteLine("Email Aluno: ");
            emailAluno = Console.ReadLine();
            emailAluno = emailAluno.Trim();
            } while (emailAluno == null || emailAluno == "");


            Aluno novoAluno = new Aluno { MatriculaAluno = escola.Alunos.Count + 1, Nome = nomeAluno, DataNascimento = dataNascimento, EmailAluno = emailAluno};
            escola.Alunos.Add(novoAluno);

            escola.SalvarDados();
            Console.WriteLine("Aluno Cadastrado com Sucesso!");
            Console.ReadKey();
        }

        public void CadastrarProfessor(Escola escola)
        {
            string nomeProf;
            DateTime dataNasc;
            string formacao;
            string emailProf;

            Console.Clear();
            Console.WriteLine("Cadastro de Professor:");
            do {
            Console.WriteLine("Nome Completo: ");
            nomeProf = Console.ReadLine();
            nomeProf = nomeProf.Trim();
            } while (nomeProf == null || nomeProf == "");

            do {
            Console.WriteLine("Data de Nascimento(AAAA-MM-DD): ");
            DateTime.TryParse(Console.ReadLine(), out dataNasc);
            } while (dataNasc == new DateTime());

            do {
            Console.WriteLine("Formação: ");
            formacao = Console.ReadLine().Trim();
            formacao = formacao.Trim();
            } while (formacao == null || formacao == "");

            do {
            Console.WriteLine("Email Institucional: ");
            emailProf = Console.ReadLine();
            emailProf = emailProf.Trim();
            }while (emailProf == null || emailProf == "");

            Professor novoProf = new Professor { MatriculaProfessor = escola.Professores.Count + 1, Nome = nomeProf, DataNascimento = dataNasc, Formacao = formacao, EmailInstitucional = emailProf };
            escola.Professores.Add(novoProf);
            escola.SalvarDados();
            Console.WriteLine("Professor Cadastrado com Sucesso!");
            Console.ReadKey();
        }

        public void CadastrarMateria(Escola escola)
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Matéria:");
            Console.WriteLine("Nome Matéria: ");
            string nomeMateria = Console.ReadLine();

            int cond = 0;
            int IDprof;

            do
            {
                Console.WriteLine("ID da Turma");
                IDprof = Convert.ToInt32(Console.ReadLine());

                Professor profs = Professores.Find(p => p.MatriculaProfessor == IDprof);

                if (profs == null)
                {
                    Console.WriteLine("Turma não Econtrada.");
                    cond = 0;
                }

                else
                {
                    Console.WriteLine("Turma econtrada...");
                    cond = 3;
                }
            } while (cond < 2);

            Materia novaMat = new Materia { IdMateira = escola.Materias.Count + 1, NomeMateria = nomeMateria, ProfessorResposavel = IDprof };
            escola.Materias.Add(novaMat);
            escola.SalvarDados();
            Console.WriteLine("Matéria cadastrada com Sucesso!");
            Console.ReadKey();
        }

        public void CadastrarTurmas(Escola escola)
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Turma:");
            Console.WriteLine("Nome Turma: ");
            string nomeTurma = Console.ReadLine();
            Console.WriteLine("Número da Sala: ");
            int numSala = Convert.ToInt32(Console.ReadLine());




            Turma novaTuma = new Turma { Idturma = escola.Turmas.Count + 1, NomeTurma = nomeTurma, NumeroSala = numSala };
            escola.Turmas.Add(novaTuma);
            escola.SalvarDados();
            Console.WriteLine("Turma cadastrada com Sucesso!");
            Console.ReadKey();
        }
    }
}