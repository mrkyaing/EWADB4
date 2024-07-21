using CloudHRMS.DAO;
using CloudHRMS.Services;
using CloudHRMS.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//get the configuration 
var config = builder.Configuration;
//register the CloudHRMSApplicationDbContext with connectionString of appSetting.json
builder.Services.AddDbContext<CloudHRMSApplicationDbContext>(o =>o.UseSqlServer(config.GetConnectionString("CloudHRMSConnectionString")));
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();//register the Unit Of Work for all repositories for it.
builder.Services.AddTransient<IPositionService,PositionService>();// register the Position domain for CRUD process
builder.Services.AddTransient<IDepartmentService, DepartmentService>();// register the Department domain for CRUD process
builder.Services.AddRazorPages();//for Identity pages
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<CloudHRMSApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
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
//Enable Both Authentication & Authorization for Security Purpose
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();//for  Authentication & Authorization UI Pages.
app.Run();
