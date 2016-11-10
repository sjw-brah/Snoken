using System.Collections.Generic;

namespace Snoken.Domain.Interfaces
{
    public interface IRepository
    {
        IEnumerable<string> GetKeys();
        IItemModel GetItemByKey(string key);
        IEnumerable<IItemModel> GetItemsByBrand(string brand);
        IEnumerable<IItemModel> GetItemsByCategory(string category);
        bool UpdateItem(IItemModel model);
        bool DeleteItem(IItemModel model);
        int SaveItem(IItemModel model);
    }
}
