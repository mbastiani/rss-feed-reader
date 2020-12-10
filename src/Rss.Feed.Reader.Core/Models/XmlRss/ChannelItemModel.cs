using System.Xml.Serialization;

namespace Rss.Feed.Reader.Core.Models.XmlRss
{
    public class ChannelItemModel
    {
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("link")]
        public string Link { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        
        [XmlElement("content\\:encoded")]
        public string Content { get; set; }
    }
}
