using System.Text.Json.Serialization;

namespace WebAPI.Entities.Products;

public class Specification
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;
}
