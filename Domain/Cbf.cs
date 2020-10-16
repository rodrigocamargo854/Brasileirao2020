using System.Collections.Generic;
using System.Linq;

namespace dev.Brasileirao2020
{
    public class Cbf
    {

        public sealed class Torcedor : Usuario
        {
            public Torcedor(string nome) : base(nome)
            {
                Nome = nome;
            }
        }
    }
}