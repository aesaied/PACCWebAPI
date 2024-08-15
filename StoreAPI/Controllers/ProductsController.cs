using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.AppServices.Products;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly  IProductsAppService _productsAppService;
        public ProductsController(IProductsAppService productsAppService)
        {
            _productsAppService = productsAppService;

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            return Ok(await _productsAppService.GetProducts());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            ProductDto? output = await _productsAppService.GetById(id);

            if (output == null) { 
            return NotFound();
            }

            return Ok(output);
        }

        [HttpPost]

        public async Task<IActionResult> Post(CreateProductDto input)
        {

            if (input != null)
            {
                var newId = await _productsAppService.Create(input);

                if (newId > 0)
                {
                    return CreatedAtAction("GetProducts", new { id = newId }, input);
                }
            }



            return BadRequest();
        }
    }
}
