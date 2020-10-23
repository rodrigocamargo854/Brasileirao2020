using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{


    public class Campeonato
    {
        public List<Time> Times { get; protected set; } = new List<Time>();//inicializa vazia
        public bool InicioCampeonato { get; protected set; } = false;


        //Metodo para misturar os times dentro de uma lista
        private List<Time> embaralhar(List<Time> times)
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
            return times;
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

            if (usuario is Cbf)
            {
                Times = times;

                return true;
            }

            return false;

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
        public List<Time[,]> GerarRodadas(Usuario usuario, int numeroRodadas, string nomeTime)
        {

            var rodadas = new List<Time[,]>();
            Time[,] tabelaConflitos = new Time[4, 2];


            if (usuario is Cbf)
            {

                for (int k = 0; k < numeroRodadas; k++)
                {


                    var timesRandomicos = embaralhar(Times).ToArray();

                    // var timesRandomicos = Times.OrderBy(time => time.Pontos).ToArray();
                    //memdoto gerar partidas precisa gerar partidas diferentes
                    Time[] arrayTimes = timesRandomicos;

                    int s = -1;
                    for (int i = 0; i < arrayTimes.Length / 2; i++)
                    {

                        for (int j = 0; j < 2; j++)
                        {

                            tabelaConflitos[i, j] = arrayTimes[++s];

                        }

                    }
                    rodadas.Add(tabelaConflitos);

                }

                return rodadas;
            }
            return rodadas = null;

        }



    }
}

//!Todo  Regra de necogio usuario torcedor
//!Todo Metodos 

