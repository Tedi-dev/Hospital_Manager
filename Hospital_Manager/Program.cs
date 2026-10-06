using Data_Hospital_Manager;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HospitalDbContext>(options =>
    options.UseSqlServer(
<<<<<<< HEAD
        builder.Configuration.GetConnectionString("Arsenal")));
=======
        builder.Configuration.GetConnectionString("ShcoolConnection")));
>>>>>>> 5fd0922e6384c5f943a3eea8c1594797bc7638f8

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
    pattern: "{controller=Hospital}/{action=Index}/{id?}");

app.Run();
