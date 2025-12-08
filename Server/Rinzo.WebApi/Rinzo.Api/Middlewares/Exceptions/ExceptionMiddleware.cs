using System.Net;

namespace JobLeet.WebApi.JobLeet.Api.Middlewares.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = exception switch
            {
                ApplicationException appEx => new ExceptionResponse(
                    HttpStatusCode.BadRequest,
                    "An application error occurred.",
                    appEx.Message
                ),

                KeyNotFoundException notFoundEx => new ExceptionResponse(
                    HttpStatusCode.NotFound,
                    "The requested resource was not found.",
                    notFoundEx.Message
                ),

                UnauthorizedAccessException unauthorizedEx => new ExceptionResponse(
                    HttpStatusCode.Unauthorized,
                    "Unauthorized access.",
                    unauthorizedEx.Message
                ),

                _ => new ExceptionResponse(
                    HttpStatusCode.InternalServerError,
                    "Internal server error. Please try again later.",
                    exception.Message
                ),
            };

            context.Response.StatusCode = (int)response.StatusCode;

            await context.Response.WriteAsJsonAsync(
                new
                {
                    response.StatusCode,
                    response.Message,
                    Details = response.Details,
                }
            );
        }

        private record ExceptionResponse(HttpStatusCode StatusCode, string Message, string Details);
    }
}
