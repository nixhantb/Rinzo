namespace Rinzo.Application.Common;

// Each exception type becomes one HTTP status code in the Api layer's error handler.
public sealed class NotFoundException(string entityName, object key)
    : Exception($"{entityName} with id '{key}' was not found.");

public sealed class ConflictException(string message) : Exception(message);

public sealed class BadRequestException(string message) : Exception(message);
