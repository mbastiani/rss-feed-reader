using Rss.Feed.Reader.Core.Models.XmlRss;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Rss.Feed.Reader.Core.Services
{
    public class RssService
    {

        public async Task<ChannelModel> GetRss(string url)
        {
            
            using XmlReader reader = XmlReader.Create(url);
            var syndicationFeed = SyndicationFeed.Load(reader);

            var channel = new ChannelModel
            {
                Title = syndicationFeed.Title.Text,
                Description = syndicationFeed.Description.Text,
                Link = syndicationFeed.Links[0].Uri.ToString()
            };

            foreach (SyndicationItem syndicationItem in syndicationFeed.Items)
            {
                var channelItem = new ChannelItemModel
                {
                    Title = syndicationItem.Title.Text,
                    Description = syndicationItem.Summary.Text,
                    Link = syndicationItem.Links[0].Uri.ToString()
                };

                var syndicationElementExtension = syndicationItem.ElementExtensions
                    .Where(x => x.GetObject<XElement>().Name.LocalName == "encoded")
                    .FirstOrDefault();
                
                if (syndicationElementExtension != null)
                    channelItem.Content = syndicationElementExtension.GetObject<XElement>().Value;

                channel.Itens.Add(channelItem);
            }

            return channel;
        }

        //public async Task<ChannelModel> GetRss(string url)
        //{
        //    var client = new HttpClient();
        //    var content = await client.GetStringAsync("https://www.ahnegao.com.br/feed");

        //    var xmlDocument = new XmlDocument();

        //    //xmlDocument.LoadXml(HttpUtility.HtmlDecode(content));
        //    xmlDocument.LoadXml(content);


        //    var x = xmlDocument.GetElementsByTagName("channel")[0].OuterXml;

        //    var data = new ChannelModel();
        //    using (TextReader sr = new StringReader(x))
        //    {
        //        XmlSerializer serializer = new XmlSerializer(typeof(ChannelModel));
        //        return (ChannelModel)serializer.Deserialize(sr);
        //    }

        //    return data;
        //}
    }
}
