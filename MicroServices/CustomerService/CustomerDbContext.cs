using CustomerService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CustomerService
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> dbContextOptions) : base(dbContextOptions)
        {
            try
            {
                var dbCreater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (dbCreater != null)
                {
                    if (!dbCreater.CanConnect()) dbCreater.Create();
                    if (!dbCreater.HasTables()) dbCreater.CreateTables();
                }
            }
            catch { }
        }
    }
}
