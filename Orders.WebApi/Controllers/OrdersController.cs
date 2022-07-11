using Microsoft.AspNetCore.Mvc;
using MediatR;
using Domain;
using Orders.Application.Orders.Queries;
using Orders.Application.Orders.Commands.CreateOrder;
using Orders.Application.Orders.Commands;

namespace Orders.WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IMediator _mediator;

        public OrdersController(ILogger<OrdersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpGet("orders")]
        public async Task<ActionResult<List<GetOrderVm>>> Get()
        {
            return await _mediator.Send(new GetOrdersQuery());
        }
        
        [HttpGet("order/{id}")]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            var query = new GetOrderByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            return Ok(result);            
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(CreateOrderVm newOrder)
        {
            var id = _mediator.Send(new CreateOrderCommand() { Order = newOrder });

            return CreatedAtAction(nameof(GetById),new { id = id }, id);
        }


    }
}