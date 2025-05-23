namespace netart.DTO.User;

public class UserDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string DisplayName { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public string ProfilePictureUrl { get; set; }
}