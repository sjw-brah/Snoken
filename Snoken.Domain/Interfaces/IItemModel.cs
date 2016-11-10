using System;
using System.Collections.Generic;

namespace Snoken.Domain.Interfaces
{
    public interface IItemModel
    {
        string Id { get; set; }
        string Url { get; set; }
        string Brand { get; set; }
        string Model { get; set; }
        string Category { get; set; }
        string Rank { get; set; }

        Dictionary<string, string> Prices { get; set; }
        DateTime RegDate { get; set; }
    }
}