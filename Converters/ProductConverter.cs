using InternetStore.DTOs;
using InternetStore.Models;

namespace InternetStore.Converters
{
    public class ProductConverter
    {
        public ProductConverter() { }

        public ProductDTO Convert(Product product)
        {
            if (product == null)
                return null;
            else
            {
                var dto = new ProductDTO()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                    ProductQuantity = product.ProductQuantity,
                    UserNickname = product.User.UserNickname,
                    CategoryName = product.Category.CategoryName
                };
                return dto;
            }
        }

        public IEnumerable<ProductDTO> Convert(IEnumerable<Product> products)
        {
            if (products == null)
                return null;
            else
            {
                var dto = new List<ProductDTO>();
                foreach (var product in products)
                {
                    dto.Add(this.Convert(product));
                }
                return dto;
            }
        }
    }
}
