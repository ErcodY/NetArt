using netart.DTO.Like;
using netart.Models;

namespace netart.Extensions;

public static class LikeExtensions
{
    public static LikeDto ToDto(this Like like)
    {
        return new LikeDto
        {
            Id = like.Id,
            
        };
    }
}
