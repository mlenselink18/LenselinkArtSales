﻿using System.Collections;

namespace LenselinkArtSales.Models
{
    public class OrderItemListViewModel
    {
        public Order order { get; set; }
        public List<OrderItemProduct> OrderItemsProducts { get; set; }
        
    }
}
