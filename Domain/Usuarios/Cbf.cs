using System.Collections.Generic;
using System.Linq;


namespace Domain.Usuarios
{
        public sealed class Cbf : Usuario
        {
            public Cbf(string nome) : base(nome)
            {
                Nome = nome;
            }
        }
}