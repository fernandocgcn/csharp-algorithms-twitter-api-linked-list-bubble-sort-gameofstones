using System.Collections.Generic;

using TwitterApi.Models;

namespace TwitterApi.Services
{
    public interface ISearchTweetsService
    {
        void SetAuthentication(string consumerKey, string consumerSecret,
            string accessToken, string accessTokenSecret);
        IEnumerable<Tweet> GetTweetsByWord(string searchWord, int count = 10);
    }
}
