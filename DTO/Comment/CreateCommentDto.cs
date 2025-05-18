namespace netart.DTO.Comment;

public class CreateCommentDto
{
    public Guid PostId { get; set; }
    public string Content { get; set; } = string.Empty;
}
