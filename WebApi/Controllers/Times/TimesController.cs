
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [ApiController]
    [Route("[Controller]")]
    //           rota + controller
    public class TimesController : ControllerBase
    {

        [HttpGet]

        //entra uma IList 
        public List<TimeResponse> CreateTime( )
        {
            //objeto do tipo gameresponse

            return new List<TimeResponse>();

        }
    }
}