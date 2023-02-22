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
    public class DrinkCategoriesController : ControllerBase
    {
        private readonly DrinkpoDbContext _context;

        public DrinkCategoriesController(DrinkpoDbContext context)
        {
            _context = context;
        }

        // GET: api/DrinkCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrinkCategory>>> GetDrinkCategories()
        {
          if (_context.DrinkCategories == null)
          {
              return NotFound();
          }
            return await _context.DrinkCategories.ToListAsync();
        }

        // GET: api/DrinkCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DrinkCategory>> GetDrinkCategory(int id)
        {
          if (_context.DrinkCategories == null)
          {
              return NotFound();
          }
            var drinkCategory = await _context.DrinkCategories.FindAsync(id);

            if (drinkCategory == null)
            {
                return NotFound();
            }

            return drinkCategory;
        }

        // PUT: api/DrinkCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrinkCategory(int id, DrinkCategory drinkCategory)
        {
            if (id != drinkCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(drinkCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkCategoryExists(id))
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

        // POST: api/DrinkCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DrinkCategory>> PostDrinkCategory(DrinkCategory drinkCategory)
        {
          if (_context.DrinkCategories == null)
          {
              return Problem("Entity set 'DrinkpoDbContext.DrinkCategories'  is null.");
          }
            _context.DrinkCategories.Add(drinkCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrinkCategory", new { id = drinkCategory.Id }, drinkCategory);
        }

        // DELETE: api/DrinkCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrinkCategory(int id)
        {
            if (_context.DrinkCategories == null)
            {
                return NotFound();
            }
            var drinkCategory = await _context.DrinkCategories.FindAsync(id);
            if (drinkCategory == null)
            {
                return NotFound();
            }

            _context.DrinkCategories.Remove(drinkCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrinkCategoryExists(int id)
        {
            return (_context.DrinkCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
