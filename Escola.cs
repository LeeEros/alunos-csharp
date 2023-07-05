using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Escola {
    public class Escola {
        public List < Aluno > Alunos = new List < Aluno > ();

        public List < Professor > Professores = new List < Professor > ();

        public List < Turma > Turmas = new List < Turma > ();

        public List < Materia > Materias = new List < Materia > ();

        public void SalvarDados() {
            File.WriteAllText("Alunos.json", JsonConvert.SerializeObject(Alunos));
            File.WriteAllText("Professores.json", JsonConvert.SerializeObject(Professores));
            File.WriteAllText("Turmas.json", JsonConvert.SerializeObject(Turmas));
            File.WriteAllText("Materias.json", JsonConvert.SerializeObject(Materias));
        }

        public void CarregarDados() {
            if (File.Exists("Alunos.json")) {
                Alunos = JsonConvert.DeserializeObject < List < Aluno >> (File.ReadAllText("Alunos.json"));
            }

            if (File.Exists("Professores.json")) {
                Professores = JsonConvert.DeserializeObject < List < Professor >> (File.ReadAllText("Professores.json"));
            }

            if (File.Exists("Turmas.json")) {
                Turmas = JsonConvert.DeserializeObject < List < Turma >> (File.ReadAllText("Turmas.json"));
            }

            if (File.Exists("Materias.json")) {
                Materias = JsonConvert.DeserializeObject < List < Materia >> (File.ReadAllText("Materias.json"));
            }
        }

        //Cadastros

        public void CadastrarAluno(Escola escola) {

            string emailAluno;
            DateTime dataNascimento;
            string nomeAluno;
            Console.Clear();
            Console.WriteLine("Cadastro de aluno(a): (Pressione 0 para abortar em qualquer momento)");

            do {
                Console.WriteLine("Nome Completo: ");
                nomeAluno = Console.ReadLine().Trim();
                if (nomeAluno == "0") {
                    Console.WriteLine("Abortando..");
                    Console.ReadLine();
                    return;
                }
            } while (nomeAluno == null || nomeAluno == "");

            do {
                Console.WriteLine("Data de Nascimento(AAAA-MM-DD): ");
                string consoleRead = Console.ReadLine();
                if (consoleRead == "0") {
                    Console.WriteLine("Abortando..");
                    Console.ReadLine();
                    return;
                }
                DateTime.TryParse(consoleRead, out dataNascimento);
            } while (dataNascimento == new DateTime());

            do {

                Console.WriteLine("Email Aluno: ");
                emailAluno = Console.ReadLine().Trim();
                if (emailAluno == "0") {
                    Console.WriteLine("Abortando..");
                    Console.ReadLine();
                    return;
                }
            } while (emailAluno == null || emailAluno == "");

            Aluno novoAluno = new Aluno (
                nomeAluno, dataNascimento, escola.Alunos.Count + 1, emailAluno
            );
            escola.Alunos.Add(novoAluno);

            escola.SalvarDados();
            Console.WriteLine("Aluno Cadastrado com Sucesso!");
            Console.ReadKey();
        }

        public void CadastrarProfessor(Escola escola) {
            string nomeProf;
            DateTime dataNasc;
            string formacao;
            string emailProf;

            Console.Clear();
            Console.WriteLine("Cadastro de Professor: (Pressione 0 para abortar em qualquer momento)");
            do {
                Console.WriteLine("Nome Completo: ");
                nomeProf = Console.ReadLine().Trim();
                if (nomeProf == "0") {
                    Console.WriteLine("Abortando..");
                    Console.ReadLine();
                    return;
                }
            } while (nomeProf == null || nomeProf == "");

            do {
                Console.WriteLine("Data de Nascimento(AAAA-MM-DD): ");
                string consoleRead = Console.ReadLine();
                if (consoleRead == "0") {
                    Console.WriteLine("Abortando..");
                    Console.ReadLine();
                    return;
                }
                DateTime.TryParse(consoleRead, out dataNasc);
            } while (dataNasc == new DateTime());

            do {
                Console.WriteLine("Formação: ");
                formacao = Console.ReadLine().Trim();
                if (formacao == "0") {
                    Console.WriteLine("Abortando..");
                    Console.ReadLine();
                    return;
                }
            } while (formacao == null || formacao == "");

            do {
                Console.WriteLine("Email Institucional: ");
                emailProf = Console.ReadLine().Trim();
                if (emailProf == "0") {
                    Console.WriteLine("Abortando..");
                    Console.ReadLine();
                    return;
                }
            } while (emailProf == null || emailProf == "");

            Professor novoProf = new Professor (
                nomeProf, dataNasc, escola.Professores.Count + 1, formacao, emailProf
            );
            escola.Professores.Add(novoProf);
            escola.SalvarDados();
            Console.WriteLine("Professor Cadastrado com Sucesso!");
            Console.ReadKey();
        }

        public void CadastrarMateria(Escola escola) {
            try {

                string nomeMateria;
                Console.Clear();
                Console.WriteLine("Cadastro de Matéria: (Pressione 0 para abortar em qualquer momento)");
                do {
                    Console.WriteLine("Nome Matéria: ");
                    nomeMateria = Console.ReadLine().Trim();
                    if (nomeMateria == "0") {
                        Console.WriteLine("Abortando..");
                        return;
                    }
                } while (nomeMateria == null || nomeMateria == "");

                int cond = 0;
                int IDprof;

                do {

                    Console.WriteLine("{0,-10} {1,-30}", "Id Prof", "Nome Professor");
                    foreach(var professor in escola.Professores) {
                        Console.WriteLine("{0,-10} {1,-30}", professor.MatriculaProfessor, professor.Nome);
                    }

                    Console.WriteLine("ID do Professor Responsável pela materia de " + nomeMateria + ":");
                    IDprof = Convert.ToInt32(Console.ReadLine());
                    if (IDprof == 0) {
                        Console.WriteLine("Abortando..");
                        return;
                    }

                    Professor profs = Professores.Find(p => p.MatriculaProfessor == IDprof);

                    if (profs == null) {
                        Console.WriteLine("Professor não Econtrado.");
                        cond = 0;
                    } else {
                        Console.WriteLine("Professor econtrado...");
                        cond = 3;
                    }
                } while (cond < 2);

                Materia novaMat = new Materia {
                    IdMateira = escola.Materias.Count + 1, NomeMateria = nomeMateria, ProfessorResposavel = IDprof
                };
                escola.Materias.Add(novaMat);
                escola.SalvarDados();
                Console.WriteLine("Matéria cadastrada com Sucesso!");

            } catch (System.FormatException) {
                Console.WriteLine("O id do professor deve ser um inteiro");
            } finally {
                Console.ReadKey();
            }
        }

        public void CadastrarTurmas(Escola escola) {
            try {
                string nomeTurma;
                int numSala;

                Console.Clear();
                Console.WriteLine("Cadastro de Turma: (Pressione 0 para abortar em qualquer momento)");
                do {

                    Console.WriteLine("Nome Turma: ");
                    nomeTurma = Console.ReadLine().Trim();
                    if (nomeTurma == "0") {
                        Console.WriteLine("Abortando..");
                        return;
                    }
                } while (nomeTurma == null || nomeTurma == "");

                do {
                    Console.WriteLine("Número da Sala: ");
                    numSala = Convert.ToInt32(Console.ReadLine());
                    if (numSala == 0) {
                        Console.WriteLine("Abortando..");
                        return;
                    }
                } while (numSala == null);

                Turma novaTuma = new Turma {
                    Idturma = escola.Turmas.Count + 1, NomeTurma = nomeTurma, NumeroSala = numSala
                };
                escola.Turmas.Add(novaTuma);
                escola.SalvarDados();
                Console.WriteLine("Turma cadastrada com Sucesso!");
            } catch (System.FormatException) {

                Console.WriteLine("O id da turma deve ser um inteiro");
            } finally {
                Console.ReadKey();
            }

        }

        // Consultas

        public void ConsultarAluno(Escola escola) {
            try {
                int idAluno;
                Aluno aluno;
                Console.Clear();
                Console.WriteLine("Qual aluno você quer consultar:");
                do {

                    Console.WriteLine("{0,-10} {1,-30}", "Id Aluno", "Nome Aluno");
                    foreach(var alunoLista in escola.Alunos) {
                        Console.WriteLine("{0,-10} {1,-30}", alunoLista.MatriculaAluno, alunoLista.Nome);
                    }
                    int.TryParse(Console.ReadLine(), out idAluno);
                } while (idAluno == null);

                aluno = escola.Alunos.Find(aluno => aluno.MatriculaAluno == idAluno);

                if (aluno == null) {
                    Console.WriteLine("Aluno não encontrado");
                } else {
                    aluno.ExibirInformacoes();
                }
            } catch (System.FormatException) {

                Console.WriteLine("O id do aluno deve ser um inteiro");
            } finally {
                Console.ReadKey();
            }
        }

        public void ConsultarProfessor(Escola escola) {
            try {
                int idProfessor;
                Professor professor;
                Console.Clear();
                Console.WriteLine("Qual professor você quer consultar:");
                do {

                    Console.WriteLine("{0,-10} {1,-30}", "Id Professor", "Nome Professor");
                    foreach(var professorLista in escola.Professores) {
                        Console.WriteLine("{0,-10} {1,-30}", professorLista.MatriculaProfessor, professorLista.Nome);
                    }
                    int.TryParse(Console.ReadLine(), out idProfessor);
                } while (idProfessor == null);

                professor = escola.Professores.Find(professor => professor.MatriculaProfessor == idProfessor);

                if (professor == null) {
                    Console.WriteLine("Professor não encontrado");
                } else {
                    professor.ExibirInformacoes();
                }
            } catch (System.FormatException) {

                Console.WriteLine("O id do professor deve ser um inteiro");
            } finally {
                Console.ReadKey();
            }
        }

        // Alterações

        public void VincularAlunoATurma(Escola escola) {
            try {

                int idAluno;
                int idTurma;
                Turma turmaCadastrada;
                int cond = 0;

                do {
                    Console.Clear();
                    Console.WriteLine("Vincular aluno a turma.");
                    do {

                        Console.WriteLine("Selecione um aluno:");
                        Console.WriteLine("{0,-10} {1,-30}", "Id Aluno", "Nome Aluno");
                        foreach(var aluno in escola.Alunos) {
                            Console.WriteLine("{0,-10} {1,-30}", aluno.MatriculaAluno, aluno.Nome);
                        }
                        Console.WriteLine("ID do Aluno:");
                        idAluno = Convert.ToInt32(Console.ReadLine());
                    } while (idAluno == null || idAluno == 0);

                    Aluno alunoMatriculado = Alunos.Find(aluno => aluno.MatriculaAluno == idAluno);

                    if (alunoMatriculado == null) {
                        Console.WriteLine("Aluno não Econtrado.");
                        idAluno = 0;
                        cond = 0;
                    } else {
                        Console.WriteLine("Aluno econtrado...");
                        cond = 3;
                    }
                }
                while (cond < 2);

                cond = 0;

                do {
                    do {

                        Console.WriteLine("Selecione uma turma:");
                        Console.WriteLine("{0,-10} {1,-30}", "Id Aluno", "Nome Turma");
                        foreach(var turma in escola.Turmas) {
                            Console.WriteLine("{0,-10} {1,-30}", turma.Idturma, turma.NomeTurma);
                        }
                        Console.WriteLine("ID do Turma:");
                        idTurma = Convert.ToInt32(Console.ReadLine());
                    } while (idTurma == null || idTurma == 0);

                    turmaCadastrada = Turmas.Find(turma => turma.Idturma == idTurma);

                    if (turmaCadastrada == null) {
                        Console.WriteLine("Turma não Econtrada.");
                        idTurma = 0;
                        cond = 0;
                    } else {
                        Console.WriteLine("Turma econtrada...");
                        cond = 3;
                    }
                }
                while (cond < 2);

                Aluno alunoJaVinculado = turmaCadastrada.AlunosTurma.Find(aluno => aluno.MatriculaAluno == idAluno);

                if (alunoJaVinculado != null) {
                    Console.WriteLine("Aluno ja cadastrado nessa turma");

                } else {
                    Aluno alunoParaVincular = escola.Alunos.Find(aluno => aluno.MatriculaAluno == idAluno);
                    turmaCadastrada.AlunosTurma.Add(alunoParaVincular);
                    escola.SalvarDados();
                    Console.WriteLine("Aluno Vinculado a turma!");
                }

            } catch (System.FormatException) {

                Console.WriteLine("O id do aluno e da turma devem ser um inteiro");
            } finally {
                Console.ReadKey();
            }
        }
    }
}