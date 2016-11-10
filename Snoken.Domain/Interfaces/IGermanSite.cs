namespace Snoken.Domain.Interfaces
{
    public interface IGermanSite
    {
        string ScrapeUrl(string key);
        string ScrapeGermanInfo(string url);
    }
}