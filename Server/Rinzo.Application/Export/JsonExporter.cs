using System.Text.Json;

namespace Rinzo.Application.Export;

public sealed class JsonExporter<T> : IExporter<T>
{
    public string Format => "json";
    public string ContentType => "application/json";

    public byte[] Export(IReadOnlyList<T> items) =>
        JsonSerializer.SerializeToUtf8Bytes(items, JsonSerializerOptions.Web);
}
