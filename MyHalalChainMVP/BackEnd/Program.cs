using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http; // ✅ Fix for `Results`
using System.ComponentModel.DataAnnotations;
using System.Linq; // ✅ Fix for `.Where()` method

// ✅ Create WebApplication Builder
var builder = WebApplication.CreateBuilder(args);

// ✅ Configure services
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://your-auth-provider.com";
        options.Audience = "your-api";
    });

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// ✅ Apply migrations automatically (Only in Development)
ApplyMigrations(app);

// ✅ Middleware
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// ✅ Secure API Endpoint
app.MapGet("/secure-data", [Authorize] () => "This is secure data");

// ✅ Get all Halal Products
app.MapGet("/products", async (AppDbContext db) => 
    await db.Products.Where(p => p.IsHalalCertified).ToListAsync()); // ✅ FIXED: LINQ now recognized

// ✅ Get all Vendors
app.MapGet("/vendors", async (AppDbContext db) => 
    await db.Vendors.ToListAsync());

// ✅ Add a new Halal Product
app.MapPost("/products", async (AppDbContext db, Product product) => 
{
    db.Products.Add(product);
    await db.SaveChangesAsync();
    return Results.Created($"/products/{product.Id}", product); // ✅ FIXED: `Results` now recognized
});

// ✅ Run application
app.Run();

// ✅ Migration Method
static void ApplyMigrations(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

// ✅ DbContext & Models
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
}

// ✅ Updated Product Model with Halal Certification
public class Product
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }

    public bool IsHalalCertified { get; set; } = false;

    public string CertificationAuthority { get; set; } // E.g., MUI, JAKIM, etc.
}

// ✅ Updated Vendor Model
public class Vendor
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public bool IsApproved { get; set; } = false;
}
