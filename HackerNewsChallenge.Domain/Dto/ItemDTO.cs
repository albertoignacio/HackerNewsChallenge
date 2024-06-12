using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HackerNewsChallenge.Domain.Dto;

public record ItemDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("by")]
    public string By { get; set; }
    public string Text { get; set; }
    public string Parent { get; set; }
    public int? Poll { get; set; }
    [JsonPropertyName("kids")]
    public List<int> Kids { get; set; }
    public string Url { get; set; }
    [JsonPropertyName("score")]
    public int? Score { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("descendants")]
    public int? Descendants { get; set; }
}

