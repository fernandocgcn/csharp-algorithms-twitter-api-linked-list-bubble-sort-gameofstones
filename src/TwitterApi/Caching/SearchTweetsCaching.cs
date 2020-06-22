using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

using TwitterApi.Models;
using TwitterApi.Services;

namespace TwitterApi.Caching
{
    public class SearchTweetsCaching<T> : ISearchTweetsService
        where T : ISearchTweetsService
    {
        private readonly IMemoryCache MemoryCache;
        private readonly T Inner;

        public SearchTweetsCaching(IMemoryCache memoryCache, T inner)
        {
            MemoryCache = memoryCache;
            Inner = inner;
        }

        public IEnumerable<Tweet> GetTweetsByWord(string searchWord, int count = 10)
        {
            var key = $"tweets-{searchWord}-{count}";
            var item = MemoryCache.Get<IEnumerable<Tweet>>(key);
            if (item == null)
            {
                item = Inner.GetTweetsByWord(searchWord, count);
                if (item != null)
                    MemoryCache.Set(key, item, TimeSpan.FromMinutes(1));
            }
            return item;
        }

        public void SetAuthentication(string consumerKey, string consumerSecret,
            string accessToken, string accessTokenSecret) =>
            Inner.SetAuthentication(consumerKey, consumerSecret, accessToken, accessTokenSecret);
    }
}
