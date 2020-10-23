using System;
using Xunit;
using Domain;
using System.Collections.Generic;

namespace Tests
{
    public class TestTime
    {

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


        [Fact]
        public void Deve_retornar_True_se_numero_de_jogadores_for_acima_de15_ou_abaixo_de33()
        {

            // a criacao do time 'igual ao criação do candidato, para testar
            //no campeonato é necessário copiar o metodo
            // inicializçaõ objeto jogador necessariamente com propriedade nome
            //given
            var atletico = new Time("Atletico");

            //when
            var jogadores = atletico.adicionarJogador(GeradorListaJogadores());
            //then

            Assert.True(jogadores);

        }

        [Fact]
        public void Deve_Remover_Um_Jogador_que_Possui_O_mesmo_Nome_Passado()
        {


            var atletico = new Time("Atletico");

            //when
            var jogadores = atletico.adicionarJogador(GeradorListaJogadores());
            var jogadorASerRemovido = new Jogador("SpiderMan");

            atletico.removerJogador(jogadorASerRemovido);

            //then

            Assert.DoesNotContain(jogadorASerRemovido, atletico.Jogadores);

        }
        [Fact]

        public void Deve_Incrementar_Os_Gols_Do_Jogador_Passado_Como_Parametro()
        {
            var atletico = new Time("Atletico");

            //when
            var jogadores = atletico.adicionarJogador(GeradorListaJogadores());


            //then

            
        }

        [Fact]
        public void Deve_Retornar_Jogador_Artilheiro_Quando_Adicionado_ListaDeJogadores_Com_Gols()
        {

            // a criacao do time 'igual ao criação do candidato, para testar
            //no campeonato é necessário copiar o metodo
            // inicializçaõ objeto jogador necessariamente com propriedade nome
            //given
            var atletico = new Time("Atletico");

            //when
            //jogadores do atletico
            var jogadores = atletico.adicionarJogador(GeradorListaJogadores());

            var jogadorQueMarcouGol = new Jogador("SpiderMan");
            atletico.AddicionarPontosJogador(jogadorQueMarcouGol);
            var result = atletico.adicionarArtilheiro();

            //then

            Assert.Equal("SpiderMan", atletico.Artilheiro.Nome);

        }
        //////////////////////////////////////////////////////////////////////////////////////////////

    }
}
