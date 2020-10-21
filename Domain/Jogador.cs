using System;

namespace Domain {
    public  class Jogador 
    {
       public Guid Id { get;  private set; } = new Guid();
        public string Nome { get; set; }
        public int Pontos { get; private set;}

        public Jogador(Guid id, string nome, int pontos)
        {
            Id = id;
            Nome = nome;
            Pontos = pontos;
        }

        public void MarcarPontos()
        {
            Pontos++;
        }

        
    }
}