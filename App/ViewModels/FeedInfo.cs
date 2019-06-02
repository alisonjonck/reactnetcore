using App.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using App.Domain.Helpers;

namespace App.ViewModels
{
    public class FeedInfo
    {
        public IList<TopicInfo> Topics { get; set; }
        public IList<StringCount> MostUsed10 { get; set; }

        public FeedInfo(IList<FeedTopic> topics)
        {
            this.Topics = getTopicInfo(topics);
            this.MostUsed10 = topics.Select(x => x.Title.RemovePrepositions(" "))
                .ToList()
                .MostUsed(10);
        }

        private IList<TopicInfo> getTopicInfo(IList<FeedTopic> topics)
        {
            var topicInfos = new List<TopicInfo>();

            foreach (var topic in topics)
            {
                topicInfos.Add(new TopicInfo(topic));
            }

            return topicInfos;
        }
    }
}
