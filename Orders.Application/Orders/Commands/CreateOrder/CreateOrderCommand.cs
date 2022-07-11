using MediatR;
using Orders.Application.Orders.Commands.CreateOrder;

namespace Orders.Application.Orders.Commands
{
    public class CreateOrderCommand : IRequest<int>
    {
        public CreateOrderVm Order { get; set; }
    }
}
