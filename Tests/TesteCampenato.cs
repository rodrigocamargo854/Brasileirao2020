using System;
using System.Collections.Generic;
using System.Linq;
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
            var cbf = new Cbf("Administrador"); //usuario cbf para validar a inserção de dados

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
            var torcedor = new Torcedor("Torcedor"); //usuario cbf para validar a inserção de dados

            //when
            //Metodo criado no escopo gerador de jogadores
            var result = campeonato.AdicionarTimes(Time, torcedor);

            //then

            Assert.False(result);
            Assert.Empty(campeonato.Times);

        }

        [Fact]
        public void Deve_Retornar_Ponto_ao_Adicionado_Ao_Time_Passado_Como_Parametro()
        {

            // !cria o time
            //given
            var campeonato = new Campeonato();
            var Time = GeradorListaDeTimes();

            //criação de usuario para validacao da inserção de times
            var cbf = new Cbf("Admin"); //usuario cbf para validar a inserção de dados

            //when
            //Metodo criado no escopo gerador de jogadores
            campeonato.AdicionarTimes(Time, cbf);
            var jogosPrimieroaRodada = campeonato.GerarPrimeiraRodada(cbf);

            campeonato.AdicionarGolsAoJogo("Santos", 2, "Ituano", 2);

            var result = campeonato.Times.FirstOrDefault(time => time.Nome == "Santos").Gols;

            // AdicionarPontosAoTime(cbf,"Santos");

            //then
            //Cada time joga com todos times, em casa e fora de casa
            Assert.Equal(2, result);

        }

        [Fact]
        public void Deve_Retornar_PrimeiraRodada_se_o_usuario_for_cbf()
        {

            // !cria o time
            //given
            var assert = new List<List<((string, int), (string, int), string)>>();

            var campeonato = new Campeonato();
            var time = GeradorListaDeTimes();

            //criação de usuario para validacao da inserção de times
            var cbf = new Cbf("Admin"); //usuario cbf para validar a inserção de dados

            //when
            //Metodo criado no escopo gerador de jogadores
            var times = campeonato.AdicionarTimes(time, cbf);
            var primeiraRodada = campeonato.GerarPrimeiraRodada(cbf);


        }

        [Fact]

        public void Deve_Retornar_Resultado_Primeira_Rodada()
        {

            var campeonato = new Campeonato();
            var time = GeradorListaDeTimes();
            var vitoriasDaRodada = new Estatisticas();


            // inserir uma forma que apos o campeonato começar nao registrar novamente resultados do mesmo confronto
            //inserir Id nos confrontos
            //
            //criação de usuario para validacao da inserção de times
            var cbf = new Cbf("Admin"); //usuario cbf para validar a inserção de dados
            campeonato.AdicionarTimes(time, cbf);
            var primeiraRodada = campeonato.GerarPrimeiraRodada(cbf);

            campeonato.AdicionarGolsAoJogo("Flamengo", 1, "Portuguesa", 0);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Flamengo", campeonato.Times[0].Jogadores[1].Id);

            campeonato.AdicionarGolsAoJogo("Atletico", 1, "Ituano", 0);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Atletico", campeonato.Times[1].Jogadores[1].Id);

            campeonato.AdicionarGolsAoJogo("Palmeiras", 1, "Bahia", 0);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Palmeiras", campeonato.Times[2].Jogadores[1].Id);

            campeonato.AdicionarGolsAoJogo("Santos", 2, "Jabaquara", 0);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Santos", campeonato.Times[3].Jogadores[1].Id);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Santos", campeonato.Times[3].Jogadores[1].Id);
            campeonato.exibeResultadoPorRodada(cbf);

            var vitoriasPrimeiraRodada = vitoriasDaRodada.ExibirVitoriasCampeonato(campeonato.Times);


            Assert.Equal(1, primeiraRodada[0].Item1.Gols);
            Assert.Equal(0, primeiraRodada[0].Item2.Gols);
            Assert.Equal(1, primeiraRodada[1].Item1.Gols);
            Assert.Equal(0, primeiraRodada[1].Item2.Gols);
            Assert.Equal(1, primeiraRodada[2].Item1.Gols);
            Assert.Equal(0, primeiraRodada[2].Item2.Gols);
            Assert.Equal(2, primeiraRodada[3].Item1.Gols);
            Assert.Equal(0, primeiraRodada[3].Item2.Gols);

        }

        [Fact]
        public void Deve_Retornar_SegundaRodada_se_o_usuario_for_cbf()
        {

            // !cria o time
            //given

            var campeonato = new Campeonato();
            var time = GeradorListaDeTimes();

            //criação de usuario para validacao da inserção de times
            var cbf = new Cbf("Admin"); //usuario cbf para validar a inserção de dados

            //when
            //Metodo criado no escopo gerador de jogadores
            var times = campeonato.AdicionarTimes(time, cbf);
            var segundaRodada = campeonato.GerarSegundaRodada(cbf);

            Assert.Equal("Flamengo", segundaRodada[0].Item1.Nome);
            Assert.Equal("Ituano", segundaRodada[0].Item2.Nome);

        }

        [Fact]

        public void Deve_Retornar_Resultado_Segunda_Rodada()
        {

            var campeonato = new Campeonato();
            var time = GeradorListaDeTimes();
            // inserir uma forma que apos o campeonato começar nao registrar novamente resultados do mesmo confronto
            //inserir Id nos confrontos
            //
            //criação de usuario para validacao da inserção de times
            var cbf = new Cbf("Admin"); //usuario cbf para validar a inserção de dados
            campeonato.AdicionarTimes(time, cbf);
            var vitoriasDaRodada = new Estatisticas();

            var segundaRodada = campeonato.GerarSegundaRodada(cbf);

            campeonato.AdicionarGolsAoJogo("Flamengo", 1, "Ituano", 1);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Flamengo", campeonato.Times[0].Jogadores[1].Id);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Ituano", campeonato.Times[6].Jogadores[1].Id);


            campeonato.AdicionarGolsAoJogo("Portuguesa", 1, "Bahia", 2);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Portuguesa", campeonato.Times[7].Jogadores[1].Id);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Bahia", campeonato.Times[5].Jogadores[1].Id);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Bahia", campeonato.Times[5].Jogadores[1].Id);


            campeonato.AdicionarGolsAoJogo("Atletico", 1, "Jabaquara", 1);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Atletico", campeonato.Times[1].Jogadores[1].Id);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Jabaquara", campeonato.Times[4].Jogadores[1].Id);

            campeonato.AdicionarGolsAoJogo("Palmeiras", 1, "Santos", 5);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Palmeiras", campeonato.Times[2].Jogadores[1].Id);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Santos", campeonato.Times[3].Jogadores[1].Id);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Santos", campeonato.Times[3].Jogadores[1].Id);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Santos", campeonato.Times[3].Jogadores[1].Id);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Santos", campeonato.Times[3].Jogadores[1].Id);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Santos", campeonato.Times[3].Jogadores[1].Id);

            campeonato.exibeResultadoPorRodada(cbf);
            var vitoriasSegundaRodada = vitoriasDaRodada.ExibirVitoriasCampeonato(campeonato.Times);


            Assert.Equal(1, segundaRodada[0].Item1.Gols);
            Assert.Equal(1, segundaRodada[0].Item2.Gols);
            Assert.Equal(1, segundaRodada[1].Item1.Gols);
            Assert.Equal(2, segundaRodada[1].Item2.Gols);
            Assert.Equal(1, segundaRodada[2].Item1.Gols);
            Assert.Equal(1, segundaRodada[2].Item2.Gols);
            Assert.Equal(1, segundaRodada[3].Item1.Gols);
            Assert.Equal(5, segundaRodada[3].Item2.Gols);
            Assert.Equal(2, vitoriasSegundaRodada.Count());

        }

        [Fact]
        public void Deve_Retornar_TerceiraRodada_se_o_usuario_for_cbf()
        {

            // !cria o time
            //given
            var assert = new List<List<((string, int), (string, int), string)>>();

            var campeonato = new Campeonato();
            var time = GeradorListaDeTimes();

            //criação de usuario para validacao da inserção de times
            var cbf = new Cbf("Admin"); //usuario cbf para validar a inserção de dados

            //when
            //Metodo criado no escopo gerador de jogadores
            var times = campeonato.AdicionarTimes(time, cbf);
            var terceiraRodada = campeonato.GerarTerceiraRodada(cbf);

            Assert.Equal("Flamengo", terceiraRodada[0].Item1.Nome);
            Assert.Equal("Bahia", terceiraRodada[0].Item2.Nome);

        }

        [Fact]
        public void Deve_Retornar_Resultado_Terceira_Rodada()
        {

            var campeonato = new Campeonato();
            var time = GeradorListaDeTimes();
            var vitoriasDaRodada = new Estatisticas();

            // inserir uma forma que apos o campeonato começar nao registrar novamente resultados do mesmo confronto
            //inserir Id nos confrontos
            //
            //criação de usuario para validacao da inserção de times
            var cbf = new Cbf("Admin"); //usuario cbf para validar a inserção de dados
            campeonato.AdicionarTimes(time, cbf);

            var terceiraRodada = campeonato.GerarTerceiraRodada(cbf);

            campeonato.AdicionarGolsAoJogo("Flamengo", 1, "Bahia", 0);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Flamengo", campeonato.Times[0].Jogadores[1].Id);

            campeonato.AdicionarGolsAoJogo("Atletico", 1, "Jabaquara", 0);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Atletico", campeonato.Times[1].Jogadores[1].Id);

            campeonato.AdicionarGolsAoJogo("Ituano", 1, "Santos", 4);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Ituano", campeonato.Times[6].Jogadores[1].Id);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Santos", campeonato.Times[3].Jogadores[1].Id);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Santos", campeonato.Times[3].Jogadores[1].Id);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Santos", campeonato.Times[3].Jogadores[1].Id);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Santos", campeonato.Times[3].Jogadores[1].Id);

            campeonato.AdicionarGolsAoJogo("Portuguesa", 1, "Palmeiras", 0);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Portuguesa", campeonato.Times[7].Jogadores[1].Id);


            campeonato.exibeResultadoPorRodada(cbf);
            var vitoriasTerceiraRodada = vitoriasDaRodada.ExibirVitoriasCampeonato(campeonato.Times);



            Assert.Equal(1, terceiraRodada[0].Item1.Gols);
            Assert.Equal(0, terceiraRodada[0].Item2.Gols);
            Assert.Equal(1, terceiraRodada[1].Item1.Gols);
            Assert.Equal(0, terceiraRodada[1].Item2.Gols);
            Assert.Equal(1, terceiraRodada[2].Item1.Gols);
            Assert.Equal(4, terceiraRodada[2].Item2.Gols);
            Assert.Equal(1, terceiraRodada[3].Item1.Gols);
            Assert.Equal(0, terceiraRodada[3].Item2.Gols);
            Assert.Equal(2, vitoriasTerceiraRodada.Count());


        }

        [Fact]
        public void Deve_Retornar_QuartaRodada_se_o_usuario_for_cbf()
        {

            // !cria o time
            //given


            var campeonato = new Campeonato();
            var time = GeradorListaDeTimes();


            //criação de usuario para validacao da inserção de times
            var cbf = new Cbf("Admin"); //usuario cbf para validar a inserção de dados

            //when
            //Metodo criado no escopo gerador de jogadores
            var times = campeonato.AdicionarTimes(time, cbf);
            var quartaRodada = campeonato.GerarQuartaRodada(cbf);

            Assert.Equal("Flamengo", quartaRodada[0].Item1.Nome);
            Assert.Equal("Jabaquara", quartaRodada[0].Item2.Nome);

        }

        [Fact]
        public void Deve_Retornar_Resultado_Quarta_Rodada()
        {

            var campeonato = new Campeonato();
            var time = GeradorListaDeTimes();
            // inserir uma forma que apos o campeonato começar nao registrar novamente resultados do mesmo confronto
            //inserir Id nos confrontos
            //
            //criação de usuario para validacao da inserção de times
            var cbf = new Cbf("Admin"); //usuario cbf para validar a inserção de dados
            campeonato.AdicionarTimes(time, cbf);
            var vitoriasDaRodada = new Estatisticas();


            var quartaRodada = campeonato.GerarQuartaRodada(cbf);

            campeonato.AdicionarGolsAoJogo("Flamengo", 1, "Jabaquara", 0);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Flamengo", campeonato.Times[0].Jogadores[1].Id);

            campeonato.AdicionarGolsAoJogo("Atletico", 1, "Santos", 0);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Atletico", campeonato.Times[1].Jogadores[1].Id);


            campeonato.AdicionarGolsAoJogo("Palmeiras", 1, "Portuguesa", 0);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Palmeiras", campeonato.Times[2].Jogadores[1].Id);


            campeonato.AdicionarGolsAoJogo("Bahia", 1, "Ituano", 0);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Bahia", campeonato.Times[5].Jogadores[1].Id);


            Assert.Equal(1, quartaRodada[0].Item1.Gols);
            Assert.Equal(0, quartaRodada[0].Item2.Gols);
            Assert.Equal(1, quartaRodada[1].Item1.Gols);
            Assert.Equal(0, quartaRodada[1].Item2.Gols);
            Assert.Equal(1, quartaRodada[2].Item1.Gols);
            Assert.Equal(0, quartaRodada[2].Item2.Gols);
            Assert.Equal(1, quartaRodada[3].Item1.Gols);
            Assert.Equal(0, quartaRodada[3].Item2.Gols);

            campeonato.exibeResultadoPorRodada(cbf);
            var vitoriasQuartaRodada = vitoriasDaRodada.ExibirVitoriasCampeonato(campeonato.Times);





        }

        [Fact]
        public void Deve_Retornar_QuintaRodada_se_o_usuario_for_cbf()
        {

            // !cria o time
            //given
            var assert = new List<List<((string, int), (string, int), string)>>();

            var campeonato = new Campeonato();
            var time = GeradorListaDeTimes();

            //criação de usuario para validacao da inserção de times
            var cbf = new Cbf("Admin"); //usuario cbf para validar a inserção de dados

            //when
            //Metodo criado no escopo gerador de jogadores
            var times = campeonato.AdicionarTimes(time, cbf);
            var quintaRodada = campeonato.GerarQuintaRodada(cbf);

            Assert.Equal("Flamengo", quintaRodada[0].Item1.Nome);
            Assert.Equal("Portuguesa", quintaRodada[0].Item2.Nome);

        }

        [Fact]
        public void Deve_Retornar_Resultado_Quinta_Rodada()
        {

            var campeonato = new Campeonato();
            var time = GeradorListaDeTimes();
            // inserir uma forma que apos o campeonato começar nao registrar novamente resultados do mesmo confronto
            //inserir Id nos confrontos
            //
            //criação de usuario para validacao da inserção de times
            var cbf = new Cbf("Admin"); //usuario cbf para validar a inserção de dados
            campeonato.AdicionarTimes(time, cbf);
            var vitoriasDaRodada = new Estatisticas();


            var quartaRodada = campeonato.GerarQuintaRodada(cbf);

            campeonato.AdicionarGolsAoJogo("Flamengo", 1, "Portuguesa", 0);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Flamengo", campeonato.Times[0].Jogadores[1].Id);

            campeonato.AdicionarGolsAoJogo("Atletico", 1, "Ituano", 0);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Atletico", campeonato.Times[1].Jogadores[1].Id);

            campeonato.AdicionarGolsAoJogo("Palmeiras", 1, "Bahia", 0);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Palmeiras", campeonato.Times[2].Jogadores[1].Id);

            campeonato.AdicionarGolsAoJogo("Santos", 1, "Jabaquara", 0);
            campeonato.AdicionarGolsDaPartidaAUmJogador("Santos", campeonato.Times[3].Jogadores[1].Id);

            campeonato.exibeResultadoPorRodada(cbf);
            var vitoriasQuintaRodada = vitoriasDaRodada.ExibirVitoriasCampeonato(campeonato.Times);



            Assert.Equal(1, quartaRodada[0].Item1.Gols);
            Assert.Equal(0, quartaRodada[0].Item2.Gols);
            Assert.Equal(1, quartaRodada[1].Item1.Gols);
            Assert.Equal(0, quartaRodada[1].Item2.Gols);
            Assert.Equal(1, quartaRodada[2].Item1.Gols);
            Assert.Equal(0, quartaRodada[2].Item2.Gols);
            Assert.Equal(1, quartaRodada[3].Item1.Gols);
            Assert.Equal(0, quartaRodada[3].Item2.Gols);
            Assert.Equal(1, campeonato.Times[3].Jogadores[1].Gols);
            Assert.Equal(1, campeonato.Times[2].Jogadores[1].Gols);
            Assert.Equal(1, campeonato.Times[1].Jogadores[1].Gols);
            Assert.Equal(1, campeonato.Times[0].Jogadores[1].Gols);
            Assert.Equal(4, vitoriasQuintaRodada.Count());





        }









        [Fact]
        public void Deve_Retornar_Tabela_De_Resultado_Com_Pontuações_Geradas_Automaticamente()
        {

            // !cria o time
            //given
            var assert = new List<List<((string, int), (string, int), string)>>();

            var campeonato = new Campeonato();
            var time = GeradorListaDeTimes();

            //criação de usuario para validacao da inserção de times
            var cbf = new Cbf("Admin"); //usuario cbf para validar a inserção de dados

            //when
            //Metodo criado no escopo gerador de jogadores
            var times = campeonato.AdicionarTimes(time, cbf);
            // var tabelaResultadodasPartidas = campeonato.AdicionarGolsAoJogo (cbf);

        }

        // !Metodo criador de times

        private List<Time> GeradorListaDeTimes()
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

        // !Metodo criador de jogador
        // private List<Jogador> GeradorListaJogadores()
        // {

        //     var jogadores = new List<Jogador>()
        //     {
        //         new JogadorCampeonato ("Galvao"),
        //         new JogadorCampeonato ("Bruno"),
        //         new JogadorCampeonato ("Jorge salvador"),
        //         new JogadorCampeonato ("Vamputo"),
        //         new JogadorCampeonato ("Jorginho satan"),
        //         new JogadorCampeonato ("Dinamite"),
        //         new JogadorCampeonato ("fogonorabo"),
        //         new JogadorCampeonato ("ligeirinho"),
        //         new JogadorCampeonato ("CaiCai"),
        //         new JogadorCampeonato ("Banheirinha"),
        //         new JogadorCampeonato ("deixaQeuEuChuto"),
        //         new JogadorCampeonato ("PassaPMim"),
        //         new JogadorCampeonato ("MarcaMarca"),
        //         new JogadorCampeonato ("Michele"),
        //         new JogadorCampeonato ("caixeta"),
        //         new JogadorCampeonato ("Henrique Alves")
        //     };
        //     return jogadores;
        // }

    }
}