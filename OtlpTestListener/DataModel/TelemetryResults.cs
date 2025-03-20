using System.Text.Json;

namespace OtlpTestListener;

public class TelemetryResults
{
    public int SpanIdCount;
    public int LogMessageCount;
    public List<string> MetricNames { get; init; } = new();
    public List<string> ResourceNames { get; init; } = new();
    public List<string> TraceIds { get; init; } = new();
    public int MetricNameCount => MetricNames.Count;
    public int TraceIdCount => TraceIds.Count;

    public void Clear()
    {
        SpanIdCount = 0;
        LogMessageCount = 0;
        MetricNames.Clear();
        ResourceNames.Clear();
        TraceIds.Clear();
    }

    public void AddResourceName(string resourceName)
    {
        if (resourceName is not null && !ResourceNames.Contains(resourceName))
        {
            ResourceNames.Add(resourceName);
        }
    }

    #region JSON Serialization
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true,
    };

    public string GetResultsJSON() => JsonSerializer.Serialize(this, _jsonOptions);

    #endregion
}
