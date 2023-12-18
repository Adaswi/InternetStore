using InternetStore.DTOs;
using InternetStore.Models;

namespace InternetStore.Converters
{
    public class SingleProductConverter
    {
        private readonly OptionConverter optionConverter = new OptionConverter();
        public SingleProductConverter() { }

        public SingleProductDTO Convert(Product product)
        {
            if (product == null)
                return null;
            else
            {
                var dto = new SingleProductDTO()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                    ProductQuantity = product.ProductQuantity,
                    UserNickname = product.User.UserNickname,
                    UserNumber = product.User.UserNumber,
                    CategoryName = product.Category.CategoryName,      
                };
                if(product.OptionPack != null)
                {
                    dto.Options = (ICollection<OptionDTO>?)optionConverter.Convert(product.OptionPack.Options);
                }
                return dto;
            }
        }

        public IEnumerable<SingleProductDTO> Convert(IEnumerable<Product> products)
        {
            if (products == null)
                return null;
            else
            {
                var dto = new List<SingleProductDTO>();
                foreach (var product in products)
                {
                    dto.Add(this.Convert(product));
                }
                return dto;
            }
        }
    }
}
