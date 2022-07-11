using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Interfaces;

namespace Orders.Application.Orders.Queries
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery,List<GetOrderVm>>
    {
        public readonly IOrderDbContext _context;
        public readonly IMapper _mapper;
        public GetOrdersHandler(IOrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public Task<List<GetOrderVm>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = _context.Orders
                .Include(order => order.Products)
                .ToList();


            var result = _mapper.Map<List<GetOrderVm>>(orders);

            return Task.FromResult(result);
        }
    }
}
