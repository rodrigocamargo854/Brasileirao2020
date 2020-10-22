namespace Domain
{
    public class Estatisticas
    {
        public int Vitorias { get; set; }
        public int PontosJogador { get; set; } = 0;
        public int Derrotas { get; set; }
        public int Empates { get; set; }
        public double PorcentagemDeAproveitamento { get; set; }
        public int GolsPro { get; set; }
        public int GolsContra { get; set; }
    }
}