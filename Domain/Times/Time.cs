using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Jogadores;

namespace Domain.Times {
    public  class Time 
    {
       public Guid Id { get;  private set; } = new Guid();
        public string Nome { get; set; }
        public int Gols { get; private set;}
        public List<Jogador> Jogadores { get; set; } = new List<Jogador>();

        public Time(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            
        }

        public bool adicionarJogador(List<Jogador> listaDeJogadores)
        {
            if (listaDeJogadores.Count > 15 && listaDeJogadores.Count < 33)
            {
                Jogadores = listaDeJogadores;

                return true;
            }
            return false;
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