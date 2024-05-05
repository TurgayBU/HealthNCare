using HealthNCare.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using HealthNCare.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);


static void NewMethod(WebApplication app)
{
    app.Run();
}

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<PatientDbContext>(options =>{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"));
});
builder.Services.AddDbContext<Patients1DbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Patients1DbContextConnection"));
});

builder.Services.AddDefaultIdentity<Patients1>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<Patients1DbContext>();
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
builder.Services.Configure<IdentityOptions>(options=>{
    options.Password.RequireUppercase=false;
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
app.MapRazorPages();

NewMethod(app);

