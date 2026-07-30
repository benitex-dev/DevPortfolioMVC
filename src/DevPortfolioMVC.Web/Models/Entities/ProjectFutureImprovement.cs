namespace DevPortfolioMVC.Web.Models.Entities
{
    public class ProjectFutureImprovement
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public int SortOrder { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; } = null!;
    }
}
