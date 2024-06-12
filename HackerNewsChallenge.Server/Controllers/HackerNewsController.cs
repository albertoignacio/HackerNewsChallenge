using HackerNewsChallenge.Domain.Dto;
using HackerNewsChallenge.Domain.Models;
using HackerNewsChallenge.Services;
using HackerNewsChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsChallenge.API.Controllers;

[ApiController]
[Route("[controller]")]
public class HackerNewsController : ControllerBase
{
    private readonly IHackerNewsChallengeService _hackerChallengeService;

    public HackerNewsController( IHackerNewsChallengeService hackerChallengeService)
    {
        this._hackerChallengeService = hackerChallengeService;
    }

    [HttpGet]
    [Route("/getlisttopstories")]
    public async Task<IEnumerable<TopStories>> GetListTopStories(int page, int pageSize)
    {
        var result = await this._hackerChallengeService.GetListTopStories(page, pageSize);
        return result;
    }

    [HttpGet]
    [Route("/getitem")]
    public async Task<Item> GetItem(int id)
    {
        var result = await this._hackerChallengeService.GetItem(id);
        return result;
    }
}

