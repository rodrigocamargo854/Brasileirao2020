using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Usuarios;

namespace Domain.Jogadores
{
    public class JogadorServices
    {

        public Jogador BuscarJogador(Guid idJogador)
        {
            return RespositorioDeJogadores.BuscarJogador(idJogador);
        }

        public bool AdicionarJogador(string nome)
        {
            // noAdmin recebe um usuairo do tipo Cbf como nome como parametro
            var novoJogador = new Jogador(nome);
            // var nomeJogador = RespositorioDeJogadores.Jogadores.FirstOrDefault(x => x.Nome == nome);
            //&& nomeJogador == null

            if (novoJogador.Validar().eValido)
            {
                //acessa o metodo adicionar usuario pela classe UsuarioRepositorio
                RespositorioDeJogadores.AdicionarJogador(novoJogador);

                return true;
            }


            return false;
        }

        public void RemoverJogador(Guid idJogador)
        {
            RespositorioDeJogadores.RemoverJogador(idJogador);
        }

        public void AdicionarListaDeJogadores(List<Jogador> listaDeJogadores)
        {
            RespositorioDeJogadores.AdicionarListaDeJogadores(listaDeJogadores);
        }
        
        public Guid ObterIDJogador(string name)
        {
            return RespositorioDeJogadores.RetornarIdJogador(name);
        }


        public IReadOnlyCollection<Jogador> RetornarTodosJogadores()
        {
            return RespositorioDeJogadores.Jogadores;
        }




    }
}
