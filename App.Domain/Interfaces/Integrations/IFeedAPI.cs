using System.Xml.Linq;

namespace App.Domain.Interfaces.Integrations
{
    public interface IFeedAPI
    {
        XElement GetFeedXml();
    }
}
