using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Usuarios;

namespace Domain.Times
{
    public class TimesServices
    {

        public Time BuscarTime(Guid idTime)
        {
            return RespositorioDeTimes.BuscarTime(idTime);
        }

        public bool AdicionarJogador(string nomeTime)
        {
            // noAdmin recebe um usuairo do tipo Cbf como nome como parametro
            var novoTime = new Time(nomeTime);
            // var nomeJogador = RespositorioDeJogadores.Jogadores.FirstOrDefault(x => x.Nome == nome);
            //&& nomeJogador == null

            if (novoTime.Validar().eValido)
            {
                //acessa o metodo adicionar usuario pela classe UsuarioRepositorio
                RespositorioDeTimes.AdicionarTime(novoTime);

                return true;
            }


            return false;
        }

        public void RemoverTime(Guid idTime)
        {
            RespositorioDeTimes.RemoverTime(idTime);
        }

        public void AdicionarListaDeTimes(List<Time> listaDeTimes)
        {
            RespositorioDeTimes.AdicionarListadeTimes(listaDeTimes);
        }
        
        public Guid ObterIDTime(string name)
        {
            return RespositorioDeTimes.RetornarIdTime(name);
        }


        public IReadOnlyCollection<Time> RetornarTodosTimes()
        {
            return RespositorioDeTimes.Times;
        }




    }
}
