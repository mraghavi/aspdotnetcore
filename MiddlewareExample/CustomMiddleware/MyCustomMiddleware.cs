﻿
namespace MiddlewareExample.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Middle ware 1");
            next(context);
            await context.Response.WriteAsync("Middleware 2");
        }
    }
}
