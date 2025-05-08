namespace netart.Models.Poll;

public class PollOption : BaseEntity
{
    public Guid PollId { get; set; }
    public string OptionText { get; set; }

    public Poll Poll { get; set; }
    public ICollection<PollVote> Votes { get; set; } = new List<PollVote>();
}