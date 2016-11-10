using Snoken.Domain.Functionality;
using Snoken.Domain.Interfaces;

namespace Snoken.Domain.Factories
{
    public class Gear4MusicFactory : ISiteFactory
    {
        public IDanishSite CreateDanishSite()
        {
            return new Gear4MusicDanishSite(new Gear4MusicUrl());
        }

        public IGermanSite CreateGermanSite()
        {
            return new Gear4MusicGermanSite(new Gear4MusicUrl());
        }

        public INorwegianSite CreateNorwegianSite()
        {
            return new Gear4MusicNorwegianSite(new Gear4MusicUrl());
        }

        public ISwedishSite CreateSwedishSite()
        {
            return new Gear4MusicSwedishSite(new Gear4MusicUrl());
        }
    }
}
