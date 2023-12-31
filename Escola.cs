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
            File.WriteAllText(".\\dados\\Alunos.json", JsonConvert.SerializeObject(Alunos));
            File.WriteAllText(".\\dados\\Professores.json", JsonConvert.SerializeObject(Professores));
            File.WriteAllText(".\\dados\\Turmas.json", JsonConvert.SerializeObject(Turmas));
            File.WriteAllText(".\\dados\\Materias.json", JsonConvert.SerializeObject(Materias));
        }

        public void CarregarDados() {
            if (File.Exists(".\\dados\\Alunos.json")) {
                if (new FileInfo(".\\dados\\Alunos.json").Length > 0) {
                    Alunos = JsonConvert.DeserializeObject < List < Aluno >> (File.ReadAllText(".\\dados\\Alunos.json"));

                }
            } else {
                File.Create(".\\dados\\Alunos.json");
            }

            if (File.Exists(".\\dados\\Professores.json")) {
                if (new FileInfo(".\\dados\\Professores.json").Length > 0) {
                    Professores = JsonConvert.DeserializeObject < List < Professor >> (File.ReadAllText(".\\dados\\Professores.json"));
                }
            } else {
                File.Create(".\\dados\\Professores.json");
            }

            if (File.Exists(".\\dados\\Turmas.json")) {
                if (new FileInfo(".\\dados\\Turmas.json").Length > 0) {
                    Turmas = JsonConvert.DeserializeObject < List < Turma >> (File.ReadAllText(".\\dados\\Turmas.json"));
                }
            } else {
                File.Create(".\\dados\\Turmas.json");
            }

            if (File.Exists(".\\dados\\Materias.json")) {
                if (new FileInfo(".\\dados\\Materias.json").Length > 0) {
                    Materias = JsonConvert.DeserializeObject < List < Materia >> (File.ReadAllText(".\\dados\\Materias.json"));
                }
            } else {
                File.Create(".\\dados\\Materias.json");
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

            Aluno novoAluno = new Aluno(
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

            Professor novoProf = new Professor(
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
                Professor profs;

                if (escola.Professores.Count < 1) {
                    Console.Clear();
                    Console.WriteLine("A escola não possuí professores!");
                    return;
                }

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

                    profs = Professores.Find(p => p.MatriculaProfessor == IDprof);

                    if (profs == null) {
                        Console.WriteLine("Professor não Econtrado.");
                        cond = 0;
                    } else {
                        Console.WriteLine("Professor econtrado...");
                        cond = 3;
                    }
                } while (cond < 2);

                Materia novaMat = new Materia {
                    IdMateria = escola.Materias.Count + 1, NomeMateria = nomeMateria, ProfessorResposavel = profs
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

                if (escola.Alunos == null || escola.Alunos.Count < 1) {
                    Console.WriteLine("A Escola não possuí alunos cadastrados!");
                    return;
                }

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
                    Console.Clear();
                    Console.WriteLine("Aluno não encontrado");
                } else {
                    Console.Clear();
                    aluno.ExibirInformacoes();
                }
            } catch (System.FormatException) {
                Console.Clear();
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
                if (escola.Professores == null || escola.Professores.Count < 1) {
                    Console.WriteLine("A Escola não possuí professores cadastrados!");
                    return;
                }
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
                    Console.Clear();
                    Console.WriteLine("Professor não encontrado");
                } else {
                    Console.Clear();
                    professor.ExibirInformacoes();
                }
            } catch (System.FormatException) {
                Console.Clear();
                Console.WriteLine("O id do professor deve ser um inteiro");
            } finally {
                Console.ReadKey();
            }
        }

        public void ConsultarMateria(Escola escola) {
            try {
                int IdMateria;
                Materia materia;
                Console.Clear();
                if (escola.Materias == null || escola.Materias.Count < 1) {
                    Console.WriteLine("A Escola não possuí matérias cadastradas!");
                    return;
                }
                Console.WriteLine("Qual materia você quer consultar:");
                do {

                    Console.WriteLine("{0,-20} {1,-30}", "Id Materia", "Nome Materia");
                    foreach(var materiaLista in escola.Materias) {
                        Console.WriteLine("{0,-20} {1,-30}", materiaLista.IdMateria, materiaLista.NomeMateria);
                    }
                    int.TryParse(Console.ReadLine(), out IdMateria);
                } while (IdMateria == null);

                materia = escola.Materias.Find(materia => materia.IdMateria == IdMateria);

                if (materia == null) {
                    Console.Clear();
                    Console.WriteLine("Materia não encontrada");
                } else {
                    Console.Clear();

                    List < Turma > turmas = materia.obterTurmas(escola);

                    Console.WriteLine("Código da materia: " + materia.IdMateria);
                    Console.WriteLine("Nome da materia: " + materia.NomeMateria);
                    Console.WriteLine("Professor da materia: " + materia.ProfessorResposavel.Nome);

                    if (turmas.Count > 0) {
                        Console.WriteLine("{0,-10} {1,-30}", "Id Turma", "Nome Turma");
                        foreach(var turmaLista in turmas) {
                            Console.WriteLine("{0,-10} {1,-30}", turmaLista.Idturma, turmaLista.NomeTurma);
                        }
                    }
                }
            } catch {

            } finally {
                Console.ReadLine();
            }
        }

        public void ConsultarTurma(Escola escola) {

            try {
                int IdTurma;
                Turma turma;
                Console.Clear();
                if (escola.Turmas == null || escola.Turmas.Count < 1) {
                    Console.WriteLine("A Escola não possuí turmas cadastradas!");
                    return;
                }
                Console.WriteLine("Qual turma você quer consultar:");
                do {

                    Console.WriteLine("{0,-20} {1,-30}", "Id Turma", "Nome Turma");
                    foreach(var turmaLista in escola.Turmas) {
                        Console.WriteLine("{0,-20} {1,-30}", turmaLista.Idturma, turmaLista.NomeTurma);
                    }
                    IdTurma = Convert.ToInt32(Console.ReadLine());
                } while (IdTurma == null);

                turma = escola.Turmas.Find(turma => turma.Idturma == IdTurma);

                Console.Clear();
                if (turma == null) {
                    Console.Clear();
                    Console.WriteLine("Turma não encontrada");
                } else {
                    Console.Clear();
                    Console.WriteLine("Código da turma: " + turma.Idturma);
                    Console.WriteLine("Nome da turma: " + turma.NomeTurma);
                    Console.WriteLine("Sala da turma: " + turma.NumeroSala);
                    turma.MostrarAlunos();
                    turma.MostrarGrade();
                }
            } catch (System.FormatException) {
                //Console.Clear();
                Console.WriteLine("O id da materia deve ser um inteiro");
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

                if (escola.Turmas.Count < 1) {
                    Console.WriteLine("Não há turmas cadastradas para vincular");
                    return;
                } else if (escola.Alunos.Count < 1) {
                    Console.WriteLine("Não há alunos cadastrados para vincular");
                    return;
                }

                do {
                    Console.Clear();
                    Console.WriteLine("Vincular aluno a turma. (Pressione 0 para abortar em qualquer momento)");
                    do {

                        Console.WriteLine("Selecione um aluno:");
                        Console.WriteLine("{0,-10} {1,-30}", "Id Aluno", "Nome Aluno");
                        foreach(var aluno in escola.Alunos) {
                            Console.WriteLine("{0,-10} {1,-30}", aluno.MatriculaAluno, aluno.Nome);
                        }
                        Console.WriteLine("ID do Aluno:");
                        idAluno = Convert.ToInt32(Console.ReadLine());
                        if (idAluno == 0) {
                            Console.WriteLine("Abortando..");
                            return;
                        }
                    } while (idAluno == null);

                    Aluno alunoMatriculado = Alunos.Find(aluno => aluno.MatriculaAluno == idAluno);

                    if (alunoMatriculado == null) {
                        Console.Clear();
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
                        Console.Clear();
                        Console.WriteLine("Selecione uma turma: (Pressione 0 para abortar em qualquer momento)");
                        Console.WriteLine("{0,-10} {1,-30}", "Id Turma", "Nome Turma");
                        foreach(var turma in escola.Turmas) {
                            Console.WriteLine("{0,-10} {1,-30}", turma.Idturma, turma.NomeTurma);
                        }
                        Console.WriteLine("ID do Turma:");
                        idTurma = Convert.ToInt32(Console.ReadLine());
                        if (idTurma == 0) {
                            Console.WriteLine("Abortando..");
                            return;
                        }
                    } while (idTurma == null);

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
                    Console.Clear();
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

        public void DesvincularAlunoDaTurma(Escola escola) {
            try {
                int IdAluno;
                int Idturma;
                Turma turma;
                Aluno aluno;

                if (escola.Turmas.Count < 1) {
                    Console.WriteLine("Não há turmas cadastradas para desvincular");

                    return;
                } else if (escola.Alunos.Count < 1) {
                    Console.WriteLine("Não há alunos cadastrados para desvincular");

                    return;
                }
                Console.Clear();
                Console.WriteLine("De qual turma você quer remover um aluno:");
                do {

                    Console.WriteLine("{0,-20} {1,-30}", "Id Turma", "Nome Turma");
                    foreach(var turmaLista in escola.Turmas) {
                        Console.WriteLine("{0,-20} {1,-30}", turmaLista.Idturma, turmaLista.NomeTurma);
                    }
                    int.TryParse(Console.ReadLine(), out Idturma);
                } while (Idturma == null);

                turma = escola.Turmas.Find(turma => turma.Idturma == Idturma);

                if (turma == null) {
                    Console.WriteLine("Turma não encontrada");
                    return;
                }

                do {
                    Console.Clear();
                    Console.WriteLine("Qual aluno você deseja remover da turma de " + turma.NomeTurma + ":");
                    turma.MostrarAlunos();
                    int.TryParse(Console.ReadLine(), out IdAluno);

                } while (IdAluno == null);

                aluno = escola.Alunos.Find(aluno => aluno.MatriculaAluno == IdAluno);

                if (aluno == null) {
                    Console.WriteLine("Aluno não encontrado");
                    return;
                }

                int indexAluno = turma.AlunosTurma.FindIndex(alunoDaLista => alunoDaLista.MatriculaAluno == aluno.MatriculaAluno);

                turma.AlunosTurma.RemoveAt(indexAluno);
                escola.SalvarDados();
                Console.Clear();
                Console.WriteLine("Aluno desvinculado!");
            } catch (System.ArgumentOutOfRangeException) {
                Console.Clear();
                Console.WriteLine("Aluno não localizado na turma!");
            } finally {
                Console.ReadLine();

            }
        }

        public void VincularMateriaATurma(Escola escola) {
            try {

                int IdMateria;
                int IdTurma;
                Turma turmaCadastrada;
                Materia materiaParaCadastrar;
                int cond = 0;

                if (escola.Turmas.Count < 1) {
                    Console.WriteLine("Não há turmas cadastradas para vincular");
                    return;
                } else if (escola.Materias.Count < 1) {
                    Console.WriteLine("Não há materias cadastrados para vincular");
                    return;
                }

                do {
                    Console.Clear();
                    Console.WriteLine("Vincular materia a turma. (Pressione 0 para abortar em qualquer momento)");
                    do {

                        Console.WriteLine("Selecione uma materia:");
                        Console.WriteLine("{0,-10} {1,-30}", "Id Materia", "Nome Materia");
                        foreach(var materiaLista in escola.Materias) {
                            Console.WriteLine("{0,-10} {1,-30}", materiaLista.IdMateria, materiaLista.NomeMateria);
                        }
                        Console.WriteLine("ID da Materia:");
                        IdMateria = Convert.ToInt32(Console.ReadLine());
                        if (IdMateria == 0) {
                            Console.WriteLine("Abortando..");
                            return;
                        }
                    } while (IdMateria == null);

                    materiaParaCadastrar = Materias.Find(materia => materia.IdMateria == IdMateria);

                    if (materiaParaCadastrar == null) {
                        Console.Clear();
                        Console.WriteLine("Materia não Econtrada.");
                        IdMateria = 0;
                        cond = 0;
                    } else {
                        Console.WriteLine("Materia econtrada...");
                        cond = 3;
                    }
                }
                while (cond < 2);

                cond = 0;

                do {
                    do {
                        Console.Clear();
                        Console.WriteLine("Selecione uma turma: (Pressione 0 para abortar em qualquer momento)");
                        Console.WriteLine("{0,-10} {1,-30}", "Id Turma", "Nome Turma");
                        foreach(var turma in escola.Turmas) {
                            Console.WriteLine("{0,-10} {1,-30}", turma.Idturma, turma.NomeTurma);
                        }
                        Console.WriteLine("ID do Turma:");
                        IdTurma = Convert.ToInt32(Console.ReadLine());
                        if (IdTurma == 0) {
                            Console.WriteLine("Abortando..");
                            return;
                        }
                    } while (IdTurma == null);

                    turmaCadastrada = Turmas.Find(turma => turma.Idturma == IdTurma);

                    if (turmaCadastrada == null) {
                        Console.WriteLine("Turma não Econtrada.");
                        IdTurma = 0;
                        cond = 0;
                    } else {
                        Console.WriteLine("Turma econtrada...");
                        cond = 3;
                    }
                }
                while (cond < 2);

                Materia materiaJaCadastrada = turmaCadastrada.GradeTurma.Find(materia => materia.IdMateria == IdMateria);

                if (materiaJaCadastrada != null) {
                    Console.Clear();
                    Console.WriteLine("Materia ja vincula nessa turma");

                } else {
                    turmaCadastrada.GradeTurma.Add(materiaParaCadastrar);
                    escola.SalvarDados();
                    Console.WriteLine("Materia Vinculada a turma!");
                }

            } catch (System.FormatException) {

                Console.WriteLine("O id da materia e da turma devem ser um inteiro");
            } finally {
                Console.ReadKey();
            }
        }

        public void DesvincularMateriaDaTurma(Escola escola) {
            try {
                int IdMateria;
                int Idturma;
                Turma turma;
                Materia materia;

                if (escola.Turmas.Count < 1) {
                    Console.WriteLine("Não há turmas cadastradas para desvincular");
                    return;
                } else if (escola.Materias.Count < 1) {
                    Console.WriteLine("Não há materias cadastradas para desvincular");

                    return;
                }
                Console.Clear();
                Console.WriteLine("De qual turma você quer remover a materia:");
                do {

                    Console.WriteLine("{0,-20} {1,-30}", "Id Turma", "Nome Turma");
                    foreach(var turmaLista in escola.Turmas) {
                        Console.WriteLine("{0,-20} {1,-30}", turmaLista.Idturma, turmaLista.NomeTurma);
                    }
                    int.TryParse(Console.ReadLine(), out Idturma);
                } while (Idturma == null);

                turma = escola.Turmas.Find(turma => turma.Idturma == Idturma);

                if (turma == null) {
                    Console.WriteLine("Turma não encontrada");
                    return;
                }

                do {
                    Console.Clear();
                    Console.WriteLine("Qual materia você deseja remover da turma de " + turma.NomeTurma + ":");
                    turma.MostrarGrade();
                    int.TryParse(Console.ReadLine(), out IdMateria);

                } while (IdMateria == null);

                materia = escola.Materias.Find(materia => materia.IdMateria == IdMateria);

                if (materia == null) {
                    Console.WriteLine("Materia não encontrada");
                    return;
                }

                int indexMateria = turma.GradeTurma.FindIndex(materiaDaLista => materiaDaLista.IdMateria == materia.IdMateria);

                turma.GradeTurma.RemoveAt(indexMateria);
                escola.SalvarDados();
                Console.Clear();
                Console.WriteLine("Materia desvinculada!");
            } catch (System.ArgumentOutOfRangeException) {
                Console.Clear();
                Console.WriteLine("Materia não localizada na turma!");
            } finally {
                Console.ReadLine();
            }
        }

        public void AlterarProfessorDaMateria(Escola escola) {
            try {
                int IdMateria;
                int IdProfessor;
                Materia materia;
                Professor professor;
                Console.Clear();
                if (escola.Materias == null || escola.Materias.Count < 1) {
                    Console.WriteLine("A Escola não possuí matérias cadastradas!");
                    return;
                } else if (escola.Professores == null || escola.Professores.Count < 1) {
                    Console.WriteLine("A Escola não possuí professores cadastrados!");
                    return;
                }
                Console.WriteLine("Qual materia você quer alterar:");
                do {

                    Console.WriteLine("{0,-20} {1,-30} {2,-30}", "Id Materia", "Nome Materia", "Professor");
                    foreach(var materiaLista in escola.Materias) {
                        Console.WriteLine("{0,-20} {1,-30} {2,-30}", materiaLista.IdMateria, materiaLista.NomeMateria, materiaLista.ProfessorResposavel.Nome);
                    }
                    int.TryParse(Console.ReadLine(), out IdMateria);
                } while (IdMateria == null);

                materia = escola.Materias.Find(materia => materia.IdMateria == IdMateria);

                if (materia == null) {
                    Console.Clear();
                    Console.WriteLine("Materia não encontrada");
                } else {
                    Console.Clear();
                    Console.WriteLine("Qual professor você quer colocar na materia:");
                    do {
                        Console.WriteLine("{0,-10} {1,-30}", "Id Professor", "Nome Professor");
                        foreach(var professorLista in escola.Professores) {
                            Console.WriteLine("{0,-10} {1,-30}", professorLista.MatriculaProfessor, professorLista.Nome);
                        }
                        int.TryParse(Console.ReadLine(), out IdProfessor);
                    } while (IdProfessor == null);

                    professor = escola.Professores.Find(professor => professor.MatriculaProfessor == IdProfessor);

                    if (professor == null) {
                        Console.Clear();
                        Console.WriteLine("Professor não encontrado");
                    } else {
                        Console.Clear();
                        materia.ProfessorResposavel = professor;
                        escola.SalvarDados();
                        Console.WriteLine("Professor alterado com sucesso");

                    }
                }
            } catch {

            } finally {
                Console.ReadLine();
            }
        }
    }
}