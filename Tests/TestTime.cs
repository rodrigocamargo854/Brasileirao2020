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
