namespace netart.DTO.Poll;

public class PollOptionDto
{
    public Guid Id { get; set; }
    public string OptionText { get; set; }
    public int VoteCount { get; set; }
}
