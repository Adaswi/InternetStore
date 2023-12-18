using InternetStore.DTOs;
using InternetStore.Models;

namespace InternetStore.Converters
{
    public class OptionConverter
    {
        public OptionConverter() { }

        public OptionDTO Convert(Option option)
        {
            if (option == null)
                return null;
            else
            {
                var dto = new OptionDTO()
                {
                    OptionId = option.OptionId,
                    OptionName = option.OptionName,
                    OptionPackId = option.OptionPackId,
                    OptionPrice = option.OptionPrice
                };
                return dto;
            }
        }

        public IEnumerable<OptionDTO> Convert(IEnumerable<Option> options)
        {
            if (options == null)
                return null;
            else
            {
                var dto = new List<OptionDTO>();
                foreach (var product in options)
                {
                    dto.Add(this.Convert(product));
                }
                return dto;
            }
        }
    }
}
