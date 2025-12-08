namespace JobLeet.WebApi.JobLeet.Api.Security.Headers
{
    public class SecurityHeadersOptions
    {
        public string ContentSecurityPolicy { get; set; } = "default-src 'self'";
        public string XContentTypeOptions { get; set; } = "nosniff";
        public string XFrameOptions { get; set; } = "SAMEORIGIN";
        public string XXssProtection { get; set; } = "1; mode=block";
    }
}
