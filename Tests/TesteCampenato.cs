using System;
using System.Collections.Generic;
using Domain;
using Xunit;

namespace Tests
{
    public class TesteCampeonato : Campeonato
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
        public void Deve_Retornar_Tabela_De__Acordo_com_Numero_de_Conflitos_e_Se_Usuario_for_Cbf_()
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
            var result = campeonato.GerarRodadas(new Cbf ("Adm") , 6);

            //then
            Assert.NotNull(result);
            Assert.Equal(6, result.Count);

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
                new JogadorCampeonato (new Guid(),"SpiderMan",5),
                new JogadorCampeonato (new Guid(),"Wolverine",2),
                new JogadorCampeonato (new Guid(),"Hulk",0),
                new JogadorCampeonato (new Guid(),"Thor",0),
                new JogadorCampeonato (new Guid(),"Tony stark",1),
                new JogadorCampeonato (new Guid(),"Doutor Manhatan",2),
                new JogadorCampeonato (new Guid(),"Rosarch",0),
                new JogadorCampeonato (new Guid(),"Hellboy",0),
                new JogadorCampeonato (new Guid(),"Punisher",0),
                new JogadorCampeonato (new Guid(),"Spawn",0),
                new JogadorCampeonato (new Guid(),"Squal",0),
                new JogadorCampeonato (new Guid(),"Link",0),
                new JogadorCampeonato (new Guid(),"Solid Snake",0),
                new JogadorCampeonato (new Guid(),"Jaspion",0),
                new JogadorCampeonato (new Guid(),"Bruce Lee",1),
                new JogadorCampeonato (new Guid(),"Jason",0)
            };

            return jogadores;
        }

    }
}



