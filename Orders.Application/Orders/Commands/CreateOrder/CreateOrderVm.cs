namespace Orders.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderVm
    {
        public string Number { get; set; }
        public string Customer { get; set; }
        public List<CreateProductVm> Products { get; set; }

    }
}
