
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    //           rota + controller
    public class ProductsController : ControllerBase
    {

        [HttpGet]
       
       //entra uma IList 
        public IList<GameResponse> Get()
        {
            //objeto do tipo gameresponse
            var jogo1 = new GameResponse
            {
                Name = "Dark Souls",
                Plataforma = "Multiplaforma",
                Price = 150
            };
             var jogo2 = new GameResponse
            {
                Name = "Blood Bourne",
                Plataforma = "Multiplaforma",
                Price = 195
            };
             var jogo3 = new GameResponse
            {
                Name = "Minecraft",
                Plataforma = "Multiplaforma",
                Price = 200
            };

            
            //retorna Lista
            return new List<GameResponse>{jogo1,jogo2,jogo3};
        }
    }
}