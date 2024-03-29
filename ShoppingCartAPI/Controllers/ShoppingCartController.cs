using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ShoppingCartLibrary.Model;
using ShoppingCartAPI.Data;



[Route("api/[controller]")]
[ApiController]
[Authorize] // Requires the user to be authenticated
public class ShoppingCartController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public ShoppingCartController(AppDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    //Add a Get endpoint that returns all products in the user's shopping cart.
    [HttpGet]
    public async Task<ActionResult> GetCart()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var cart = await _context.ShoppingCarts
                                 .Include(c => c.Products)
                                 .FirstOrDefaultAsync(c => c.User == userId);

        if (cart == null) return NotFound("Shopping cart not found.");

        return Ok(cart.Products);
    }

    [HttpPost("add/{productId}")]
    public async Task<ActionResult> AddToCart(int productId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var cart = await _context.ShoppingCarts
                                .Include(c => c.Products)
                                .SingleOrDefaultAsync(c => c.User == userId);

        // Ensure that cart is not null before accessing its members
        if (cart == null)
        {
            cart = new ShoppingCart { User = userId };
            _context.ShoppingCarts.Add(cart);
        }

        var product = await _context.Products.FindAsync(productId);
        if (product == null) return NotFound("Product not found.");

        cart.Products.Add(product);
        await _context.SaveChangesAsync();
        return Ok();
    }


    [HttpPost("remove/{productId}")]
    public async Task<ActionResult> RemoveFromCart(int productId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var cart = await _context.ShoppingCarts
                                 .Include(c => c.Products)
                                 .SingleOrDefaultAsync(c => c.User == userId);

        if (cart == null) return NotFound("Shopping cart not found.");

        var product = cart.Products.FirstOrDefault(p => p.Id == productId);
        if (product == null) return NotFound("Product not found in cart.");

        cart.Products.Remove(product);
        await _context.SaveChangesAsync();
        return Ok();
    }

}
