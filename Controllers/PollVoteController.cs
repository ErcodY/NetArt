using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netart.Data;
using netart.Models.Poll;

namespace netart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollVoteController : ControllerBase
{
    private readonly AppDbContext _context;

    public PollVoteController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<PollVote>> Vote(PollVote vote)
    {
        var exists = await _context.PollVotes.AnyAsync(v => v.Option.PollId == vote.Option.PollId && v.UserId == vote.UserId);
        if (exists)
        {
            return Conflict("User has already voted.");
        }

        _context.PollVotes.Add(vote);
        await _context.SaveChangesAsync();

        return Ok(vote);
    }
}