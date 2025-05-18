namespace netart.DTO.Poll;

public class CreatePollDto
{
    public string Question { get; set; } = string.Empty;
    public List<CreatePollOptionDto> Options { get; set; } = new();
}

