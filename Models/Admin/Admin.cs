using netart.Models.Enums;

namespace netart.Models.Admin;

public class Admin : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public AdminRole RoleName { get; set; }
    public List<Permission> Permissions { get; set; } = new();

    public ICollection<Report> ForwardedReports { get; set; } = new List<Report>();
}