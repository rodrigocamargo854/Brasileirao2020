using System;

namespace WebApi.Controller
{
    public class JogadorResponse
    {
        public Guid Id { get;  private set; } = new Guid();
        public string Nome { get; set; }
        public int Gols { get; private set;}

        public JogadorResponse(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            
            
        }
    }
}