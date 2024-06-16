var builder = WebApplication.CreateBuilder(args);
//register all of the Controllers/Views to the middleware
builder.Services.AddControllersWithViews();
var app = builder.Build();//hosting for  the browser as building  process 
//initialized the default route
app.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
//map all of the url address of Controllers
app.MapDefaultControllerRoute();
app.Run();//run the hosting web to the browser 

