using Rss.Feed.Reader.Core.Models.XmlRss;
using System;
using System.IO;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

Console.WriteLine("Hello World!");


string url = "https://www.ahnegao.com.br/feed";
using (XmlReader reader = XmlReader.Create(url))
{
    SyndicationFeed feed = SyndicationFeed.Load(reader);
    Console.WriteLine(feed.Title.Text);
    Console.WriteLine(feed.Links[0].Uri);
    foreach (SyndicationItem item in feed.Items)
    {
        string content = "";
        foreach (SyndicationElementExtension ext in item.ElementExtensions)
        {
            if (ext.GetObject<XElement>().Name.LocalName == "encoded")
            {
                content = ext.GetObject<XElement>().Value;
                Console.WriteLine(content);
            }
                
                
        }

        Console.WriteLine(item.Title.Text);
    }
}

//var client = new HttpClient();
//var content = await client.GetStringAsync("https://www.ahnegao.com.br/feed");

//var xmlDocument = new XmlDocument();

////xmlDocument.LoadXml(HttpUtility.HtmlDecode(content));
//xmlDocument.LoadXml(content);


//var x = xmlDocument.GetElementsByTagName("channel")[0].OuterXml;

//var data = new ChannelModel();
//using (TextReader sr = new StringReader(x))
//{
//    XmlSerializer serializer = new XmlSerializer(typeof(ChannelModel));
//    data = (ChannelModel)serializer.Deserialize(sr);
//}

//Console.WriteLine(data.Title);
//Console.WriteLine(data.Itens[0].Description);