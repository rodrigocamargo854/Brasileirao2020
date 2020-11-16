using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Usuarios
{
    public class UsuarioServices
    {


        public Usuario CriarUsuario(string senha, string nome)
        {
            if (senha == "Cbf")
            {
                // noAdmin recebe um usuairo do tipo Cbf como nome como parametro
                var novoAdmin = new Cbf(nome);

                if (novoAdmin.Validar().eValido)
                {
                    //acessa o metodo adicionar usuario pela classe UsuarioRepositorio
                    UsuarioRepositorio.AdicionarUsuario(novoAdmin);
                    return novoAdmin;
                }

                return null;
            }
            else if (senha == "torcedor")
            {
                //novoTorcedor recebe um usuario do tipo Torcedor
                var novoTorcedor = new Torcedor(nome);

                if (novoTorcedor.Validar().eValido)
                {
                    UsuarioRepositorio.AdicionarUsuario(novoTorcedor);
                    return novoTorcedor;
                }

                return null;

            }

            return null;
        }

        public Usuario ObterUsuario(Guid idUser)
        {
            return UsuarioRepositorio.ObterUsuario(idUser);
        }

        public bool AdicionarUsuario(string nome, string senha)
        {
            var novoUsuario = CriarUsuario(senha, nome);

            if (novoUsuario == null)
            {
                return false;
            }

            UsuarioRepositorio.AdicionarUsuario(novoUsuario);
            return true;
        }

        public void RemoverUsuario(Guid idUser)
        {
            UsuarioRepositorio.RemoverUsuario(idUser);
        }

        public Guid ObterIDUsuario(string name)
        {
            return UsuarioRepositorio.RetornarIdUsuario(name);
        }
      

    }
}
