using Microsoft.AspNetCore.Builder;

namespace PetClinic.Extensions
{
    public static class CustomMiddlewareExtensions
    {
        public static void ConfigureExceptionHanderMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
