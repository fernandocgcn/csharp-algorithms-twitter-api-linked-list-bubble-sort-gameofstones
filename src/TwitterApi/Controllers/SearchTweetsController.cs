using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using TwitterApi.Models;
using TwitterApi.Services;

namespace TwitterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchTweetsController : ControllerBase
    {
        private readonly ISearchTweetsService SearchTweetsService;

        public SearchTweetsController(ISearchTweetsService searchTweetsService)
        {
            SearchTweetsService = searchTweetsService;
            // Put your twitter credentials on here.
            SearchTweetsService.SetAuthentication(
                "XXXXXXXXXXXXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
        }

        [HttpGet]
        public IEnumerable<Tweet> GetTweetsByWord(string searchWord, int count = 10) => 
            SearchTweetsService.GetTweetsByWord(searchWord, count);
    }
}
