namespace netart.Models;

public class Media : BaseEntity
{
    public Guid PostId { get; set; }
    public Post Post { get; set; }

    public string Url { get; set; }
    public MediaType Type { get; set; }

    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}