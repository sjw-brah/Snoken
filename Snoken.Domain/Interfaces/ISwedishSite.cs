namespace Snoken.Domain.Interfaces
{
    public interface ISwedishSite
    {
        string ScrapeUrl(string key);
        string ScrapeSwedishInfo(string url);
    }
}