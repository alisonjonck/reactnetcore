using App.Domain.Conversors;
using App.Domain.Interfaces.Conversors;
using App.Domain.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Xml.Linq;

namespace App.Tests.Conversors
{
    [TestFixture]
    public class FeedTopicsFromXmlTests
    {
        private IFeedTopicsFromXml xmlConversor;

        [SetUp]
        public void SetUp()
        {
            xmlConversor = new FeedTopicsFromXml();
        }

        [Test]
        public void ReturnsFeedTopicsFromXml()
        {
            IList<FeedTopic> feedTopics;
            XElement xmlSample = new XElement("root"),
                xmlContainer = new XElement("container"),
                xmlItem = new XElement("item"),
                xmlTitle = new XElement("title", "Sample Title");

            xmlItem.Add(xmlTitle);
            xmlContainer.Add(xmlItem);
            xmlSample.Add(xmlContainer);

            feedTopics = xmlConversor.GetFeedTopics(xmlSample);

            Assert.AreEqual(1, feedTopics.Count);
        }
    }
}
