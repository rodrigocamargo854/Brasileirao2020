
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Users;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [ApiController]
    [Route("[Controller]")]
    //           rota + controller
    public class JogadoresController : ControllerBase
    {

        [HttpGet]

        //entra uma IList 
        public List<JogadorResponse> GetIdJogadores()
        {
            //objeto do tipo gameresponse

            var jogadores = new List<JogadorResponse>()

            {
                new JogadorResponse ("Sarrafo"),
                new JogadorResponse ("correParaEsquerda"),
                new JogadorResponse ("TocaParaMim"),
                new JogadorResponse ("José Dildo"),
                new JogadorResponse ("Jorginho PéDeMoça"),
                new JogadorResponse ("MataMata"),
                new JogadorResponse ("Valderanho"),
                new JogadorResponse ("Joca gado"),
                new JogadorResponse ("Biro Biro"),
                new JogadorResponse ("Buzuang"),
                new JogadorResponse ("Zumbido Nouvido"),
                new JogadorResponse ("coronga"),
                new JogadorResponse ("coronguinha"),
                new JogadorResponse ("Lucas Tatu"),
                new JogadorResponse ("Carlos Bezerra")

            };

            //retorna Lista

            return jogadores;

        }

        private readonly JogadorService _jogadoresService;

        public JogadoresController()
        {
            _jogadoresService = new JogadorService();
        }


        [HttpPost]
        public IActionResult Create(User request)
        {
            if (request.Profile == Profile.CBF && request.Password != "brasileirao")
            {
                return Unauthorized("Senha incorreta");
            }

            var jogadorId = _jogadoresService.Create(request.Name);

            return Ok(jogadorId);
        }

        


    }
}