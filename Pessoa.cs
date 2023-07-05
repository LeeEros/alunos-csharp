using System;

namespace Escola {
    public abstract class Pessoa: IPessoa {
        public string Nome {
            get;
            protected set;
        }
        public DateTime DataNascimento {
            get;
            protected set;
        }

        public Pessoa(string nome, DateTime dataNascimento) {
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
        }

        public int calculaIdade() {

            DateTime hoje = DateTime.Now;

            int idade = hoje.Year - DataNascimento.Year;

            if (DataNascimento.Date > hoje.AddYears(-idade)) {
                idade--;
            }

            return idade;
        }

        public abstract void ExibirInformacoes();
    }
}