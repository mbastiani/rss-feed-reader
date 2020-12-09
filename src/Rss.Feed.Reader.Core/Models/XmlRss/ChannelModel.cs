using System.Collections.Generic;
using System.Xml.Serialization;

namespace Rss.Feed.Reader.Core.Models.XmlRss
{
    [XmlRoot("channel")]
    public class ChannelModel
    {
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("link")]
        public string Link { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("item")]
        public List<ItemModel> Itens { get; set; }
    }
}