using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netart.Data;
using netart.DTO.Like;
using netart.Models;
using netart.Extensions;
using netart.Helpers;

namespace netart.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class LikeController(AppDbContext context) : ControllerBase
{
    [HttpPost("{postId}")]
    public async Task<ActionResult<LikeDto>> LikePost(Guid postId)
    {
        var userId = HttpContext.GetUserId();
        if (userId == null) return Unauthorized();

        var existingLike = await context.Likes
            .FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);

        if (existingLike != null)
            return BadRequest("You have already liked this post.");

        var post = await context.Posts.FindAsync(postId);
        var user = await context.Users.FindAsync(userId);

        if (post == null || user == null)
            return NotFound("Post or user not found.");

        var like = new Like
        {
            Id = Guid.NewGuid(),
            PostId = post.Id,
            UserId = user.Id,
            Post = post,
            User = user
        };

        context.Likes.Add(like);
        await context.SaveChangesAsync();

        return Ok(like.ToDto
            ());
    }

    [HttpDelete("{postId}")]
    public async Task<ActionResult> UnlikePost(Guid postId)
    {
        var userId = HttpContext.GetUserId();
        if (userId == null) return Unauthorized();

        var like = await context.Likes
            .FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);

        if (like == null)
        {
            return NotFound();
        }

        context.Likes.Remove(like);
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("post/{postId}")]
    public async Task<ActionResult<IEnumerable<LikeDto>>> GetLikesForPost(Guid postId)
    {
        var likes = await context.Likes
            .Where(l => l.PostId == postId)
            .ToListAsync();

        return Ok(likes.Select(l => l.ToDto()));
    }
}