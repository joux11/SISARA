using SISARA.WebAPI.Middleware;

namespace SISARA.WebAPI.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder appBuilder)
        {
            return appBuilder.UseMiddleware<ValidationMiddleware>();
        }
    }

}
