using netart.Models;
using netart.DTO.User;

namespace netart.Extensions;

public static class UserExtensions
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            DisplayName = user.DisplayName,
            ProfilePictureUrl = user.ProfilePictureUrl
        };
    }
}