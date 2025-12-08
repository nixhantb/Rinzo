namespace JobLeet.WebApi.JobLeet.Api.Exceptions
{
    public class JwtTokenException : Exception
    {
        public JwtTokenException(string message)
            : base(message) { }

        public JwtTokenException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
