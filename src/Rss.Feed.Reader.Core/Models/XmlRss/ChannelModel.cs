using System.Collections.Generic;
using System.Xml.Serialization;

namespace Rss.Feed.Reader.Core.Models.XmlRss
{
    [XmlRoot("channel")]
    public class ChannelModel
    {
        public ChannelModel()
        {
            Items = new List<ChannelItemModel>();
        }

        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("link")]
        public string Link { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("item")]
        public List<ChannelItemModel> Items { get; set; }
    }
}