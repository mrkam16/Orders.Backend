using MediatR;

namespace Orders.Application.Orders.Queries
{
    public class GetOrderByIdQuery : IRequest<GetOrderVm>
    {
        public int Id { get; set; }
    }
}
