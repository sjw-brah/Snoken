using HtmlAgilityPack;
using Snoken.Domain.Interfaces;

namespace Snoken.Domain.Functionality
{
    internal class Gear4MusicUrl : IUrlScraper
    {
        public string GetUrl(string key)
        {
            string url = "http://www.gear4music.com";
            key = key.StartsWith("0") ? key.Remove(0, 1) : key;

            var html = new HtmlWeb().Load(url + "/search/?str_search_phrase=" + key);
            HtmlNodeCollection nodes = html.DocumentNode.SelectNodes("//ul[@class='result-list']//li");
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    url = node.ChildNodes["a"].ChildNodes["div"].ChildNodes["h3"].GetAttributeValue("data-xplr", null)
                        .Contains(key) ? node.ChildNodes[1].Attributes[0].Value : null;
                    if (!string.IsNullOrEmpty(url)) return url;
                }
            }
            return url;
        }
    }
}
