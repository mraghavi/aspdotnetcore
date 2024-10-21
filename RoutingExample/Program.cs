var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("file/{filename}.{extension}" , async context =>
    {
        await context.Response.WriteAsync("file name is");

    }
    );

});
app.Run( async context =>
{
    await context.Response.WriteAsync($"Request recieved at {context.Request.Path}");
}
);

app.Run();
