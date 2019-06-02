using App.Domain.Interfaces.Integrations;
using System.Net.Http;
using System.Xml.Linq;

namespace App.Services.Integrations
{
    public class FeedAPI : IFeedAPI
    {
        private const string FEED_API = "http://www.minutoseguros.com.br/blog/feed/";

        private readonly HttpClient _httpClient;

        public FeedAPI()
        {
            _httpClient = new HttpClient();
        }

        public XElement GetFeedXml()
        {
            var result = _httpClient.GetAsync(FEED_API).Result;

            var stream = result.Content.ReadAsStreamAsync().Result;

            return XElement.Load(stream);
        }
    }
}
