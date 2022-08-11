using Microsoft.EntityFrameworkCore;
using MotorcycleMarket.DAL;
using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.DAL.Repositories;
using MotorcycleMarket.Service.Interfaces;
using MotorcycleMarket.Service.Implementation;
using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<IBaseRepository<Motorcycle>, MotorcycleRepository>();
builder.Services.AddScoped<IMotorcycleService, MotorcycleService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseMiddleware<JwtMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
 


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
