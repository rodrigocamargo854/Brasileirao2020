
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
            var game = new GameResponse
            {
                Name = "Dark Souls",
                Plataforma = "Multiplaforma",
                Price = 150
            };
            
            //retorna Lista
            return new List<GameResponse>{game};
        }
    }
}