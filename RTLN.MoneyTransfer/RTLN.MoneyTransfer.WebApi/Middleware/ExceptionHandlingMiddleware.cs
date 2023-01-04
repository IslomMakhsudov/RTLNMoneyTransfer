using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Text.Json;

namespace RTLN.MoneyTransfer.WebApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                string? message = null;
                switch (ex)
                {
                    case KeyNotFoundException:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        message = ex.Message;
                        break;
                    default:
                        message = "Server error";
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = message ?? ex?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
