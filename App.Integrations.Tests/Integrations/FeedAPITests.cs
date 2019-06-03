using App.Domain.Interfaces.Integrations;
using App.Services.Integrations;
using NUnit.Framework;
using System.Xml.Linq;

namespace App.Tests.Services
{
    [TestFixture]
    public class FeedAPITests
    {
        private readonly IFeedAPI _feedAPI;

        public FeedAPITests()
        {
            _feedAPI = new FeedAPI();
        }

        [Test]
        public void ReturnsFeedXml()
        {
            var feedXml = _feedAPI.GetFeedXml(false);

            Assert.IsNotNull(feedXml);
            Assert.IsInstanceOf<XElement>(feedXml);
        }
    }
}