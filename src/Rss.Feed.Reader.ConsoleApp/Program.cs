using Rss.Feed.Reader.Core.Models.XmlRss;
using System;
using System.IO;
using System.Net.Http;
using System.Xml;
using System.Xml.Serialization;

Console.WriteLine("Hello World!");

var client = new HttpClient();
var content = await client.GetStringAsync("https://www.ahnegao.com.br/feed");

var xmlDocument = new XmlDocument();

//xmlDocument.LoadXml(HttpUtility.HtmlDecode(content));
xmlDocument.LoadXml(content);


var x = xmlDocument.GetElementsByTagName("channel")[0].OuterXml;

var data = new ChannelModel();
using (TextReader sr = new StringReader(x))
{
    XmlSerializer serializer = new XmlSerializer(typeof(ChannelModel));
    data = (ChannelModel)serializer.Deserialize(sr);
}

Console.WriteLine(data.Title);
Console.WriteLine(data.Itens[0].Description);