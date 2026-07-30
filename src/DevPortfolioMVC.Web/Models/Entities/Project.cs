namespace DevPortfolioMVC.Web.Models.Entities
{
    public class Project
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Summary { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Problem { get; set; } = string.Empty;

        public string Development { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string? RepositoryUrl { get; set; }

        public string? DemoUrl { get; set; }

        public bool IsFeatured { get; set; }

        public ICollection<Technology> Technologies { get; set; } = [];

        public ICollection<ProjectLearning> Learnings { get; set; } = [];

        public ICollection<ProjectFutureImprovement> FutureImprovements { get; set; } = [];

        public ICollection<ProjectImage> Images { get; set; } = [];
    }
}
