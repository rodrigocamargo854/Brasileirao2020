using System;
using System.Collections.Generic;

namespace Domain.Usuarios
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }        
        public bool EValido { get; set; }        
        public List<string> Error { get; set; }

        public UsuarioDTO(Guid idUser)
        {
           EValido = true;
           Id = idUser;
        }

        public UsuarioDTO(List<string> erros)
        {    EValido = false;
             Error = erros;
        }
    }    
}