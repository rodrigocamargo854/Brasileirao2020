using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Jogadores
{
    public static class RespositorioDeJogadores
    {
        private static List<Jogador> jogadores = new List<Jogador>();
        public static IReadOnlyCollection<Jogador> Jogadores => jogadores;



        // metodos do repositorio de jogadores

        public static void AdicionarJogador(Jogador jogador)
        {
            jogadores.Add(jogador);
        }

        public static List<Jogador> ObterJogadores()
        {
            return jogadores;
        }

        public static Jogador BuscarJogador(Guid idJogador)
        {
            return jogadores.FirstOrDefault(x => x.Id == idJogador);
        }

        public static void RemoverJogador(Guid idJogador)
        {
            jogadores.Remove(jogadores.FirstOrDefault(u => u.Id == idJogador));
        }

        public static Guid RetornarIdJogador(string name)
        {
            var jogadorId = jogadores.FirstOrDefault(x => x.Nome == name).Id;

            return jogadorId;
        }

        public static void AdicionarListaDeJogadores(List<Jogador> listaDeJogadores)
        {

            for (int i = 0; i < listaDeJogadores.Count; i++)
            {
                if (listaDeJogadores[i].Validar().eValido)
                {
                    //acessa o metodo adicionar usuario pela classe UsuarioRepositorio
                    jogadores.Add(listaDeJogadores[i]);

                }

            }


        }


        public static List<Jogador> GeradorListaJogadores()
        {

            var jogadores = new List<Jogador>()

            {
                new Jogador ("SpiderMan"),
                new Jogador ("Wolverine"),
                new Jogador ("Hulk"),
                new Jogador ("Thor"),
                new Jogador ("Tony stark"),
                new Jogador ("Doutor Manhatan"),
                new Jogador ("Rosarch"),
                new Jogador ("Hellboy"),
                new Jogador ("Punisher"),
                new Jogador ("Spawn"),
                new Jogador ("Squal"),
                new Jogador ("Link"),
                new Jogador ("Solid Snake"),
                new Jogador ("Jaspion"),
                new Jogador ("Bruce Lee"),
                new Jogador ("Jason")
            };
            return jogadores;
        }


    }
}