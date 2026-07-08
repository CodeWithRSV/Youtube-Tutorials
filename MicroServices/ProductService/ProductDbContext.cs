using ProductService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ProductService
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext> dbContextOptions) : base(dbContextOptions)
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
