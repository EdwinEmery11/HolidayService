using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace serviceone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DestinationController : ControllerBase
    {
        private static readonly string[] Countries = new[]
        {
            "Spain","Italy","America","Greece"
        };

        [HttpGet]
        public ActionResult<string> Get()
        {
            var rnd = new Random();
            var returnIndex = rnd.Next(0,Countries.Length-1);
            return Countries[returnIndex].ToString();
        }
    }
}
