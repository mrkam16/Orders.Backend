namespace Orders.Application.Orders.Queries
{
    public class GetOrderVm
    {
        public int Id { get; set; }

        public string? Number { get; set; }

        public string? Customer { get; set; }
        public DateTime DateTime { get; set; }

        public ICollection<GetProductVm> Products { get; set; } = new List<GetProductVm>();

        public decimal Total { get; set; }
            
    }
}
