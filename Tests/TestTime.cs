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
                new JogadorCampeonato ("Jason"),
                new JogadorCampeonato ("Fred Kruger")

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
//////////////////////////////////////////////////////////////////////////////////////////////
        
    }
}
