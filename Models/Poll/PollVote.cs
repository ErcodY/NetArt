namespace netart.Models.Poll;

public class PollVote : BaseEntity
{
    public Guid OptionId { get; set; }
    public Guid UserId { get; set; }

    public PollOption Option { get; set; }
    public User User { get; set; }
}