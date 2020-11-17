using System;
using System.Collections.Generic;
using Domain;
using Domain.Jogadores;
using Domain.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace WebAPI.Controllers.Jogadores
{
    [ApiController]
    [Route("[Controller]")]
    public class TimesController : ControllerBase
    {
        private readonly JogadorServices servicosJogador;
        private readonly UsuarioServices servicoUsuarios;



        public TimesController()
        {
            servicosJogador = new JogadorServices();
            servicoUsuarios = new UsuarioServices();
        }

        [HttpPost]
        public IActionResult PostJogador(CreateJogadorRequest request)
        {

            // toda parte de validação para criar o jogador
            StringValues userId;
            if (!Request.Headers.TryGetValue("UserId", out userId))
            {
                return Unauthorized();
            }

            var user = servicoUsuarios.GetById(Guid.Parse(userId));

            if (user == null)
            {
                return Unauthorized();
            }

            if (user is Torcedor)
            {
                return Unauthorized();
                // return Forbid("Test");
            }

            if (!servicosJogador.AdicionarJogador(request.Nome))
            {
                return BadRequest();
            }


            return Content($"Jogador Adicionado!{request.Nome}");
        }

         
        [HttpGet]
        public IActionResult GetAllJogadores( )
        {
            var jogadores = servicosJogador.RetornarTodosJogadores(); 


            return Ok(jogadores);
        }

        [HttpGet("{idJogador}")]
        public Jogador GetUsuario(Guid idJogador)
        {
            return servicosJogador.BuscarJogador(idJogador);
        }


        [HttpDelete("{idJogador}")]
        public IActionResult DeleteUsuario(Guid idJogador)
        {
            servicosJogador.RemoverJogador(idJogador);

            return Content("Jogador deletado!");
        }
    }
}