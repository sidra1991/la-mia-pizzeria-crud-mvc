
using la_mia_pizzeria_static.Controllers.Repository;
using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Models;



var builder = WebApplication.CreateBuilder(args);

// gi? presente (non inserire)
//builder.Services.AddControllersWithViews();

builder.Services.AddScoped<InerfacePizzaRepository, DbPizzaRepository>();


// Add services to the container.
builder.Services.AddControllersWithViews();

//da inserirsi sotto a AddControllersWithViews
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();
