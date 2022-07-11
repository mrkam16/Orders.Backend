using Domain;
using Microsoft.EntityFrameworkCore;

namespace Orders.Persistence.DatabaseInit
{
    public static class DbInitializer
    {
        public static ModelBuilder InitDatabase(this ModelBuilder modelBuilder)
        {
            // так как у меня пока не скачан ms sql server я решил использовать InMemoryDb                               
            var orders = new List<Order>()
            {
                new Order { Id = 1, Customer="Иван", DateTime = DateTime.Now.AddDays(-1), Number = "ORD-001"},
                new Order { Id = 2, Customer="Василий", DateTime = DateTime.Now.AddDays(-2), Number = "ORD-002"},
                new Order { Id = 3, Customer="Дмитрий", DateTime = DateTime.Now.AddDays(-3), Number = "ORD-003"},
                new Order { Id = 4, Customer="Николай", DateTime = DateTime.Now.AddMinutes(-15), Number = "ORD-004"},
                new Order { Id = 5, Customer="Денис", DateTime = DateTime.Now.AddHours(-3), Number = "ORD-005"}
            };

            var products = new List<Product>()
            {
                new Product { Id = 1, Title = "Клавиатура", Amount = 2, Price = 3000, OrderId = 2},
                new Product { Id = 2, Title = "Монитор", Amount = 1, Price = 6000, OrderId = 4 },
                new Product { Id = 3, Title = "Мышь", Amount = 4, Price = 1200, OrderId = 2},
                new Product { Id = 4, Title = "Системный блок", Amount = 1, Price = 20000, OrderId = 3},
                new Product { Id = 5, Title = "Колонка", Amount = 4, Price = 7000, OrderId = 5},
                new Product { Id = 6, Title = "Наушники", Amount = 2, Price = 15000, OrderId = 2},
                new Product { Id = 7, Title = "Видеокарта", Amount = 1, Price = 25000, OrderId = 3}
            };

            modelBuilder.Entity<Order>().HasData(orders);
            modelBuilder.Entity<Product>().HasData(products);

            return modelBuilder;
        }
    }
}
