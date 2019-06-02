using App.Domain.Interfaces.Integrations;
using App.Domain.Interfaces.Services;
using App.Domain.Models;
using App.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace App.Tests.Services
{
    [TestFixture]
    public class FeedServicesTests
    {
        private readonly IFeedServices _feedServices;

        public FeedServicesTests()
        {
            //IFeedAPI feedAPI = new Mock<IFeedAPI>();
            
            _feedServices = new FeedServices();
        }

        [Test]
        public void ReturnsFeedTopics()
        {
            var results = _feedServices.GetFeedTopics();

            Assert.IsInstanceOf<IList<FeedTopic>>(results);
        }
    }
}