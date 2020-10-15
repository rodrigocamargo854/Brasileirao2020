using System.Collections.Generic;

namespace dev.Brasileirao2020
{
    public class Cbf

    {
        //propriedades para o nome do time e uma lista para armazenar os jogadores
        public string NameTeam { get; set; }
        public List<string> Players { get; set; }

        public Cbf(string nameTeam, List<string> players)
        {
            NameTeam = nameTeam;
            Players = players;
        }

        public void AddPlayer(List<string> players)
        {
            foreach (var item in players)
            {
                Players.Add(item);

            }
        }

        public void AddPlayer(string players)
        {
            foreach (var item in players)
            {
                Players.Remove(item);

            }



        }
    }