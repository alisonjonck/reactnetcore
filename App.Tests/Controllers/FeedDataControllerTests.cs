using App.Controllers;
using App.Domain.Interfaces.Services;
using App.Domain.Models;
using App.ViewModels;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace App.Tests.Controllers
{
    [TestFixture]
    public class FeedDataControllerTests
    {
        [Test]
        public void ReturnsFeedInfo()
        {
            Mock<IFeedServices> feedServicesMock = new Mock<IFeedServices>();

            var feedTopics = new List<FeedTopic>();

            for (int i = 0; i < 10; i++)
            {
                feedTopics.Add(new FeedTopic("Exemplo de topico com palavras de exemplo " + i));
            }

            feedServicesMock.Setup(x => x.GetFirst10FeedTopics()).Returns(feedTopics);

            FeedDataController controller = new FeedDataController(feedServicesMock.Object);

            var feedInfo = (FeedInfo)controller.ReturnsFeedInfo().Value;

            var expected = new FeedInfo(feedTopics);

            Assert.AreEqual(expected.MostUsed10.Count, feedInfo.MostUsed10.Count);
            Assert.AreEqual(expected.Topics.Count, feedInfo.Topics.Count);
        }
    }
}
