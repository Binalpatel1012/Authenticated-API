using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartAPI.Data;
using ShoppingCartLibrary;
using System.Linq;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ShoppingCartController : ControllerBase
{
    private readonly AppDbContext _context;

    public ShoppingCartController(AppDbContext context)
    {
        _context = context;
    }

    // Implement endpoints here
}
