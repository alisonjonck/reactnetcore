using App.Domain.Models;
using NUnit.Framework;

namespace App.Tests.Models
{
    [TestFixture]
    public class FeedTopicTests
    {
        private FeedTopic topic;

        [SetUp]
        public void SetUp()
        {
            topic = new FeedTopic("Sample Topic");
        }

        [Test]
        public void InstantiatesFeedTopic()
        {
            Assert.IsInstanceOf<FeedTopic>(topic);
            Assert.AreEqual("Sample Topic", topic.Title);
        }
    }
}
