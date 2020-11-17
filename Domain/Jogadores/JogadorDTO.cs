using System;
using System.Collections.Generic;

namespace Domain.Jogadores
{
    public class JogadorDTO
    {
        public Guid Id { get; set; }        
        public bool EValido { get; set; }        
        public List<string> Error { get; set; }

        public JogadorDTO(Guid idUser)
        {
           EValido = true;
           Id = idUser;
        }

        public JogadorDTO(List<string> erros)
        {    EValido = false;
             Error = erros;
        }
    }    
}