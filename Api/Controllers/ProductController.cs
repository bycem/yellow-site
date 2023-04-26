using Application.Commands.CreateVehicleListing;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new CreateVehicleListingCommand()
            {
                Brand = "Renault",
                Model = "Fluence",
                ModelYear = 2012,
                MileAge = 200000,
                SellingPrice = 370000
            });

            return Ok(result);
        }
    }
}