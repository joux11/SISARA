using SISARA.Application.Common.Base;
using System.Text.Json;
using ValidationException = SISARA.Application.Common.Exceptions.ValidationException;

namespace SISARA.WebAPI.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;
        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
                {
                    Message = "Errores de Validacion",
                    Errors = ex.Errors,
                });
            }
        }
    }
}
