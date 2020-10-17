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
            var result = campeonato.AddTimes(Time, cbf);


            //then

            Assert.True(result);

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        // !Metodo criador de times

        public List<Time> GeradorListaDeTimes()
        {

            var Time2 = new Time("Atletico");
            var Time3 = new Time("Palmeiras");
            var Time1 = new Time("Flamengo");
            var Time4 = new Time("Santos");
            var Time5 = new Time("Jabaquara");
            var Time6 = new Time("Atletico");
            var Time7 = new Time("Ituano");
            var Time8 = new Time("Portuguesa");

            Time1.AddJogador(GeradorListaJogadores());
            Time2.AddJogador(GeradorListaJogadores());
            Time3.AddJogador(GeradorListaJogadores());
            Time4.AddJogador(GeradorListaJogadores());
            Time5.AddJogador(GeradorListaJogadores());
            Time6.AddJogador(GeradorListaJogadores());
            Time7.AddJogador(GeradorListaJogadores());
            Time8.AddJogador(GeradorListaJogadores());

            var ListaDeTimes = new List<Time>() { Time1, Time2, Time3, Time4, Time5, Time6, Time7, Time8 };

            return ListaDeTimes;

        }
        
        // !Metodo criador de jogador
        public List<Jogador> GeradorListaJogadores()
        {

            var jogadoresAtletico = new List<Jogador>()
            {
                new JogadorCampeonato ("ximira"),
                new JogadorCampeonato ("teteco"),
                new JogadorCampeonato ("Tatuane tiral"),
                new JogadorCampeonato ("ximira"),
                new JogadorCampeonato ("teteco"),
                new JogadorCampeonato ("Tatuane tiral"),
                new JogadorCampeonato ("ximira"),
                new JogadorCampeonato ("teteco"),
                new JogadorCampeonato ("Tatuane tiral"),
                new JogadorCampeonato ("ximira"),
                new JogadorCampeonato ("teteco"),
                new JogadorCampeonato ("Tatuane tiral"),
                new JogadorCampeonato ("ximira"),
                new JogadorCampeonato ("teteco"),
                new JogadorCampeonato ("Tatuane tiral"),
                new JogadorCampeonato ("Tatuane tiral")

            };

            return jogadoresAtletico;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////
    }
}



