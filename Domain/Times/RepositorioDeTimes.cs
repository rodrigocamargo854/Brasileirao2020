using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Jogadores;

namespace Domain.Times
{
    public static class RespositorioDeTimes
    {
        private static List<Time> times = new List<Time>();
        public static IReadOnlyCollection<Time> Times => times;



        // metodos do repositorio de jogadores

        public static void AdicionarTime(Time time)
        {
            times.Add(time);
        }

        public static List<Time> ObterTimes()
        {
            return times;
        }

        public static Time BuscarTime(Guid idTime)
        {
            return times.FirstOrDefault(x => x.Id == idTime);
        }

        public static void RemoverTime(Guid idTime)
        {
            times.Remove(times.FirstOrDefault(u => u.Id == idTime));
        }

        public static Guid RetornarIdTime(string nomeTime)
        {
            var timeId = times.FirstOrDefault(x => x.Nome == nomeTime).Id;

            return timeId;
        }

        public static void AdicionarListadeTimes(List<Time> listaDeTimes)
        {

            for (int i = 0; i < listaDeTimes.Count; i++)
            {
                if (listaDeTimes[i].Validar().eValido)
                {
                    //acessa o metodo adicionar usuario pela classe UsuarioRepositorio
                    times.Add(listaDeTimes[i]);

                }

            }


        }

        private static List<Time> GeradorListaDeTimes()
        {

            var Time1 = new Time("Flamengo");
            var Time2 = new Time("Atletico");
            var Time3 = new Time("Palmeiras");
            var Time4 = new Time("Santos");
            var Time5 = new Time("Jabaquara");
            var Time6 = new Time("Bahia");
            var Time7 = new Time("Ituano");
            var Time8 = new Time("Portuguesa");

            Time2.adicionarJogador(new List<Jogador>() {
                new JogadorCampeonato ("Galvao"),
                    new JogadorCampeonato ("Bruno"),
                    new JogadorCampeonato ("Jorge salvador"),
                    new JogadorCampeonato ("Vamputo"),
                    new JogadorCampeonato ("Jorginho satan"),
                    new JogadorCampeonato ("Dinamite"),
                    new JogadorCampeonato ("fogonorabo"),
                    new JogadorCampeonato ("ligeirinho"),
                    new JogadorCampeonato ("CaiCai"),
                    new JogadorCampeonato ("Banheirinha"),
                    new JogadorCampeonato ("deixaQeuEuChuto"),
                    new JogadorCampeonato ("PassaPMim"),
                    new JogadorCampeonato ("MarcaMarca"),
                    new JogadorCampeonato ("Michele"),
                    new JogadorCampeonato ("caixeta"),
                    new JogadorCampeonato ("Henrique Alves")
            });

            Time3.adicionarJogador(new List<Jogador>() {
                new JogadorCampeonato ("Tancredão"),
                    new JogadorCampeonato ("Sarrafo"),
                    new JogadorCampeonato ("correParaEsquerda"),
                    new JogadorCampeonato ("TocaParaMim"),
                    new JogadorCampeonato ("Banqguelinho"),
                    new JogadorCampeonato ("Jorginho PéDeMoça"),
                    new JogadorCampeonato ("MataMata"),
                    new JogadorCampeonato ("Valderanho"),
                    new JogadorCampeonato ("Joca gado"),
                    new JogadorCampeonato ("Biro Biro"),
                    new JogadorCampeonato ("Buzuang"),
                    new JogadorCampeonato ("Zumbido Nouvido"),
                    new JogadorCampeonato ("coronga"),
                    new JogadorCampeonato ("coronguinha"),
                    new JogadorCampeonato ("Lucas Tatu"),
                    new JogadorCampeonato ("Carlos Bezerra")
            });
            Time4.adicionarJogador(new List<Jogador>() {
                new JogadorCampeonato ("Max"),
                    new JogadorCampeonato ("Tancredo neves"),
                    new JogadorCampeonato ("Afonso Pena"),
                    new JogadorCampeonato ("Collor"),
                    new JogadorCampeonato ("Lula robaroba"),
                    new JogadorCampeonato ("Luquinhas"),
                    new JogadorCampeonato ("Felipe henrique"),
                    new JogadorCampeonato ("Juca Chaves"),
                    new JogadorCampeonato ("Walmir pédeonça"),
                    new JogadorCampeonato ("Tirulipa"),
                    new JogadorCampeonato ("TakeoverDance"),
                    new JogadorCampeonato ("Michael jackson"),
                    new JogadorCampeonato ("Henrique alves"),
                    new JogadorCampeonato ("Don ramon"),
                    new JogadorCampeonato ("Pedro pedrera"),
                    new JogadorCampeonato ("Jacinto ")
            });
            Time5.adicionarJogador(new List<Jogador>() {
                new JogadorCampeonato ("Galvao"),
                    new JogadorCampeonato ("Bruno"),
                    new JogadorCampeonato ("Jorge salvador"),
                    new JogadorCampeonato ("Vamputo"),
                    new JogadorCampeonato ("Jorginho satan"),
                    new JogadorCampeonato ("Dinamite"),
                    new JogadorCampeonato ("fogonorabo"),
                    new JogadorCampeonato ("ligeirinho"),
                    new JogadorCampeonato ("CaiCai"),
                    new JogadorCampeonato ("Banheirinha"),
                    new JogadorCampeonato ("deixaQeuEuChuto"),
                    new JogadorCampeonato ("PassaPMim"),
                    new JogadorCampeonato ("MarcaMarca"),
                    new JogadorCampeonato ("Michele"),
                    new JogadorCampeonato ("caixeta"),
                    new JogadorCampeonato ("Henrique Alves")
            });
            Time6.adicionarJogador(new List<Jogador>() {
                new JogadorCampeonato ("Galvao"),
                    new JogadorCampeonato ("Bruno"),
                    new JogadorCampeonato ("Jorge salvador"),
                    new JogadorCampeonato ("Vamputo"),
                    new JogadorCampeonato ("Jorginho satan"),
                    new JogadorCampeonato ("Dinamite"),
                    new JogadorCampeonato ("fogonorabo"),
                    new JogadorCampeonato ("ligeirinho"),
                    new JogadorCampeonato ("CaiCai"),
                    new JogadorCampeonato ("Banheirinha"),
                    new JogadorCampeonato ("deixaQeuEuChuto"),
                    new JogadorCampeonato ("PassaPMim"),
                    new JogadorCampeonato ("MarcaMarca"),
                    new JogadorCampeonato ("Michele"),
                    new JogadorCampeonato ("caixeta"),
                    new JogadorCampeonato ("Henrique Alves")
            });
            Time7.adicionarJogador(new List<Jogador>() {
                new JogadorCampeonato ("Galvao"),
                    new JogadorCampeonato ("Bruno"),
                    new JogadorCampeonato ("Jorge salvador"),
                    new JogadorCampeonato ("Vamputo"),
                    new JogadorCampeonato ("Jorginho satan"),
                    new JogadorCampeonato ("Dinamite"),
                    new JogadorCampeonato ("fogonorabo"),
                    new JogadorCampeonato ("ligeirinho"),
                    new JogadorCampeonato ("CaiCai"),
                    new JogadorCampeonato ("Banheirinha"),
                    new JogadorCampeonato ("deixaQeuEuChuto"),
                    new JogadorCampeonato ("PassaPMim"),
                    new JogadorCampeonato ("MarcaMarca"),
                    new JogadorCampeonato ("Michele"),
                    new JogadorCampeonato ("caixeta"),
                    new JogadorCampeonato ("Henrique Alves")
            });
            Time8.adicionarJogador(new List<Jogador>() {
                new JogadorCampeonato ("Galvao"),
                    new JogadorCampeonato ("Bruno"),
                    new JogadorCampeonato ("Jorge salvador"),
                    new JogadorCampeonato ("Vamputo"),
                    new JogadorCampeonato ("Jorginho satan"),
                    new JogadorCampeonato ("Dinamite"),
                    new JogadorCampeonato ("fogonorabo"),
                    new JogadorCampeonato ("ligeirinho"),
                    new JogadorCampeonato ("CaiCai"),
                    new JogadorCampeonato ("Banheirinha"),
                    new JogadorCampeonato ("deixaQeuEuChuto"),
                    new JogadorCampeonato ("PassaPMim"),
                    new JogadorCampeonato ("MarcaMarca"),
                    new JogadorCampeonato ("Michele"),
                    new JogadorCampeonato ("caixeta"),
                    new JogadorCampeonato ("Henrique Alves")
            });

            Time1.adicionarJogador(new List<Jogador>() {
                new JogadorCampeonato ("Galvao"),
                    new JogadorCampeonato ("Bruno"),
                    new JogadorCampeonato ("Jorge salvador"),
                    new JogadorCampeonato ("Vamputo"),
                    new JogadorCampeonato ("Jorginho satan"),
                    new JogadorCampeonato ("Dinamite"),
                    new JogadorCampeonato ("fogonorabo"),
                    new JogadorCampeonato ("ligeirinho"),
                    new JogadorCampeonato ("CaiCai"),
                    new JogadorCampeonato ("Banheirinha"),
                    new JogadorCampeonato ("deixaQeuEuChuto"),
                    new JogadorCampeonato ("PassaPMim"),
                    new JogadorCampeonato ("MarcaMarca"),
                    new JogadorCampeonato ("Michele"),
                    new JogadorCampeonato ("caixeta"),
                    new JogadorCampeonato ("Henrique Alves")
            });

            var ListaDeTimes = new List<Time>() { Time1, Time2, Time3, Time4, Time5, Time6, Time7, Time8 };

            return ListaDeTimes;

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