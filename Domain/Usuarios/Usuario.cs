using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Usuarios;

namespace Domain
{
    public abstract class Usuario
    {
        public string Nome { get; set; }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Password { get; set; }
        public Profile Profile { get; set; }

        public Usuario(string nome)
        {
            Nome = nome;
            Id = Guid.NewGuid();
        }

// metodos de validação, onde o usuario valida ele mesmo
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

