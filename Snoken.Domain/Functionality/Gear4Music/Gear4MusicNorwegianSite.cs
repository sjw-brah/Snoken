using HtmlAgilityPack;
using Snoken.Domain.Interfaces;

namespace Snoken.Domain.Functionality
{
    internal class Gear4MusicNorwegianSite : INorwegianSite
    {
        private IUrlScraper _url;
        public Gear4MusicNorwegianSite(IUrlScraper url)
        {
            _url = url;
        }
        public string ScrapeNorwegianInfo(string url)
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
