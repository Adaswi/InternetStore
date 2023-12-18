using InternetStore.Models;

namespace InternetStore.DTOs
{
    public class SingleProductDTO
    {
        public decimal ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string ProductDescription { get; set; } = null!;

        public decimal ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

        public string UserNickname { get; set; } = null!;

        public string? UserNumber { get; set; }

        public string CategoryName { get; set; } = null!;

        public virtual ICollection<OptionDTO>? Options { get; set; } = new List<OptionDTO>();
    }
}
