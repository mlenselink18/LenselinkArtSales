using System;
using System.Collections.Generic;

namespace LenselinkArtSales.Models
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public int? OrderId { get; set; }
        public int? SizeId { get; set; }
        public int? ShippingCompanyId { get; set; }
        public string? TrackingNumber { get; set; }
        public bool? ShippingStatus { get; set; }
        public bool? DeliveryStatus { get; set; }
        public bool? PaidStatus { get; set; }
    }
}
