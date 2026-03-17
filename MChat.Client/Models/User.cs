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

        private List<TeamChat> MyTeamChats { get; set; }

        private List<TeamChat> JoinedTeamChats { get; set; }

        public User(Guid id, string email, string? password, string username, DateOnly createAt, DateTime lastUpdate)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.Username = username;
            this.CreateAt = createAt;
            this.LastUpdate = lastUpdate;
            this.MyTeamChats = new List<TeamChat>();
            this.JoinedTeamChats = new List<TeamChat>();
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj.GetType() != typeof(User)) return false;
            if (obj == this) return true;
            User? u = obj as User;
            return u.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Email, Username, CreateAt, LastUpdate);
        }

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

        public void CreateTeamChat(string teamName, string? coverImageUrl)
        {
            TeamChat chat = new TeamChat(Guid.NewGuid(), coverImageUrl, teamName, this);
            this.MyTeamChats.Add(chat);
        }
    }
}
