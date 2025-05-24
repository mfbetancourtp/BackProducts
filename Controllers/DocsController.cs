using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ProductsController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll() =>
            await _db.Products.OrderByDescending(p => p.CreatedAt).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var prod = await _db.Products.FindAsync(id);
            if (prod == null) return NotFound();
            return prod;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product dto)
        {
            _db.Products.Add(dto);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product dto)
        {
            if (id != dto.Id) return BadRequest();
            _db.Entry(dto).State = EntityState.Modified;
            try { await _db.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _db.Products.AnyAsync(e => e.Id == id))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var prod = await _db.Products.FindAsync(id);
            if (prod == null) return NotFound();
            _db.Products.Remove(prod);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
