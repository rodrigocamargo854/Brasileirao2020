using System;
using System.Collections.Generic;

namespace Domain
{
    public class Campeonato
    {
        public List<Time> Times { get; set; } = new List<Time>();//inicializa vazia
        public bool IniciaCampeonato { get; set; }
        public int Rodadas { get; set; }

        public string[] Conflitos { get; set; }


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


            Random mistura = new Random();
            Time[,] tabelaConflitos = new Time[4, 2];

            //recebe a conversão times em array
            Time[] arrayTimes = times.ToArray();

            if (usuario is Cbf)
            {
                //objeto do tipo Random para misturar os times


                for (int i = 0; i < arrayTimes.Length; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        tabelaConflitos[i, j] = arrayTimes[i];
                    }
                    return tabelaConflitos;
                }
            }

            return tabelaConflitos = null;


        }


    }




}

//!Todo  Regra de necogio usuario torcedor
//!Todo Metodos 

