using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Jogadores {
    public  class Jogador 
    {
       public Guid Id { get;  private set; } = new Guid();
        public string Nome { get; set; }
        public int Gols { get; private set;}

        public Jogador(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            
        }

        public void MarcarGols()
        {
            Gols++;
        }



         private bool ValidarNomeUsuario()
        {
            if (string.IsNullOrEmpty(Nome) || string.IsNullOrWhiteSpace(Nome) || Nome.StartsWith(" ") || Nome.EndsWith(" ")) return false;

            if(Nome.Any(char.IsDigit) || Nome.Any(char.IsSymbol) || Nome.Any(char.IsNumber)) return false;

            return true;
        }

       public (List<string> erros, bool eValido) Validar()
       {
           var erros = new List<string>();

           if (!ValidarNomeUsuario())
           {
                erros.Add("Nome inválido");    
           }

           return (erros, erros.Count==0);
       }

        
    }
}