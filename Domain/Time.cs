using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Time
    {
        public List<Jogador> Jogadores { get; private set; } = new List<Jogador>();
        public Jogador Artilheiro { get; private set; }

        public string Nome { get; private set; }
        public int Gols { get; set; }

        public Jogador JogadorComMaisGols { get; set; }
        public int Vitorias { get; private set; }
        public int Derrotas { get; private set; }
        public int Empates { get; private set; }
        public int GolsContra { get; private set; }
        public int GolsPro { get; private set; }

        public int Pontos { get; set; }
        public Time(string nome)
        {
            Nome = nome;
        }

        public bool adicionarJogador(List<Jogador> jogadores)
        {
            if (jogadores.Count > 15 && jogadores.Count < 33)
            {
                Jogadores = jogadores;

                return true;
            }
            return false;
        }

        //metodo para remover um jogador
        public void removerJogador(Jogador jogador)
        {
            foreach (Jogador item in Jogadores)
            {
                if (jogador == item)
                {
                    Jogadores.Add(item);
                }
            }
        }

        public void AddicionarGolsJogador(string nome)
        {

            var jogador = Jogadores.FirstOrDefault(j => j.Nome == nome);
            // jogador?.MarcarGols(); garante que o jogador so ira marcar gols se nao for null

            if (jogador != null)
            {
                jogador.MarcarGols();

            }

        }

        public Jogador adicionarArtilheiro()
        {

            var pontosJogador = 0;
            foreach (Jogador jogador in Jogadores)
            {
                if (jogador.Gols > pontosJogador)
                {
                    pontosJogador = jogador.Gols;
                    JogadorComMaisGols = jogador;
                }
            }

            Artilheiro = JogadorComMaisGols;
            return Artilheiro;
        }

        // public void AddPontosTime()
        // {

        // }

        public void AdicionarVitoria()
        {
            Vitorias++;
            Pontos+= 3;
        }

        public void AdicionarEmpates()
        {
            Empates++;
            Pontos++;
        }

        public void AdicionarGolscontra()
        {
            GolsContra++;
        }
        public void AdicionarGolspro()
        {
            GolsPro++;
        }

         public void AdicionarDerrotas()
        {
            GolsPro++;
        }

    }
}