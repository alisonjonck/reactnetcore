using App.Domain.Interfaces.Conversors;
using App.Domain.Interfaces.Integrations;
using App.Domain.Interfaces.Services;
using App.Domain.Models;
using App.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace App.Tests.Services
{
    [TestFixture]
    public class FeedServicesTests
    {
        private IFeedServices _feedServices;
        private Mock<IFeedAPI> feedAPIMock;
        private Mock<IFeedTopicsFromXml> feedConversorMock;

        [SetUp]
        public void SetUp()
        {
            feedAPIMock = new Mock<IFeedAPI>();
            feedConversorMock = new Mock<IFeedTopicsFromXml>();

            feedConversorMock.Setup(m => m.GetFeedTopics(null)).Returns(new List<FeedTopic>());

            _feedServices = new FeedServices(feedAPIMock.Object, feedConversorMock.Object);
        }

        [Test]
        public void ReturnsFeedTopics()
        {
            var results = _feedServices.GetFeedTopics(false);

            Assert.IsInstanceOf<IList<FeedTopic>>(results);
            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ReturnsFirst10FeedTopics()
        {
            prepareMockToReturnMoreThan10FeedTopics();

            var results = _feedServices.GetFirst10FeedTopics(false);
            Assert.AreEqual(10, results.Count);
        }

        [Test]
        public void ReturnsMockedFirst10FeedTopics()
        {
            prepareMockToReturnMoreThan10FeedTopics();

            var results = _feedServices.GetFirst10FeedTopics(true);
            Assert.AreEqual(10, results.Count);
        }

        private void prepareMockToReturnMoreThan10FeedTopics()
        {
            var feedTopics = new List<FeedTopic>();

            for (int i = 0; i < 11; i++)
            {
                feedTopics.Add(new FeedTopic("Sample Topic " + i));
            }

            feedConversorMock.Setup(m => m.GetFeedTopics(null)).Returns(feedTopics);

            _feedServices = new FeedServices(feedAPIMock.Object, feedConversorMock.Object);
        }
    }
}