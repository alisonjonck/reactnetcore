using App.Domain.Interfaces.Conversors;
using App.Domain.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace App.Domain.Conversors
{
    public class FeedTopicsFromXml : IFeedTopicsFromXml
    {
        public IList<FeedTopic> GetFeedTopics(XElement xml)
        {
            return new List<FeedTopic>();
        }
    }
}
