using netart.DTO.User;
using netart.DTO.Media;
using netart.DTO.Comment;
using netart.DTO.Like;
using netart.DTO.Poll;

namespace netart.DTO.Post;

public class PostDto
{
    public Guid Id { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public UserPreviewDto User { get; set; } = null!;
    public List<MediaDto> Media { get; set; } = new();
    public List<CommentDto> Comments { get; set; } = new();
    public List<LikeDto> Likes { get; set; } = new();
    public PollDto? Poll { get; set; }
}
