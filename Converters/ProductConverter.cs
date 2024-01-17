using InternetStore.DTOs;
using InternetStore.Models;

namespace InternetStore.Converters
{
    public class ItemConverter
    {
        public ItemConverter() { }

        public ItemDTO Convert(Item item)
        {
            if (item == null)
                return null;
            else
            {
                var dto = new ItemDTO()
                {
                    ItemPrice = item.ItemPrice,
                    ItemQuantity = item.ItemQuantity,
                    ItemVisible = item.ItemVisible,
                    CartId = item.CartId,
                    OptionId = item.OptionId,
                    OrderId = item.OrderId,
                    ProductId = item.ProductId

                };
                return dto;
            }
        }

        public IEnumerable<ItemDTO> Convert(IEnumerable<Item> items)
        {
            if (items == null)
                return null;
            else
            {
                var dto = new List<ItemDTO>();
                foreach (var item in items)
                {
                    dto.Add(this.Convert(item));
                }
                return dto;
            }
        }
    }
}
