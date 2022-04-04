using System;
using System.Collections.Generic;

namespace LenselinkArtSales.Models
{
    public partial class PrintSize
    {
        public int Id { get; set; }
        public string? Dimensions { get; set; }
        public decimal? Price { get; set; }
    }
}
