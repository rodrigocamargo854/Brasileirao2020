using System;
using Xunit;
using Domain;
using System.Collections.Generic;

namespace Tests
{
    public class TestTime
    {
        [Fact]
        public void Deve_retornar_true_se_numero_de_jogadores_for_entre_16_e_32()
        {
            //given
            var jogador = new Time();
            //when
            var jogadores = new List<Jogador>()
            {
                new Jogador("ximira"),
                new Jogador("teteco"),
                new Jogador("Tatuane tiral")
            };

            var result = jogador.AddJogador(jogadores);

            Assert.False(result);


            //then
        }

        
    }
}
