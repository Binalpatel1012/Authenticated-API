using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.Data; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure DbContext for Identity
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure ASP.NET Core Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add authentication
builder.Services.AddAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization();

app.Run();
