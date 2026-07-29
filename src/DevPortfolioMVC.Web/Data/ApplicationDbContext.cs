using DevPortfolioMVC.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevPortfolioMVC.Web.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; } = null!;
    }
}
