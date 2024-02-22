using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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

}
