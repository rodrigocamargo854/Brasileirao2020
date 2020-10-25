using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Deve_Retornar_Ponto_ao_Adicionado_Ao_Time_Passado_Como_Parametro()
        {

            // !cria o time
            //given
            var campeonato = new Campeonato();
            var Time = GeradorListaDeTimes();

            //criação de usuario para validacao da inserção de times
            var cbf = new Cbf("Admin");//usuario cbf para validar a inserção de dados


            //when
            //Metodo criado no escopo gerador de jogadores
            campeonato.AdicionarTimes(Time, cbf);

            campeonato.AdicionarPontosAoTime(cbf, "Santos");
            var result = campeonato.Times.FirstOrDefault(time => time.Nome == "Santos").Pontos;

            // AdicionarPontosAoTime(cbf,"Santos");

            //then
            //Cada time joga com todos times, em casa e fora de casa
            // // Assert.Equal(1, result);

        }
        [Fact]
        public void Deve_Retornar_Tabela_de_Resultados_de_Acordo_com_numero_de_times_e_Se_Usuario_for_Cbf_()
        {

            // !cria o time
            //given
            var assert = new List<List<((string, int), (string, int))>>();

            var campeonato = new Campeonato();
            var time = GeradorListaDeTimes();

            //criação de usuario para validacao da inserção de times
            var cbf = new Cbf("Admin");//usuario cbf para validar a inserção de dados


            //when
            //Metodo criado no escopo gerador de jogadores
            var times = campeonato.AdicionarTimes(time, cbf);
            var rodadasGeradas = campeonato.GerarRodadas(cbf);

            //Adicionando pontos acbf

            campeonato.AdicionarPontosAoTime(cbf, "Santos");
            campeonato.AdicionarPontosAoTime(cbf, "Santos");
            campeonato.AdicionarPontosAoTime(cbf, "Santos");
            campeonato.AdicionarPontosAoTime(cbf, "Santos");
            campeonato.AdicionarPontosAoTime(cbf, "Santos");
            campeonato.AdicionarPontosAoTime(cbf, "Santos");
            campeonato.AdicionarPontosAoTime(cbf, "Santos");
            campeonato.AdicionarPontosAoTime(cbf, "Santos");
            campeonato.AdicionarPontosAoTime(cbf, "Santos");
            campeonato.AdicionarPontosAoTime(cbf, "Santos");
            campeonato.AdicionarPontosAoTime(cbf, "Ituano");
            campeonato.AdicionarPontosAoTime(cbf, "Corinthians");
            campeonato.AdicionarPontosAoTime(cbf, "Corinthians");
            campeonato.AdicionarPontosAoTime(cbf, "Corinthians");
            campeonato.AdicionarPontosAoTime(cbf, "Santos");
            campeonato.AdicionarPontosAoTime(cbf, "Flamengo");
            campeonato.AdicionarPontosAoTime(cbf, "Flamengo");
            campeonato.AdicionarPontosAoTime(cbf, "Atletico");
            campeonato.AdicionarPontosAoTime(cbf, "Palmeiras");

            //then

            Assert.NotNull(campeonato.retornarTabelaDeResultados(cbf));

        }



        // !Metodo criador de times

        private List<Time> GeradorListaDeTimes()
        {

            var Time2 = new Time("Atletico");
            var Time3 = new Time("Palmeiras");
            var Time1 = new Time("Flamengo");
            var Time4 = new Time("Santos");
            var Time5 = new Time("Jabaquara");
            var Time6 = new Time("Bahia");
            var Time7 = new Time("Ituano");
            var Time8 = new Time("Portuguesa");
            var Time9 = new Time("Corinthians");


            Time2.adicionarJogador(new List<Jogador>()
            {
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

            Time3.adicionarJogador(new List<Jogador>()
            {
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
            Time4.adicionarJogador(new List<Jogador>()
            {
                new JogadorCampeonato ("Max pe de cana"),
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
            Time5.adicionarJogador(new List<Jogador>()
            {
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
            Time6.adicionarJogador(new List<Jogador>()
            {
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
            Time7.adicionarJogador(new List<Jogador>()
            {
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
            Time8.adicionarJogador(new List<Jogador>()
            {
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
            Time1.adicionarJogador(new List<Jogador>()
            {
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

            var ListaDeTimes = new List<Time>() { Time1, Time2, Time3, Time4, Time5, Time6, Time7, Time8,Time9 };

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



