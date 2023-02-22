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
    public class IngredientCategoriesController : ControllerBase
    {
        private readonly DrinkpoDbContext _context;

        public IngredientCategoriesController(DrinkpoDbContext context)
        {
            _context = context;
        }

        // GET: api/IngredientCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientCategory>>> GetIngredientCategories()
        {
            if (_context.IngredientCategories == null)
            {
              return NotFound();
            }
            return await _context.IngredientCategories.ToListAsync();
        }

        // GET: api/IngredientCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientCategory>> GetIngredientCategory(int id)
        {
            if (_context.IngredientCategories == null)
            {
              return NotFound();
            }
            var ingredientCategory = await _context.IngredientCategories.FindAsync(id);

            if (ingredientCategory == null)
            {
                return NotFound();
            }

            return ingredientCategory;
        }

        // PUT: api/IngredientCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredientCategory(int id, IngredientCategory ingredientCategory)
        {
            if (id != ingredientCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingredientCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientCategoryExists(id))
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

        // POST: api/IngredientCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngredientCategory>> PostIngredientCategory(IngredientCategory ingredientCategory)
        {
            if (_context.IngredientCategories == null)
            {
              return Problem("Entity set 'DrinkpoDbContext.IngredientCategories'  is null.");
}
            _context.IngredientCategories.Add(ingredientCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredientCategory", new { id = ingredientCategory.Id }, ingredientCategory);
        }

        // DELETE: api/IngredientCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredientCategory(int id)
        {
            if (_context.IngredientCategories == null)
            {
                return NotFound();
            }
            var ingredientCategory = await _context.IngredientCategories.FindAsync(id);
            if (ingredientCategory == null)
            {
                return NotFound();
            }

            _context.IngredientCategories.Remove(ingredientCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientCategoryExists(int id)
        {
            return (_context.IngredientCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
