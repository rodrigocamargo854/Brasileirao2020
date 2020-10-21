using System;

namespace Domain {
    public  class Jogador 
    {
       public Guid Id { get;  private set; } = new Guid();
        public string Nome { get; private set; }
        public int Pontos { get; private set;}
        protected Jogador(string nome)
        {
            
        }

        protected Jogador(){}

        public void MarcarPontos()
        {
            Pontos++;
        }

        
    }
}