using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{


    public class Campeonato
    {
        public List<Time> Times { get; set; } = new List<Time>();//inicializa vazia
        public bool InicioCampeonato { get; set; } = false;
        public int Rodadas { get; set; }

        public string[] Conflitos { get; set; }

        //Metodo para misturar os times dentro de uma lista
        private void embaralhar(List<Time> times)
        {
            // cria um objeto da classe Random
            Random rnd = new Random();

            // a lista de times
            for (int i = 0; i < times.Count; i++)
            {
                int a = rnd.Next(times.Count);
                var temp = times[i];
                times[i] = times[a];
                times[a] = temp;
            }
        }


        ///Regra de negocio usuario CBF
        //Este metodo recebe uma lista de jogadores do timpo Time e o tipo de usuario
        //Para validar o acesso . Usuario cdf ou torcedor
        public bool AdicionarTimes(List<Time> times, Usuario usuario)
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

        public Time[,] GerarPrimeiraRodada(Usuario usuario)
        {

            
            embaralhar(Times);
            Time[,] tabelaConflitos = new Time[4, 2];
            //recebe a conversão times em array
            Time[] arrayTimes = Times.ToArray();
            
        
            if (usuario is Cbf)
            {
                //objeto do tipo Random para misturar os times

                int s = -1;
                
                for (int i = 0; i < arrayTimes.Length/2; i++)
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


        // soment o usuario do tipo Cbf tem permissao para iniciar o Campeonato
        //caso contrario o metodo retorna o defaut da prop InicioCampeonato(false)
        public bool iniciarCampeonato(Usuario usuario)
        {
            
            if (usuario is Cbf)
            {   
                
                return !InicioCampeonato;
            }

            return InicioCampeonato;
        }
    }

    




}

//!Todo  Regra de necogio usuario torcedor
//!Todo Metodos 

