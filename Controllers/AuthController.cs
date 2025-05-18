using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netart.Data;
using netart.Models;
using netart.Services;
using System.Security.Cryptography;
using System.Text;
using netart.DTO.Auth;

namespace netart.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AppDbContext context, TokenService tokenService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        if (await context.Users.AnyAsync(u => u.Email == dto.Email))
            return BadRequest("Email already in use.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = dto.UserName,
            Email = dto.Email,
            DisplayName = dto.DisplayName,
            Bio = "",
            ProfilePictureUrl = "",
            PasswordHash = HashPassword(dto.Password),
            Posts = new List<Post>(),
            Comments = new List<Comment>(),
            Likes = new List<Like>()
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();

        var token = tokenService.GenerateToken(user);
        return Ok(new { token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (user == null || user.PasswordHash != HashPassword(dto.Password))
            return Unauthorized("Invalid credentials.");

        var token = tokenService.GenerateToken(user);
        return Ok(new { token });
    }

    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}
