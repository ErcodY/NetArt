using netart.DTO.User;

namespace netart.DTO.Like;

public class LikeDto
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
}
