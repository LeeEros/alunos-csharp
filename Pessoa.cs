using System;

namespace Escola {
   public abstract class Pessoa: IPessoa {
      public string Nome {
         get;
          set;
      }
      public DateTime DataNascimento {
         get;
          set;
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