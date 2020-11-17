




using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Jogadores;
using Domain.Usuarios;

namespace Domain
{
    public class Estatisticas
    {
        public int Vitorias { get; set; }
        public int PontosJogador { get; set; }
        public int Derrotas { get; set; }
        public int Empates { get; set; }
        public double PorcentagemDeAproveitamento { get; set; }
        public int GolsPro { get; set; }
        public int GolsContra { get; set; }


        public List<(string, int)> ExibirVitoriasCampeonato(Usuario usuario, List<Time> timesDaRodada)
        {
            var vitoriasPorTime = new List<(string nomeTime, int vitorias)>();

            if (usuario is Cbf || usuario is Torcedor)
            {

                for (int i = 0; i < timesDaRodada.Count; i++)
                {
                    if (timesDaRodada[i].Vitorias > 0)
                    {
                        vitoriasPorTime.Add((timesDaRodada[i].Nome, timesDaRodada[i].Vitorias));
                    }

                }
                return vitoriasPorTime;
            }
            return null;
        }

        public List<(string, int)> ExibirDerrotasCampeonato(Usuario usuario, List<Time> timesBrasileirao2020)
        {

            if (usuario is Cbf || usuario is Torcedor)
            {
                var listaDeDerrotas = new List<(string, int)>();

                for (int i = 0; i < timesBrasileirao2020.Count; i++)
                {
                    listaDeDerrotas.Add((timesBrasileirao2020[i].Nome, timesBrasileirao2020[i].Derrotas));
                }

                return listaDeDerrotas;
            }
            return null;
        }

        public List<(string, int)> ExibirPontosDeCadaTimeCampeonato(Usuario usuario, List<Time> timesBrasileirao2020)
        {
            if (usuario is Cbf || usuario is Torcedor)
            {
                var pontosDoTime = new List<(string, int)>();

                for (int i = 0; i < timesBrasileirao2020.Count; i++)
                {
                    pontosDoTime.Add((timesBrasileirao2020[i].Nome, timesBrasileirao2020[i].Pontos));
                }

                return pontosDoTime;
            }
            return null;
        }

        public List<(string, int)> ExibirEPorcentagemDeAproveitamento(Usuario usuario, List<Time> times)
        {
            var porcentagemDeAproveitamentoDeCadaTime = new List<(string, int)>();
            if (usuario is Cbf || usuario is Torcedor)
            {
                for (int i = 0; i < times.Count; i++)
                {
                    //retorna a procentagem de aproveitamento de cada time de acordo com a pontuação 
                    //que poedria alcançar
                    porcentagemDeAproveitamentoDeCadaTime.Add(((times[i].Nome), (times[i].Pontos * 24) / 100));

                }
                return porcentagemDeAproveitamentoDeCadaTime.ToList();

            }

            return null;





        }

        public List<(string, int)> ExibirGolsContra(Usuario usuario, List<Time> timesBrasileirao2020)
        {
            if (usuario is Cbf || usuario is Torcedor)
            {

                var golsContraTimes = new List<(string, int)>();

                for (int i = 0; i < golsContraTimes.Count; i++)
                {
                    golsContraTimes.Add((timesBrasileirao2020[i].Nome, timesBrasileirao2020[i].GolsContra));
                }

                return golsContraTimes;
            }
            return null;
        }

        public List<(string, int)> ExibirGolsCampeonato(Usuario usuario, List<Time> timesBrasileirao2020)
        {
            if (usuario is Cbf || usuario is Torcedor)
            {

                var golsCampeonato = new List<(string, int)>();

                for (int i = 0; i < timesBrasileirao2020.Count; i++)
                {
                    golsCampeonato.Add((timesBrasileirao2020[i].Nome, timesBrasileirao2020[i].Gols));
                }

                return golsCampeonato;
            }
            return null;
        }

        public List<(string, int, Guid)> ExibirArtilheirosDoCampeonato(Usuario usuario, List<List<Jogador>> timesBrasileirao2020)
        {
            var artilheirosBrasileirao = new List<(string nome, int gols, Guid id)> { };

            if (usuario is Cbf || usuario is Torcedor)
            {
                foreach (var time in timesBrasileirao2020)
                {
                    for (int i = 0; i < time.Count; i++)
                    {
                        if (time[i].Gols > 0)
                        {
                            artilheirosBrasileirao.Add((time[i].Nome, time[i].Gols, time[i].Id));
                        }
                    }
                }
                return (List<(string, int, Guid)>)artilheirosBrasileirao.OrderBy(item => item.gols).TakeLast(5).ToList();
            }

            return null;
        }

        public List<(string, int)> ExibirTimesRebaixados(Usuario usuario, List<Time> timesBrasileirao2020)
        {
            var artilheirosBrasileirao = new List<(string nome, int pontosTime)> { };

            if (usuario is Cbf || usuario is Torcedor)
            {

                for (int i = 0; i < timesBrasileirao2020.Count; i++)
                {

                    artilheirosBrasileirao.Add((timesBrasileirao2020[i].Nome, timesBrasileirao2020[i].Gols));

                }

                return (List<(string, int)>)artilheirosBrasileirao.OrderBy(item => item.pontosTime).Reverse().TakeLast(5).ToList();
            }
            return null;

        }

    }
}
