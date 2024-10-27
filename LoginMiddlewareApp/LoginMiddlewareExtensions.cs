namespace LoginMiddlewareApp
{
    using Microsoft.AspNetCore.Builder;

    namespace LoginMiddlewareApp
    {
        public static class LoginMiddlewareExtensions
        {
            public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<LoginMiddleware>();
            }
        }
    }

}
