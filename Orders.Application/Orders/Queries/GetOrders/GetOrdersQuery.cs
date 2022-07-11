using MediatR;

namespace Orders.Application.Orders.Queries
{
    public class GetOrdersQuery : IRequest<List<GetOrderVm>>
    {
    }
}
