using Snoken.Domain.Functionality;
using Snoken.Domain.Interfaces;

namespace Snoken.Domain.Factories
{
    public class ThomannFactory : ISiteFactory
    {
        public IDanishSite CreateDanishSite()
        {
            return new ThomannDanishSite();
        }

        public IGermanSite CreateGermanSite()
        {
            return new ThomannGermanSite();
        }

        public INorwegianSite CreateNorwegianSite()
        {
            return new ThomannNorwegianSite();
        }

        public ISwedishSite CreateSwedishSite()
        {
            return new ThomannSwedishSite();
        }
    }
}
