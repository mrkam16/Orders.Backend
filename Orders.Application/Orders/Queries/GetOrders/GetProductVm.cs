namespace Orders.Application
{
    public class GetProductVm
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public int? Amount { get; set; }

        public decimal Price { get; set; }
    }
}
