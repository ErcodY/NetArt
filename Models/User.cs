namespace netart.Models;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string DisplayName { get; set; }
    public string Bio { get; set; }
    public string ProfilePictureUrl { get; set; }

    public required ICollection<Post> Posts { get; set; } = new List<Post>();
    public required ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public required ICollection<Like> Likes { get; set; } = new List<Like>();
}