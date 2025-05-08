namespace netart.Models.Poll;

public class Poll : BaseEntity
{
    public string Question { get; set; }

    public ICollection<PollOption> Options { get; set; } = new List<PollOption>();

    public Guid PostId { get; set; }
    public Post Post { get; set; }
}