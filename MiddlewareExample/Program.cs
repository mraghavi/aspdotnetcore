using MiddlewareExample.CustomMiddleware;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

//MiddlewareFactory which terminates by using Run
//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("Hello World!!!!!!!!!");
//}

//    );
//// app.run method doesnt forward subsequent method or anything to run 
//app.MapGet("/", () => "Hello aggain");

app.Use(async(HttpContext context , RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello World 1");
    next(context);
    
});

app.UseMiddleware<MyCustomMiddleware>();
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello World 2");
    next(context);
   
});




app.Run();
