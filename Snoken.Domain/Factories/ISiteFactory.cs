using Snoken.Domain.Interfaces;

namespace Snoken.Domain.Factories
{
    public interface ISiteFactory
    {
        ISwedishSite CreateSwedishSite();
        IDanishSite CreateDanishSite();
        INorwegianSite CreateNorwegianSite();
        IGermanSite CreateGermanSite();
    }
}
