using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LoginMiddlewareApp
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Post && context.Request.Path == "/")
            {
                // Ensure the request has form content type
                if (!context.Request.HasFormContentType)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid form data");
                    return;
                }

                // Read form data
                var form = await context.Request.ReadFormAsync();
                var email = form["email"].ToString();
                var password = form["password"].ToString();

                // Validate inputs
                if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'email'\nInvalid input for 'password'");
                }
                else if (string.IsNullOrEmpty(email))
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'email'");
                }
                else if (string.IsNullOrEmpty(password))
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'password'");
                }
                else if (email == "admin@example.com" && password == "admin1234")
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Successful login");
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid login");
                }
            }
            else
            {
                // Pass non-POST requests down the pipeline
                await _next(context);
            }
        }
    }
}
