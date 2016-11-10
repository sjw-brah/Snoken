namespace Snoken.Domain.Interfaces
{
    public interface INorwegianSite
    {
        string ScrapeUrl(string key);
        string ScrapeNorwegianInfo(string url);
    }
}