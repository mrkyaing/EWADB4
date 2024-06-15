var builder = WebApplication.CreateBuilder(args);
//register all of the Controllers/Views to the middleware
builder.Services.AddControllersWithViews();
var app = builder.Build();//hosting for  the browser as building  process 
app.MapGet("/", () => "Hello World!");//localhost:7022/
app.MapGet("/me",()=>"Mr Kyaing");
//map all of the url address of Controllers
app.MapDefaultControllerRoute();
app.Run();//run the hosting web to the browser 

