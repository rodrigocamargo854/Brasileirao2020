using System;
using System.Collections.Generic;
using Domain;
using Xunit;

namespace Tests
{
    public class TesteCampeonato
    {
        [Fact]
        public void Deve_retornar_Verdadeiro_ao_adicionar_O_Time_No_Campeonato_se_O_Usuario_For_Cbf()
        {

            // !cria o time
            //given
            var campeonato = new Campeonato();
            var Time = GeradorListaDeTimes();

            //criação de usuario para validacao da inserção de times
            var cbf = new Cbf("Administrador");//usuario cbf para validar a inserção de dados


            //when
            //Metodo criado no escopo gerador de jogadores
            var result = campeonato.AdicionarTimes(Time, cbf);


            //then

            Assert.True(result);
            Assert.NotEmpty(campeonato.Times);
            
        }
        
        [Fact]
        public void Deve_retornar_Falso_Se_O_Usuarios_Nao_for_Cbf()
        {

            // !cria o time
            //given
            var campeonato = new Campeonato();
            var Time = GeradorListaDeTimes();
            //criação de usuario para validacao da inserção de times
            var torcedor = new Torcedor("Torcedor");//usuario cbf para validar a inserção de dados


            //when
            //Metodo criado no escopo gerador de jogadores
            var result = campeonato.AdicionarTimes(Time, torcedor);
            

            //then

            Assert.False(result);
            Assert.Empty(campeonato.Times);

        }
        

        [Fact]
        public void Deve_Retornar_Tabela_de_conflitos_de_Times_Se_Usuario_For_Cbf()
        {

            // !cria o time
            //given
            var campeonato = new Campeonato();
            var Time = GeradorListaDeTimes();

            //criação de usuario para validacao da inserção de times
            var cbf = new Cbf("Administrador");//usuario cbf para validar a inserção de dados


            //when
            //Metodo criado no escopo gerador de jogadores
            var times = campeonato.AdicionarTimes(Time, cbf);

            // todo entrar com listTimes e usuarios
            var result = campeonato.GerarPrimeiraRodada(new Cbf ("Adm") );

            //then
            Assert.NotNull(result);


        }


        // !Metodo criador de times

        private List<Time> GeradorListaDeTimes()
        {

            var Time2 = new Time("Atletico");
            var Time3 = new Time("Palmeiras");
            var Time1 = new Time("Flamengo");
            var Time4 = new Time("Santos");
            var Time5 = new Time("Jabaquara");
            var Time6 = new Time("Atletico");
            var Time7 = new Time("Ituano");
            var Time8 = new Time("Portuguesa");

            Time2.adicionarJogador(GeradorListaJogadores());
            Time3.adicionarJogador(GeradorListaJogadores());
            Time4.adicionarJogador(GeradorListaJogadores());
            Time5.adicionarJogador(GeradorListaJogadores());
            Time6.adicionarJogador(GeradorListaJogadores());
            Time7.adicionarJogador(GeradorListaJogadores());
            Time8.adicionarJogador(GeradorListaJogadores());
            Time1.adicionarJogador(GeradorListaJogadores());

            var ListaDeTimes = new List<Time>() { Time1, Time2, Time3, Time4, Time5, Time6, Time7, Time8 };

            return ListaDeTimes;

        }

        // !Metodo criador de jogador
        private List<Jogador> GeradorListaJogadores()
        {

            var jogadores = new List<Jogador>()
            {
                new JogadorCampeonato ("SpiderMan"),
                new JogadorCampeonato ("Wolverine"),
                new JogadorCampeonato ("Hulk"),
                new JogadorCampeonato ("Thor"),
                new JogadorCampeonato ("Tony stark"),
                new JogadorCampeonato ("Doutor Manhatan"),
                new JogadorCampeonato ("Rosarch"),
                new JogadorCampeonato ("Hellboy"),
                new JogadorCampeonato ("Punisher"),
                new JogadorCampeonato ("Spawn"),
                new JogadorCampeonato ("Squal"),
                new JogadorCampeonato ("Link"),
                new JogadorCampeonato ("Solid Snake"),
                new JogadorCampeonato ("Jaspion"),
                new JogadorCampeonato ("Bruce Lee"),
                new JogadorCampeonato ("Jason")
            };

            return jogadores;
        }

    }
}



