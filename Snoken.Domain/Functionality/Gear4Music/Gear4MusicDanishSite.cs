using HtmlAgilityPack;
using Snoken.Domain.Interfaces;

namespace Snoken.Domain.Functionality
{
    internal class Gear4MusicDanishSite : IDanishSite
    {
        private IUrlScraper _url;
        public Gear4MusicDanishSite(IUrlScraper url)
        {
            _url = url;
        }
        public string ScrapeDanishInfo(string url)
        {
            var price = string.Empty;

            return new HtmlWeb().Load(url)
                .DocumentNode.SelectSingleNode("//span[@itemprop='price']")
                .GetAttributeValue("content", "");
        }

        public string ScrapeUrl(string key)
        {
            return _url.GetUrl(key);
        }
    }
}
