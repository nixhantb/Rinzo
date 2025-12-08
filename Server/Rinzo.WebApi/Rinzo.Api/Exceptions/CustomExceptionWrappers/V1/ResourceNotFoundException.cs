namespace JobLeet.WebApi.JobLeet.Api.Exceptions.CustomExceptionWrappers.V1
{
    public class ResourceNotFoundException
    {
        private readonly RequestDelegate _next;

        public ResourceNotFoundException(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            // Save the original response stream and create a new one
            var originalResponseBody = context.Response.Body;
            var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            try
            {
                await _next(context);

                if (
                    context.Response.StatusCode == StatusCodes.Status404NotFound
                    && !context.Response.HasStarted
                )
                {
                    var requestPath = context.Request.Path;
                    var requestUri =
                        $"{context.Request.Scheme}://{context.Request.Host}{requestPath}";
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync(
                        $"{{\"Message\": \"No HTTP resource was found that matches the request URI '{requestUri}'\"}}"
                    );
                }
            }
            finally
            {
                // Restore the original response stream
                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalResponseBody);
                context.Response.Body = originalResponseBody;
            }
        }
    }
}
