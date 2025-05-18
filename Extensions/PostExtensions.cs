using netart.DTO.Post;
using netart.DTO.User;
using netart.DTO.Media;
using netart.DTO.Comment;
using netart.DTO.Like;
using netart.DTO.Poll;
using netart.Models;

namespace netart.Extensions;

public static class PostExtensions
{
    public static PostDto ToDto(this Post post)
    {
        return new PostDto
        {
            Id = post.Id,
            Content = post.Content,
            CreatedAt = post.CreatedAt,
            User = new UserPreviewDto()
            {
                Id = post.User.Id,
                DisplayName = post.User.DisplayName,
                ProfilePictureUrl = post.User.ProfilePictureUrl
            },
            Media = post.Media.Select(m => new MediaDto
            {
                Id = m.Id,
                Url = m.Url,
                Type = m.Type.ToString()
            }).ToList(),
            Comments = post.Comments.Select(c => c.ToDto()).ToList(),
            Likes = post.Likes.Select(l => l.ToDto()).ToList(),
            Poll = post.Poll != null ? new PollDto
            {
                Id = post.Poll.Id,
                Question = post.Poll.Question,
                Options = post.Poll.Options.Select(o => new PollOptionDto
                {
                    Id = o.Id,
                    OptionText = o.OptionText,
                    VoteCount = o.Votes.Count
                }).ToList()
            } : null
        };
    }
}
