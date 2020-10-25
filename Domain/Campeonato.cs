using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{

    public class Campeonato
    {
        public List<Time> Times { get; private set; }  
        
        private bool InicioCampeonato  = false;

        public Campeonato( )
        {
            Times = new List<Time>();
            
        }



        //Metodo para misturar os times dentro de uma lista
        // private List<Time> embaralhar(List<Time> listaDeTimes)
        // {
        //     // cria um objeto da classe Random
        //     Random rnd = new Random();

        //     // a lista de times
        //     for (int i = 0; i < listaDeTimes.Count; i++)
        //     {
        //         int a = rnd.Next(listaDeTimes.Count);
        //         var temp = listaDeTimes[i];
        //         listaDeTimes[i] = listaDeTimes[a];
        //         listaDeTimes[a] = temp;

        //     }
        //     return listaDeTimes;
        // }

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

            if (!(usuario is Cbf) || InicioCampeonato)
            {
                return false;
            }

            Times = times;
            InicioCampeonato = true;
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
                Times.FirstOrDefault(time => time.Nome == nomeTime).Pontos++;
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
                var conflitos = Times.ToArray();
                Time[] arrayTimes = conflitos;

                for (int i = 0; i < arrayTimes.Length / 2; i++)
                {

                    for (int j = 0; j < arrayTimes.Length; j++)
                    {
                        if (arrayTimes[i] != arrayTimes[j])
                        {
                            tabelaRodadas.Add((arrayTimes[i], arrayTimes[j]));
                        }

                    }
                    //Descomenta caso queira que os times não joguem fora de casa
                    //var timeList = arrayTimes.ToList();
                    //timeList.RemoveAt(i);
                    //arrayTimes = timeList.ToArray();



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

        public List<((string, int), (string, int))> retornarTabelaDeResultados(Usuario usuario)
        {
            //todo arrumar a logica de times aleatorio 1 para todos
            Time[,] tabelaConflitos = new Time[4, 2];
            var rodadas = new List<Time[,]>();

            var tabelaRodadas = new List<((string, int), (string, int))> { };
            if (usuario is Torcedor || usuario is Cbf)
            {

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
                var conflitos = Times.ToArray();
                Time[] arrayTimes = conflitos;

                for (int i = 0; i < arrayTimes.Length / 2; i++)
                {
                    for (int j = 0; j < arrayTimes.Length; j++)
                    {
                        if (arrayTimes[i] != arrayTimes[j])
                        {
                            tabelaRodadas.Add(((arrayTimes[i].Nome, arrayTimes[i].Pontos), (arrayTimes[j].Nome, arrayTimes[j].Pontos)));
                        }
                    }
                    //Descomenta caso queira que os times não joguem fora de casa
                    //var timeList = arrayTimes.ToList();
                    //timeList.RemoveAt(i);
                    //arrayTimes = timeList.ToArray();
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

    }
}

//!Todo  Regra de necogio usuario torcedor
//!Todo Metodos