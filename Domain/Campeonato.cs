using System.Collections.Generic;

namespace Domain
{
    public class Campeonato
    {
        public List<Time> Times { get; set; } = new List<Time>();//inicializa vazia
        public bool IniciaCampeonato { get; set; }
        public int Rodadas { get; set; }

        
        ///Regra de negocio usuario CBF
        public bool AddTimes(List<Time> times, Usuario usuario)
        {
            //como é uma variavel de referencia é preciso utilizar o is
            // se fosse variaveis normais, utilizaria ==
            // Como é um objeto do tipo Usuario ele reconhece automaticamente
            // a herança

            if (usuario is Cbf)
            {
                Times = times;
                return true;
            }

            return false;
        }

        

    }

    //!Todo  Regra de necogio usuario torcedor
    //!Todo Metodos 

}