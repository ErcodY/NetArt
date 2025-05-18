using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netart.Data;
using netart.Models;

namespace netart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MediaController : ControllerBase
{
    private readonly AppDbContext _context;

    public MediaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{postId}")]
    public async Task<ActionResult<IEnumerable<Media>>> GetMediaForPost(Guid postId)
    {
        return await _context.Media.Where(m => m.PostId == postId).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Media>> UploadMedia(Media media)
    {
        _context.Media.Add(media);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMediaForPost), new { postId = media.PostId }, media);
    }
}