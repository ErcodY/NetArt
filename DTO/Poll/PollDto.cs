namespace netart.DTO.Poll;

public class PollDto
{
    public Guid Id { get; set; }
    public string Question { get; set; }
    public List<PollOptionDto> Options { get; set; }
}
