namespace MChat.Client.Models
{
    public class TeamChat
    {
        public Guid Id { get; set; }

        public string TeamName { get; set; } = string.Empty;
        
        public string? CoverImageUrl { get; set; } = string.Empty;

        public User Creator { get; set; }

        public TeamChat(Guid id, string? coverImageUrl, string teamName, User creator)
        {
            this.Id = id;
            this.TeamName = teamName;
            this.CoverImageUrl = coverImageUrl;
            this.Creator = creator;
        }

        public override string ToString()
        {
            return "TeamChat {" +
                "Id = " + Id + "\n" +
                "Name = " + TeamName + "\n" +
                "Creator = " + Creator +
                "}";
        }
    }
}
