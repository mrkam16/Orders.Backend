namespace Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string ? Title { get; set; }

        public int ? Amount { get; set; }

        public decimal Price { get; set; }

        public int OrderId { get; set; }
        public Order ? Order { get; set; }

    }
}
