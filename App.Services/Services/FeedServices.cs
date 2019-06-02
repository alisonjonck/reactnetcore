using App.Domain.Conversors;
using App.Domain.Interfaces.Conversors;
using App.Domain.Interfaces.Integrations;
using App.Domain.Interfaces.Services;
using App.Domain.Models;
using App.Services.Integrations;
using System.Collections.Generic;
using System.Linq;

namespace App.Services
{
    public class FeedServices : IFeedServices
    {
        private readonly IFeedAPI _feedAPI;
        private readonly IFeedTopicsFromXml _feedConversor;

        public FeedServices(IFeedAPI feedAPI = null, IFeedTopicsFromXml feedConversor = null)
        {
            _feedAPI = feedAPI ?? new FeedAPI();
            _feedConversor = feedConversor ?? new FeedTopicsFromXml();
        }

        public IList<FeedTopic> GetFeedTopics()
        {
            var feedXml = _feedAPI.GetFeedXml();

            return _feedConversor.GetFeedTopics(feedXml);
        }

        public IList<FeedTopic> GetFirst10FeedTopics()
        {
            var feedTopics = this.GetFeedTopics();

            return feedTopics.Take(10).ToList();
        }
    }
}
