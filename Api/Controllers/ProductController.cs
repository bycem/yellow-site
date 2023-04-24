using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            return "Test";
        }
    }
}