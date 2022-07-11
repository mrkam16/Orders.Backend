namespace Domain
{
    public class Order
    {
        public int Id { get; set; }

        public string ? Number { get; set; }

        public string ? Customer { get; set; }
        public DateTime DateTime { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
