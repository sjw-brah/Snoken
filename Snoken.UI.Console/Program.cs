using Snoken.DAL.Repositories;
using Snoken.Domain.Factories;
using Snoken.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snoken.UI.Console
{
    class Program
    {

        static void Main(string[] args)
        {
            Action<ThomannItemModel> a = model =>
            System.Console.WriteLine($"{model.Url.Remove(0, 25),50}{model.Prices["SEK"],12}\t{model.Prices["DKK"],20}\t{model.Prices["NOK"],15}\t{model.Prices["EUR"],15}");

            var repo = new FakeThomannRepository();
            var list = new List<ThomannItemModel>();
            ISiteFactory factory = new ThomannFactory();


            System.Console.WriteLine($"{"URL",50} {"SEK",11} {"DKK",21 }{"NOK",19 } {"EUR",15}");

            foreach (var item in repo.GetKeys())
            {
                Thread.Sleep(3000);
                Start(item, factory, list, a);
            }
            System.Console.ReadKey();
        }
        static async Task Start(string item, ISiteFactory factory, List<ThomannItemModel> list, Action<ThomannItemModel> a)
        {
            await Task.Run(() =>
            {
                var model = new ThomannItemModel() { Prices = new Dictionary<string, string>() };
                model.Url = factory.CreateSwedishSite().ScrapeUrl(item);
                if (!string.IsNullOrEmpty(model.Url))
                {
                    model.Prices.Add("SEK", factory.CreateSwedishSite().ScrapeSwedishInfo(model.Url));
                    model.Prices.Add("DKK", factory.CreateDanishSite().ScrapeDanishInfo(model.Url.Replace("/se/", "/dk/")));
                    model.Prices.Add("NOK", factory.CreateNorwegianSite().ScrapeNorwegianInfo(model.Url.Replace("/se/", "/de/")));
                    model.Prices.Add("EUR", factory.CreateGermanSite().ScrapeGermanInfo(model.Url.Replace("/se/", "/de/")));

                    a(model);
                    list.Add(model);
                }
            });
        }
    }
}
