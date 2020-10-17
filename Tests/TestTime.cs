using System;
using Xunit;
using Domain;
using System.Collections.Generic;

namespace Tests
{
    public class TestTime
    {
        [Fact]
        public void Deve_retornar_False_se_numero_de_jogadores_abaixo_de16_ou_acima_de32()
        {

            // a criacao do time 'igual ao criação do candidato, para testar
            //no campeonato é necessário copiar o metodo
            // inicializçaõ objeto jogador necessariamente com propriedade nome
            //given
            var Atletico = new Time("Atletico");

            //when
            // herança do jogador
            var jogadores = new List<Jogador>()
            {
                new JogadorCampeonato("ximira"),
                new JogadorCampeonato("teteco"),
                new JogadorCampeonato("Tatuane tiral")
            };

            var result = Atletico.AddJogador(jogadores);

            //then

            Assert.False(result);

        }
    }
}
