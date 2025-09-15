using MenuApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MenuApp.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuContext _context;

        public MenuController(MenuContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            List<Models.Dish> dishes;
            if(string.IsNullOrEmpty(searchString))
                dishes = await _context.Dishes.ToListAsync();
            else
                dishes = await _context.Dishes
                .Where(d => d.Name.Contains(searchString))
                .ToListAsync();
            return View(dishes);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var dish = await _context.Dishes
                .Include(d => d.DishIngredients)
                .ThenInclude(di => di.Ingredient)
                .FirstOrDefaultAsync(m => m.Id == id);
            return View(dish);
        }
    }
}
