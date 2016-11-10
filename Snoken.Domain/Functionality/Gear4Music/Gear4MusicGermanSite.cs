using HtmlAgilityPack;
using Snoken.Domain.Interfaces;

namespace Snoken.Domain.Functionality
{
    internal class Gear4MusicGermanSite : IGermanSite
    {
        private IUrlScraper _url;
        public Gear4MusicGermanSite(IUrlScraper url)
        {
            _url = url;
        }
        public string ScrapeGermanInfo(string url)
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
