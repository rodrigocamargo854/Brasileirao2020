using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace WebApi.Controller
{

    public class TimeResponse
    {
        public List<JogadorResponse> Jogadores { get; private set; } = new List<JogadorResponse>();
        public JogadorResponse Artilheiro { get; private set; }

        public string Nome { get; private set; }
        public int Gols { get; set; }

        public JogadorResponse JogadorComMaisGols { get; set; }
        public int Vitorias { get; private set; }
        public int Derrotas { get; private set; }
        public int Empates { get; private set; }
        public int GolsContra { get; private set; }
        public int GolsPro { get; private set; }

        public int Pontos { get; set; }
        public TimeResponse(string nome)
        {
            Nome = nome;
        }

        public bool adicionarJogador(List<JogadorResponse> jogadores)
        {
            if (jogadores.Count > 15 && jogadores.Count < 33)
            {
                Jogadores = jogadores;

                return true;
            }
            return false;
        }

        //metodo para remover um jogador
        public void removerJogador(JogadorResponse jogador)
        {
            foreach (JogadorResponse item in Jogadores)
            {
                if (jogador == item)
                {
                    Jogadores.Add(item);
                }
            }
        }

        public void AdicionarGolsJogador(Guid id)
        {

            var jogador = Jogadores.FirstOrDefault(j => j.Id == id);
            // jogador?.MarcarGols(); garante que o jogador so ira marcar gols se nao for null

            // if (jogador != null)
            // {
            //     jogador.MarcarGols();

            // }

        }

        public JogadorResponse adicionarArtilheiro()
        {

            var pontosJogador = 0;

            foreach (JogadorResponse jogador in Jogadores)
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
            Pontos += 3;
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
            Derrotas++;
        }

    }
}


