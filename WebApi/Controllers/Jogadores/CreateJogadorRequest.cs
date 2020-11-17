using System;
using Domain;
using Domain.Usuarios;

namespace WebAPI.Controllers.Jogadores
{
    public class CreateJogadorRequest
    {
        public string Nome { get; set; }
    }
}