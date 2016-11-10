using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snoken.Domain.Factories;
using Snoken.Domain.Interfaces;
using Snoken.Domain.Models;

namespace Snoken.Domain.Test
{
    [TestClass]
    public class ThomannTest
    {
        ThomannItemModel model = new ThomannItemModel();

        //Gear4MusicSite site = new Gear4MusicSite(new Gear4MusicSwedishSite(), new Gear4MusicDanishSite(), new Gear4MusicNorwegianSite(), new Gear4MusicGermanSite());
        ISiteFactory G4factory = new Gear4MusicFactory();
        ISiteFactory TmanFactory = new ThomannFactory();

        [TestMethod]
        public void Method_Returns_Url()
        {
            model.Url = TmanFactory.CreateSwedishSite().ScrapeUrl("246474");
            Assert.IsTrue(model.Url.Contains("behringer_eurolive_b212d.htm"));
        }

        [TestMethod]
        public void Method_Returns_Swedish_Price()
        {
            ISwedishSite tmanSE = TmanFactory.CreateSwedishSite();
            model.Url = tmanSE.ScrapeUrl("246474");
            decimal result;
            bool valid = decimal.TryParse(tmanSE.ScrapeSwedishInfo(model.Url), out result);
            Assert.IsTrue(valid);
        }
        [TestMethod]
        public void Method_Returns_Danish_Price()
        {
            IDanishSite tmanDk = TmanFactory.CreateDanishSite();
            model.Url = tmanDk.ScrapeUrl("246474");
            decimal result;
            bool valid = decimal.TryParse(tmanDk.ScrapeDanishInfo(model.Url), out result);
            Assert.IsTrue(valid);
        }
        [TestMethod]
        public void Method_Returns_Norwegian_Price()
        {
            INorwegianSite tmanNo = TmanFactory.CreateNorwegianSite();
            model.Url = tmanNo.ScrapeUrl("246474");
            decimal result;
            bool valid = decimal.TryParse(tmanNo.ScrapeNorwegianInfo(model.Url), out result);
            Assert.IsTrue(valid);
        }
        [TestMethod]
        public void Method_Returns_German_Price()
        {
            IGermanSite tmanDe = TmanFactory.CreateGermanSite();
            model.Url = tmanDe.ScrapeUrl("246474");
            decimal result;
            bool valid = decimal.TryParse(tmanDe.ScrapeGermanInfo(model.Url), out result);
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void Method_Returns_G4M_Danish_Price()
        {
            IDanishSite site = G4factory.CreateDanishSite();
            var url = site.ScrapeUrl("888");
            decimal result;
            bool valid = decimal.TryParse(site.ScrapeDanishInfo("http://www.gear4music.dk/en" + url), out result);
            Assert.IsTrue(valid);
        }
        [TestMethod]
        public void Method_Returns_G4M_Norwegian_Price()
        {
            INorwegianSite site = G4factory.CreateNorwegianSite();
            var url = site.ScrapeUrl("888");
            decimal result;
            bool valid = decimal.TryParse(site.ScrapeNorwegianInfo("http://www.gear4music.no/en" + url), out result);
            Assert.IsTrue(valid);
        }
        [TestMethod]
        public void Method_Returns_G4M_Swedish_Price()
        {
            ISwedishSite site = G4factory.CreateSwedishSite();
            var url = site.ScrapeUrl("888");
            decimal result;
            bool valid = decimal.TryParse(site.ScrapeSwedishInfo("http://www.gear4music.se/en" + url), out result);
            Assert.IsTrue(valid);
        }
        [TestMethod]
        public void Method_Returns_G4M_German_Price()
        {
            IGermanSite site = G4factory.CreateGermanSite();
            var url = site.ScrapeUrl("888");
            decimal result;
            bool valid = decimal.TryParse(site.ScrapeGermanInfo("http://www.gear4music.de/en" + url), out result);
            Assert.IsTrue(valid);
        }

    }
}
