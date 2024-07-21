using Footballers_v2.Data;
using Footballers_v2.Hubs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//SIGNAL R
builder.Services.AddSignalR();

builder.Services.AddControllersWithViews();

//NPGSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("FootballerPortal")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.MapHub<FootballersHub>("/football");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Footballers}/{action=Add}/{id?}");

app.Run();
