using LoginMiddlewareApp;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Ensure middleware is properly registered in the correct order.
app.UseMiddleware<LoginMiddleware>();

// Handle GET requests at "/".
app.MapGet("/", () => Results.Ok("No response"));

app.Run();
