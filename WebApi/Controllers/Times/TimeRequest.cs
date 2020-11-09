using System;
using System.Collections.Generic;

namespace WebApi.Controller
{
    public class TimeRequest
    {
        public string Nome { get; set; }
        public List<JogadorResponse> Jogadores { get; set; }

        


    }
}