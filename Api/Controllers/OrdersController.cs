using Api.Models.Orders;
using Application.Commands.ApprovePayment;
using Application.Commands.CreateOrder;
using Application.Commands.MakePayment;
using Application.Queries.ListBoughtVehicles;
using Application.Queries.ListSoldVehiclesByBuyers;
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
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderModel model)
        {
            var result = await _mediator.Send(new CreateOrderCommand() { VehicleId = model.VehicleId });
            return Ok(result);
        }

        [HttpPost("{orderId}/make-payment")]
        public async Task<IActionResult> MakePayment([FromRoute] Guid orderId, [FromBody] MakePaymentModel model)
        {
            var result = await _mediator.Send(new MakePaymentCommand
            {
                OrderId = orderId,
                Amount = model.Amount,
                IsSuccess = model.IsSuccess
            });
            return Ok(result);
        }

        [HttpPost("{orderId}/approve-order")]
        public async Task<IActionResult> ApproveOrder([FromRoute] Guid orderId)
        {
            var result = await _mediator.Send(new ApproveOrderCommand
            {
                OrderId = orderId
            });
            return Ok(result);
        }

        [HttpGet("bought")]
        public async Task<IActionResult> GetBoughtOrdersForCurrentCustomer()
        {
            var result = await _mediator.Send(new ListBoughtVehiclesQuery());
            return Ok(result);
        }

        [HttpGet("sold")]
        public async Task<IActionResult> GetSoldOrdersForCurrentCustomer()
        {
            var result = await _mediator.Send(new ListSoldVehiclesQuery());
            return Ok(result);
        }
    }
}
