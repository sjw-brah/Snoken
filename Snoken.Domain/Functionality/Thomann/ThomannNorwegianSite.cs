using HtmlAgilityPack;
using Snoken.Domain.Interfaces;
using System.Configuration;

namespace Snoken.Domain.Functionality
{
    internal class ThomannNorwegianSite : INorwegianSite
    {
        public string ScrapeNorwegianInfo(string url)
        {
            double VAT = double.Parse(ConfigurationManager.AppSettings["NokVAT"]);
            var price = string.Empty;

            var html = new HtmlWeb().Load(url).DocumentNode.SelectSingleNode("//div[@class='lr-prod-pricebox-price-primary']//div//span[@itemprop='price']");
            if (html != null)
            {
                price = html.InnerHtml.Replace(" &euro;", "").Replace(".", "").Replace(",", ".") ?? "";
                price = (double.Parse(price) * VAT).ToString();
            }
            return price;
        }

        public string ScrapeUrl(string key)
        {
            string url = "http://www.thomann.de/de/search_dir.html?bf=&sw=";

            var html = new HtmlWeb().
                Load(url + key);

            var articleList = html.DocumentNode.SelectNodes("//div[@class='lr-articlelist-article lr-search-entry lr-compare-parent']");
            if (articleList != null)
                foreach (HtmlNode article in articleList)
                {
                    var id = article.GetAttributeValue("rel", "");
                    if (id == key)
                    {
                        url = "http://www.thomann.de/de/" + article.SelectSingleNode("//a[@class='lr-articlelist-article-articleLink']").
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
