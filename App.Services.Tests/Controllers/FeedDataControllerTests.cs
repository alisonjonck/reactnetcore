using App.Controllers;
using App.Services;
using App.ViewModels;
using NUnit.Framework;

namespace App.Integration.Tests.Controllers
{
    [TestFixture]
    public class FeedDataControllerTests
    {
        [Test]
        public void ReturnsFeedInfo()
        {
            FeedDataController controller = new FeedDataController(new FeedServices());

            var feedInfo = (FeedInfo)controller.ReturnsFeedInfo().Value;

            Assert.AreEqual(feedInfo.MostUsed10.Count, 10);
            Assert.AreEqual(feedInfo.Topics.Count, 10);
        }
    }
}
