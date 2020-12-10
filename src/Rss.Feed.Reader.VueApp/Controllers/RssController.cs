using Microsoft.AspNetCore.Mvc;
using Rss.Feed.Reader.Core.Models.XmlRss;
using Rss.Feed.Reader.Core.Services;
using System.Threading.Tasks;

namespace Rss.Feed.Reader.VueApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RssController : ControllerBase
    {
        public async Task<ChannelModel> Get()
        {
            var service = new RssService();
            var data = await service.GetRss("https://www.ahnegao.com.br/feed");

            return data;
        }
    }
}
