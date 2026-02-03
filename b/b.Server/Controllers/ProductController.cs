using b.demo.database;
using b.demo.database.Models;
using b.Server.Dtos;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace b.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly CoreDbContext coreDbContext;
        private readonly IMapper mapper;

        public ProductController(CoreDbContext coreDbContext, IMapper mapper)
        {
            this.coreDbContext = coreDbContext;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await coreDbContext.Products.ToListAsync();

            var mapped = mapper.Map<List<ProductDto>>(products);

            return Ok(mapped);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ProductDto>> GetById(long id)
        {
            var product = await coreDbContext.Products.SingleOrDefaultAsync(p => p.Id == id);

            if(product == null)
            {
                return NotFound();
            }

            var mapped = mapper.Map<List<ProductDto>>(product); ;

            return Ok(mapped); 
        }

        [HttpPost]
        [Authorize(Roles = BuiltInRoles.Admin)]
        public async Task<ActionResult<Product>> Post(ProductDto product)
        {
            var mapped = mapper.Map<Product>(product);

            await coreDbContext.Products.AddAsync(mapped);
            await coreDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpDelete("{id:long}")]
        [Authorize(Roles = BuiltInRoles.Admin)]
        public async Task<ActionResult> Delete(long id)
        {
            var product = await coreDbContext.Products.SingleOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            coreDbContext.Products.Remove(product);
            await coreDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        [Authorize(Roles = BuiltInRoles.Admin)]
        public async Task<ActionResult> Put(ProductDto product)
        {
            var existingProduct = await coreDbContext.Products.SingleOrDefaultAsync(p => p.Id == product.Id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            var mapped=mapper.Map<Product>(product);

            coreDbContext
                .Entry(existingProduct)
                .CurrentValues
                .SetValues(mapped);

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;

            await coreDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
