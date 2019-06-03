using App.Domain.Interfaces.Integrations;
using System;
using System.IO;
using System.Net.Http;
using System.Xml.Linq;
using System.Xml.Serialization;

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

        public XElement GetFeedXml(bool isThrottle = false)
        {
            HttpResponseMessage result;
            Stream stream;
            XElement xml;

            try
            {
                if (isThrottle) throw new Exception("force throttle");

                result = _httpClient.GetAsync(FEED_API).Result;
                using (stream = result.Content.ReadAsStreamAsync().Result)
                {
                    xml = XElement.Load(stream);
                }
            }
            catch
            {
                using (FileStream xmlStream = new FileStream("Resources/feed.xml", FileMode.Open))
                {
                    xml = XElement.Load(xmlStream);
                    xml.Add(new XAttribute("isMocked", true));
                }
            }

            return xml;
        }
    }
}
