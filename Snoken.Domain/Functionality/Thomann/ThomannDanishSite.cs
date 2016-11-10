using HtmlAgilityPack;
using Snoken.Domain.Interfaces;

namespace Snoken.Domain.Functionality
{
    internal class ThomannDanishSite : IDanishSite
    {
        public string ScrapeDanishInfo(string url)
        {
            var price = string.Empty;

            var html = new HtmlWeb().Load(url).DocumentNode.SelectSingleNode("//div[@class='lr-prod-pricebox-price-primary']//div//span[@class='secondary']");
            if (html != null)
            {
                price = html.InnerHtml.Replace(".", "").Replace("DKK", "").Replace(",", ".") ?? "";
            }
            return price;
        }

        public string ScrapeUrl(string key)
        {
            string url = "http://www.thomann.de/dk/search_dir.html?bf=&sw=";

            var html = new HtmlWeb().
                Load(url + key);

            var articleList = html.DocumentNode.SelectNodes("//div[@class='lr-articlelist-article lr-search-entry lr-compare-parent']");
            if (articleList != null)
                foreach (HtmlNode article in articleList)
                {
                    var id = article.GetAttributeValue("rel", "");
                    if (id == key)
                    {
                        url = "http://www.thomann.de/dk/" + article.SelectSingleNode("//a[@class='lr-articlelist-article-articleLink']").
                            Attributes[0].Value.Split('?')[0];
                        break;
                    }
                    else
                    {
                        url = string.Empty;
                    }

                }
            return url;
        }
    }
}
