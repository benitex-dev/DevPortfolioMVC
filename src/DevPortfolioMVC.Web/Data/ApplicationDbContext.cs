using DevPortfolioMVC.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevPortfolioMVC.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; } = null!;

        public DbSet<Technology> Technologies { get; set; } = null!;

        public DbSet<ProjectLearning> ProjectLearnings { get; set; } = null!;

        public DbSet<ProjectFutureImprovement> ProjectFutureImprovements { get; set; } = null!;

        public DbSet<ProjectImage> ProjectImages { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(project => project.Title)
                    .HasMaxLength(150);

                entity.Property(project => project.Category)
                    .HasMaxLength(100);

                entity.HasMany(project => project.Technologies)
                    .WithMany(technology => technology.Projects)
                    .UsingEntity("ProjectTechnologies");

                entity.HasMany(project => project.Learnings)
                    .WithOne(learning => learning.Project)
                    .HasForeignKey(learning => learning.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(project => project.FutureImprovements)
                    .WithOne(improvement => improvement.Project)
                    .HasForeignKey(improvement => improvement.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(project => project.Images)
                    .WithOne(image => image.Project)
                    .HasForeignKey(image => image.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Technology>(entity =>
            {
                entity.Property(technology => technology.Name)
                    .HasMaxLength(100);

                entity.HasIndex(technology => technology.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<ProjectLearning>()
                .Property(learning => learning.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<ProjectFutureImprovement>()
                .Property(improvement => improvement.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<ProjectImage>(entity =>
            {
                entity.Property(image => image.Url)
                    .HasMaxLength(500);

                entity.Property(image => image.AltText)
                    .HasMaxLength(250);

                entity.Property(image => image.Caption)
                    .HasMaxLength(250);

                entity.HasIndex(image => new { image.ProjectId, image.Url })
                    .IsUnique();
            });
        }
    }
}
