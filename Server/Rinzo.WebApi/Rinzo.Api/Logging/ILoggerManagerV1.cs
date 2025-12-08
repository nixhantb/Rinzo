namespace JobLeet.WebApi.JobLeet.Api.Logging
{
    public interface ILoggerManagerV1
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
