using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace servicethree.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MergeController : ControllerBase
    {
        private IConfiguration Configuration;
        public MergeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var destinationService = $"{Configuration["destinationServiceURL"]}/destination";
            //var serviceOneResponseCall = await new HttpClient().GetStringAsync(destinationService);
            var citiesService = $"{Configuration["citiesServiceURL"]}/cities";
            var serviceTwoResponseCall = await new HttpClient().GetStringAsync(citiesService);
            //var mergedResponse = $"{serviceOneResponseCall}\n{serviceTwoResponseCall}";
            var mergedResponse = $"{serviceTwoResponseCall}";
            return Ok(mergedResponse);
        }
    }
}
