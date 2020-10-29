using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{

    public class Campeonato
    {
        public List<Time> Times { get; private set; }

        private bool InicioCampeonato = false;

        public bool Empate { get; set; }

        public Campeonato()
        {
            Times = new List<Time>();

        }

        private int golsAleatorios(int gols)
        {
            Random numAleatorio = new Random();
            gols = numAleatorio.Next(1,10);

            return gols;
        }



        private string jogadorAleatorio(Jogador[] listaDeJogadores)
        {
            Random rnd = new Random();

            for (int i = 0; i < listaDeJogadores.Length; i++)
            {
                int a = rnd.Next(listaDeJogadores.Length);
                var temp = listaDeJogadores[i];
                listaDeJogadores[i] = listaDeJogadores[a];
                listaDeJogadores[a] = temp;

            }
            return listaDeJogadores[0].ToString();
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

            if (!(usuario is Cbf) || InicioCampeonato)
            {
                return false;
            }

            Times = times;
            InicioCampeonato = true;
            return true;
        }
        public void AdicionarGolsAoJogo(string nomeTimeAnfitriao, int numeroGolsAnf, string nomeTimeDeFora, int numeroGolsVis)
        {
            //como é uma variavel de referencia é preciso utilizar o is
            // se fosse variaveis normais, utilizaria ==
            // Como é um objeto do tipo Usuario ele reconhece automaticamente
            // a herança

            Times.FirstOrDefault(time => time.Nome == nomeTimeAnfitriao).Gols += numeroGolsAnf;

            Times.FirstOrDefault(time => time.Nome == nomeTimeDeFora).Gols += numeroGolsVis;

            // Times.FirstOrDefault(time => time.Nome == nomeTime).AddicionarGolsJogador(nomeJogador);


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

                }


                return tabelaRodadas;
            }
            return tabelaRodadas = null;

        }

        private void AdicionarResultadosParaOsJogos(string a, int i, string f, int j)
        {
            //Adicionando gols para partidas especificas
            //por Rodada
            AdicionarGolsAoJogo(a, i, f, j);
        }

        private void AdicionarGolsDaPartidaAUmJogador(string time, string nome)
        {
            Times.FirstOrDefault(time => time.Nome == nome).AdicionarGolsJogador(nome);
        }

        public List<List<((string nomeTimeCasa, int golsJogo), (string nomeTimeVisitante, int golsJogo))>> registrarPontuacoesDasPartidas(Usuario usuario)
        {
            //todo arrumar a logica de times aleatorio 1 para todos
            var ListaDosResultadosPorRodada = new List<List<((string, int), (string, int))>>();


            var tabelaRodadas = new List<((string, int), (string, int))> { };
            if (usuario is Torcedor || usuario is Cbf)
            {
                //todo chamar metodo que: adiciona gol ao jogador, adiciona gol contra, adiciona, gols para cada jogo

                var conflitos = Times.ToArray();
                Time[] arrayTimes = conflitos;
                //Metodo para adicionar resultados mocados para os jogos

                for (int i = 0; i < arrayTimes.Length / 2; i++)
                {



                    for (int j = 1; j < arrayTimes.Length; j++)
                    {
                        //todo adicionar pontos ao time a cada
                        AdicionarResultadosParaOsJogos(arrayTimes[i].Nome, golsAleatorios(10), arrayTimes[j].Nome, golsAleatorios(10));
                        arrayTimes[i].AdicionarGolsJogador(jogadorAleatorio(arrayTimes[i].Jogadores.ToArray()));
                        arrayTimes[j].AdicionarGolsJogador(jogadorAleatorio(arrayTimes[j].Jogadores.ToArray()));

                        if (arrayTimes[i].Gols == arrayTimes[j].Gols)
                        {
                            //chama o metodo AdicionarResultadosParaOsJogos onde recebera nome time, metodo numero de gols aleatorios de 1 a 10


                            //empate true , adiciona  Gols aos dois times
                            tabelaRodadas.Add(((arrayTimes[i].Nome, arrayTimes[i].Gols), (arrayTimes[j].Nome, arrayTimes[j].Gols)));
                            arrayTimes[i].AdicionarEmpates();
                            arrayTimes[j].AdicionarEmpates();

                            //atualizar percentagem
                        }
                        if (arrayTimes[i].Gols > arrayTimes[j].Gols)
                        {
                            //empate false , adiciona  Gols ao time vencedor

                            tabelaRodadas.Add(((arrayTimes[i].Nome, arrayTimes[i].Gols), (arrayTimes[j].Nome, arrayTimes[j].Gols)));
                            arrayTimes[i].AdicionarVitoria();
                            arrayTimes[j].AdicionarDerrotas();

                        }
                        if (arrayTimes[i].Gols < arrayTimes[j].Gols)
                        {
                            //empate false , adiciona  Gols ao time vencedor

                            tabelaRodadas.Add(((arrayTimes[i].Nome, arrayTimes[i].Gols), (arrayTimes[j].Nome, arrayTimes[j].Gols)));
                            arrayTimes[i].AdicionarDerrotas();
                            arrayTimes[j].AdicionarVitoria();
                        }

                    }
                    ListaDosResultadosPorRodada.Add(tabelaRodadas);

                    //Descomenta caso queira que os times não joguem fora de casa
                    //var timeList = arrayTimes.ToList();
                    //timeList.RemoveAt(i);
                    //arrayTimes = timeList.ToArray();
                }


                return ListaDosResultadosPorRodada;
            }

            return ListaDosResultadosPorRodada = null;
        }

    }
}

//!Todo  Regra de negocio usuario torcedor
//!Todo Metodos



// var timesRandomicos = Times.OrderByDescending(time => time.Pontos).ToArray();
//metodo gerar partidas precisa gerar partidas diferentes

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



//descomenta se quiser gerar partidas randomicas
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
//criar var e tirar da classe