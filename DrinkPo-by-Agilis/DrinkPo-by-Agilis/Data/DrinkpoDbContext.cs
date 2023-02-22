using DrinkPo_by_Agilis.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DrinkPo_by_Agilis.Data;

public class DrinkpoDbContext : IdentityDbContext
{
    public DrinkpoDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<IngredientCategory> IngredientCategories { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<DrinkCategory> DrinkCategories { get; set; }
    public DbSet<Drink> Drinks { get; set; }
    public DbSet<IngredientInDrink> IngredientsInDrinks { get;set; }

}