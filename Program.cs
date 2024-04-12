using HealthNCare.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

static void NewMethod(WebApplication app)
{
    app.Run();
}

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RepositoryContext>(options =>{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"));
});
builder.Services.AddDbContext<DoctorContext>(options =>{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection1"));
});
builder.Services.AddDbContext<LocationContext>(options =>{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection3"));
});
builder.Services.AddDbContext<DepartmentContext>(options=>{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection4"));
});
builder.Services.AddDbContext<HospitalContext>(options=>{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection5"));
});
builder.Services.AddDbContext<AppointmentContext>(options=>{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection6"));
});

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

NewMethod(app);

