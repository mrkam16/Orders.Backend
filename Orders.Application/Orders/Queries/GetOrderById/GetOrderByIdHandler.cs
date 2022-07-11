using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Exceptions;
using Orders.Application.Interfaces;

namespace Orders.Application.Orders.Queries
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, GetOrderVm>
    {
        public readonly IOrderDbContext _context;
        public readonly IMapper _mapper;
        public GetOrderByIdHandler(IOrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetOrderVm> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(order => order.Products)
                .FirstOrDefaultAsync(order => order.Id == request.Id, cancellationToken);

            if(order is null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            return _mapper.Map<GetOrderVm>(order);

        }
    }
}
