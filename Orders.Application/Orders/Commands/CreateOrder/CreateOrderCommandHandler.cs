using AutoMapper;
using Domain;
using MediatR;
using Orders.Application.Interfaces;
using Orders.Application.Orders.Commands.CreateOrder;

namespace Orders.Application.Orders.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderDbContext _context;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var products = _mapper.Map<List<CreateProductVm>,List<Product>>(request.Order.Products);

            var order = new Order
            {
                Customer = request.Order.Customer,
                Number = request.Order.Number,
                Products = products,
                DateTime = DateTime.Now
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
