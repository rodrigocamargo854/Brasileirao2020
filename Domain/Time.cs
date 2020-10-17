
using System.Collections.Generic;

namespace Domain
{
    public class Time
    {
        public string Nome { get; set; }
        public List<Jogador> Jogadores { get; set; } =  new List<Jogador> ();
        public int PontosTime { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public int Empates { get; set; }
        public double PorcentagemDeAproveitamento { get; set; }
        public int GolsPro { get; set; }
        public int GolsContra { get; set; }

        public Time(string nome)
        {
            Nome = nome;
            
        }

        public bool AddJogador(List<Jogador> jogadores)
        {


            if (Jogadores.Count >= 16 && Jogadores.Count <= 32)
            {
                Jogadores = jogadores;

                return true;
            }

            return false;
        }


        //metodo para remover um jogador
        public void RemoveJogador(Jogador jogador)
        {
            foreach (Jogador item in Jogadores)
            {
                if (jogador == item)
                {
                    Jogadores.Remove(item);
                }
            }

        }

        // public void AddPontosJogador()
        // {


        // }

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


        // public void AddArtilheiros()
        // {

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