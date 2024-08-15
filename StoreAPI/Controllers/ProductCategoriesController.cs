using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreAPI.Entities;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductCategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategories([FromQuery]bool includeProducts=false)
        {
           
                var  data= await _context.ProductCategories.ToListAsync();


            if (includeProducts)
            {
                foreach (var item in data)
                {
                    _context.Entry(item)
               .Collection(b => b.Products)
               .Load();
                }
            }

            return Ok(data);

        }

        // GET: api/ProductCategories/5
        // GET: api/ProductCategories/findById?Id=5


        [HttpGet("{id}")]
        [HttpGet("findById")]

        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(ProductCategory) )]
        [ProducesResponseType(StatusCodes.Status404NotFound )]
        public async Task<ActionResult<ProductCategory>> GetProductCategory([FromQuery,FromRoute] int id)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);

            if (productCategory == null)
            {
                return NotFound();
            }

            return productCategory;
        }

        // PUT: api/ProductCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategory(int id, ProductCategory productCategory)
        {
            if (id != productCategory.PCId)
            {
                return BadRequest();
            }

            _context.Entry(productCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(id))
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

        // POST: api/ProductCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

        //[ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductCategory", new { id = productCategory.PCId }, productCategory);
        }

        // DELETE: api/ProductCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }

            _context.ProductCategories.Remove(productCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductCategoryExists(int id)
        {
            return _context.ProductCategories.Any(e => e.PCId == id);
        }
    }
}
