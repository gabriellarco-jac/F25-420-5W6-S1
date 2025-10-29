using Dutch_Treat.Data;
using Dutch_Treat.Data.Interfaces;
using Dutch_Treat.Data.Repositories;
using Dutch_Treat.Data.Repositories.Helpers;
using DutchTreat.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<DutchSeeder>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepositoryProvider, RepositoryProvider>();


var app = builder.Build();

await RunSeeding(app);

async Task RunSeeding(WebApplication app)
{
    var scopeFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopeFactory.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetService<DutchSeeder>();
        await seeder.Seed();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
