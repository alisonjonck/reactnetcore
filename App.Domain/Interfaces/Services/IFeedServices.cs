using App.Domain.Models;
using System.Collections.Generic;

namespace App.Domain.Interfaces.Services
{
    public interface IFeedServices
    {
        IList<FeedTopic> GetFeedTopics(bool isThrottle);

        IList<FeedTopic> GetFirst10FeedTopics(bool isThrottle);
    }
}
