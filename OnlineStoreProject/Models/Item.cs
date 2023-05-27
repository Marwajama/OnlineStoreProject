using System;
using System.Collections.Generic;

namespace OnlineStoreProject.Models
{
    public partial class Item
    {
        public Item()
        {
            CartItemIds = new HashSet<CartItemId>();
        }

        public int ItemId { get; set; }
        public int? CategoryId { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public int? Qtn { get; set; }
        public bool? IsAvailabile { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<CartItemId> CartItemIds { get; set; }
    }
}
