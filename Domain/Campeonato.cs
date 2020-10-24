using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{

    public class Campeonato
    {
        public List<Time> Times { get; protected set; } = new List<Time>(); //inicializa vazia
        public bool InicioCampeonato { get; protected set; } = false;

        //Metodo para misturar os times dentro de uma lista
        private List<Time> embaralhar(List<Time> listaDeTimes)
        {
            // cria um objeto da classe Random
            Random rnd = new Random();

            // a lista de times
            for (int i = 0; i < listaDeTimes.Count; i++)
            {
                int a = rnd.Next(listaDeTimes.Count);
                var temp = listaDeTimes[i];
                listaDeTimes[i] = listaDeTimes[a];
                listaDeTimes[a] = temp;

            }
            return listaDeTimes;
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
        ///Regra de negocio usuario CBF
        //Este metodo recebe uma lista de jogadores do timpo Time e o tipo de usuario
        //Para validar o acesso . Usuario cdf ou torcedor
        public bool AdicionarTimes(List<Time> times, Usuario usuario)
        {
            //como é uma variavel de referencia é preciso utilizar o is
            // se fosse variaveis normais, utilizaria ==
            // Como é um objeto do tipo Usuario ele reconhece automaticamente
            // a herança

            if (InicioCampeonato || !(usuario is Cbf))
            {
                return false;
            }

            Times = times;
            return true;

        }

        public void AdicionarPontosAoTime(Usuario usuario, string nomeTime)
        {
            //como é uma variavel de referencia é preciso utilizar o is
            // se fosse variaveis normais, utilizaria ==
            // Como é um objeto do tipo Usuario ele reconhece automaticamente
            // a herança

            if (usuario is Cbf)
            {
                foreach (Time time in Times)
                {
                    if (time.Nome == nomeTime)
                    {
                        time.Pontos += 1;
                    }
                }
            }

        }
        // public List<Time[,]> GerarRodadas(Usuario usuario)
        public List<(Time, Time)> GerarRodadas(Usuario usuario)
        {
            //todo arrumar a logica de times aleatorio 1 para todos
            Time[,] tabelaConflitos = new Time[4, 2];
            var rodadas = new List<Time[,]>();

            var tabelaRodadas = new List<(Time, Time)> { };
            var testeRodadas = new Time[] { };


            if (usuario is Cbf)
            {

                var conflitos = Times.ToArray();

                // var timesRandomicos = Times.OrderByDescending(time => time.Pontos).ToArray();
                //memdoto gerar partidas precisa gerar partidas diferentes

                // Time[] arrayTimes = conflitos;

                // int s = 0;
                // for (int i = 0; i < arrayTimes.Length / 2; i++)
                // {
                //     for (int j = 0; j < 2; j++)
                //     {
                //         tabelaConflitos[i, j] = arrayTimes[s++];
                //     }
                //     rodadas.Add(tabelaConflitos);
                // }
                // Times = embaralhar(arrayTimes.ToList());

                Time[] arrayTimes = conflitos;

                for (int i = 0; i < arrayTimes.Length; i++)
                {

                    for (int j = 1; j < arrayTimes.Length; j++)
                    {
                        if (arrayTimes[i] != arrayTimes[j])
                        {
                            tabelaRodadas.Add((arrayTimes[i], arrayTimes[j]));
                        }

                    }

                    var timeList = arrayTimes.ToList();
                    timeList.RemoveAt(i);
                    arrayTimes = timeList.ToArray();


                }

                // int s = -1;
                // for (int i = 0; i < 11; i++)
                // {
                //     for (int j = 0; j < 2; j++)
                //     {
                //         tabelaConflitos[i, j] = arrayTimes[++s];
                //     }
                //     rodadas.Add(tabelaConflitos);
                // }

                return tabelaRodadas;
            }
            return tabelaRodadas = null;

        }

         public List<(Time, Time)> RetornarTabelaResultados(Usuario usuario)
        {
            

        }

    }
}

//!Todo  Regra de necogio usuario torcedor
//!Todo Metodos