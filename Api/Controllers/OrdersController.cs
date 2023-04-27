using Application.Commands.CreateOrder;
using Application.Commands.MakePayment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("/{orderId}/make-payment")]
        public async Task<IActionResult> MakePayment(MakePaymentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
