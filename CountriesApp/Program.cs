using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Hardcoded dictionary of countries
var countries = new Dictionary<int, string>
{
    { 1, "United States" },
    { 2, "Canada" },
    { 3, "United Kingdom" },
    { 4, "India" },
    { 5, "Japan" }
};
app.MapGet("/", () => "Welcome to Countries app");
// Endpoint to get the list of all countries
app.MapGet("/countries", async context =>
{
    context.Response.StatusCode = 200;
    foreach (var country in countries)
    {
        await context.Response.WriteAsync($"{country.Key}, {country.Value}\n");
    }
});

// Endpoint to get a specific country by ID
app.MapGet("/countries/{countryID:int}", async (HttpContext context, int countryID) =>
{
    if (countryID > 100)
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("The CountryID should be between 1 and 100");
    }
    else if (countries.TryGetValue(countryID, out string countryName))
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync(countryName);
    }
    else
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("[No Country]");
    }
});

// Run the application
app.Run();
