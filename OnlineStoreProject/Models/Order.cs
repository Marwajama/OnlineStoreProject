using System;
using System.Collections.Generic;

namespace OnlineStoreProject.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? CartId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public double? TotalPrice { get; set; }

        public virtual Cart? Cart { get; set; }
    }
}
