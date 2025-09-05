using Microsoft.EntityFrameworkCore;
using MvcProductApp.Services;
using MvcWebApp_Wk3v2.Data;
using MvcWebApp_Wk3v2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// This block is the key to fixing the error. It tells the application
// to look for views inside the /Features folder structure.
builder.Services.Configure<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>(options =>
{
    // {0} = View Name (e.g., "Index")
    // {1} = Controller Name (e.g., "Product")
    options.ViewLocationFormats.Insert(0, "/Features/{1}/Views/{0}.cshtml");
});


// Register the DbContext for the database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the ProductService with a Scoped lifetime for Dependency Injection
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// This line enables attribute routing for the controllers
app.MapControllers();

app.Run();

