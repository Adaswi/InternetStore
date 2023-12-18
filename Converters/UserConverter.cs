using InternetStore.DTOs;
using InternetStore.Models;

namespace InternetStore.Converters
{
    public class UserConverter
    {
        public UserConverter() { }

        public UserDTO Convert(User user)
        {
            var dto = new UserDTO()
            {
                UserNickname = user.UserNickname,
                UserName = user.UserName,
                UserSurname = user.UserSurname,
                UserEmail = user.UserEmail,
                UserNumber = user.UserNumber,
                UserPassword = user.UserPassword
            };
            return dto;
        }
    }
}
