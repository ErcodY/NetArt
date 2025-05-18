using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using netart.Data;
using netart.DTO.Post;
using netart.Extensions;
using netart.Helpers;
using netart.Models;
using netart.Models.Poll;

namespace netart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController(AppDbContext context) : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePost([FromForm] CreatePostDto dto)
        {
            var userId = HttpContext.GetUserId();
            if (userId == null)
                return Unauthorized();

            var user = await context.Users.FindAsync(userId);
            if (user == null)
                return NotFound("User not found");

            var post = new Post
            {
                Content = dto.Content,
                UserId = user.Id,
                User = user,
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Reports = new List<Report>(),
                Media = new List<Media>()
            };

            // Сохраняем медиа
            if (dto.MediaFiles != null)
            {
                foreach (var file in dto.MediaFiles)
                {
                    var filePath = $"wwwroot/uploads/{Guid.NewGuid()}_{file.FileName}";
                    await using var stream = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(stream);

                    post.Media.Add(new Media
                    {
                        Url = filePath.Replace("wwwroot/", ""),
                        Post = post
                    });
                }
            }
            
            if (dto.Poll != null)
            {
                var poll = new Poll()
                {
                    Question = dto.Poll.Question,
                    Options = dto.Poll.Options.Select(o => new PollOption { OptionText = o.Text }).ToList()
                };
                post.Poll = poll;
            }

            context.Posts.Add(post);
            await context.SaveChangesAsync();

            return Ok(post.ToDto());
        }

        private bool PostExists(Guid id)
        {
            return context.Posts.Any(e => e.Id == id);
        }
    }
}