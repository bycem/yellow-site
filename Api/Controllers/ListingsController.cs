using Application.Commands.CreateVehicleListing;
using Application.Queries.GetActiveListings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ListingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ListingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateListing(CreateVehicleListingCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("active")]
        public async Task<IActionResult> ActiveListings()
        {
            var result = await _mediator.Send(new GetActiveListingsQuery());

            return Ok(result);
        }
    }
}