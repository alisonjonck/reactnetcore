using App.Domain.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace App.Domain.Interfaces.Conversors
{
    public interface IFeedTopicsFromXml
    {
        IList<FeedTopic> GetFeedTopics(XElement xml);
    }
}
