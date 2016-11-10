using Snoken.Domain.Interfaces;
using Snoken.Domain.Models;
using System.Collections.Generic;

namespace Snoken.DAL.Repositories
{
    public class FakeThomannRepository : IRepository

    {
        private static List<string> TmanRepo = new List<string>
        {
            "100529",
"100533",
"100534",
"100614",
"100616",
"100618",
"100620",
"100638",
"100640",
"100642",
"100643",
"100655",
"100656",
"100657",
"100667",
"100669",
"100673",
"100674",
"100677",
"100678",
"100679",
"100681",
"100682",
"100684",
"100685",
"100693",
"100696",
"100708",
"100709",
"100711",
"100714",
"100715",
"100716",
"100718",
"100719",
"100723",
"100745",
"100746",
"100758",
"100759",
"100762",
"100769",
"100781",
"100782"



        };

        public bool DeleteItem(IItemModel model)
        {
            return TmanRepo.Remove(model.Id);
        }

        public IItemModel GetItemByKey(string key)
        {
            var model = new ThomannItemModel();
            model.Id = TmanRepo.Find(i => i == key);
            return model;
        }

        public IEnumerable<IItemModel> GetItemsByBrand(string brand)
        {
            return new List<IItemModel>();
        }

        public IEnumerable<IItemModel> GetItemsByCategory(string category)
        {
            return new List<IItemModel>();
        }

        public IEnumerable<string> GetKeys()
        {
            return TmanRepo;
        }

        public int SaveItem(IItemModel model)
        {
            int itemCount = TmanRepo.Count;
            var _model = TmanRepo.Find(x => x == model.Id);

            if (_model != null) { _model = model.Id; }
            else {
                TmanRepo.Add(model.Id);
                itemCount++;
            }

            return itemCount;
        }

        public bool UpdateItem(IItemModel model)
        {
            var result = false;
            var item = TmanRepo.Find(i => i == model.Id);
            if (item != null)
            {
                item = model.Id;
                result = true;
            }
            return result;
        }
    }
}
