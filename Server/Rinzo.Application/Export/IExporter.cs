namespace Rinzo.Application.Export;

// One "strategy" = one way to turn a list of response DTOs into a file. Generic over T
// so every resource (Company, Job, Seeker...) gets CSV and JSON export for free,
// instead of five near-identical exporter classes.
public interface IExporter<T>
{
    string Format { get; } // "csv" or "json": the name used in the URL
    string ContentType { get; }
    byte[] Export(IReadOnlyList<T> items);
}
