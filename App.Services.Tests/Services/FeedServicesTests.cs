using App.Domain.Interfaces.Services;
using App.Services;
using NUnit.Framework;

namespace App.Tests.Services
{
    [TestFixture]
    public class FeedServicesTests
    {
        private readonly IFeedServices _feedServices;

        public FeedServicesTests()
        {
            _feedServices = new FeedServices();
        }

        [Test]
        public void ReturnsAnyFeedTopics()
        {
            var results = _feedServices.GetFeedTopics();

            Assert.Greater(results.Count, 0);
        }
    }
}