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

        [SetUp]
        public void SetUp()
        {
            var feedAPIMock = new Mock<IFeedAPI>();
            var feedConversorMock = new Mock<IFeedTopicsFromXml>();

            feedConversorMock.Setup(m => m.GetFeedTopics(null)).Returns(new List<FeedTopic>());

            _feedServices = new FeedServices(feedAPIMock.Object, feedConversorMock.Object);
        }

        [Test]
        public void ReturnsFeedTopics()
        {
            var results = _feedServices.GetFeedTopics();

            Assert.IsInstanceOf<IList<FeedTopic>>(results);
            Assert.AreEqual(0, results.Count);
        }
    }
}