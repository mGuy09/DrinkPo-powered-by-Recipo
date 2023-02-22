using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DrinkPo_by_Agilis.Data;
using DrinkPo_by_Agilis.Models;

namespace DrinkPo_by_Agilis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientInDrinksController : ControllerBase
    {
        private readonly DrinkpoDbContext _context;

        public IngredientInDrinksController(DrinkpoDbContext context)
        {
            _context = context;
        }

        // GET: api/IngredientInDrinks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientInDrink>>> GetIngredientsInDrinks()
        {
          if (_context.IngredientsInDrinks == null)
          {
              return NotFound();
          }
            return await _context.IngredientsInDrinks.ToListAsync();
        }

        // GET: api/IngredientInDrinks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientInDrink>> GetIngredientInDrink(int id)
        {
          if (_context.IngredientsInDrinks == null)
          {
              return NotFound();
          }
            var ingredientInDrink = await _context.IngredientsInDrinks.FindAsync(id);

            if (ingredientInDrink == null)
            {
                return NotFound();
            }

            return ingredientInDrink;
        }

        // PUT: api/IngredientInDrinks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredientInDrink(int id, IngredientInDrink ingredientInDrink)
        {
            if (id != ingredientInDrink.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingredientInDrink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientInDrinkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/IngredientInDrinks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngredientInDrink>> PostIngredientInDrink(IngredientInDrink ingredientInDrink)
        {
          if (_context.IngredientsInDrinks == null)
          {
              return Problem("Entity set 'DrinkpoDbContext.IngredientsInDrinks'  is null.");
          }
            _context.IngredientsInDrinks.Add(ingredientInDrink);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredientInDrink", new { id = ingredientInDrink.Id }, ingredientInDrink);
        }

        // DELETE: api/IngredientInDrinks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredientInDrink(int id)
        {
            if (_context.IngredientsInDrinks == null)
            {
                return NotFound();
            }
            var ingredientInDrink = await _context.IngredientsInDrinks.FindAsync(id);
            if (ingredientInDrink == null)
            {
                return NotFound();
            }

            _context.IngredientsInDrinks.Remove(ingredientInDrink);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientInDrinkExists(int id)
        {
            return (_context.IngredientsInDrinks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
