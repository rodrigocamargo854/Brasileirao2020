using System;
using Domain.Usuarios;

namespace WebAPI.Controllers.Users
{
    public class CreateUserRequest
    {
        public string Nome { get; set; }
        public Profile Profile { get; set; }
        public string Senha { get; set; }
    }
}