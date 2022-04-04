using System;
using System.Collections.Generic;

namespace LenselinkArtSales.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? ArtistId { get; set; }
        public bool? Active { get; set; }
        public string? ImageFilePath { get; set; }
        public string Slug
        {
            get
            {
                if (Title == null)
                    return "";
                else
                    return Title.Replace(' ', '-');
            }
        }

        public string ImageURL
        {
            get
            {
                var display = "https://cdn.vanderbilt.edu/vu-wp0/wp-content/uploads/sites/288/2019/03/28062612/Image-Coming-Soon-Placeholder.png";

                if(ImageFilePath != null)
                {
                    display = ImageFilePath;
                }

                return display;
            }
        }
    }
}
