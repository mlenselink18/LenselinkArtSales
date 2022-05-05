namespace LenselinkArtSales.Models
{
    public class ProductImageListView
    {
        public Product product { get; set; }
        public List<ProductImage> productImages { get; set; }

        public List<ProductImage> productImagesDisplay
        {
            get
            {
                List<ProductImage> display = new List<ProductImage>();
                if(productImages == null)
                {
                    display.Add(new ProductImage()
                    {
                        Id = 0,
                        ProductId = product.Id,
                        FilePath = "https://cdn.vanderbilt.edu/vu-wp0/wp-content/uploads/sites/288/2019/03/28062612/Image-Coming-Soon-Placeholder.png",
                        FileName = "No Image",
                        Active = false
                    });
                }
                else
                {
                    display = productImages;
                }

                return display;
            }
        }

        public string FirstImageThumbnail
        {
            get
            {
                var display = "/Media/Images/ComingSoon.jpg";

                if(productImages == null)
                {
                    display = "/Media/Images/ComingSoon.jpg";
                }
                else
                {
                    var firstImage = productImages.First();
                    display = firstImage.FullPath;
                }

                return display;
            }
        }

        public string FirstImageAlt
        {
            get
            {
                var display = "Error";

                if (productImages != null)
                {
                    display = product.Title;
                }

                return display;
            }
        }
    }
}
