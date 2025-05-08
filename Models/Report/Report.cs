namespace netart.Models;

public class Report : BaseEntity
{
    public Guid ReporterId { get; set; }
    public User Reporter { get; set; }

    public string Reason { get; set; }
    public ReportStatus Status { get; set; } = ReportStatus.Pending;

    public Guid PostId { get; set; }
    public Post Post { get; set; }

    public Guid? HandledByAdminId { get; set; }
    public Admin.Admin? HandledBy { get; set; }

    public Guid? ForwardedToAdminId { get; set; }
    public Admin.Admin? ForwardedTo { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}