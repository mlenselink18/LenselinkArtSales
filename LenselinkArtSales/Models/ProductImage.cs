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
        public bool Active { get; set; }

        public string FullPath
        {
            get
            {
                var display = "";

                if(FilePath != null && FileName != null)
                    display = "/Media/Images/" + FileName;

                return display;
            }
        }
    }
}
