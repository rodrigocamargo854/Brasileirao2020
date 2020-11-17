using System;
using Domain;
using Domain.Usuarios;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers.Users
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioServices usuarioServices;


        public UsuarioController()
        {
            usuarioServices = new UsuarioServices();
        }

        [HttpPost]
        public IActionResult PostUsuario(CreateUserRequest request)
        {
            if (!usuarioServices.AdicionarUsuario(request.Nome, request.Senha))
            {
                return Unauthorized();
            }


            return Content("Usuario Adicionado!");
        }

        [HttpGet]
        public IActionResult GetIdUsuario(CreateUserRequest request)
        {
            var idUser = usuarioServices.ObterIDUsuario(request.Nome);


            return Ok(idUser);
        }

        [HttpGet("{idUser}")]
        public Usuario GetUsuario(Guid idUser)
        {
            return usuarioServices.ObterUsuario(idUser);
        }


        [HttpDelete("{idUser}")]
        public IActionResult DeleteUsuario(Guid idUser)
        {
            usuarioServices.RemoverUsuario(idUser);

            return Content("Usuário deletado!");
        }
    }
}