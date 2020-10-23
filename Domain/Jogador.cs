using System;

namespace Domain {
    public  class Jogador 
    {
       public Guid Id { get;  private set; } = new Guid();
        public string Nome { get; set; }
        public int Gols { get; private set;}

        public Jogador(string nome)
        {
            Id = Guid.NewGuid();
            Nome=nome;
            
        }

        public void MarcarGols()
        {
            Gols++;
        }

        
    }
}