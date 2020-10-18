using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{


    public class Campeonato
    {
        public List<Time> Times { get; set; } = new List<Time>();//inicializa vazia
        public bool IniciaCampeonato { get; set; }
        public int Rodadas { get; set; }

        public string[] Conflitos { get; set; }


        private void embaralhar(List<Time> times)
        {
            // cria um objeto da classe Random
            Random rnd = new Random();

            // vamos embaralhar o ArrayList
            for (int i = 0; i < times.Count; i++)
            {
                int a = rnd.Next(times.Count);
                var temp = times[i];
                times[i] = times[a];
                times[a] = temp;
            }
        }


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

        public Time[,] GeraConflitos(List<Time> times, Usuario usuario)
        {

            embaralhar(times);

            Time[,] tabelaConflitos = new Time[4, 2];

            //recebe a conversão times em array
            Time[] arrayTimes = times.ToArray();



            if (usuario is Cbf)
            {
                //objeto do tipo Random para misturar os times

                int s = -1;

                for (int i = 0; i < arrayTimes.Length/2; i+=2)
                {
                    

                    for (int j = 0; j < 2; j++)
                    {
                        
                        tabelaConflitos[i,j] = arrayTimes[++s];

                    }
                }
                return tabelaConflitos;

            }
            return tabelaConflitos = null;
        }
        // método que embaralha os jogadores da lista

    }




}

//!Todo  Regra de necogio usuario torcedor
//!Todo Metodos 

