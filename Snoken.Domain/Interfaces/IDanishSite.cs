namespace Snoken.Domain.Interfaces
{
    public interface IDanishSite
    {
        string ScrapeUrl(string key);
        string ScrapeDanishInfo(string url);
    }
}