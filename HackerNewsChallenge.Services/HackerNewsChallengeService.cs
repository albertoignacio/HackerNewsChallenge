using HackerNewsChallenge.Domain.Models;
using HackerNewsChallenge.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace HackerNewsChallenge.Services;

public class HackerNewsChallengeService(IHttpClientFactory clientFactory, IConfiguration configuration) : IHackerNewsChallengeService
{
    private readonly IHttpClientFactory _httpClientFactory = clientFactory;
    private readonly IConfiguration _configuration = configuration;
    public const string baseUrl = "https://hacker-news.firebaseio.com/v0";
    public const string storiesPath = "topstories.json?print=pretty";
    public const string itemPath = "item";

    private async Task<List<int>> GetListOfItem(int page, int pageSize)
    {
        const string url = $"{baseUrl}/{storiesPath}";
        var httpClient = this._httpClientFactory.CreateClient();
        var response = await httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var listItems = await response.Content.ReadAsStringAsync();
            var listItemsDeserialize = (JsonSerializer.Deserialize<List<int>>(listItems));
            var itemCount = listItemsDeserialize.Count();
            return listItemsDeserialize.Skip((page - 1) * pageSize).Take(30).ToList();
        }

        throw new Exception(response.StatusCode.ToString());
    }

    public async Task<IEnumerable<TopStories>> GetListTopStories(int page, int pageSize)
    {
        var listTopStories = new List<TopStories>();
        var listItemIds = await GetListOfItem(page, pageSize);
        var httpClient = this._httpClientFactory.CreateClient();
        foreach (var id in listItemIds)
        {
            var url = $"{baseUrl}/{itemPath}/{id}.json?print=pretty";
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadAsStringAsync();
                var story = JsonSerializer.Deserialize<TopStories>(item);
                listTopStories.Add(story);
            }
        }
        return listTopStories;
    }

    public async Task<Item> GetItem(int id)
    {
        var httpClient = this._httpClientFactory.CreateClient();
        var url = $"{baseUrl}/{itemPath}/{id}.json?print=pretty";
        var response = await httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var item = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Item>(item);
        }
        throw new Exception(response.StatusCode.ToString());
    }
}


