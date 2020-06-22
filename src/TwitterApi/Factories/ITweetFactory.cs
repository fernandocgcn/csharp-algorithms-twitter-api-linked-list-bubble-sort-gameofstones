using Newtonsoft.Json.Linq;

using TwitterApi.Models;

namespace TwitterApi.Factories
{
    public interface ITweetFactory
    {
        Tweet CreateFromStatus(JToken status);
    }
}
