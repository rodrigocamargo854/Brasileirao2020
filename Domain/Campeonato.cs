using System.Collections.Generic;

namespace Brasileirao2020
{
    public class Campeonato
    {
      public List<Time> Time { get; set; } = new List<Time>();//inicializa vazia
      public bool IniciaCampeonato { get; set; }
      public int Rodadas { get; set; }

        public Campeonato( bool iniciaCampeonato, int rodadas)
        {
            IniciaCampeonato = iniciaCampeonato;
            Rodadas = rodadas;
        }
    }


}