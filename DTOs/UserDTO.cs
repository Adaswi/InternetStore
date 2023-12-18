namespace InternetStore.DTOs
{
    public class UserDTO
    {

        public string UserNickname { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string UserSurname { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

        public string? UserNumber { get; set; }

        public string UserPassword { get; set; } = null!;
    }
}
