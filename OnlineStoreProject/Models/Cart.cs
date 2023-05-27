using System;
using System.Collections.Generic;

namespace OnlineStoreProject.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartItemIds = new HashSet<CartItemId>();
            Orders = new HashSet<Order>();
        }

        public int CartId { get; set; }
        public int? UserId { get; set; }
        public bool? IsActive { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<CartItemId> CartItemIds { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
