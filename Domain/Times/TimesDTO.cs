using System;
using System.Collections.Generic;

namespace Domain.Jogadores
{
    public class TimesDTO
    {
        public Guid Id { get; set; }        
        public bool EValido { get; set; }        
        public List<string> Error { get; set; }

        public TimesDTO(Guid idUser)
        {
           EValido = true;
           Id = idUser;
        }

        public TimesDTO(List<string> erros)
        {    EValido = false;
             Error = erros;
        }
    }    
}