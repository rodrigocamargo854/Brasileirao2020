




using System.Collections.Generic;

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


        public List<(string, int)> ExibirVitoriasCampeonato(List<Time> timesDaRodada)
        {
            var vitoriasPorTime = new List<(string nomeTime, int vitorias)>();

            for (int i = 0; i < timesDaRodada.Count; i++)
            {
                if (timesDaRodada[i].Vitorias > 0)
                {
                    vitoriasPorTime.Add((timesDaRodada[i].Nome, timesDaRodada[i].Vitorias));
                }

            }
            return vitoriasPorTime;

        }

        public List<(string, int)> ExibirDerrotasCampeonato(List<Time> timesBrasileirao2020)
        {
            var listaDeDerrotas = new List<(string, int)>();

            for (int i = 0; i < timesBrasileirao2020.Count; i++)
            {
                listaDeDerrotas.Add((timesBrasileirao2020[i].Nome, timesBrasileirao2020[i].Derrotas));
            }

            return listaDeDerrotas;
        }

        public List<(string, int)> ExibirPontosDeCadaTimeCampeonato(List<Time> timesBrasileirao2020)
        {
            var pontosDoTime = new List<(string, int)>();

            for (int i = 0; i < timesBrasileirao2020.Count; i++)
            {
                pontosDoTime.Add((timesBrasileirao2020[i].Nome, timesBrasileirao2020[i].Pontos));
            }

            return pontosDoTime;
        }

        public void ExibirEPorcentagemDeAproveitamento()
        {

        }

        public List<(string, int)> ExibirGolsContra(List<Time> timesBrasileirao2020)
        {
            var golsContraTimes = new List<(string, int)>();

            for (int i = 0; i < golsContraTimes.Count; i++)
            {
                golsContraTimes.Add((timesBrasileirao2020[i].Nome, timesBrasileirao2020[i].GolsContra));
            }

            return golsContraTimes;
        }

        public List<(string, int)> ExibirGolsCampeonato(List<Time> timesBrasileirao2020)
        {
            var golsCampeonato = new List<(string, int)>();

            for (int i = 0; i < timesBrasileirao2020.Count; i++)
            {
                golsCampeonato.Add((timesBrasileirao2020[i].Nome, timesBrasileirao2020[i].Gols));
            }

            return golsCampeonato;

        }

        public void ExibirArtilheirosDoCampeonato(List<Jogador> jogadoresCampeonato)
        {


        }



    }
}