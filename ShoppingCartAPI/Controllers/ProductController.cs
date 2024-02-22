using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
[Authorize] // Requires the user to be authenticated
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }


    //Add a Get endpoint that returns all products.
   [HttpGet]
    public async Task<ActionResult> GetAllProducts()
    {
        var products = await _context.Products.ToListAsync();
        return Ok(products);
    }

    //Add a Get endpoint that takes a category Id and returns all products in that category.
    [HttpGet("category/{categoryId}")]
    public async Task<ActionResult> GetProductsByCategory(int categoryId)
    {
        var products = await _context.Products
                                     .Where(p => p.Category.Id == categoryId)
                                     .ToListAsync();
        return Ok(products);
    }
}