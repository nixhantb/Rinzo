using System.Text.Json;

namespace JobLeet.WebApi.JobLeet.Api.Middlewares.TotalXCount
{
    public class TotalResponseHeaderCount
    {
        private readonly RequestDelegate _next;

        public TotalResponseHeaderCount(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Intercept the response
            var originalBodyStream = context.Response.Body;
            try
            {
                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;

                    await _next(context);

                    if (context.Response.StatusCode == StatusCodes.Status200OK)
                    {
                        int totalCount = CalculateTotalResponseCount(responseBody);

                        context.Response.Headers["X-Total-Count"] = totalCount.ToString();
                    }
                    responseBody.Seek(0, SeekOrigin.Begin);
                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured" + ex.Message);
            }
        }

        private int CalculateTotalResponseCount(MemoryStream responseBody)
        {
            try
            {
                // Reset the position of the memory stream to the beginning
                responseBody.Seek(0, SeekOrigin.Begin);
                using (var document = JsonDocument.Parse(responseBody))
                {
                    if (document.RootElement.ValueKind == JsonValueKind.Array)
                    {
                        int count = 0;
                        foreach (var element in document.RootElement.EnumerateArray())
                        {
                            count++;
                        }
                        return count;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (JsonException ex)
            {
                // Handle JSON parsing errors, if any
                Console.WriteLine("Error parsing JSON content: " + ex.Message);
                return 0;
            }
        }
    }
}
