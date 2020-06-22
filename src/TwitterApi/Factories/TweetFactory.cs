using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

using TwitterApi.Models;

namespace TwitterApi.Factories
{
    internal class TweetFactory : ITweetFactory
    {
        public Tweet CreateFromStatus(JToken status) =>
            new Tweet
            {
                Id = (long)status["id"],
                Text = (string)status["text"],
                CreatedAt = DateTime.ParseExact(
                        (string)status["created_at"], "ddd MMM dd HH:mm:ss zzz yyyy",
                        CultureInfo.InvariantCulture)
            };
    }
}
