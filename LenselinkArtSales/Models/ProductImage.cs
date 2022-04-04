using System;
using System.Collections.Generic;

namespace LenselinkArtSales.Models
{
    public partial class ProductImage
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? FilePath { get; set; }
        public string? FileName { get; set; }
    }
}
