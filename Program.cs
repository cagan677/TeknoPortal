using Microsoft.EntityFrameworkCore;
using TeknoPortal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSession();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<PortalContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DbBaglantisi")));

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();