using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace JobLeet.WebApi.JobLeet.Api.Security.Headers
{
    public class SecurityHeaders
    {
        public readonly RequestDelegate _next;
        public readonly SecurityHeadersOptions _options;

        public SecurityHeaders(RequestDelegate next, IOptions<SecurityHeadersOptions> options)
        {
            _next = next;
            _options = options.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!string.IsNullOrEmpty(_options.ContentSecurityPolicy))
            {
                context.Response.Headers.Add(
                    "Content-Security-Policy",
                    new StringValues(_options.ContentSecurityPolicy)
                );
            }
            if (!string.IsNullOrEmpty(_options.XContentTypeOptions))
            {
                context.Response.Headers.Add(
                    "X-Content-Type-Options",
                    new StringValues(_options.XContentTypeOptions)
                );
            }
            if (!string.IsNullOrEmpty(_options.XFrameOptions))
            {
                context.Response.Headers.Add(
                    "X-Frame-Options",
                    new StringValues(_options.XFrameOptions)
                );
            }
            if (!string.IsNullOrEmpty(_options.XXssProtection))
            {
                context.Response.Headers.Add(
                    "X-XSS-Protection",
                    new StringValues(_options.XXssProtection)
                );
            }
            await _next(context);
        }
    }
}
