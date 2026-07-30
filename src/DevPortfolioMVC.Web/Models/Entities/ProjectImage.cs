namespace DevPortfolioMVC.Web.Models.Entities
{
    public class ProjectImage
    {
        public int Id { get; set; }

        public string Url { get; set; } = string.Empty;

        public string AltText { get; set; } = string.Empty;

        public string Caption { get; set; } = string.Empty;

        public int SortOrder { get; set; }

        public bool IsCover { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; } = null!;
    }
}
