using System;
using Domain.Users;

namespace WebApi.Controller
{
    public class JogadorRequest
    {
        public Guid Id { get;  private set; } = new Guid();
        public string Nome { get; set; }



       
    }
}