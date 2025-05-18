namespace netart.DTO.Comment;

using netart.DTO.User;

public class CommentDto
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public UserPreviewDto User { get; set; }
}
