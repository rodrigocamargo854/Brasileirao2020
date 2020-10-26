using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Time
    {
        public List<Jogador> Jogadores { get; private set; } = new List<Jogador>();
        public Jogador Artilheiro { get; private set; }

        public string Nome { get; private set; }
        public int Pontos { get;  set; }

        public Jogador JogadorComMaisGols { get; set; }
        public int Vitorias { get; private set; }
        public int Derrotas { get; private set; }
        
        public Time(string nome )
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

        public void AddicionarPontosJogador(Jogador nome)
        {
            foreach (Jogador jogador in Jogadores)
            {
                if (jogador == nome)
                {
                    jogador.MarcarGols();
                }
            }

            //todo adicionar em uma variavel artilheiro para adicionar na lista

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

        // public void AddVitoria()
        // {
        //     Vitorias ++;
        //     return true;
        // }

        // public void AddEmpates()
        // {
        //     Empates ++;
        //     return true;
        // }

        // public void Goldcontra()
        // {
        //     GolsContra ++;
        //     return true;
        // }
        // public void Golspro()
        // {
        //     GolsPro ++;
        //     return true;
        // }

    }
}