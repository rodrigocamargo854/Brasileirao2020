using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Time
    {
        public List<Jogador> Jogadores { get; private set; } = new List<Jogador>();
        public Jogador Artilheiro { get; private set; } 

        public string Nome { get; private set; }
        public Jogador JogadorComMaisGols { get; set; }
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
        private void removerJogador(Jogador jogador)
        {
            foreach (Jogador item in Jogadores)
            {
                if (jogador == item)
                {
                    Jogadores.Remove(item);
                }
            }
        }

        private void AddicionarPontosJogador(Jogador nome)
        {
            foreach (Jogador jogador in Jogadores)
            {
                if (jogador == nome)
                {
                    jogador.MarcarPontos();
                }
            }

            //todo adicionar em uma variavel artilheiro para adicionar na lista

        }

        private void adicionarArtilheiro()
        {

            var pontosJogador = 0;
            foreach (Jogador jogador in Jogadores)
            {
                if (jogador.Pontos > pontosJogador)
                {
                    pontosJogador = jogador.Pontos;
                    JogadorComMaisGols = jogador;
                }
            }

            Artilheiro = JogadorComMaisGols;
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