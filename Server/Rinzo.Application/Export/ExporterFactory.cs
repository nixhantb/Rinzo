using Rinzo.Application.Common;

namespace Rinzo.Application.Export;

public interface IExporterFactory<T>
{
    IExporter<T> Get(string format);
}

// DI gives us every registered IExporter<T> (one per format). We pick one by name.
public sealed class ExporterFactory<T>(IEnumerable<IExporter<T>> exporters) : IExporterFactory<T>
{
    public IExporter<T> Get(string format) =>
        exporters.FirstOrDefault(e => e.Format.Equals(format, StringComparison.OrdinalIgnoreCase))
        ?? throw new BadRequestException(
            $"Format '{format}' is not supported. Use one of: {string.Join(", ", exporters.Select(e => e.Format))}."
        );
}
