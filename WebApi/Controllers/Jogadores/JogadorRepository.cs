using System;
using System.Collections.Generic;

namespace WebApi.Controller 
{

    static class UsersRepository 
    {
        private static List<JogadorResponse> _jogadores = new List<JogadorResponse> ();
        public static IReadOnlyCollection<JogadorResponse> Jogadores => _jogadores;
        

        //Adiciona um jogador
        public static void Add (JogadorResponse jogador) 
        {
            _jogadores.Add (jogador);
        }
    }

}