using Snoken.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Snoken.Domain.Models
{
    public class ThomannItemModel : IItemModel
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public Dictionary<string, string> Prices { get; set; }
        public string Rank { get; set; }
        public DateTime RegDate { get; set; }

    }
}
