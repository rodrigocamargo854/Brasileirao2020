using System;

namespace WebApi.Controller
{
    public class JogadorService
    {
        public Guid Create(string name)
        {
            var jogador = new JogadorResponse(name);

            return jogador.Id;
        }

        public void RegistraGolsJogador(string name)
        {
            var jogador = new JogadorResponse(name);

        }
       
    }
}