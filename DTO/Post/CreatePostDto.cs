using netart.DTO.Poll;

namespace netart.DTO.Post;

public class CreatePostDto
{
    public string? Content { get; set; }
    public List<IFormFile>? MediaFiles { get; set; }
    public CreatePollDto? Poll { get; set; }
}
