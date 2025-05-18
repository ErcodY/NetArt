using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using netart.Data;
using netart.DTO.Comment;
using netart.Extensions;
using netart.Helpers;
using netart.Models;

namespace netart.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController(AppDbContext context) : ControllerBase
{
    [Authorize]
    [HttpPost("{postId}")]
    public async Task<ActionResult<CommentDto>> CreateComment(Guid postId, CreateCommentDto dto)
    {
        var userId = HttpContext.GetUserId();
        if (userId == null) return Unauthorized();

        var post = await context.Posts.FindAsync(postId);
        var user = await context.Users.FindAsync(userId);

        if (post == null || user == null)
            return NotFound("Post or user not found.");

        var comment = new Comment
        {
            Id = Guid.NewGuid(),
            Content = dto.Content,
            CreatedAt = DateTime.UtcNow,
            PostId = post.Id,
            UserId = user.Id,
            Post = post,
            User = user
        };

        context.Comments.Add(comment);
        await context.SaveChangesAsync();

        return Ok(comment.ToDto());
    }
}