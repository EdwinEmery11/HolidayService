using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace serviceone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : ControllerBase
    {

        private IConfiguration Configuration;
        private ActionResult<string> city;

        public CitiesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var destinationService = $"{Configuration["destinationServiceURL"]}/destination";
            var serviceOneResponseCall = await new HttpClient().GetStringAsync(destinationService);
            var city = "";

            switch (serviceOneResponseCall)
            {
                case "America":
                    city = "New York";
                    break;
                case "Greece":
                    city = "Athens";
                    break;
                case "Italy":
                    city = "Milan";
                    break;
                case "Spain":
                    city = "Barcelona";
                    break;
                    //default:
                    //break;
            }
            // var rnd = new Random();
            //var returnIndex = rnd.Next(0, 25);
            //return Letters[returnIndex].ToString();
            return Ok($"{serviceOneResponseCall}\n{city}");
        }
    }
}
