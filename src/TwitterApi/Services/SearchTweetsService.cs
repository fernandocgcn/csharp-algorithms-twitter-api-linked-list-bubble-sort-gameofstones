using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

using TwitterApi.Factories;
using TwitterApi.Models;

namespace TwitterApi.Services
{
    public class SearchTweetsService : ISearchTweetsService
    {
        private readonly RestClient Client;
        private readonly ITweetFactory TweetFactory;

        public SearchTweetsService(ITweetFactory tweetFactory)
        {
            Client = new RestClient("https://api.twitter.com");
            TweetFactory = tweetFactory;
        }

        public void SetAuthentication(string consumerKey, string consumerSecret, 
            string accessToken, string accessTokenSecret) =>
            Client.Authenticator = OAuth1Authenticator.ForProtectedResource(
                    consumerKey, consumerSecret, accessToken, accessTokenSecret);

        public IEnumerable<Tweet> GetTweetsByWord(string searchWord, int count = 10)
        {
            var request = new RestRequest($"1.1/search/tweets.json?q={searchWord}&count={count}", 
                Method.GET) { RequestFormat = DataFormat.Json };
            var response = Client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var statuses = (JArray)JObject.Parse(response.Content)["statuses"];
                return statuses.Select(status => TweetFactory.CreateFromStatus(status));
            }
            else
                throw new HttpRequestException(response.Content);
        }
    }
}
