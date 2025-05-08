namespace netart.Models;

public class Like : BaseEntity
{
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }

    public required Post Post { get; set; }
    public required User User { get; set; }
}