namespace MChat.Client.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string? Password { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public DateOnly CreateAt { get; set; }

        public DateTime LastUpdate { get; set; }

        public override string ToString()
        {
            return "User {" +
                "Id = " + Id + "\n" +
                "Email = " + Email + "\n" +
                "Username = " + Username + "\n" +
                "CreateAt = " + CreateAt + "\n" +
                "LastUpdate = " + LastUpdate +
                "}";
        }
    }
}
