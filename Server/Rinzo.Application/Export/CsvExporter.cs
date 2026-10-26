using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Rinzo.Application.Export;

// Builds a CSV by reflecting over T's public properties, so each resource's response
// record gets a CSV exporter with no per-resource code. A simple (string/number/date/
// enum/guid) property becomes a column value; anything else (nested DTOs, lists) is
// serialized to a compact JSON string in that cell.
public sealed class CsvExporter<T> : IExporter<T>
{
    private static readonly PropertyInfo[] Properties = typeof(T).GetProperties(
        BindingFlags.Public | BindingFlags.Instance
    );

    public string Format => "csv";
    public string ContentType => "text/csv";

    public byte[] Export(IReadOnlyList<T> items)
    {
        var csv = new StringBuilder();
        csv.AppendLine(string.Join(',', Properties.Select(p => Escape(p.Name))));

        foreach (var item in items)
        {
            var values = Properties.Select(p => Escape(FormatValue(p.GetValue(item))));
            csv.AppendLine(string.Join(',', values));
        }

        return Encoding.UTF8.GetBytes(csv.ToString());
    }

    private static string FormatValue(object? value) =>
        value switch
        {
            null => string.Empty,
            string s => s,
            bool or byte or short or int or long or float or double or decimal => Convert.ToString(
                value,
                System.Globalization.CultureInfo.InvariantCulture
            )!,
            DateTime or DateOnly or Guid or Enum => value.ToString()!,
            _ => JsonSerializer.Serialize(value, JsonSerializerOptions.Web),
        };

    // CSV rule: a value with a comma, quote or new line goes inside quotes, and every
    // quote inside it is doubled.
    private static string Escape(string value) =>
        value.IndexOfAny([',', '"', '\n']) < 0 ? value : '"' + value.Replace("\"", "\"\"") + '"';
}
