namespace netart.Models;

public class Comment : BaseEntity
{
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public required string Content { get; set; }

    public required Post Post { get; set; }
    public required User User { get; set; }
}