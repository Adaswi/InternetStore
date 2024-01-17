using System.IdentityModel.Tokens.Jwt;

namespace InternetStore.DTOs
{
    public class TokenDTO
    {
        public string Token { get; set; } = null!;

        public UserDTO User { get; set; } = null!;

        public DateTime expiresIn { get; set; }
    }
}
