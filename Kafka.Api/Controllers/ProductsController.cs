using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kafka.Api;

public class ProductsController(AppDbContext db) : ControllerBase
{
    [HttpGet("api/products")]
    public async Task<IActionResult> GetProducts([FromQuery] int? id)
    {
        var products = db.Products
            .Select(p => new ProductResponse
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price
            });

        if(id.HasValue) products = products.Where(p => p.Id == id);

        var result = await products.ToListAsync();

        return Ok(result);
    }


    private class ProductResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }

}