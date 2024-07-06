using CloudHRMS.DAO;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//get the configuration 
var config = builder.Configuration;
//register the CloudHRMSApplicationDbContext with connectionString of appSetting.json
builder.Services.AddDbContext<CloudHRMSApplicationDbContext>(o =>o.UseSqlServer(config.GetConnectionString("CloudHRMSConnectionString")));
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

app.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
