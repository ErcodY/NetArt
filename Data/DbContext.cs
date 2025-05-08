using Microsoft.EntityFrameworkCore;
using netart.Models;
using netart.Models.Admin;
using netart.Models.Poll;

namespace netart.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Media> Media { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Poll> Polls { get; set; }
    public DbSet<PollOption> PollOptions { get; set; }
    public DbSet<PollVote> PollVotes { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Admin> Admins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();

        modelBuilder.Entity<Post>()
            .HasMany(p => p.Comments)
            .WithOne(c => c.Post)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Post>()
            .HasMany(p => p.Likes)
            .WithOne(l => l.Post)
            .HasForeignKey(l => l.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Post>()
            .HasMany(p => p.Reports)
            .WithOne(r => r.Post)
            .HasForeignKey(r => r.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Posts)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Likes)
            .WithOne(l => l.User)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Media>()
            .HasOne(m => m.Post)
            .WithMany(p => p.Media)
            .HasForeignKey(m => m.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Post>()
            .HasOne(p => p.Poll)
            .WithMany()
            .HasForeignKey(p => p.PollId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<PollVote>()
            .HasOne(v => v.Option)
            .WithMany(o => o.Votes)
            .HasForeignKey(v => v.OptionId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PollVote>()
            .HasOne(v => v.User)
            .WithMany()
            .HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Report>()
            .HasOne(r => r.HandledBy)
            .WithMany()
            .HasForeignKey(r => r.HandledByAdminId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Report>()
            .HasOne(r => r.ForwardedTo)
            .WithMany()
            .HasForeignKey(r => r.ForwardedToAdminId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Report>()
            .Property(r => r.Status)
            .HasDefaultValue(ReportStatus.Pending);

        modelBuilder.Entity<Media>()
            .Property(m => m.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<User>()
            .Property(u => u.Bio)
            .HasDefaultValue("");

        modelBuilder.Entity<User>()
            .Property(u => u.ProfilePictureUrl)
            .HasDefaultValue("");
    }
}