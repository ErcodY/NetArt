using netart.DTO.User;

namespace netart.DTO.Auth;

public class AuthResponseDto
{
    public string Token { get; set; }
    public UserDto User { get; set; }
}