using Domain;
using Microsoft.EntityFrameworkCore;

namespace Orders.Application.Interfaces
{
    public interface IOrderDbContext
    {
        DbSet<Order> Orders { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
