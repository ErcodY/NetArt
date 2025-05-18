using System.Security.Claims;

namespace netart.Helpers;

public static class HttpContextExtensions
{
    public static Guid? GetUserId(this HttpContext context)
    {
        var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);
        return userIdClaim != null ? Guid.Parse(userIdClaim.Value) : null;
    }
}