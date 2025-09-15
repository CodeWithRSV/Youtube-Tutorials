using MenuApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuApp.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {
        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>()
                .HasKey(di => new { di.DishId, di.IngredientId });
            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Dish)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(di => di.DishId);
            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany(i => i.DishIngredients)
                .HasForeignKey(di => di.IngredientId);
            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Spaghetti Carbonara", ImageUrl = "https://example.com/images/spaghetti_carbonara.jpg", Price = 12.99M },
                new Dish { Id = 2, Name = "Margherita Pizza", ImageUrl = "https://example.com/images/margherita_pizza.jpg", Price = 10.99M },
                new Dish { Id = 3, Name = "Caesar Salad", ImageUrl = "https://example.com/images/caesar_salad.jpg", Price = 8.99M }
            );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Spaghetti" },
                new Ingredient { Id = 2, Name = "Eggs" },
                new Ingredient { Id = 3, Name = "Pancetta" },
                new Ingredient { Id = 4, Name = "Parmesan Cheese" },
                new Ingredient { Id = 5, Name = "Tomato Sauce" },
                new Ingredient { Id = 6, Name = "Mozzarella Cheese" },
                new Ingredient { Id = 7, Name = "Basil" },
                new Ingredient { Id = 8, Name = "Romaine Lettuce" },
                new Ingredient { Id = 9, Name = "Croutons" },
                new Ingredient { Id = 10, Name = "Caesar Dressing" }
            );
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 1 },
                new DishIngredient { DishId = 1, IngredientId = 2 },
                new DishIngredient { DishId = 1, IngredientId = 3 },
                new DishIngredient { DishId = 1, IngredientId = 4 },
                new DishIngredient { DishId = 2, IngredientId = 5 },
                new DishIngredient { DishId = 2, IngredientId = 6 },
                new DishIngredient { DishId = 2, IngredientId = 7 },
                new DishIngredient { DishId = 3, IngredientId = 8 },
                new DishIngredient { DishId = 3, IngredientId = 9 },
                new DishIngredient { DishId = 3, IngredientId = 10 }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
