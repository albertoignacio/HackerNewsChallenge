using HackerNewsChallenge.Domain.Models;

namespace HackerNewsChallenge.Services.Interfaces;
public interface IHackerNewsChallengeService
{
    Task<IEnumerable<TopStories>> GetListTopStories(int page, int pageSize);
    Task<Item> GetItem(int id);
}

