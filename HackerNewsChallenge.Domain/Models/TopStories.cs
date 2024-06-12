using System.Text.Json.Serialization;

namespace HackerNewsChallenge.Domain.Models;

public record TopStories
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("url")]
    public string Url { get; set; }
}