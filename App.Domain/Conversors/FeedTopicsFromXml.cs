using App.Domain.Interfaces.Conversors;
using App.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace App.Domain.Conversors
{
    public class FeedTopicsFromXml : IFeedTopicsFromXml
    {
        private IEnumerable<XElement> getXmlFeedTopics(XElement xml)
        {
            return xml?.Elements()?.First()?.Elements()?.Where(e => e.Name.LocalName == "item");
        }

        public IList<FeedTopic> GetFeedTopics(XElement xml)
        {
            var feedTopics = new List<FeedTopic>();
            var xmlTopics = this.getXmlFeedTopics(xml);
            var isMocked = bool.Parse(xml.Attribute("isMocked")?.Value ?? "false");

            if (xmlTopics != null)
                foreach (var xmlTopic in xmlTopics)
                {
                    var title = (xmlTopic.FirstNode as XElement).Value;

                    if (!string.IsNullOrWhiteSpace(title))
                        feedTopics.Add(new FeedTopic(title, isMocked));
                }

            return feedTopics;
        }
    }
}
