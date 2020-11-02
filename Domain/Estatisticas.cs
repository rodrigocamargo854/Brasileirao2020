




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
                    vitoriasPorTime.Add((timesDaRodada[i].Nome,timesDaRodada[i].Vitorias));
                }

            }
            return vitoriasPorTime;

        }

        public List<Time> ExibirDerrotasCampeonato()
        {
            var listaDeDerrotas = new List<Time>();

            return listaDeDerrotas;
        }

        public void ExibirEPorcentagemDeAproveitamento()
        {

        }

        public void ExibirGolsContra()
        {

        }

        public void ExibirGolsCampeonato()
        {

        }

        public void ExibirArtilheirosDoCampeonato()
        {

        }



    }
}