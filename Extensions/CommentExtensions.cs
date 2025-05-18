using netart.DTO.Comment;
using netart.DTO.User;
using netart.Models;

namespace netart.Extensions;

public static class CommentExtensions
{
    public static CommentDto ToDto(this Comment comment)
    {
        return new CommentDto
        {
            Id = comment.Id,
            Content = comment.Content,
            CreatedAt = comment.CreatedAt,
            User = new UserPreviewDto
            {
                Id = comment.User.Id,
                DisplayName = comment.User.DisplayName,
                ProfilePictureUrl = comment.User.ProfilePictureUrl
            }
        };
    }
}
