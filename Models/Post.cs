namespace netart.Models;

public class Post : BaseEntity
{
    public Guid? UserId { get; set; }
    public string? Content { get; set; }

    public Guid? PollId { get; set; }
    public Poll.Poll? Poll { get; set; }

    public required User User { get; set; }
    public required ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public required ICollection<Media> Media { get; set; } = new List<Media>();
    public required ICollection<Like> Likes { get; set; } = new List<Like>();
    public required ICollection<Report> Reports { get; set; } = new List<Report>();
}